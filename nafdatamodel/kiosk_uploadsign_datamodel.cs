using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Kiosk_uploadsign_model;

namespace nafdatamodel
{
   public class kiosk_uploadsign_datamodel
    {
        public List<uploadsignlist> GetuploadsignList_db(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<uploadsignlist>>(Mysql,
                "Kiosk_fetch_uploadsign", t => t.TranslateUploadsignList(), myParamArray);
        }

        public uploadsignfetch Getuploadsignfetch_db(string org, string locn, string user, string lang, int In_signature_rowid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_signature_rowid",In_signature_rowid),

            };
            return SqlHelper.ExtecuteProcedureReturnData<uploadsignfetch>(Mysql,
                "Kiosk_fetch_uploadsign_GetList", t => t.TranslateUploadsignFetch(), myParamArray);
        }

        public string[] NewUploadSignsave_db(Saveuploadsign model, string connString)
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
                new MySqlParameter("In_signature_rowid",model.In_signature_rowid),
                new MySqlParameter("In_signature_tran_id",model.In_signature_tran_id),
                new MySqlParameter("In_signature_name",model.In_signature_name),
                new MySqlParameter("In_signature_desgn",model.In_signature_desgn), 
                new MySqlParameter("In_signature_image",model.In_signature_image),
                new MySqlParameter("In_mode_flag",model.In_mode_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_uploadsign", param);
            return returnvalues;
        }

    }
}
