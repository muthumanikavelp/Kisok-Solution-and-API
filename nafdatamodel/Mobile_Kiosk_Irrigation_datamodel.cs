using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_Kiosk_Irrigation_model;

namespace nafdatamodel
{
   public class Mobile_Kiosk_Irrigation_datamodel
    {
        public string[] Newmobirrigationsave_db(mobsaveirrigation model, string connString)
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
                new MySqlParameter("userId",model.userId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("irrigation_gid",model.irrigation_gid),
                new MySqlParameter("farmer_gid",model.farmer_gid),
                new MySqlParameter("Tran_Id",model.Tran_Id),
                new MySqlParameter("collection_date",model.collection_date),
                new MySqlParameter("sample_status",model.sample_status),
                new MySqlParameter("sample_drawnby",model.sample_drawnby),
                new MySqlParameter("customer_ref",model.customer_ref),
                new MySqlParameter("mode_flag",model.mode_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Mob_kiosk_Irrigation", param);
            return returnvalues;
        }
    }
}
