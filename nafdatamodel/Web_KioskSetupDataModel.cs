using System;
using System.Collections.Generic;
using System.Text;
using nafmodel;
using MySql.Data.MySqlClient;
using System.Data;
using static nafmodel.Web_KioskSetupModel;
using nafdatamodel;
 



namespace nafdatamodel
{
   public class Web_KioskSetupDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Web_ErrorMessageModel ObjErrormsg = new Web_ErrorMessageModel();


    
 
    

         
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //next increment id KioskSave ObjModel
       

        public int NextIncrementid(KioskSave ObjModel, string Mysql, string kiosk_code)  //Get Nextgid
        {
            int Result;
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(Mysql);
                UserContext objContext = new UserContext();
                 
                MySqlCommand cmd = new MySqlCommand("SP_Get_Next_Gid", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjModel.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjModel.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjModel.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjModel.localeId;
                cmd.Parameters.Add("in_tablename", MySqlDbType.VarChar).Value = kiosk_code;

                

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                Result = Convert.ToInt32(dt.Rows[0]["Auto_increment"].ToString());
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

         



        //Get Kiosk List
        public KioskList GetKioskList(string org, string locn, string user, string lang, string Mysql )
        {
            KioskList ObjFetchAll = new KioskList();
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
                MySqlCommand cmd = new MySqlCommand("Sp_Get_KioskList", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
               

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                 
                MysqlCon.con.Close();

                List<KioskFetch> objRoleLst = new List<KioskFetch>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    KioskFetch objList = new KioskFetch();
                    objList.Kiosk_id =  Convert.ToInt16(dt.Rows[i]["kiosk_gid"].ToString().ToString());
                     objList.KioskCode =  (dt.Rows[i]["kiosk_code"].ToString());


                    objList.kiosk_Name = dt.Rows[i]["kiosk_Name"].ToString();
                    objList.Bilingual = dt.Rows[i]["Bilingual"].ToString();
                    
                    
                    objList.Village = dt.Rows[i]["Village"].ToString();
                    objList.Taluk = dt.Rows[i]["Taluk"].ToString();
                    objList.District = dt.Rows[i]["District"].ToString();
                    objList.State = dt.Rows[i]["State"].ToString();
                   

                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.list = objRoleLst;
            }
            catch (Exception ex)
            {
                 
            }
            return ObjFetchAll;
        }


        //GEt Kiosk Onchange

        public KioskList GetKioskonchange(string org, string locn, string user, string lang, string Mysql ,string Depend_Code )
        {
            KioskList ObjFetchAll = new KioskList();
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
                objContext.dependcode = Depend_Code;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Sp_Get_KioskOnchange", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
              cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_Master_code", MySqlDbType.VarChar).Value = Depend_Code;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //   LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<KioskFetch> objRoleLst = new List<KioskFetch>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    KioskFetch objList = new KioskFetch();
                   // objList.Kiosk_id = Convert.ToInt16(dt.Rows[i]["kiosk_gid"].ToString().ToString());
                    objList.tk_code = dt.Rows[i]["tk_code"].ToString();
                    objList.tk_name = dt.Rows[i]["tk_name"].ToString();
                    objList.dt_code = dt.Rows[i]["dt_code"].ToString();
                    objList.dt_name = dt.Rows[i]["dt_name"].ToString();

                    objList.st_code = dt.Rows[i]["st_code"].ToString();
                    objList.st_name = dt.Rows[i]["st_name"].ToString();

                    objList.village_code = dt.Rows[i]["village_code"].ToString();
                    objList.vill_name = dt.Rows[i]["vill_name"].ToString();
                    objList.vill_nameII = dt.Rows[i]["vill_nameII"].ToString();
                    objList.tk_nameII = dt.Rows[i]["tk_nameII"].ToString();
                    objList.dt_nameII = dt.Rows[i]["dt_nameII"].ToString();
                    objList.st_nameII = dt.Rows[i]["st_nameII"].ToString();
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


        public SaveKioskheader GetKioskheader(string org, string locn, string user, string lang, int kiosk_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_KioskId",kiosk_gid)
            };
            return SqlHelper.ExtecuteProcedureReturnData<SaveKioskheader>(Mysql,
                "Sp_Fetch_Kioskheader", t => t.TranslateAsKioskList(), myParamArray);
        }
        public List<SaveRMDetail> GetKioskdetails(string org, string locn, string user, string lang, int kiosk_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_KioskId",kiosk_gid)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<SaveRMDetail>>(Mysql,
                "SP_Fetch_KioskDetails", r => r.TranslateAskioskdet(), myParamArray);
        }













        ////Save Kiosk 
        public string[] SaveKioskSetup(KioskSave model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam2 = new MySqlParameter("out_nxtid", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("In_userId",model.userId),
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_KioskId",model.header.In_Kiosk_gid),
                new MySqlParameter("In_KioskCode",model.header.in_Kiosk_code),
                new MySqlParameter("In_KioskName",model.header.in_Kiosk_name),
                new MySqlParameter("In_KioskStatus",model.header.in_status_name),
                new MySqlParameter("In_KioskFponame",model.header.in_fpo_name),
                new MySqlParameter("In_KioskVillage",model.header.in_Village),
                new MySqlParameter("In_kioskAddress",model.header.in_Address),
                new MySqlParameter("In_KioskPincode",model.header.in_Pincode),
                new MySqlParameter("In_KioskLanguage",model.header.in_Bilingual_code),
                new MySqlParameter("In_KioskTalk",model.header.in_Taluk),
                new MySqlParameter("In_kioskDist",model.header.in_District),
                new MySqlParameter("In_kioskState",model.header.in_State),
                new MySqlParameter("In_notes",model.notes),

 





                new MySqlParameter("In_mode_flag", model.header.In_mode_flag),
               new MySqlParameter("detail_formatted",model.detail_formatted),
                outParam,
                outParam1,
                 outParam2
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_kiosksetup", param);
            return returnvalues;
        }

        //kiosk contact Details

        public string[] SaveKioskSetupDetails(SavesingleContext model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("In_userId",model.userId),
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_kiosk_gid",model.Kiosk_gid),
                  new MySqlParameter("In_contact_gid",model.Kiosk_Contactgid),
                new MySqlParameter("In_contact_name",model.in_Name),
                new MySqlParameter("In_contact_designation",model.in_Designation),
                new MySqlParameter("In_contact_email",model.in_eMail),
                 new MySqlParameter("In_contact_mobile",model.in_Mobile),
                  new MySqlParameter("In_contact_landline",model.in_Landline),
                    new MySqlParameter("In_mode_flag", model.In_mode_flag),
             //  new MySqlParameter("detail_formatted",model.In_mode_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "SP_DML_KioskContactDetails", param);
            return returnvalues;
        }


        //veiw kiosk detils
        
        public List<SaveRMDetail> viewkioskdetails(string org, string locn, string user, string lang, int contact_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_contact_gid",contact_gid)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<SaveRMDetail>>(Mysql,
                "SP_KioskDetailfetch", r => r.TranslateAskioskdet(), myParamArray);
        }

        //View details


        public List<SaveRMDetail>  kioskdetails(string org, string locn, string user, string lang, int kiosk_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_KioskId",kiosk_gid)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<SaveRMDetail>>(Mysql,
                "SP_Fetch_KioskDetails", r => r.TranslateAskioskdet(), myParamArray);
        }

    }
}
