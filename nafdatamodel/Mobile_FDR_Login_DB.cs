
using MySql.Data.MySqlClient;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_FDR_Login_model;

namespace nafdatamodel
{
    public class Mobile_FDR_Login_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        //ErrorMessages ObjErrormsg = new ErrorMessages();
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_Datamodel)); //Declaring Log4Net. 
        public FDRLoginfetchApplication GetAllFdrLogin_DB(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd, string mysqlcon)
        {
            DataTable dt = new DataTable();

            FDRLoginfetchApplication objinvoiceRoot = new FDRLoginfetchApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new FDRLoginfetchContext();
            objinvoiceRoot.context.FDRLoginfetch = new FDRLoginfetch();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_UserValidation", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = In_user_code;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = In_user_pwd;
                cmd.Parameters.Add(new MySqlParameter("In_user_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_user_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_role_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_role_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                objinvoiceRoot.context.FDRLoginfetch.In_user_code1 = (string)cmd.Parameters["In_user_code1"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_user_name = (string)cmd.Parameters["In_user_name"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_role_code = (string)cmd.Parameters["In_role_code"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_role_name = (string)cmd.Parameters["In_role_name"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_location = (string)cmd.Parameters["In_location"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
                objinvoiceRoot.context.orgnId = org;
                objinvoiceRoot.context.locnId = locn;
                objinvoiceRoot.context.localeId = user;
                objinvoiceRoot.context.userId = lang;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public LoginfetchApplication GetAllLogin_DB(LoginfetchContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            LoginfetchApplication objinvoiceRoot = new LoginfetchApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new LoginfetchContext();
            objinvoiceRoot.context.List = new List<Loginfetch>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_Login", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = objinvoice.In_user_code;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = objinvoice.In_user_pwd;
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Loginfetch objList = new Loginfetch();

                    objList.In_parent_code = dt.Rows[i]["In_parent_code"].ToString();
                    objList.In_orgn_desc = dt.Rows[i]["In_orgn_desc"].ToString();
                    objList.In_orgn_code = dt.Rows[i]["In_orgn_code"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
                objinvoiceRoot.context.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
            }
            catch (Exception ex)
            {
                objinvoiceRoot.context.In_Reponse = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }

        public string[] Getforgotpassword_DB(Application objinvoice, string connString)
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
            new MySqlParameter("orgnId",objinvoice.document.context.orgnId),
            new MySqlParameter("locnId",objinvoice.document.context.locnId),
            new MySqlParameter("userId",objinvoice.document.context.userId),
            new MySqlParameter("localeId",objinvoice.document.context.localeId),
            new MySqlParameter("p_user_code",objinvoice.document.context.Header.user_code),
            new MySqlParameter("p_secquestion_code",objinvoice.document.context.Header.secquestion_code),
            new MySqlParameter("p_secquestion_answer",objinvoice.document.context.Header.secquestion_answer),
            new MySqlParameter("p_user_pwd",objinvoice.document.context.Header.user_pwd),
            new MySqlParameter("p_mode_flag",objinvoice.document.context.Header.mode_flag),
            outParam,
            outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "forgot_password", param);
            return returnvalues;

        }
    }
}
