using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static nafmodel.Kiosk_uploadsign_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_UploadSignController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private readonly IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        kiosk_uploadsign_service objRoleService = new kiosk_uploadsign_service();
        public Kiosk_UploadSignController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        [HttpGet("UploadSignList")]
        public uploadsigncontext uploadsignList(string org, string locn, string user, string lang)
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

            uploadsigncontext ObjList = new uploadsigncontext();
            try
            {
                ObjList = objRoleService.GetuploadsignList_srv(org, locn, user, lang, ConString);

               

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("UploadSignfetch")]
        public uploadsignfetchContext uploadsignfetch(string org, string locn, string user, string lang, int In_signature_rowid)
        {
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            uploadsignfetchContext ObjList = new uploadsignfetchContext();
            try
            {
                ObjList = objRoleService.Getuploadsignfetch_srv(org, locn, user, lang, In_signature_rowid, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [Authorize]
        [HttpPost("UploadSignsave")]
        public Retrnmesg newUploadsignsave(Saveuploadsign ObjModel)
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
                response = objRoleService.NewUploadSignsave_Srv(ObjModel, ConString);
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
