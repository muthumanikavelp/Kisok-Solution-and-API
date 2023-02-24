using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class LoginDatamodel
    {
        private MySqlConnection con;
        public DataSet login(string userId, string pwd, string mysqlconn)
        {
            DataSet temp = new DataSet();
            con = new MySqlConnection(mysqlconn);
            con.Open();
            string[] returnvalues = { };
            MySqlCommand cmd = new MySqlCommand("User_validation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_user_code", MySqlDbType.VarChar).Value = userId;
            cmd.Parameters.Add("p_user_pwd", MySqlDbType.VarChar).Value = pwd;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(temp);
            con.Close();
            return temp;
        }
        public DataSet getseqval(string userId, string mysqlconn)
        {
            DataSet temp = new DataSet();
            con = new MySqlConnection(mysqlconn);
            con.Open();
            string[] returnvalues = { };
            MySqlCommand cmd = new MySqlCommand("fetch_getseqval", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_user_code", MySqlDbType.VarChar).Value = userId;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(temp);
            con.Close();
            return temp;
        }
        public DataSet fetch_menu(string userId, string mysqlconn)
        {
            DataSet temp = new DataSet();
            con = new MySqlConnection(mysqlconn);
            con.Open();
            string[] returnvalues = { };
            MySqlCommand cmd = new MySqlCommand("fetch_menu_submenu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_SQLType", MySqlDbType.VarChar).Value = "Menu";
            cmd.Parameters.Add("p_OrgnID", MySqlDbType.VarChar).Value = "Kiosk";
            cmd.Parameters.Add("p_LocnId", MySqlDbType.VarChar).Value = "CHENNAI";
            cmd.Parameters.Add("p_Module", MySqlDbType.VarChar).Value = 0;
            cmd.Parameters.Add("p_URL", MySqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("p_user_id", MySqlDbType.VarChar).Value = userId;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(temp);
            con.Close();
            return temp;
        }
        public DataSet fetch_submenu(string userId, string mysqlconn)
        {
            DataSet temp = new DataSet();
            con = new MySqlConnection(mysqlconn);
            con.Open();
            string[] returnvalues = { };
            MySqlCommand cmd = new MySqlCommand("fetch_menu_submenu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_SQLType", MySqlDbType.VarChar).Value = "SUBMENU";
            cmd.Parameters.Add("p_OrgnID", MySqlDbType.VarChar).Value = "FFI";
            cmd.Parameters.Add("p_LocnId", MySqlDbType.VarChar).Value = "CHENNAI";
            cmd.Parameters.Add("p_Module", MySqlDbType.VarChar).Value = 0;
            cmd.Parameters.Add("p_URL", MySqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("p_user_id", MySqlDbType.VarChar).Value = userId;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(temp);
            con.Close();
            return temp;
        }
        public DataSet logout(string userId, string mysqlconn)
        {
            DataSet temp = new DataSet();
            con = new MySqlConnection(mysqlconn);
            con.Open();
            string[] returnvalues = { };
            MySqlCommand cmd = new MySqlCommand("ICDMOB_UserValidation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = "logout";
            cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = "FFI";
            cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = "CHENNAI";
            cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = "en_US";
            cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = userId;
            cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = "0";
            cmd.Parameters.Add("In_user_code1", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("In_user_name", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("In_role_code", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("In_role_name", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("In_location", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("In_Reponse", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(temp);
            con.Close();
            return temp;
        }
    }
}
