using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using nafdatamodel;
using System.Collections;
using static nafmodel.Web_MasterDefinition_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Web_MasterDefinitionController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(MasterDefinitionController)); //Declaring Log4Net. 
        public Web_MasterDefinitionController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("MasterDefinition_List")]
        public MasterRootObject MasterDefinition_List(MasterContext objfarmer)
        {
            //log Input information
            //   LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            MasterRootObject ObjList = new MasterRootObject();
            try
            {
                ObjList = Web_MasterDefinition_service.MasterDefinition_List(objfarmer, ConString);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }

        [HttpPost("MasterDefinition_SingleFetch")]
        public Master_FRoot MasterDefinition_SingleFetch(Master_FContext SobjContext)
        {
            //log Input information
            //   LogHelper.ConvertObjIntoString(SobjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            Master_FRoot ObjList = new Master_FRoot();
            try
            {
                ObjList = Web_MasterDefinition_service.MasterDefinition_SingleFetch(SobjContext, ConString);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + SobjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }

        [HttpPost("MasterDefinition_Save")]
        public Master_DocumentSave MasterDefinition_Save(Master_RootSave ObjModel)
        {
            //log Input information
            //   LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            string[] response = { };
            Master_DocumentSave Objresult = new Master_DocumentSave();
            try
            {
                Objresult = Web_MasterDefinition_service.MasterDefinition_Save(ObjModel, ConString);
                //   LogHelper.ConvertObjIntoString(Objresult, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return Objresult;

        }

        //delete
        [HttpPost("MasterDefinition_delete")]
        public Master_DocumentSave MasterDefinition_detaildelete(Master_RootSave ObjModel)
        {
            //log Input information
            //   LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            string[] response = { };
            Master_DocumentSave Objresult = new Master_DocumentSave();
            try
            {
                Objresult = Web_MasterDefinition_service.MasterDefinition_delete(ObjModel, ConString);
                //   LogHelper.ConvertObjIntoString(Objresult, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return Objresult;

        }

        [HttpGet("mastercode_screenid")]
        public MasterCodeScreenID GetMasterCodeScreenId(string org, string locn, string user, string lang, string screen_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(screen_code);
            //log Input information
            //   LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            MasterCodeScreenID objScreen = new MasterCodeScreenID();
            try
            {
                objScreen = Web_MasterDefinition_service.GetMasterCodeScreenId_srv(org, locn, user, lang, screen_code, ConString);
                //   LogHelper.ConvertObjIntoString(objScreen, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objScreen;
        }

    }
}
