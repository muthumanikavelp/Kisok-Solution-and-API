using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using nafservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.Web_RoleManagementModel;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Web_RoleManagementController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
       // log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Admin_RoleManagementController)); //Declaring Log4Net.
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        Web_RoleMangementService objRoleService = new Web_RoleMangementService();
        public Web_RoleManagementController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("allroles")]
        public RoleMangementList AllRoles(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            //log Input information
            //   LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
           
            RoleMangementList ObjList = new RoleMangementList();
            try
            {
                ObjList = objRoleService.GetAllRoleList(org, locn, user, lang, ConString);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("roleactivity")]
        public RoleManagementFetch RoleaAtivity(string org, string locn, string user, string lang, int role_rowid, string orgn_level)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(role_rowid);
            objArr.Add(orgn_level);
            //log Input information
            //   LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
           
            RoleManagementFetch ObjFetch = new RoleManagementFetch();
            try
            {
                ObjFetch = objRoleService.RoleaAtivity(org, locn, user, lang, role_rowid, orgn_level, ConString);
                //   LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return ObjFetch;
        }
        [HttpPost("newrole")]
        public RMOutput SaveRoleActivity(SaveRMRoot objRole)
        {
            //log Input information
            //   LogHelper.ConvertObjIntoString(objRole, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objRole.document.context.locnId, this.appSettings.Value);
            
            RMOutput ObjFetch = new RMOutput();
            try
            {
                ObjFetch = objRoleService.SaveRoleActivity(objRole, ConString);
                //   LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }

}
