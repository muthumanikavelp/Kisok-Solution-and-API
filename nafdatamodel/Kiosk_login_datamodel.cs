using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Kiosk_login_model;

namespace nafdatamodel
{
    public class Kiosk_login_datamodel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        public kioskLoginContext GetkioskLogin_DB(string In_user_code, string In_user_pwd, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("In_user_code",In_user_code),
                new MySqlParameter("In_user_pwd",In_user_pwd)
            };
            return SqlHelper.ExtecuteProcedureReturnData<kioskLoginContext>(Mysql,
                "Kiosk_UserValidation", t => t.kioskloginList(), myParamArray);
        }
        public kioskLoginfetchApplication GetAllkioskLogin_DB(string In_user_code, string In_user_pwd, string mysqlcon)
        {
            DataTable dt = new DataTable();

            kioskLoginfetchApplication objinvoiceRoot = new kioskLoginfetchApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new kioskLoginfetchContext();


            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("kiosk_forgotpassword", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = In_user_code;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = In_user_pwd;
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                objinvoiceRoot.context.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
            }
            catch (Exception ex)
            {
                objinvoiceRoot.context.In_Reponse = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }
        public kioskresetApplication GetAllkioskresetpass_DB(string In_user_code, string mysqlcon)
        {
            DataTable dt = new DataTable();

            kioskresetApplication objinvoiceRoot = new kioskresetApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new kioskresetContext();


            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("kiosk_resetpassword", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = In_user_code;
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_email", MySqlDbType.LongText)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                objinvoiceRoot.context.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
                objinvoiceRoot.context.In_email = (string)cmd.Parameters["In_email"].Value.ToString();
            }
            catch (Exception ex)
            {
                objinvoiceRoot.context.In_Reponse = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
