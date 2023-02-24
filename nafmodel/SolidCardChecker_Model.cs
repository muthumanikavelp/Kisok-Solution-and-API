using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class SolidCardChecker_Model
    {
        #region listview model
        [DataContract]
        public class soilviewHeader
        {
            [DataMember(Name = "out_soil_gid")]
            public int out_soil_gid { get; set; }
            [DataMember(Name = "out_farmer_gid")]
            public int out_farmer_gid { get; set; }
            [DataMember(Name = "out_farmer_code")]
            public string out_farmer_code { get; set; }

            [DataMember(Name = "out_farmer_name")]
            public string out_farmer_name { get; set; }

            [DataMember(Name = "out_Tran_Id")]
            public string out_Tran_Id { get; set; }

            [DataMember(Name = "out_collection_date")]
            public string out_collection_date { get; set; }

            [DataMember(Name = "out_sample_status")]
            public string out_sample_status { get; set; }

            [DataMember(Name = "out_reject_reason")]
            public string out_reject_reason { get; set; }

            [DataMember(Name = "out_sample_Id")]
            public string out_sample_Id { get; set; }

            [DataMember(Name = "out_sample_drawnby")]
            public string out_sample_drawnby { get; set; }

            [DataMember(Name = "out_customer_ref")]
            public string out_customer_ref { get; set; }

            [DataMember(Name = "out_Lab_reportno")]
            public string out_Lab_reportno { get; set; }

            [DataMember(Name = "out_Lab_Id")]
            public string out_Lab_Id { get; set; }

            [DataMember(Name = "out_sample_receiveon")]
            public string out_sample_receiveon { get; set; }

            [DataMember(Name = "out_Analysis_starton")]
            public string out_Analysis_starton { get; set; }

            [DataMember(Name = "out_Analysis_completeon")]
            public string out_Analysis_completeon { get; set; }

            [DataMember(Name = "out_test_method")]
            public string out_test_method { get; set; }

            [DataMember(Name = "out_crop_recommendation")]
            public string out_crop_recommendation { get; set; }

            [DataMember(Name = "out_soil_status")]
            public string out_soil_status { get; set; }

            [DataMember(Name = "out_soil_notes")]
            public string out_soil_notes { get; set; }

            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
            [DataMember(Name = "out_nablnonnabl_param")]
            public string out_nablnonnabl_param { get; set; }
        }
        [DataContract]
        public class soilviewDetailItems
        {
            [DataMember(Name = "In_soilparam_rowid")]
            public int In_soilparam_rowid { get; set; }

            [DataMember(Name = "out_soil_Id")]
            public string out_soil_Id { get; set; }

            [DataMember(Name = "In_soil_Parameter")]
            public string In_soil_Parameter { get; set; }

            [DataMember(Name = "In_soil_Parameter_desc")]
            public string In_soil_Parameter_desc { get; set; }

            [DataMember(Name = "In_soil_uom")]
            public string In_soil_uom { get; set; }

            [DataMember(Name = "In_soil_uom_desc")]
            public string In_soil_uom_desc { get; set; }

            [DataMember(Name = "In_soil_results")]
            public string In_soil_results { get; set; }

            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
        }
        [DataContract]
        public class soilviewContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            [DataMember(Name = "farmer_code")]
            public string farmer_code { get; set; }
            public int soil_gid { get; set; }
            //print
            public string In_Tran_Id { get; set; }
            public string In_farmer_code { get; set; }
            public soilviewHeader Header { get; set; }

            public List<soilviewDetailItems> Detail { get; set; }
            public List<soilPrintList> Print { get; set; }
        }



        //Print list context
        public class soilPrintContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public int soil_gid { get; set; }

            public string In_Tran_Id { get; set; }
            public string In_farmer_code { get; set; }

            public List<soilPrintList> Print { get; set; }
        }

        //Print List
        public class soilPrintList
        {
            [DataMember(Name = "soil_gid")]
            public int soil_gid { get; set; }
            [DataMember(Name = "farmer_sampleid")]
            public string farmer_sampleid { get; set; }
            [DataMember(Name = "farmer_tranid")]
            public string farmer_tranid { get; set; }

            [DataMember(Name = "farmer_sampledrawn")]
            public string farmer_sampledrawn { get; set; }

            [DataMember(Name = "farmer_customerref")]
            public string farmer_customerref { get; set; }

            [DataMember(Name = "farmer_labreportno")]
            public string farmer_labreportno { get; set; }


            [DataMember(Name = "sampledescription")]
            public string sampledescription { get; set; }

            [DataMember(Name = "farmer_analystarted")]
            public string farmer_analystarted { get; set; }

            [DataMember(Name = "farmer_analycompleted")]
            public string farmer_analycompleted { get; set; }

            [DataMember(Name = "farmer_samplereceived")]
            public string farmer_samplereceived { get; set; }

            [DataMember(Name = "farmer_labid")]
            public string farmer_labid { get; set; }

            [DataMember(Name = "farmer_testmethod")]
            public string farmer_testmethod { get; set; }

            [DataMember(Name = "parameter")]
            public string parameter { get; set; }

            [DataMember(Name = "unit")]
            public string unit { get; set; }

            [DataMember(Name = "result")]
            public string result { get; set; }

            [DataMember(Name = "farmer_code")]
            public string farmer_code { get; set; }



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
            [DataMember(Name = "userId")]
            public string userId { get; set; }
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }
            [DataMember(Name = "locnId")]
            public string locnId { get; set; }
            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_soil_gid")]
            public int In_soil_gid { get; set; }
            [DataMember(Name = "In_farmer_gid")]
            public int In_farmer_gid { get; set; }
            [DataMember(Name = "In_Tran_Id")]
            public string In_Tran_Id { get; set; }
            [DataMember(Name = "In_collection_date")]
            public string In_collection_date { get; set; }
            [DataMember(Name = "In_sample_status")]
            public string In_sample_status { get; set; }
            [DataMember(Name = "In_reject_reason")]
            public string In_reject_reason { get; set; }
            [DataMember(Name = "In_sample_Id")]
            public string In_sample_Id { get; set; }
            [DataMember(Name = "In_sample_drawnby")]
            public string In_sample_drawnby { get; set; }
            [DataMember(Name = "In_customer_ref")]
            public string In_customer_ref { get; set; }
            [DataMember(Name = "In_Lab_reportno")]
            public string In_Lab_reportno { get; set; }
            [DataMember(Name = "In_Lab_Id")]
            public string In_Lab_Id { get; set; }
            [DataMember(Name = "In_sample_receiveon")]
            public string In_sample_receiveon { get; set; }
            [DataMember(Name = "In_Analysis_starton")]
            public string In_Analysis_starton { get; set; }
            [DataMember(Name = "In_Analysis_completeon")]
            public string In_Analysis_completeon { get; set; }
            [DataMember(Name = "In_test_method")]
            public string In_test_method { get; set; }
            [DataMember(Name = "In_crop_recommendation")]
            public string In_crop_recommendation { get; set; }
            [DataMember(Name = "In_soil_status")]
            public string In_soil_status { get; set; }
            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
            public string In_crop_confirm { get; set; }
            public string In_nablnonnabl_param { get; set; }
            public string detail_formatted { get; set; }
            public List<soilviewDetail> Detail { get; set; }
        }

        public class soilviewDetail
        {
            [DataMember(Name = "In_soilparam_rowid")]
            public int In_soilparam_rowid { get; set; }

            [DataMember(Name = "In_soil_parameter")]
            public string In_soil_Parameter { get; set; }

            [DataMember(Name = "In_soil_uom")]
            public string In_soil_uom { get; set; }

            [DataMember(Name = "In_soil_results")]
            public string In_soil_results { get; set; }

            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }

        }
        #endregion
        public class Retrnmesg
        {
            [DataMember(Name = "out_msg")]
            public string out_msg { get; set; }

            [DataMember(Name = "out_result")]
            public string out_result { get; set; }

        }
        #region list
        public class soilcardlist
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }
            [DataMember(Name = "locnId")]
            public string locnId { get; set; }
            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_soil_gid")]
            public int In_soil_gid { get; set; }
            [DataMember(Name = "In_farmer_gid")]
            public int In_farmer_gid { get; set; }
            [DataMember(Name = "In_farmer_code")]
            public string In_farmer_code { get; set; }
            [DataMember(Name = "In_farmer_name")]
            public string In_farmer_name { get; set; }
            [DataMember(Name = "Collection_date")]
            public string Collection_date { get; set; }
            [DataMember(Name = "tran_id")]
            public string tran_id { get; set; }
            [DataMember(Name = "soil_status")]
            public string soil_status { get; set; }
            [DataMember(Name = "farmer_soil_rejreason")]
            public string farmer_soil_rejreason { get; set; }


        }
        public class soilListContext
        {
            public List<soilcardlist> List { get; set; }
        }
        #endregion

        public class soilprint
        {
            public string path { get; set; }
        }


        #region
        #region kioskloginfetch        
        public class kioskLoginfetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string In_user_code { get; set; }
            public string In_user_pwd { get; set; }
            public string In_Reponse { get; set; }
            public string instance { get; set; }
        }
        public class kioskLoginfetchApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class kioskLoginfetchApplication
        {
            public kioskLoginfetchContext context { get; set; }
            public kioskLoginfetchApplicationException ApplicationException { get; set; }

        }

        #endregion

        #region KioskAppAutomatically pdf created Email sent    

        public class kioskSolidcardPdfAndEmail
        {
            public string In_Reponse { get; set; }
        }



        #endregion


    }
}
#endregion