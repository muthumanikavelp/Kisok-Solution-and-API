using nafdatamodel;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Web_RoleManagementModel;

namespace nafservice
{
    public class Web_RoleMangementService
    {
        Web_RoleManagementDataModel objDataModel = new Web_RoleManagementDataModel();
        public RoleMangementList GetAllRoleList(string org, string locn, string user, string lang, string Mysql)
        {
            RoleMangementList ObjFetchAll = new RoleMangementList();
            try
            {
                ObjFetchAll = objDataModel.GetAllRoleList(org, locn, user, lang, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public RoleManagementFetch RoleaAtivity(string org, string locn, string user, string lang, int role_rowid, string orgn_level, string ConString)
        {
            RoleManagementFetch ObjFetch = new RoleManagementFetch();
            try
            {
                ObjFetch = objDataModel.RoleaAtivity(org, locn, user, lang, role_rowid, orgn_level, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public RMOutput SaveRoleActivity(SaveRMRoot objRole, string ConString)
        {
            RMOutput ObjFetch = new RMOutput();
            try
            {
                ObjFetch = objDataModel.SaveRoleActivity(objRole, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        //public static SaveItemMasterDocument SaveItemMasterDtls(SaveItemMasterApplication ObjContext, string Mysql)
        //{
        //    SaveItemMasterDocument ObjFetchAll = new SaveItemMasterDocument();
        //    PAWHSItemMaster_DataModel objDataModel = new PAWHSItemMaster_DataModel();
        //    try
        //    {
        //        ObjFetchAll = objDataModel.SaveItemMaster(ObjContext, Mysql);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ObjFetchAll;
        //}
    }
}
