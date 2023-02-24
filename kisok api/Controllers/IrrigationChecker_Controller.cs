using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.IrrigationChecker_Model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IrrigationChecker_Controller : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        IrrigationChecker_Service objRoleService = new IrrigationChecker_Service();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Kiosk_IrrigationWaterTestController)); //Declaring Log4Net.
        public IrrigationChecker_Controller(IOptions<MySettingsModel> app, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        #region  irrigationgridvalues bind

        //introduced code by Venkat getsolidparameters grid values 2021-04-21

        [Authorize]
        [HttpGet("getirrigationparametersChecker")]
        public irrigationParametersDetailItems getirrigationparameters(string org, string locn, string lang, string status)
        {
            irrigationParametersDetailItems obj_soilDetailItems = new irrigationParametersDetailItems();
            try
            {
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
                obj_soilDetailItems = objRoleService.getirrigationparametersChecker(ConString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_soilDetailItems;
        }

        #endregion

        #region ListIrrigationgrid
        [HttpGet("IrrigationListChecker")]
        public irrigationListContext IrrigationList(string org, string locn, string lang, string status)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(lang);
            objArr.Add(status);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            irrigationListContext ObjList = new irrigationListContext();
            try
            {
                ObjList = objRoleService.GetsoilList_srvChecker(org, locn, lang, status, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        #endregion
       
        #region
        [HttpPost("irrigationsaveChecker")]
        public Retrnmesg newirrigationsave(irrigationsave ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.Detail);
            ObjModel.detail_formatted = jsonString;
            try
            {
                response = objRoleService.Newirrigationsave_SrvChecker(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }
        #endregion

        #region irrigationFetch
        [Authorize]
        [HttpGet("IrrigationListViewChecker")]
        public irrigationviewContext irrigationviewList(string org, string locn, string user, string lang, int irrigation_gid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(irrigation_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            irrigationviewContext ObjList = new irrigationviewContext();
            try
            {
                ObjList = objRoleService.GetirrigationviewListChecker(org, locn, user, lang, irrigation_gid, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        #endregion

        #region
        //print list
        [Authorize]
        [HttpGet("IrrigationprintChecker")]
        public irrigationviewContext irrigationviewPrintList(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(soil_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            irrigationviewContext ObjList = new irrigationviewContext();
            try
            {
                ObjList = objRoleService.irrigationviewPrintListChecker(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }


        #endregion
    }
}
