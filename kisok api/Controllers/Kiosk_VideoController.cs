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
using static nafmodel.Kiosk_Soil_Card_model;
using static nafmodel.Kiosk_Video_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_VideoController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private readonly IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Kiosk_VideoController));
        Kiosk_Video_Service objRoleService = new Kiosk_Video_Service();
        public Kiosk_VideoController(IOptions<MySettingsModel> app, IConfiguration configuration )
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        [Authorize]
        [HttpGet("VideoCategoryList")]
        public videocatContext VideoCategoryList(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            videocatContext ObjList = new videocatContext();
            try
            {
                ObjList = objRoleService.GetVideCatList(org, locn, user, lang, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("VideoTiltleList")]
        public videoTitleContext VideoTiltleList(string org, string locn, string user,int In_video_gid, string lang,string keyword)
        {
             string File_path = "";
            string Final_Path = "";
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_video_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            videoTitleContext ObjList = new videoTitleContext();
            VideoTitle obj_videoTitle = new VideoTitle();
            try
            {
                ObjList = objRoleService.GetVideTitleList(org, locn, user, lang, In_video_gid, keyword, ConString);


                //Venkat Added Mobile Http Path Showing Purpose Added 2021-03-17

                if(ObjList.Title.Count > 0)
                {
                    for(int i=0; i<ObjList.Title.Count; i++)
                    {
                        if(ObjList.Title[i].out_file_Name != "")
                        { 
                       // var s = ObjList.Title[i].out_file_Name;
                       // string[] urlfileName = s.Split('\\').ToArray();
                        File_path = _configuration.GetSection("AppSettings")["MobTrainpath"].ToString();
                       // string urlfileName1 = urlfileName[5];
                      //  string urlfileName2 = urlfileName[6];
                        File_path = File_path + ObjList.Title[i].video_category + '/' + ObjList.Title[i].video_filename;
                        ObjList.Title[i].out_file_Name =File_path;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                  logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("VideoListSummary")]
        public trancontext VideoListsummary(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            trancontext ObjList = new trancontext();
            try
            {
                ObjList = objRoleService.GetVideoList(org, locn, user, lang, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("VideoAttributeList")]
        public attributecontext VideoAttributeList(string locn, string  depend_code)
        {          
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            attributecontext ObjList = new attributecontext();
            try
            {
                ObjList = objRoleService.GetVideoAttributeList_srv(locn, depend_code, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [Authorize]
        [HttpPost("Videosave")]
        public Retrnmesg newsoilcardsave(SaveVideo ObjModel)
        {
            string db = ObjModel.locnId;
            Retrnmesg sucessmsg = new Retrnmesg();
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel);

            try
            {
                response = objRoleService.NewVideosave_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }
        [Authorize]
        [HttpGet("Videofetch")]
        public videofetchContext Videofetch(string org, string locn, string user, int In_video_gid, string lang)
        {
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            videofetchContext ObjList = new videofetchContext();
            try
            {
                ObjList = objRoleService.GetVideofetch_srv(org, locn, user, lang, In_video_gid, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
    }
}
