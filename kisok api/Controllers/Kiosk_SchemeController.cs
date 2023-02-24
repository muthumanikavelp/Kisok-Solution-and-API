using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.Kiosk_Scheme_model;

namespace kisok_api.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_SchemeController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Kiosk_SchemeController));
        kiosk_Scheme_service objRoleService = new kiosk_Scheme_service();
        public Kiosk_SchemeController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        [Authorize]
        [HttpGet("SchemeCatList")]
        public schemeCategoryContext SchemeCategoryList(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            schemeCategoryContext ObjList = new schemeCategoryContext();
            try
            {
                ObjList = objRoleService.GetSchemeCatList(org, locn, user, lang, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("Schemelist")]
        public schemeContext Schemecatlist(string org, string locn, string user, string lang, int In_schemecat_Id,string keyword)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_schemecat_Id);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            schemeContext ObjList = new schemeContext();
            try
            {
                ObjList = objRoleService.Getschemelist_srv(org, locn, user, lang, In_schemecat_Id, ConString, keyword);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("GetSchemadata")]
        public GetSchemeContext GetSchemadataID(string org, string locn, string user, string lang, int In_scheme_gid)
        {
            string File_path = "";
            string Final_Path = "";
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_scheme_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            GetSchemeContext ObjList = new GetSchemeContext();
            try
            {
                ObjList = objRoleService.Getschemedata(org, locn, user, lang, In_scheme_gid, ConString);

                if(ObjList.schemedata.upload_path != "")
                { 
                var s = ObjList.schemedata.upload_path;
                logger.Debug("s - " + s);
                string urlfileName = s.Split('\\').Last();
                logger.Debug("UrlfileName -" + urlfileName);
                File_path =_configuration.GetSection("AppSettings")["GovtSchemePath"].ToString();
                logger.Debug("File_Path -" + File_path);
                Final_Path = File_path + urlfileName;
                logger.Debug("Final_Path -" + Final_Path);
                ObjList.schemedata.upload_path = Final_Path;
                logger.Debug("ObjList.schemedata.upload_path -" + ObjList.schemedata.upload_path);
                }

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpPost("Schemesave")]
        public Retrnmesg newSchemesave(SaveScheme ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel);

            try
            {
                response = objRoleService.NewSchemesave_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }
        [Authorize]
        [HttpGet("SchemeSummaryList")]
        public SchemesSummaryContext SchemeSummaryList(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            SchemesSummaryContext ObjList = new SchemesSummaryContext();
            try
            {
                ObjList = objRoleService.GetSchemeSummary_srv(org, locn, user, lang, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("GetSchemeGetList")]
        public GetSchemedataContext GetSchemaGetList(string org, string locn, string user, string lang, int In_scheme_gid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_scheme_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            GetSchemedataContext ObjList = new GetSchemedataContext();
            try
            {
                ObjList = objRoleService.GetschemeGetdata(org, locn, user, lang, In_scheme_gid, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

    }
}
