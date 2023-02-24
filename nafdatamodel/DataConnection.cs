using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace nafdatamodel
{
    public  class DataConnection
    {
        public  MySqlConnection con;
        private  MySqlCommand cmd;

        
        public  DataConnection(string dbsource)
        {
            con = new MySqlConnection(dbsource);
            cmd = new MySqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
        }
        public  DataSet RunDataSetProc(string command, Dictionary<string, Object> values = null)
        {
            DataSet temp = new DataSet();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                foreach (string key in values.Keys)
                {
                    cmd.Parameters.AddWithValue(key, values[key]);
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp; 
            }
            catch (Exception ex)
            {
                return temp;

            }
        }

        
       
       
    }
}
