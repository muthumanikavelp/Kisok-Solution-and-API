using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.kiosk_advertisement_model;
using static nafmodel.Kiosk_FAQS_Model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class kiosk_advertisementController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private readonly IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        kiosk_advertisement_service objRoleService = new kiosk_advertisement_service();
        public kiosk_advertisementController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }       
        [HttpGet("advertisementList")]
        public advertisementcontext advertisementList(string org, string locn, string user, string lang)
        {
            string File_path = "";
            string Final_Path = "";
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            advertisementcontext ObjList = new advertisementcontext();
            try
            {
                ObjList = objRoleService.GetadvertisementList_srv(org, locn, user, lang, ConString);

                if (ObjList.list.Count > 0)
                {
                    for (int i = 0; i < ObjList.list.Count; i++)
                    {
                      if (ObjList.list[i].ad_name != "")
                      {
                    //        // var s = ObjList.Title[i].out_file_Name;
                    //        // string[] urlfileName = s.Split('\\').ToArray();
                           File_path = _configuration.GetSection("AppSettings")["MobAdvertpath"].ToString();
                    //        // string urlfileName1 = urlfileName[5];
                    //        //  string urlfileName2 = urlfileName[6];
                           File_path = File_path + ObjList.list[i].ad_name;
                           ObjList.list[i].ad_path_url = File_path;
                       }
                    }
                }

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("advertisementfetch")]
        public advertisementfetchContext advertisementfetch(string org, string locn, string user, string lang, int In_AD_gid)
        {
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            advertisementfetchContext ObjList = new advertisementfetchContext();
            try
            {
                ObjList = objRoleService.GetAdvtfetch_srv(org, locn, user, lang, In_AD_gid, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [Authorize]
        [HttpPost("Advertisementsave")]
        public Retrnmesg newAdvertisementsave(SaveAdvertisement ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel);

            try
            {
                response = objRoleService.NewAdvertisementsave_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }
    }
}
