using MySql.Data.MySqlClient;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_Kiosk_Fileurlpath_Model;
namespace nafdatamodel
{
    public class Mobile_Kiosk_Fileurlpath_DataModel
    {

        public  DataConnection MysqlCon;


        public DataSet kiosk_Fileurlpath(string Constring)
        {
            Mobile_Kiosk_Fileurlpath obj_Mobile_Kiosk_Fileurlpath_Model = new Mobile_Kiosk_Fileurlpath();
            DataSet Dset = new DataSet();
            MysqlCon = new DataConnection(Constring);
            try
            {
                MysqlCon.con.Open();
                MySqlCommand cmd = new MySqlCommand("Mobile_Fileurlpath", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Da = new MySqlDataAdapter(cmd);
                Da.Fill(Dset);
                MysqlCon.con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MysqlCon.con.Close();

            }
            return Dset;
        }
    }
}
