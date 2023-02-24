using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using System;
using static nafmodel.Kiosk_localization_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_localizationController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        Kiosk_localization_service objRoleService = new Kiosk_localization_service();
        public Kiosk_localizationController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("localizationlist")]
        public localizationcontext localizationlistList(string org, string locn, string user, string lang)
        {           
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            localizationcontext ObjList = new localizationcontext();
            try
            {
                ObjList = objRoleService.Getlocalizationlist_srv(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
    }
}
