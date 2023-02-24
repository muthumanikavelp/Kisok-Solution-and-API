using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.Mobile_FDR_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDRController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDRController)); //Declaring Log4Net.       

        public Mobile_FDRController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("FarmerProfileDetail")]
        public MFDRApplication FarmerProfileDetail(MFDRContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            MFDRApplication ObjList = new MFDRApplication();
            try
            {
                ObjList = Mobile_FDR_servicecs.GetAllFarmerProfileDetail_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("Farmerbank")]
        public MFApplication Farmerbank(MFContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            MFApplication ObjList = new MFApplication();
            try
            {
                ObjList = Mobile_FDR_servicecs.GetAllFarmerbank_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
       // [Authorize]
        [HttpPost("Farmermaster")]
        public MFMApplication Farmermaster(MFMContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            MFMApplication ObjList = new MFMApplication();
            try
            {
                ObjList = Mobile_FDR_servicecs.GetAllFarmermaster_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("Farmerdocnum")]
        public docnumApplication Farmerdocnum(docnumContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            docnumApplication ObjList = new docnumApplication();
            try
            {
                ObjList = Mobile_FDR_servicecs.GetAllFarmerdocnum_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
    }
}