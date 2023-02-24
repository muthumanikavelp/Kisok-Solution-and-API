using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.OfflineAttachment_Model;


namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfflineAttachmentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

       
        public OfflineAttachmentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

      //   [Authorize]
        [HttpPost("KioskList")]
        public KioskApplication KioskAllList(KioskContext objkiosk)
        {
            string db = objkiosk.instance;
            //dynamic connection string
            AllConnectionString  con = new AllConnectionString();
            this.ConString = con.getRightConString(db, this.appSettings.Value);

            KioskApplication ObjList = new KioskApplication();
            try
            {
                ObjList = OfflineAttachment_Service.GetAllKiosk_Srv(objkiosk, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
    }
}