using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using nafmodel;
using nafdatamodel;
using static nafmodel.Web_RoleManagementModel;

namespace nafdatamodel
{
    public class Web_RoleManagementDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;

        Web_ErrorMessageModel ObjErrormsg = new Web_ErrorMessageModel();
       // log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Admin_RoleManagementDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        ////   LogHelper objHelper = new //   LogHelper();

        public RoleMangementList GetAllRoleList(string org, string locn, string user, string lang, string Mysql)
        {
            RoleMangementList ObjFetchAll = new RoleMangementList();
           
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(Mysql);
                RoleManagementContext objContext = new RoleManagementContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_roleactivity_list", MysqlCon.con);
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

                List<RoleManagement> objRoleLst = new List<RoleManagement>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RoleManagement objList = new RoleManagement();
                    objList.out_role_rowid = Convert.ToInt32(dt.Rows[i]["out_role_rowid"]);
                    objList.out_role_code = dt.Rows[i]["out_role_code"].ToString();
                    objList.out_role_name = dt.Rows[i]["out_role_name"].ToString();
                    objList.out_orgn_level = dt.Rows[i]["out_orgn_level"].ToString();
                    objList.out_orgn_level_desc = dt.Rows[i]["out_orgn_level_desc"].ToString();
                    objList.out_status_code = dt.Rows[i]["out_status_code"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();

                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.List = objRoleLst;
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }

        public RoleManagementFetch RoleaAtivity(string org, string locn, string user, string lang, int role_rowid, string orgn_level, string ConString)
        {
            RoleManagementFetch ObjFetch = new RoleManagementFetch();
            
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchRoleManagementContext objContext = new FetchRoleManagementContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_roleactivity", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_role_rowid", MySqlDbType.Int32).Value = role_rowid;
                cmd.Parameters.Add("inout_orgn_level", MySqlDbType.VarChar).Value = orgn_level;

                cmd.Parameters.Add(new MySqlParameter("out_role_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_role_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_orgn_level1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_level_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                FetchRolManagementHeader objHeader = new FetchRolManagementHeader();
                objHeader.out_role_code = (string)cmd.Parameters["out_role_code"].Value.ToString();
                objHeader.out_role_name = (string)cmd.Parameters["out_role_name"].Value.ToString();
                objHeader.inout_orgn_level = (string)cmd.Parameters["inout_orgn_level1"].Value.ToString();
                objHeader.out_orgn_level_desc = (string)cmd.Parameters["out_orgn_level_desc"].Value;
                objHeader.out_status_code = (string)cmd.Parameters["out_status_code"].Value.ToString();
                objHeader.out_status_desc = (string)cmd.Parameters["out_status_desc"].Value.ToString();
                objHeader.out_row_timestamp = (string)cmd.Parameters["out_row_timestamp"].Value.ToString();
                objHeader.out_mode_flag = (string)cmd.Parameters["out_mode_flag"].Value.ToString();

                ObjFetch.context.header = objHeader;
                List<FetchRoleManagementDetail> ObjRoleList = new List<FetchRoleManagementDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchRoleManagementDetail objList = new FetchRoleManagementDetail();
                    objList.out_rolemenu_rowid = Convert.ToInt32(dt.Rows[i]["out_rolemenu_rowid"]);
                    objList.out_activity_code = dt.Rows[i]["out_activity_code"].ToString();
                    objList.out_activity_desc = dt.Rows[i]["out_activity_desc"].ToString();
                    objList.out_add_perm = dt.Rows[i]["out_add_perm"].ToString();
                    objList.out_mod_perm = dt.Rows[i]["out_mod_perm"].ToString();
                    objList.out_view_perm = dt.Rows[i]["out_view_perm"].ToString();
                    objList.out_auth_perm = dt.Rows[i]["out_auth_perm"].ToString();
                    objList.out_inactivate_perm = dt.Rows[i]["out_inactivate_perm"].ToString();
                    objList.out_print_perm = dt.Rows[i]["out_print_perm"].ToString();
                    objList.out_deny_perm = dt.Rows[i]["out_deny_perm"].ToString();
                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.detail = ObjRoleList;
               
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public RMOutput SaveRoleActivity(SaveRMRoot objRole, string ConString)
        {
            RMOutput objOut = new RMOutput();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                RMOutputContext objContext = new RMOutputContext();
                objContext.orgnId = objRole.document.context.orgnId;
                objContext.localeId = objRole.document.context.localeId;
                objContext.locnId = objRole.document.context.locnId;
                objContext.userId = objRole.document.context.userId;
                objOut.context = objContext;
                RMOutputHeader objOutHeader = new RMOutputHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                nafmodel.ApplicationException objex = new nafmodel.ApplicationException();
                SaveRMContext objCotext = objRole.document.context;
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_roleactivity", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                cmd.Parameters.Add("inout_role_rowid", MySqlDbType.VarChar).Value = objRole.document.context.header.inout_role_rowid;
                cmd.Parameters.Add("in_role_code", MySqlDbType.VarChar).Value = objRole.document.context.header.in_role_code;
                cmd.Parameters.Add("in_role_name", MySqlDbType.VarChar).Value = objRole.document.context.header.in_role_name;
                cmd.Parameters.Add("in_orgn_level", MySqlDbType.VarChar).Value = objRole.document.context.header.in_orgn_level;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objRole.document.context.header.in_status_code;
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = objRole.document.context.header.in_row_timestamp;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objRole.document.context.header.in_mode_flag;
                cmd.Parameters.Add(new MySqlParameter("inout_role_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                retdtls = cmd.ExecuteNonQuery();
                //   LogHelper.ConvertCmdIntoString(cmd);

                if (retdtls > 0)
                {
                    objOutHeader.inout_role_rowid = (Int32)cmd.Parameters["inout_role_rowid1"].Value;
                }
                //if (cmd.Parameters["errorNo"].Value.ToString() != "")
                //{

                if ((String)cmd.Parameters["errorNo"].Value.ToString() != "") { 
                    objex.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                }
                objOut.context.header = objOutHeader;

                bool isvaild = true;
                if (objOutHeader.inout_role_rowid > 0)
                {
                    foreach (var Details in objRole.document.context.detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("Admin_iud_roleactivity", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("out_role_code", MySqlDbType.VarChar).Value = objRole.document.context.header.in_role_code;
                        cmds.Parameters.Add("out_rolemenu_rowid", MySqlDbType.VarChar).Value = Details.out_rolemenu_rowid;
                        cmds.Parameters.Add("out_activity_code", MySqlDbType.VarChar).Value = Details.out_activity_code;
                        cmds.Parameters.Add("out_add_perm", MySqlDbType.VarChar).Value = Details.out_add_perm;
                        cmds.Parameters.Add("out_mod_perm", MySqlDbType.VarChar).Value = Details.out_mod_perm;
                        cmds.Parameters.Add("out_view_perm", MySqlDbType.VarChar).Value = Details.out_view_perm;
                        cmds.Parameters.Add("out_auth_perm", MySqlDbType.VarChar).Value = Details.out_auth_perm;
                        cmds.Parameters.Add("out_inactivate_perm", MySqlDbType.VarChar).Value = Details.out_inactivate_perm;
                        cmds.Parameters.Add("out_print_perm", MySqlDbType.VarChar).Value = Details.out_print_perm;
                        cmds.Parameters.Add("out_deny_perm", MySqlDbType.VarChar).Value = Details.out_deny_perm;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                        ret = cmds.ExecuteNonQuery();
                        //   LogHelper.ConvertCmdIntoString(cmd);

                        if (ret == 0)
                        {
                            //objex.errorNumber = (string)cmds.Parameters["errorNo"].Value;
                            //objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                            //isvaild = false;
                          //  mysqltrans.Rollback();
                          //  break;
                        }
                    }
                    if (isvaild == true)
                    {
                        mysqltrans.Commit();
                    }
                }
                else
                {
                    mysqltrans.Rollback();
                }
                //MySqlCommand vcmd = new MySqlCommand("Admin_validate_roleactivity", MysqlCon.con);
                //vcmd.CommandType = CommandType.StoredProcedure;
                //vcmd.Parameters.Add("inout_role_rowid", MySqlDbType.VarChar).Value = objRole.document.context.header.inout_role_rowid;
                //vcmd.Parameters.Add("in_role_code", MySqlDbType.VarChar).Value = objRole.document.context.header.in_role_code;
                //vcmd.Parameters.Add("in_role_name", MySqlDbType.VarChar).Value = objRole.document.context.header.in_role_name;
                //vcmd.Parameters.Add("in_orgn_level", MySqlDbType.VarChar).Value = objRole.document.context.header.in_orgn_level;
                //vcmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objRole.document.context.header.in_status_code;
                //vcmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = objRole.document.context.header.in_row_timestamp;
                //vcmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objRole.document.context.header.in_mode_flag;
                //vcmd.Parameters.Add(new MySqlParameter("inout_role_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                //vcmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                //vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                //vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                //vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;

                //ret = vcmd.ExecuteNonQuery();
                //   LogHelper.ConvertCmdIntoString(cmd);
                objOut.ApplicationException = objex;
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                //   logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOut; ;
        }
    }
}
