using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.Mobile_FDR_Login_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_ComloginController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_ComloginController)); //Declaring Log4Net.       

        public Mobile_FDR_ComloginController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("Login")]
        public LoginfetchApplication Login(LoginfetchContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.instance, this.appSettings.Value);

            LoginfetchApplication ObjList = new LoginfetchApplication();
            try
            {
                ObjList = Mobile_FDR_Login_srv.GetAllLogin_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
    }
}
