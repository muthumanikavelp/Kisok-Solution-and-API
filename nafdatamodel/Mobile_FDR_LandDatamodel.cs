using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_FDR_LandModel;

namespace nafdatamodel
{
   public class Mobile_FDR_LandDatamodel
    {
        public string[] NewFarmerLandsave_db(SaveFLand model, string connString)
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
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_land_gid",model.In_land_gid),
                new MySqlParameter("In_farmer_gid",model.In_farmer_gid),
                new MySqlParameter("In_land_type",model.In_land_type),
                new MySqlParameter("In_land_ownership",model.In_land_ownership),
                new MySqlParameter("In_land_soiltype",model.In_land_soiltype),
                new MySqlParameter("In_land_irrsou",model.In_land_irrsou),
                new MySqlParameter("In_land_noofacres",model.In_land_noofacres),
                new MySqlParameter("In_land_longtitude",model.In_land_longtitude),
                new MySqlParameter("In_land_latitude",model.In_land_latitude),
                new MySqlParameter("In_land_surveyno",model.In_land_surveyno),
                new MySqlParameter("In_mode_flag",model.In_mode_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "FDRMOB_insupd_farmer_Landdetails", param);
            return returnvalues;
        }

        public List<FarmerLandfecth> GetFarmerLand_DB(string org, string locn, string user, string lang, int In_farmer_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_farmer_gid",In_farmer_gid),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<FarmerLandfecth>>(Mysql,
                "FDRMOB_Fetch_FarmerLandDetails", t => t.TranslateAsFarmerLandList(), myParamArray);
        }
    }
}
