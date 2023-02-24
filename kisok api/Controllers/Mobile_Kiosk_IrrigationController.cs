using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static nafmodel.Mobile_Kiosk_Irrigation_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_Kiosk_IrrigationController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        Mobile_Kiosk_Irrigation_service objRoleService = new Mobile_Kiosk_Irrigation_service();
        public Mobile_Kiosk_IrrigationController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [Authorize]
        [HttpPost("mobirrigationsave")]
        public Retrnmesg newmobsoilcardsave(mobsaveirrigation ObjModel)
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
                response = objRoleService.newmobirrigation_Srv(ObjModel, ConString);
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
