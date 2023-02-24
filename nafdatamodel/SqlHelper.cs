using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace nafdatamodel
{
    public static class SqlHelper
    {
        private static MySqlCommand cmd;

        public static string[] ExecuteProcedureReturnString(string connString, string procName,
           params MySqlParameter[] paramters)
        {           
            string retmsg = string.Empty;
            string retresult = string.Empty;
            using (var sqlConnection = new MySqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteScalar();
                    retmsg = command.Parameters["out_msg"].Value.ToString();
                    retresult = command.Parameters["out_result"].Value.ToString();                    
                }               
            }
            string[] returnvalues = { retmsg, retresult };
            return returnvalues;
        }
        public static TData ExtecuteProcedureReturnData<TData>(string connString, string procName,
            Func<MySqlDataReader, TData> translator,
            params MySqlParameter[] parameters)
        {
            using (var mysqlConnect = new MySqlConnection(connString))
            {
                using (var mysqlCommand = mysqlConnect.CreateCommand())
                {
                    cmd = new MySqlCommand();
                    mysqlCommand.CommandText = procName;
                    mysqlCommand.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = mysqlConnect;
                    if (parameters != null)
                    {
                        mysqlCommand.Parameters.AddRange(parameters);
                    }
                    mysqlConnect.Open();
                    
                    using (var reader = mysqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            {
                                elements = translator(reader);
                            }
                        }
                        return elements;
                    }
                }
            }
        }
        #region Get Values from Sql Data Reader
        public static string GetNullableString(MySqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }
        public static DateTime GetNullabledatetime(MySqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(DateTime) : Convert.ToDateTime(reader[colName]);
        }
        public static int GetNullableInt32(MySqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        public static bool GetBoolean(MySqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(bool) : Convert.ToBoolean(reader[colName]);
        }

        //this method is to check wheater column exists or not in data reader
        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
        {
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
