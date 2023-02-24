using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.OfflineVideoList_Model;
using iTextSharp.text;
using Newtonsoft.Json;
using System.Collections;
using System.Xml;
 
namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfflineVideoListController : ControllerBase
    {

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(OfflineVideoListController)); //Declaring Log4Net.

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string dbstring = "";
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        private IHostingEnvironment _hostingEnvironment;
       
        public OfflineVideoListController(IOptions<MySettingsModel> app, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("KioskVideoList")]
        public KioskVideoApplication KioskAllVideoList(KioskVideoContext objkiosk)
        {

            string db = objkiosk.instance;
            //dynamic connection string
            AllConnectionString con = new AllConnectionString();
            this.ConString = con.getRightConString(db, this.appSettings.Value);



            KioskVideoApplication ObjList = new KioskVideoApplication();
           string advtfilepath = _configuration.GetSection("AppSettings")["Advertimentvideopath"].ToString();
            string videofilepath = _configuration.GetSection("AppSettings")["Trainingvideopath"].ToString();
            string faqfilepath = _configuration.GetSection("AppSettings")["FAQFilePath"].ToString();
            string schemesfilepath = _configuration.GetSection("AppSettings")["SchemesFilePath"].ToString();
            try
            {
                ObjList = OfflineVideoList_Service.GetAllKioskVideo_Srv(objkiosk, ConString, advtfilepath, videofilepath, faqfilepath, schemesfilepath);
               // logger.Debug("list" + ObjList);
            }
            catch (Exception ex)
            {
                   logger.Error(ex);
            }

            return ObjList;
        }
    }
}