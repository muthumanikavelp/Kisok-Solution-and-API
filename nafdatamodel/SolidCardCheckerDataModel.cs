using MySql.Data.MySqlClient;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.SolidCardChecker_Model;

namespace nafdatamodel
{
   public class SolidCardCheckerDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;

        Web_ErrorMessageModel ObjErrormsg = new Web_ErrorMessageModel();

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        public List<soilcardlist> GetsoilList_dbChecker(string org, string locn, string lang, int In_farmer_gid, string status, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("status",status),
                new MySqlParameter("In_farmer_id",In_farmer_gid)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<soilcardlist>>(Mysql,
                "kiosk_fetch_soilCheckerList", t => t.TranssoilListChecker(), myParamArray);
        }
        public soilviewHeader GetsoilviewListChecker(string org, string locn, string user, string lang, int soil_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("in_soil_gid",soil_gid)
            };
            return SqlHelper.ExtecuteProcedureReturnData<soilviewHeader>(Mysql,
                "kiosk_fetch_SoilCard_List", t => t.TranslateAssoilListChecker(), myParamArray);
        }
        public List<soilviewDetailItems> GetsoilviewdetChecker(string org, string locn, string user, string lang, string Tran_Id, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("in_Tran_Id",Tran_Id)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<soilviewDetailItems>>(Mysql,
                "kiosk_fetch_SoilCard_detail", r => r.TranslateAssoildetChecker(), myParamArray);
        }
        public string[] Newsoilcardsave_dbChecker(soilcardsave model, string connString)
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
            //if (model.In_reject_reason  == "")
            //{
            //    model.In_reject_reason= "NULL";
            //}
            //else
            //{
            //    model.In_reject_reason = model.In_reject_reason;

            //}
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userId),
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_soil_gid",model.In_soil_gid),
                new MySqlParameter("In_farmer_gid",model.In_farmer_gid),
                new MySqlParameter("In_Tran_Id",model.In_Tran_Id),
                new MySqlParameter("In_collection_date",model.In_collection_date),
                new MySqlParameter("In_sample_status",model.In_sample_status),

               new MySqlParameter("In_reject_reason", model.In_reject_reason),
            new MySqlParameter("In_sample_Id",model.In_sample_Id),
                new MySqlParameter("In_sample_drawnby",model.In_sample_drawnby),
                new MySqlParameter("In_customer_ref",model.In_customer_ref),
                new MySqlParameter("In_Lab_reportno",model.In_Lab_reportno),
                new MySqlParameter("In_Lab_Id",model.In_Lab_Id),
                new MySqlParameter("In_sample_receiveon",model.In_sample_receiveon),
                new MySqlParameter("In_Analysis_starton",model.In_Analysis_starton),
                new MySqlParameter("In_Analysis_completeon",model.In_Analysis_completeon),
                new MySqlParameter("In_test_method",model.In_test_method),
                new MySqlParameter("In_crop_recommendation",model.In_crop_recommendation),
                new MySqlParameter("In_soil_status",model.In_soil_status),
                new MySqlParameter("In_mode_flag",model.In_mode_flag),
                 new MySqlParameter("In_crop_confirm",model.In_crop_confirm),
                  new MySqlParameter("In_nablnonnabl_param",model.In_nablnonnabl_param),
                new MySqlParameter("detail_formatted",model.detail_formatted),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_Soil_Card", param);
            return returnvalues;
        }

        //Print List

        public List<soilPrintList> soilviewPrintListChecker(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string Mysql)
        {
            MySqlParameter[] myParamArray = {
               new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                 new MySqlParameter("in_soilid",soil_gid),
                  new MySqlParameter("in_farmer_tranid",In_Tran_Id),
                   new MySqlParameter("in_farmer_code",In_farmer_code)
            };


            return SqlHelper.ExtecuteProcedureReturnData<List<soilPrintList>>(Mysql,
               "kiosk_fetch_Soilcardprintlist", r => r.TranslateAssoildetprintChecker(), myParamArray);
        }

        //Api Print list
        public List<soilPrintList> apisoilviewPrintListChecker(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string Mysql)
        {
            MySqlParameter[] myParamArray = {
               new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                 new MySqlParameter("in_soilid",soil_gid),
                  new MySqlParameter("in_farmer_tranid",In_Tran_Id),
                   new MySqlParameter("in_farmer_code",In_farmer_code)
            };


            return SqlHelper.ExtecuteProcedureReturnData<List<soilPrintList>>(Mysql,
               "kiosk_fetch_Soilcardprintlist", r => r.TranslateAssoildetprintChecker(), myParamArray);


        }
    }
}
