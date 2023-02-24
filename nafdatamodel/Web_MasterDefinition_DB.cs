using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using nafmodel;
using static nafmodel.Web_MasterDefinition_model;

namespace nafdatamodel
{
    public class Web_MasterDefinition_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        //ErrorMessages ObjErrormsg = new ErrorMessages();
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(MasterDefinition_DB));
        public MasterRootObject MasterDefinition_List(MasterContext ObjContext, string mysqlcon)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            int j = 0;
            string pc = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            MasterRootObject ObjFetchAll = new MasterRootObject();
            MasterApplicationException maserror = new MasterApplicationException();
            ObjFetchAll.context = new MasterContext();
            ObjFetchAll.context.detail = new List<MasterDetailItem>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_master_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("in_parent_code", MySqlDbType.VarChar).Value = ObjContext.parent_code;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MasterDetailItem objList = new MasterDetailItem();                   
                    objList.out_master_rowid = Convert.ToInt32(dt.Rows[i]["out_master_rowid"]);
                    objList.out_parent_code = dt.Rows[i]["out_parent_code"].ToString();
                    objList.out_parent_descripton = dt.Rows[i]["out_parent_descripton"].ToString();
                    objList.out_master_code = dt.Rows[i]["out_master_code"].ToString();
                    objList.out_master_description = dt.Rows[i]["out_master_description"].ToString();
                    objList.out_master_ll_description = dt.Rows[i]["out_master_ll_description"].ToString();
                    objList.out_depend_desc = dt.Rows[i]["out_depend_desc"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();

                    ObjFetchAll.context.detail.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                //maserror.errorDescription = j + " - " + pc + " - " + ex.Message.ToString();
                //ObjFetchAll.ApplicationException = maserror;
                //   logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return ObjFetchAll;
        }

        public Master_FRoot MasterDefinition_SingleFetch(Master_FContext objfpoSearch, string mysqlcon)
        {
            DataTable dt = new DataTable();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            Master_FRoot objfpoSearchRoot = new Master_FRoot();
            objfpoSearchRoot.context = new Master_FContext();
            objfpoSearchRoot.context.detail = new List<Master_FDetail>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("Admin_fetch_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("in_parent_code", MySqlDbType.VarChar).Value = objfpoSearch.parent_code;

                cmd.Parameters.Add(new MySqlParameter("out_parent_description", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Master_FDetail objList = new Master_FDetail();
                    objList.out_master_rowid = Convert.ToInt32(dt.Rows[i]["out_master_rowid"]);
                    objList.out_master_code = dt.Rows[i]["out_master_code"].ToString();
                    objList.out_master_description = dt.Rows[i]["out_master_description"].ToString();
                    objList.out_master_ll_description = dt.Rows[i]["out_master_ll_description"].ToString();
                    objList.out_depend_desc = dt.Rows[i]["out_depend_desc"].ToString();
                    objList.out_depend_code = dt.Rows[i]["out_depend_code"].ToString();
                    objList.out_parent_code = objfpoSearch.parent_code;
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();
                    objList.out_mode_flag = dt.Rows[i]["out_mode_flag"].ToString();

                    objfpoSearchRoot.context.detail.Add(objList);
                }
                objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                objfpoSearchRoot.context.userId = objfpoSearch.userId;
                objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                objfpoSearchRoot.context.parent_code = objfpoSearch.parent_code;
                //  objfpoSearchRoot.context. = (Int32)cmd.Parameters["out_parent_description"].Value; 
                MysqlCon.con.Close();
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //da.Fill(ds);
                //MysqlCon.con.Close();
                //if (ds.Tables.Count > 0)
                //{  

                //}
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                //   logger.Error("USERNAME :" + objfpoSearchRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objfpoSearchRoot;
        }

        public Master_DocumentSave MasterDefinition_Save(Master_RootSave ObjICDSupplier, string MysqlCons)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            Master_DocumentSave ObjresICDSupplier = new Master_DocumentSave();
            ObjresICDSupplier.context = new Master_ContextSave();
            ObjresICDSupplier.context.detail = new List<Master_DetailSave>();
            Master_DetailSave objproduct1 = new Master_DetailSave();
            ApplicationExceptionsave excep = new ApplicationExceptionsave();
            string saving = "";
            int count = 1;
            DataTable tab = new DataTable();
            try
            {
                Web_MasterDefinition_DB objdb = new Web_MasterDefinition_DB();
                foreach (var Kyc in ObjICDSupplier.document.context.detail)
                {
                    objproduct1.out_master_rowid = Kyc.out_master_rowid;
                    objproduct1.out_row_slno = Kyc.out_row_slno;
                    objproduct1.out_master_code = Kyc.out_master_code;
                    objproduct1.out_master_description = Kyc.out_master_description;
                    objproduct1.out_master_ll_description = Kyc.out_master_ll_description;
                    objproduct1.out_depend_code = Kyc.out_depend_code;
                    objproduct1.out_locallang_flag = Kyc.out_locallang_flag;
                    objproduct1.out_status_code = Kyc.out_status_code;
                    objproduct1.out_row_timestamp = Kyc.out_row_timestamp;
                    objproduct1.out_mode_flag = Kyc.out_mode_flag;
                    saving = objdb.MasterDefinition_SaveSP(objproduct1, ObjICDSupplier, MysqlCons);
                    //  count = count + 1;
                    if (saving != "")
                    {
                        excep.errorDescription = saving;
                        ObjresICDSupplier.ApplicationException = excep;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjresICDSupplier;

        }

        //delete
        public Master_DocumentSave MasterDefinition_delete(Master_RootSave ObjICDSupplier, string MysqlCons)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            Master_DocumentSave ObjresICDSupplier = new Master_DocumentSave();
            ObjresICDSupplier.context = new Master_ContextSave();
            ObjresICDSupplier.context.detail = new List<Master_DetailSave>();
            Master_DetailSave objproduct1 = new Master_DetailSave();
            ApplicationExceptionsave excep = new ApplicationExceptionsave();
            Master_RootSave obj = new Master_RootSave();
            string saving = "";
            int count = 1;
            DataTable tab = new DataTable();
            try
            {
                Web_MasterDefinition_DB objdb = new Web_MasterDefinition_DB();
                 
                    saving = objdb.MasterDefinition_deletesp(objproduct1, ObjICDSupplier, MysqlCons);
                   
           }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjresICDSupplier;

        }



        public string MasterDefinition_SaveSP(Master_DetailSave objadddtl, Master_RootSave ObjICDSupplier, string mysqlcon)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            int ret = 0;
            string errordis = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("Admin_iud_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.localeId;
                cmd.Parameters.Add("in_master_rowid", MySqlDbType.Int32).Value = objadddtl.out_master_rowid;
                cmd.Parameters.Add("in_parent_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.header.in_parent_code;
                cmd.Parameters.Add("in_row_slno", MySqlDbType.VarChar).Value = objadddtl.out_row_slno;
                cmd.Parameters.Add("in_master_code", MySqlDbType.VarChar).Value = objadddtl.out_master_code;
                cmd.Parameters.Add("in_master_description", MySqlDbType.VarChar).Value = objadddtl.out_master_description;
                cmd.Parameters.Add("in_master_ll_description", MySqlDbType.VarChar).Value = objadddtl.out_master_ll_description;
                cmd.Parameters.Add("in_depend_code", MySqlDbType.VarChar).Value = objadddtl.out_depend_code;
                cmd.Parameters.Add("in_locallang_flag", MySqlDbType.VarChar).Value = objadddtl.out_locallang_flag;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objadddtl.out_status_code;
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = objadddtl.out_row_timestamp;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objadddtl.out_mode_flag;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                //   LogHelper.ConvertCmdIntoString(cmd);

                mysqltrans.Commit();
                errordis = (string)cmd.Parameters["errorNo"].Value.ToString();
                if (errordis == "05001")
                    errordis = "Parent Code cannot be blank";
                else if (errordis == "05002")
                    errordis = "Master Code cannot be blank";
                else if (errordis == "05003")
                    errordis = "Description cannot be blank";
                else if (errordis == "05007")
                    errordis = "Master Description should be unique";
                else if (errordis == "05008")
                    errordis = "Master Code cannot be duplicated";
                else if (errordis == "05009")
                    errordis = "Master local cannot be duplicated";
                else if (errordis == "05010")
                    errordis = "Record modified since last fetch so Kindly refetch and continue";

                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                //   logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return errordis;

        }

        //delete

        public string MasterDefinition_deletesp(Master_DetailSave objadddtl, Master_RootSave ObjICDSupplier, string mysqlcon)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            int ret = 0;
            string errordis = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("Admin_delete_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.localeId;
                cmd.Parameters.Add("in_master_rowid", MySqlDbType.Int32).Value = ObjICDSupplier.document.context.out_master_rowid;
              
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.out_mode_flag;
               // cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                //   LogHelper.ConvertCmdIntoString(cmd);

                mysqltrans.Commit();
                errordis = (string)cmd.Parameters["errorNo"].Value.ToString();
                if (errordis == "05001")
                    errordis = "Parent Code cannot be blank";
                else if (errordis == "05002")
                    errordis = "Master Code cannot be blank";
                else if (errordis == "05003")
                    errordis = "Description cannot be blank";
                else if (errordis == "05007")
                    errordis = "Master Description should be unique";
                else if (errordis == "05008")
                    errordis = "Master Code cannot be duplicated";
                else if (errordis == "05009")
                    errordis = "Master local cannot be duplicated";
                else if (errordis == "05010")
                    errordis = "Record modified since last fetch so Kindly refetch and continue";

                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                //   logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return errordis;

        }

        public MasterCodeScreenID GetMasterCodeScreenId_db(string org, string locn, string user, string lang, string screen_code, string ConString)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            MasterCodeScreenID objScreen = new MasterCodeScreenID();
            try
            {

                objScreen.orgnId = org;
                objScreen.locnId = locn;

                MysqlCon = new DataConnection(ConString);

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_master_definition_screen_id", MysqlCon.con);
              //  MySqlCommand cmd = new MySqlCommand("KioskMob_MasterList", MysqlCon.con);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_screen_code", MySqlDbType.VarChar).Value = screen_code;

                cmd.Parameters.Add(new MySqlParameter("userId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("orgnId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("locnId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("localeId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_screen_description", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                MysqlCon.con.Close();
                MCSIHeader objHeader = new MCSIHeader();
                objScreen.Header = objHeader;
                objHeader.screen_description = (string)cmd.Parameters["out_screen_description"].Value.ToString();
                List<MCSIDetail> objMasterList = new List<MCSIDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MCSIDetail objList = new MCSIDetail();
                    objList.out_master_rowid = Convert.ToInt32(dt.Rows[i]["out_master_rowid"]);
                    objList.out_row_slno = Convert.ToInt32(dt.Rows[i]["out_row_slno"].ToString());
                    objList.out_parent_code = dt.Rows[i]["out_parent_code"].ToString();
                    objList.out_parent_description = dt.Rows[i]["out_parent_description"].ToString();
                    objList.out_master_code = dt.Rows[i]["out_master_code"].ToString();
                    objList.out_master_description = dt.Rows[i]["out_master_description"].ToString();
                    objList.out_master_ll_description = dt.Rows[i]["out_master_ll_description"].ToString();
                    objList.out_depend_code = dt.Rows[i]["out_depend_code"].ToString();
                    objList.out_depend_desc = dt.Rows[i]["out_depend_desc"].ToString();
                    objList.out_locallang_flag = dt.Rows[i]["out_locallang_flag"].ToString();
                    objList.out_status_code = dt.Rows[i]["out_status_code"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();
                    objList.out_row_timestamp = dt.Rows[i]["out_row_timestamp"].ToString();
                    objList.out_mode_flag = dt.Rows[i]["out_mode_flag"].ToString();
                    objList.kamaraj_village_id = dt.Rows[i]["village_id"].ToString();
                    objList.Kamaraj_district_id = dt.Rows[i]["district_id"].ToString();
                    objMasterList.Add(objList);
                }
                objScreen.Detail = objMasterList;
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objScreen;
        }
    }
}
