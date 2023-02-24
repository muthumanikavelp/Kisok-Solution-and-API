using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kiosk_web.Models
{
    public class Helpdatamodel
    {
        private MySqlConnection con;
        public DataSet search(string query,string Where_condition, string mysqlconn)
        {
            DataSet temp = new DataSet();
            con = new MySqlConnection(mysqlconn);
            con.Open();
            string[] returnvalues = { };
            MySqlCommand cmd = new MySqlCommand("fetch_Search_help", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("linequery", MySqlDbType.VarChar).Value = query;
            cmd.Parameters.Add("Where_condition", MySqlDbType.VarChar).Value = Where_condition;
            cmd.CommandTimeout = 0;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(temp);
            con.Close();
            return temp;
        }
       
    }
}
