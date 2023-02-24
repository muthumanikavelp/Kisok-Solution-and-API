using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.kiosk_advertisement_model;

namespace nafdatamodel
{
  public class kiosk_advertisement_datamodel
    {
        public List<advertisementlist> GetadvertisementList_db(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<advertisementlist>>(Mysql,
                "kiosk_fetch_advertisement", t => t.TranslateAsadvertisementList(), myParamArray);
        }

        public Advertisementfetch GetAdvtfetch_db(string org, string locn, string user, string lang, int In_AD_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_AD_gid",In_AD_gid),

            };
            return SqlHelper.ExtecuteProcedureReturnData<Advertisementfetch>(Mysql,
                "Kiosk_fetch_Advt_GetList", t => t.TranslateAsadvertisementListFetch(), myParamArray);
        }

        public string[] NewAdvertisementsave_db(SaveAdvertisement model, string connString)
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
                new MySqlParameter("In_AD_gid",model.In_AD_gid),
                new MySqlParameter("In_ad_tran_id",model.In_ad_tran_id),               
                new MySqlParameter("In_ad_date",model.In_ad_date),
                new MySqlParameter("In_ad_state",model.In_ad_state),
                new MySqlParameter("In_ad_flashscreen",model.In_ad_flashscreen),
                new MySqlParameter("In_display_order",model.In_display_order),              
                new MySqlParameter("In_ad_path_url",model.In_ad_path_url),
                new MySqlParameter("In_mode_flag",model.In_mode_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_advertisement", param);
            return returnvalues;
        }

    }


}
