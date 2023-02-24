using nafmodel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Web_UserManagementModel;

namespace nafdatamodel
{
    public class Web_UserManagementDataModel
    {

        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Web_ErrorMessageModel ObjErrormsg = new Web_ErrorMessageModel();
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Admin_UserManagementDataModel));

        public UserManagementList GetAllRoleList(string org, string locn, string user, string lang, string Mysql)
        {
            UserManagementList ObjFetchAll = new UserManagementList();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(Mysql);
                UserContext objContext = new UserContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_userrole_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<UserList> objRoleLst = new List<UserList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UserList objList = new UserList();
                    objList.orgn_code = dt.Rows[i]["orgn_code"].ToString();
                    objList.orgn_desc = dt.Rows[i]["orgn_desc"].ToString();
                    objList.user_code = dt.Rows[i]["user_code"].ToString();
                    objList.user_name = dt.Rows[i]["user_name"].ToString();
                    objList.role_code = dt.Rows[i]["role_code"].ToString();
                    objList.role_name = dt.Rows[i]["role_name"].ToString();
                    objList.valid_till = dt.Rows[i]["valid_till"].ToString();
                    objList.contact_no = dt.Rows[i]["contact_no"].ToString();
                    objList.email_id = dt.Rows[i]["email_id"].ToString();
                    objList.status_desc = dt.Rows[i]["status_desc"].ToString();
                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.list = objRoleLst;
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + org + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }

        public FetchUserManagement GetUserRoleaAtivity(string org, string locn, string user, string lang, string user_id, string role_code, string ConString)
        {
            FetchUserManagement ObjFetch = new FetchUserManagement();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchUserManagementContext objContext = new FetchUserManagementContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_userroleactivity", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_user_id", MySqlDbType.VarChar).Value = user_id;
                cmd.Parameters.Add("in_role_code", MySqlDbType.VarChar).Value = role_code;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<FetchUserManagementDetail> ObjRoleList = new List<FetchUserManagementDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchUserManagementDetail objList = new FetchUserManagementDetail();
                    objList.out_activity_code = dt.Rows[i]["out_activity_code"].ToString();
                    objList.out_activity_desc = dt.Rows[i]["out_activity_desc"].ToString();
                    objList.out_add_perm = dt.Rows[i]["out_add_perm"].ToString();
                    objList.out_mod_perm = dt.Rows[i]["out_mod_perm"].ToString();
                    objList.out_auth_perm = dt.Rows[i]["out_auth_perm"].ToString();
                    objList.out_view_perm = dt.Rows[i]["out_view_perm"].ToString();
                    objList.out_inactivate_perm = dt.Rows[i]["out_inactivate_perm"].ToString();
                    objList.out_print_perm = dt.Rows[i]["out_print_perm"].ToString();
                    objList.out_deny_perm = dt.Rows[i]["out_deny_perm"].ToString();

                    
                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.detail = ObjRoleList;
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + org + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public UserManagementOutput SaveUserRoleActivity(SaveUMRoot objRole, string ConString)
        {
            UserManagementOutput objOut = new UserManagementOutput();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);
                OutContext objContext = new OutContext();
                objContext.orgnId = objRole.document.context.orgnId;
                objContext.localeId = objRole.document.context.localeId;
                objContext.locnId = objRole.document.context.locnId;
                objContext.userId = objRole.document.context.userId;
                objOut.context = objContext;

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                nafmodel.ApplicationException objEx = new nafmodel.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_userrole", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_orgn_code;
                cmd.Parameters.Add("In_role_code", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_role_code;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_user_code;
                cmd.Parameters.Add("In_user_name", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_user_name;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_user_pwd;
                cmd.Parameters.Add("In_valid_till", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_valid_till;
                cmd.Parameters.Add("In_contact_no", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_contact_no;
                cmd.Parameters.Add("In_email_id", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_email_id;
                cmd.Parameters.Add("In_profile_photo", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_profile_photo;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                retdtls = cmd.ExecuteNonQuery();
                //   LogHelper.ConvertCmdIntoString(cmd);

                if ((string)cmd.Parameters["errorNo"].Value.ToString() != "")
                {
                    objEx.errorNumber = (string)cmd.Parameters["errorNo"].Value.ToString();
                    objEx.errorDescription = ObjErrormsg.ErrorMessage(objEx.errorNumber);
                    objOut.ApplicationException = objEx;
                    mysqltrans.Rollback();
                }
                else
                {
                    mysqltrans.Commit();
                    MysqlCon.con.Close();
                }
                objOut.ApplicationException = objEx;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                MysqlCon.con.Close();
                //   logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOut; ;
        }

        public FetchUserRole UserRole(string org, string locn, string user, string lang, string user_code, string ConString)
        {
            FetchUserRole ObjFetchAll = new FetchUserRole();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchUserRoleContext objContext = new FetchUserRoleContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_userrole", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_user_code", MySqlDbType.VarChar).Value = user_code;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_user_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_role_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_user_pwd", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_valid_till", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_contact_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_email_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_profile_photo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
               
                FetchUserRoleHeader objHeader = new FetchUserRoleHeader();
                objHeader.out_orgn_code = (string)cmd.Parameters["out_orgn_code"].Value.ToString();
                objHeader.out_user_name = (string)cmd.Parameters["out_user_name"].Value.ToString();
                objHeader.out_role_code = (string)cmd.Parameters["out_role_code"].Value.ToString();
                objHeader.out_user_pwd = (string)cmd.Parameters["out_user_pwd"].Value;
                objHeader.out_valid_till = (string)cmd.Parameters["out_valid_till"].Value.ToString();
                objHeader.out_contact_no = (string)cmd.Parameters["out_contact_no"].Value.ToString();
                objHeader.out_email_id = (string)cmd.Parameters["out_email_id"].Value.ToString();
                objHeader.out_profile_photo = (string)cmd.Parameters["out_profile_photo"].Value.ToString();
                objHeader.out_status_code = (string)cmd.Parameters["out_status_code"].Value.ToString();
                objHeader.out_status_desc = (string)cmd.Parameters["out_status_desc"].Value.ToString();
                objHeader.out_row_timestamp = (string)cmd.Parameters["out_row_timestamp"].Value.ToString();

               
                ObjFetchAll.context.Header = objHeader;
                List<FetchUserRoleDetail> objRoleLst = new List<FetchUserRoleDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchUserRoleDetail objList = new FetchUserRoleDetail();
                    objList.out_activity_code = dt.Rows[i]["out_activity_code"].ToString();
                    objList.out_activity_desc = dt.Rows[i]["out_activity_desc"].ToString();
                    objList.out_add_perm = dt.Rows[i]["out_add_perm"].ToString();
                    objList.out_mod_perm = dt.Rows[i]["out_mod_perm"].ToString();
                    objList.out_view_perm = dt.Rows[i]["out_view_perm"].ToString();
                    objList.out_auth_perm = dt.Rows[i]["out_uth_perm"].ToString();
                    objList.out_inactivate_perm = dt.Rows[i]["out_inactivate_perm"].ToString();
                    objList.out_print_perm = dt.Rows[i]["out_print_perm"].ToString();
                    objList.out_deny_perm = dt.Rows[i]["out_deny_perm"].ToString();

                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.Detail = objRoleLst;

            }
            catch (Exception ex)
            {
                //throw ex;
                //   logger.Error("USERNAME :" + org + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }
    }
}
