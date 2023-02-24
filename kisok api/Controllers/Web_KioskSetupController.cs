using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using nafservice;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.Web_KioskSetupModel;
using nafdatamodel;
 
 

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Web_KioskSetupController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Admin_UserManagementController)); //Declaring Log4Net.
         Web_KioskSetupService objKioskService = new Web_KioskSetupService();
          string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
     
     

        public Web_KioskSetupController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        // next increament id

        [HttpGet("Autoincrement")]
        public int NextIncrementid(KioskSave ObjModel, string kiosk_code) // Get Nextgid
        {
            int res = 0;
            string db = ObjModel.locnId;
            //dynamic connection stringSaveRMContext 
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);


            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.Detail);
          
            try
            {
                res = objKioskService.NextIncrementid(ObjModel, ConString, kiosk_code);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return res;
        }





        [HttpGet("KioskList")]
        public KioskList GetKioskList(string org, string locn, string user, string lang )
        {
            ArrayList objArr = new ArrayList();
           objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
           objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            int res = 0;
            KioskList ObjList = new KioskList();
            try
            {
                ObjList = objKioskService.GetKioskList(org, locn, user, lang, ConString);
               // res = objKioskService.NextIncrementid(ConString, kiosk_code);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }

        //Kiosk Set up Onchange
        [HttpGet("Kioskonchange")]
        public KioskList GetKioskonchange(string org, string locn, string user, string lang,string Depend_Code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
           objArr.Add(user);
          objArr.Add(lang);
            objArr.Add(Depend_Code);

             AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            KioskList ObjList = new KioskList();
            try
            {
                ObjList = objKioskService.GetKioskonchange(org,locn, user, lang, Depend_Code, ConString);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }

        //Kiosk Fetch
        [Authorize]
        [HttpGet("Fetchkiosk")]
        public KioskSave GetKiosk(string org, string locn, string user, string lang, int Kiosk_id)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(Kiosk_id);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            KioskSave ObjList = new KioskSave();
            try
            {
                ObjList = objKioskService.GetkioskviewList(org, locn, user, lang, Kiosk_id, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        //Details list
        [Authorize]
        [HttpGet("Fetchkioskdetails")]
        public KioskSave GetKioskdetaillist(string org, string locn, string user, string lang, int Kiosk_id)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(Kiosk_id);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            KioskSave ObjList = new KioskSave();
            try
            {
                ObjList = objKioskService.GetkioskdetailList(org, locn, user, lang, Kiosk_id, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }


        //Kiosk Header save 

        // [Authorize]
        [HttpPost("Save_Kiosk")]

        public string[] SaveKioskSetup(KioskSave ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection stringSaveRMContext 
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.Detail);
            ObjModel.detail_formatted = jsonString;
            try
            {
                response = objKioskService.SaveKioskSetup(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return response;
        }

        //Kiosk Contact Details 
        [HttpPost("SaveContact_Kiosk")]

        public string[] SaveKioskSetupDetails(SavesingleContext test)
        {
            string db = test.locnId;
            //dynamic connection stringSaveRMContext 
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(test);
           // ObjModel.detail_formatted = jsonString;
            try
            {
                response = objKioskService.SaveKioskSetupDetails(test, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return response;
        }


        [Authorize]
        [HttpGet("viewFetchkiosk")]
        public KioskSave viewkioskdetails(string org, string locn, string user, string lang, int contact_id)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(contact_id);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            KioskSave ObjList = new KioskSave();
            try
            {
                ObjList = objKioskService.viewkioskdetails(org, locn, user, lang, contact_id, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }


        //fetech kiosk details  

        [Authorize]
        [HttpGet("kioskdetailslist")]
        public KioskSave  kioskdetailslist(string org, string locn, string user, string lang, int Kiosk_id)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(Kiosk_id);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            KioskSave ObjList = new KioskSave();
            try
            {
                ObjList = objKioskService.kioskdetailslist(org, locn, user, lang, Kiosk_id, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
    }
}
