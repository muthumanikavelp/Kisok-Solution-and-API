using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class SolidCardChecker_Model
    {
        #region list
        public class soilcardlist
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public int In_soil_gid { get; set; }
            public int In_farmer_gid { get; set; }
            public string In_farmer_code { get; set; }
            public string In_farmer_name { get; set; }
            public string Collection_date { get; set; }
            public string tran_id { get; set; }
            public string soil_status { get; set; }
        }



        //Print List
        public class soilPrintList
        {

            public int soil_gid { get; set; }
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
        //Print list context
        public class soilviewPrintContext
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

        public class soilListContext
        {
            public List<soilcardlist> List { get; set; }
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
        public class soilviewHeader
        {
            public int out_soil_gid { get; set; }
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
            public string out_soil_status { get; set; }
            public string out_soil_notes { get; set; }
            public string in_mode_flag { get; set; }
            public string out_nablnonnabl_param { get; set; }
        }

        public class soilviewDetailItems
        {

            public int In_soilparam_rowid { get; set; }
            public string In_soil_Parameter { get; set; }
            public string In_soil_uom { get; set; }
            public string In_soil_Parameter_desc { get; set; }
            public string In_soil_uom_desc { get; set; }
            public string In_soil_results { get; set; }
            public string out_soil_Id { get; set; }
            public string In_mode_flag { get; set; }
        }

        public class soilviewContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int soil_gid { get; set; }
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
            public soilviewHeader header { get; set; }
            public List<soilviewDetailItems> detail { get; set; }
            public List<soilPrintList> Print { get; set; }
        }

        public class soilviewApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class soilviewRootObject
        {

            public soilviewContext context { get; set; }

            public soilviewApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region soil save
        public class soilcardsave
        {
            public string userId { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public int In_soil_gid { get; set; }
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
            public string In_soil_status { get; set; }
            public string In_mode_flag { get; set; }
            public string In_crop_confirm { get; set; }
            public string In_nablnonnabl_param { get; set; }
            public string detail_formatted { get; set; }
            public List<soilviewDetail> Detail { get; set; }
        }

        public class soilviewDetail
        {
            public int In_soilparam_rowid { get; set; }
            public string In_soil_Parameter { get; set; }
            public string In_soil_uom { get; set; }
            public string In_soil_results { get; set; }
            public string In_mode_flag { get; set; }
        }
        #endregion
    }
}
