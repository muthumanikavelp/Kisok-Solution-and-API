using nafdatamodel;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Web_UserManagementModel;

namespace nafservice
{
   public class Web_UserManagementService
    {

        Web_UserManagementDataModel objRoleModel = new Web_UserManagementDataModel();
        public UserManagementList AllUsers(string org, string locn, string user, string lang,string ConString)
        {
            UserManagementList ObjList = new UserManagementList();
            try
            {
                ObjList = objRoleModel.GetAllRoleList(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return ObjList;
        }
        public FetchUserManagement GetUserRoleaAtivity(string org, string locn, string user, string lang, string user_id, string role_code, string ConString)
        {
            FetchUserManagement ObjFetch = new FetchUserManagement();
            try
            {
                ObjFetch = objRoleModel.GetUserRoleaAtivity(org, locn, user, lang, user_id, role_code, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public UserManagementOutput SaveUserRoleActivity(SaveUMRoot objUser, string ConString)
        {
            UserManagementOutput ObjFetch = new UserManagementOutput();
            try
            {
                ObjFetch = objRoleModel.SaveUserRoleActivity(objUser, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public FetchUserRole UserRole(string org, string locn, string user, string lang, string user_code,string ConString)
        {
            FetchUserRole ObjList = new FetchUserRole();
            try
            {
                ObjList = objRoleModel.UserRole(org, locn, user, lang, user_code, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjList;
        }
    }
}
