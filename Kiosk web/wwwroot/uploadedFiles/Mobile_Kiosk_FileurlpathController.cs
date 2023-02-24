using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static nafmodel.Mobile_Kiosk_Fileurlpath_Model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_Kiosk_FileurlpathController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appsettings;
        string Constring;
        private readonly IConfiguration _configuration;
        Obj_Mobile_Kiosk_Fileurlpath_Services Obj_Mobile_Kiosk_Fileurlpath_Services = new Obj_Mobile_Kiosk_Fileurlpath_Services();

        public Mobile_Kiosk_FileurlpathController(IOptions<MySettingsModel> options, IConfiguration configuration)
        {
            appsettings = options;
            Constring = appsettings.Value.mysqlcon;
            _configuration = configuration;
        }
          
        [HttpGet("allfileurlpath")]
        public Mobile_Fileurlpath kiosk_Fileurlpath(string Instance)
        {
            DataSet Dset = new DataSet();
            DataTable dt_trainvideo = new DataTable();
            DataTable dt_advertisment = new DataTable();
            DataTable dt_faq = new DataTable();
            DataTable dt_scheme = new DataTable();
            Mobile_Kiosk_Fileurlpath Obj_mobile_Kiosk_Fileurlpath = new Mobile_Kiosk_Fileurlpath();
            Mobile_Fileurlpath Obj_Mobile_Fileurlpath = new Mobile_Fileurlpath();
            Obj_Mobile_Fileurlpath.trainingvideos = new List<trainingvideo>();
            Obj_Mobile_Fileurlpath.advertismentvideos = new List<Advertismentvideo>();
            Obj_Mobile_Fileurlpath.faqfilepaths = new List<Faqfilepath>();
            Obj_Mobile_Fileurlpath.governmentschemes = new List<Governmentscheme>();
            string db = Instance;
            AllConnectionString allConnection = new AllConnectionString();
            this.Constring = allConnection.getRightConString(db, this.appsettings.Value);
            try
            {
                Dset = Obj_Mobile_Kiosk_Fileurlpath_Services.Fileurlpath(Constring);
                string File_path = "";
                string Final_Path = "";

                if (Dset.Tables.Count > 0)
                {
                    dt_trainvideo = Dset.Tables[0];
                    
                    for(int i =0;i< dt_trainvideo.Rows.Count; i++)
                    {
                        trainingvideo obj_trainingvideo = new trainingvideo();
                        obj_trainingvideo.video_gid = Convert.ToInt32(dt_trainvideo.Rows[i]["video_gid"].ToString());
                        obj_trainingvideo.video_filename = dt_trainvideo.Rows[i]["video_filename"].ToString();
                        obj_trainingvideo.video_category = dt_trainvideo.Rows[i]["video_category"].ToString();
                        if (dt_trainvideo.Rows[i]["video_category"] != "" && dt_trainvideo.Rows[i]["video_filename"] != "")
                        {
                            File_path = _configuration.GetSection("AppSettings")["MobTrainpath"].ToString();
                            File_path = File_path + obj_trainingvideo.video_category + '/' + obj_trainingvideo.video_filename;
                            obj_trainingvideo.video_filepath = File_path;
                        }

                        Obj_Mobile_Fileurlpath.trainingvideos.Add(obj_trainingvideo);
                    }

                    dt_advertisment = Dset.Tables[1];
                    for (int j = 0; j < dt_advertisment.Rows.Count; j++)
                    {
                        Advertismentvideo obj_advertismentvideos = new Advertismentvideo();
                        obj_advertismentvideos.ad_gid = Convert.ToInt32(dt_advertisment.Rows[j]["ad_gid"].ToString());
                        obj_advertismentvideos.ad_name = dt_advertisment.Rows[j]["ad_name"].ToString();
                        if(dt_advertisment.Rows[j]["ad_name"].ToString() != "")
                        {
                            File_path = _configuration.GetSection("AppSettings")["MobAdvertismentPath"].ToString();
                            File_path = File_path + obj_advertismentvideos.ad_name;
                            obj_advertismentvideos.ad_path = File_path;
                        }

                        Obj_Mobile_Fileurlpath.advertismentvideos.Add(obj_advertismentvideos);
                    }
                    dt_faq = Dset.Tables[2];
                    for (int k = 0; k < dt_faq.Rows.Count; k++)
                    {
                        Faqfilepath obj_Faqfilepath = new Faqfilepath();
                        obj_Faqfilepath.faq_gid = Convert.ToInt32(dt_faq.Rows[k]["faq_gid"].ToString());
                        obj_Faqfilepath.faq_ans_upload = dt_faq.Rows[k]["faq_ans_upload"].ToString();
                        if (dt_faq.Rows[k]["faq_ans_upload"].ToString() != "")
                        {
                            File_path = _configuration.GetSection("AppSettings")["MobFAQPath"].ToString();
                            File_path = File_path + obj_Faqfilepath.faq_ans_upload;
                            obj_Faqfilepath.faq_ans_upload = File_path;
                        }
                        Obj_Mobile_Fileurlpath.faqfilepaths.Add(obj_Faqfilepath);
                    }

                    dt_scheme = Dset.Tables[3];

                    for (int l = 0; l < dt_scheme.Rows.Count; l++)
                    {
                        Governmentscheme obj_Governmentscheme = new Governmentscheme();
                        obj_Governmentscheme.scheme_gid = Convert.ToInt32(dt_scheme.Rows[l]["scheme_gid"].ToString());
                        obj_Governmentscheme.scheme_upload = dt_scheme.Rows[l]["scheme_upload"].ToString();
                        if (dt_scheme.Rows[l]["scheme_upload"].ToString() != "")
                        {
                            var s = dt_scheme.Rows[l]["scheme_upload"].ToString();
                            string urlfileName = s.Split('\\').Last();
                            File_path = _configuration.GetSection("AppSettings")["GovtSchemePath"].ToString();
                            File_path = File_path  + urlfileName;
                            obj_Governmentscheme.scheme_upload = File_path;
                        }
                        Obj_Mobile_Fileurlpath.governmentschemes.Add(obj_Governmentscheme);
                    }


                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Obj_Mobile_Fileurlpath;
        }




    }
}
