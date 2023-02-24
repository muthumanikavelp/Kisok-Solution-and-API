using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.Mobile_FDR_FHeader_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_FHeaderController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_FHeaderController)); //Declaring Log4Net.       
        Mobile_FDR_FHeader_srv objRoleService = new Mobile_FDR_FHeader_srv();
        public Mobile_FDR_FHeaderController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [Authorize]
        [HttpPost("NewMobileFarmerHeader")]
        public MFHDocument newNewMobileFarmerHeader(MFHApplication ObjModel)
        {
            string db = ObjModel.document.context.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            MFHDocument Objresult = new MFHDocument();
            try
            {
                Objresult = Mobile_FDR_FHeader_srv.SaveNewMobileFarmerHeader_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return Objresult;
        }
        [HttpGet("FarmerRegList")]
        public farmerSummaryContext FarmerList(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            farmerSummaryContext ObjList = new farmerSummaryContext();
            try
            {
                ObjList = objRoleService.GetFarmerList_srv(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
    }
}