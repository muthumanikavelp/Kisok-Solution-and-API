using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class IrrigationChecker_Modelcs
    {
        #region  irrigationparameters grid value 
        public class irrigationParametersDetailItems
        {
            public List<irrigationDetailItems> ParametersDetailItems { get; set; }
        }
        public class irrigationDetailItems
        {

            public int In_irrigationparam_rowid { get; set; }
            public string In_irrigation_Parameter { get; set; }
            public string In_irrigation_uom { get; set; }
            public string In_irrigation_Parameter_desc { get; set; }
            public string In_irrigation_uom_desc { get; set; }
            public string In_irrigation_results { get; set; }
            public string out_irrigation_Id { get; set; }
            public string In_mode_flag { get; set; }
        }

        #endregion

        #region list
        public class irrigationlist
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public int In_irrigation_gid { get; set; }
            public int In_farmer_gid { get; set; }
            public string In_farmer_code { get; set; }
            public string In_farmer_name { get; set; }
            public string Collection_date { get; set; }
            public string tran_id { get; set; }
            public string irrigation_status { get; set; }
        }
        //Print List
        public class irrigationPrintList
        {

            public int irrigation_gid { get; set; }
            public string farmer_sampleid { get; set; }
            public string farmer_sampledrawn { get; set; }
            public string farmer_customerref { get; set; }
            public string farmer_labreportno { get; set; }
            public string sampledescription { get; set; }
            public string farmer_analystarted { get; set; }
            public string farmer_analycompleted { get; set; }
            public string farmer_samplereceived { get; set; }
            public string farmer_labid { get; set; }
            public string farmer_testmethod { get; set; }
            public string parameter { get; set; }
            public string unit { get; set; }
            public string result { get; set; }
            public string farmer_code { get; set; }
            public string tran_id { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string farmer_tranid { get; set; }
        }
        public class irrigationviewPrintContext
        {
            //public string orgnId { get; set; }
            //public string locnId { get; set; }
            //public string userId { get; set; }
            //public string localeId { get; set; }
            //public int soil_gid { get; set; }
            ////print
            //public string In_Tran_Id { get; set; }
            //public string In_farmer_code { get; set; }

            //  public soilPrintList Print { get; set; }
        }

        public class irrigationContext
        {
            public List<irrigationlist> List { get; set; }
        }

        #endregion

        #region token
        public class token
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class gettoken
        {
            public string token { get; set; }
        }
        #endregion

        #region listview model       
        public class irrigationviewHeader
        {
            public int out_irrigation_gid { get; set; }
            public int out_farmer_gid { get; set; }
            public string out_farmer_code { get; set; }
            public string out_farmer_name { get; set; }
            public string out_Tran_Id { get; set; }
            public string out_collection_date { get; set; }
            public string out_sample_status { get; set; }
            public string out_reject_reason { get; set; }
            public string out_sample_Id { get; set; }
            public string out_sample_drawnby { get; set; }
            public string out_customer_ref { get; set; }
            public string out_Lab_reportno { get; set; }
            public string out_Lab_Id { get; set; }
            public string out_sample_receiveon { get; set; }
            public string out_Analysis_starton { get; set; }
            public string out_Analysis_completeon { get; set; }
            public string out_test_method { get; set; }
            public string out_crop_recommendation { get; set; }
            public string out_irrigation_status { get; set; }
            public string out_irrigation_notes { get; set; }
            public string out_nablnonnabl_param { get; set; }
            public string in_mode_flag { get; set; }
        }

        public class irrigationviewDetailItems
        {

            public int In_irrigationparam_rowid { get; set; }
            public string In_irrigation_Parameter { get; set; }
            public string In_irrigation_uom { get; set; }
            public string In_irrigation_Parameter_desc { get; set; }
            public string In_irrigation_uom_desc { get; set; }
            public string In_irrigation_results { get; set; }
            public string out_irrigation_Id { get; set; }
            public string In_mode_flag { get; set; }
        }

        public class irrigationviewContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int irrigation_gid { get; set; }
            public string farmer_code { get; set; }

            //print

            public string farmer_sampleid { get; set; }
            public string farmer_sampledrawn { get; set; }
            public string farmer_customerref { get; set; }
            public string farmer_labreportno { get; set; }
            public string sampledescription { get; set; }
            public string farmer_analystarted { get; set; }
            public string farmer_analycompleted { get; set; }
            public string farmer_samplereceived { get; set; }
            public string farmer_labid { get; set; }
            public string farmer_testmethod { get; set; }
            public string parameter { get; set; }
            public string unit { get; set; }
            public string result { get; set; }
            public string tran_id { get; set; }
            public string In_Tran_Id { get; set; }
            public string In_farmer_code { get; set; }
            public irrigationviewHeader header { get; set; }
            public List<irrigationviewDetailItems> detail { get; set; }
            public List<irrigationPrintList> Print { get; set; }
        }

        public class irrigationviewApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class irrigationviewRootObject
        {

            public irrigationviewContext context { get; set; }

            public irrigationviewApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region irrigation save
        public class irrigationsave
        {
            public string userId { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public int In_irrigation_gid { get; set; }
            public int In_farmer_gid { get; set; }
            public string In_Tran_Id { get; set; }
            public string In_collection_date { get; set; }
            public string In_sample_status { get; set; }
            public string In_reject_reason { get; set; }
            public string In_sample_Id { get; set; }
            public string In_sample_drawnby { get; set; }
            public string In_customer_ref { get; set; }
            public string In_Lab_reportno { get; set; }
            public string In_Lab_Id { get; set; }
            public string In_sample_receiveon { get; set; }
            public string In_Analysis_starton { get; set; }
            public string In_Analysis_completeon { get; set; }
            public string In_test_method { get; set; }
            public string In_crop_recommendation { get; set; }
            public string In_irrigation_status { get; set; }
            public string In_mode_flag { get; set; }
            public string In_nablnonnabl_param { get; set; }
            
            public string In_crop_confirm { get; set; }
            public string detail_formatted { get; set; }
            public List<irrigationviewDetail> Detail { get; set; }
        }

        public class irrigationviewDetail
        {
            public int In_irrigationparam_rowid { get; set; }
            public string In_irrigation_Parameter { get; set; }
            public string In_irrigation_uom { get; set; }
            public string In_irrigation_results { get; set; }
            public string In_mode_flag { get; set; }
        }
        #endregion
    }
}
