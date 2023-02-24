using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nafdatamodel;
using nafmodel;
using nafservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static nafmodel.Web_UserManagementModel;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Web_UserManagementController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Admin_UserManagementController)); //Declaring Log4Net.
        Web_UserManagementService objRoleService = new Web_UserManagementService();
        public Web_UserManagementController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("alluserrole")]
        public UserManagementList AllUsers(string org, string locn, string user, string lang)
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
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            UserManagementList ObjList = new UserManagementList();
            try
            {
                ObjList = objRoleService.AllUsers(org, locn, user, lang, ConString);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }
        [HttpGet("userroleactivity")]
        public FetchUserManagement RoleaAtivity(string org, string locn, string user, string lang, string user_id, string role_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(user_id);
            objArr.Add(role_code);
            //log Input information
            //   LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            FetchUserManagement ObjFetch = new FetchUserManagement();
            try
            {
                ObjFetch = objRoleService.GetUserRoleaAtivity(org, locn, user, lang, user_id, role_code, ConString);
                //   LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }

            return ObjFetch;
        }
        [HttpPost("newuserrole")]
        public UserManagementOutput SaveUserRoleActivity(SaveUMRoot objUser)
        {
            //log Input information
            //   LogHelper.ConvertObjIntoString(objUser, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objUser.document.context.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            UserManagementOutput ObjFetch = new UserManagementOutput();
            try
            {
                ObjFetch = objRoleService.SaveUserRoleActivity(objUser, ConString);
                //   LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + objUser.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetch;
        }

        [HttpGet("userrole")]
        public FetchUserRole UserRole(string org, string locn, string user, string lang,string user_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(user_code);
            //log Input information
            //   LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            FetchUserRole ObjList = new FetchUserRole();
            try
            {
                ObjList = objRoleService.UserRole(org, locn, user, lang, user_code,ConString);
                //   LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }
    }
}
