using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.kiosk_advertisement_model;
using static nafmodel.Mobile_FDR_Login_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_LoginController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_LoginController)); //Declaring Log4Net.       

        public Mobile_FDR_LoginController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("FdrLogin")]
        public FDRLoginfetchApplication FdrLogin(string org, string locn, string user, string lang, string instance, string In_user_code, string In_user_pwd)
        {
            string db = instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FDRLoginfetchApplication ObjList = new FDRLoginfetchApplication();
            try
            {
                ObjList = Mobile_FDR_Login_srv.GetAllFdrLogin_Srv(org, locn, user, lang, In_user_code, In_user_pwd, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("forgotpassword")]
        public Retrnmesg Fdrforgotpassword(Application objforgot)
        {
            string db = objforgot.document.context.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();

            Application ObjList = new Application();
            try
            {
                response = Mobile_FDR_Login_srv.Getforgotpassword_Srv(objforgot, ConString);
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

