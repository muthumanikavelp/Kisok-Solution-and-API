using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.Kiosk_Soil_Card_model;
using static nafmodel.Kisok_attach_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_attachmentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        kiosk_attach_service objRoleService = new kiosk_attach_service();
        public Kiosk_attachmentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [Authorize]
        [HttpPost("attachsave")]
        public Retrnmesg newattachsave(attchementsave ObjModel)
        {
            string db = ObjModel.locid;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            try
            {
                response = objRoleService.newattachsave_Srv(ObjModel, ConString);
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
        [HttpGet("attachView")]
        public attchement attachView(string org, string locn, string user, string lang, string doc_type, string id)
        {            
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            attchement ObjList = new attchement();
            try
            {
                ObjList = objRoleService.Getattchementfetch_srv(org, locn, user, lang, doc_type, id, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [Authorize]
        [HttpPost("notessave")]
        public Retrnmesg newnotessave(notessave ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            try
            {
                response = objRoleService.newnotessave_Srv(ObjModel, ConString);
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
        [HttpPost("attachdelete")]
        public Retrnmesg newattachdelete(attachdelete ObjModel)
        {
            string db = ObjModel.locId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            try
            {
                response = objRoleService.newattachdelete_Srv(ObjModel, ConString);
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
