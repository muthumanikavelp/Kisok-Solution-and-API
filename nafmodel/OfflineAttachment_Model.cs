using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
    public class OfflineAttachment_Model
    {
        public class KioskApplication
        {
            public KioskContext context { get; set; }
            

        }
 
        public class KioskContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }

            public string instance { get; set; }

            public IList<KioskfarmerDetails> farmer { get; set; }
            public IList<KioskfaqDetails> faq { get; set; }
            public IList<KioskLandDetails> land { get; set; }
            public IList<KiosksetupheaderDetails> kioskheader { get; set; }
            public IList<KioskcontactDetails> contactdetail { get; set; }
            public IList<KioskAttachmentDetails> attachment { get; set; }
            public IList<KioskadvertismentDetails> advertisment { get; set; }


            public IList<KioskIrrigationHeader> Irrigationheader { get; set; }
            public IList<KiosksIrrigationParameters> Irrigationparameters { get; set; }
            public IList<KioskschemesrDetails> schemes { get; set; }
            public IList<KiosksoilDetails> soil { get; set; }
            public IList<KiosksoilparamDetails> soilparam { get; set; }
            public IList<KioskvideoDetails> video { get; set; }
            public IList<KioskweatherDetails> weather { get; set; }
            public IList<KioskweatherforecastDetails> weatherdetails { get; set; }
            public IList<KioskmasterheadereDetails> masterheader { get; set; }
            public IList<KioskmasterDetails> masterheaderdetails { get; set; }
            
            public IList<KiosklocalizationDetails> localize { get; set; }
            public IList<KioskUserDetails> user { get; set; }

            public IList<synmaster> synmas { get; set; }
           // public IList<synfarmermaster> synfarmer { get; set; }
        }
        public class KioskfarmerDetails
        {
            ////Error
            //public int Error_Id { get; set; }
            //public string Error_Menu { get; set; }
            //public string Error_Screen { get; set; }
            //public string Error_Msg { get; set; }

            ////document
            //public int docnum_rowid { get; set; }
            //public string orgn_code { get; set; }
            //public string activity_code { get; set; }
            //public string docnum_finyear_code { get; set; }
            //public string docnum_preview { get; set; }
            //public string status_code { get; set; }
            //public string created_datetime { get; set; }
            //public string created_by { get; set; }
            //public string modified_datetime { get; set; }
            //public string modified_by { get; set; }
            //public string row_timestamp { get; set; }

            ////document format
            //public int docnumformat_rowid { get; set; }
            ////  public int docnum_rowid { get; set; }
            //public int row_slno { get; set; }
            //public string format_type { get; set; }
            //public string format_desc { get; set; }
            //public string format_value { get; set; }
            //public string format_length { get; set; }
            //// public string status_code { get; set; }
            ////public string created_datetime { get; set; }
            ////public string created_by { get; set; }
            ////public string modified_datetime { get; set; }
            ////public string modified_by { get; set; }
            ////public string row_timestamp { get; set; }

            //farmer
            public int farmer_rowid { get; set; }
            public string farmer_code { get; set; }
            public int version_no { get; set; }
            public string farmer_name { get; set; }
            public string farmer_dob { get; set; }
            public string farmer_addr1 { get; set; }
            public string farmer_addr2 { get; set; }
            public string farmer_ll_name { get; set; }
            public string sur_ll_name { get; set; }
            public string fhw_ll_name { get; set; }
            public string farmer_ll_addr1 { get; set; }
            public string farmer_ll_addr2 { get; set; }
            public string farmer_country { get; set; }
            public string farmer_state { get; set; }
            public string farmer_dist { get; set; }
            public string farmer_taluk { get; set; }
            public string farmer_panchayat { get; set; }
            public string farmer_village { get; set; }
            public string farmer_pincode { get; set; }
            public string marital_status { get; set; }
            public string gender_flag { get; set; }
            public string reg_mobile_no { get; set; }
            public string photo_farmer { get; set; }
            public string reg_note { get; set; }
            public string sur_name { get; set; }
            public string fhw_name { get; set; }
             public string status_code { get; set; }
            //public string created_datetime { get; set; }
            //public string created_by { get; set; }
            //public string modified_datetime { get; set; }
            //public string modified_by { get; set; }
            //public string row_timestamp { get; set; }
        }

        public class KioskLandDetails
        {

            //Farmer land details
            public int land_gid { get; set; }
            public int farmer_gid { get; set; }
            public string land_type { get; set; }
            public string land_ownership { get; set; }
            public string land_soiltype { get; set; }
            public string land_irrsou { get; set; }
            public string land_noofacres { get; set; }
            public string land_longtitude { get; set; }
            public string land_latitude { get; set; }
            public string land_insertedby { get; set; }
            public string land_inserteddate { get; set; }
            public string land_modifyby { get; set; }
            public string land_modifydate { get; set; }
            public string land_isremoved { get; set; }
        }
        public class KioskfinyearDetails
        {
            //fin year
            public int finyear_rowid { get; set; }
            public string finyear_code { get; set; }
            public string finyear_desc { get; set; }
            public string finyear_start_date { get; set; }
            public string finyear_end_date { get; set; }
            public string finyear_narration { get; set; }
            //public string status_code { get; set; }
            //public string created_datetime { get; set; }
            //public string created_by { get; set; }
            //public string modified_datetime { get; set; }
            //public string modified_by { get; set; }
            //public string row_timestamp { get; set; }
        }
        public class KiosklocalizationDetails
        {
            //localization
            public int localizationtranslate_rowid { get; set; }
            public string localizationtranslate_activity_code { get; set; }
            public string control_code { get; set; }
            public string data_field { get; set; }
            public string lang_code { get; set; }
            public string control_value { get; set; }
            public string loc_insertedby { get; set; }
            public string loc_inserteddate { get; set; }
            public string loc_modifyby { get; set; }
            public string loc_modifydate { get; set; }
            public string loc_isremoved { get; set; }
        }
        public class KioskmasterheadereDetails
        {
            //master
            public int master_rowid { get; set; }
            public string master_code { get; set; }
            public string parent_code { get; set; }
            public string depend_code { get; set; }
            public string locallang_flag { get; set; }
            public int master_row_slno { get; set; }
           public string status_code { get; set; }
            //public string created_datetime { get; set; }
            //public string created_by { get; set; }
            //public string modified_datetime { get; set; }
            //public string modified_by { get; set; }
            //public string row_timestamp { get; set; }

        }
        public class KioskmasterDetails
        {
            //master translate

            public int mastertranslate_rowid { get; set; }
            public string mastertranslate_master_code { get; set; }
            public string mastertranslate_parent_code { get; set; }
            public string mastertranslate_lang_code { get; set; }
            public string master_name { get; set; }
        }

        ////menu
        //public int menu_rowid { get; set; }
        //public string OrgnId { get; set; }
        //public string LocnId { get; set; }
        //public string Menu_Id { get; set; }
        //public string Menu_Name { get; set; }
        //public string UrlIcon { get; set; }
        //public string Doc_Type { get; set; }
        //public string Doc_Ref { get; set; }
        //public string Controller { get; set; }
        //public string Action { get; set; }
        //public string submenu_code { get; set; }



        ////module
        //public int module_rowid { get; set; }
        //public string orgnId { get; set; }
        //// public string 

        ////farmer back up
        //public string farmerbak_farmer_code { get; set; }
        //public string farmerbak_farmer_name { get; set; }
        //public string farmerbak_sur_name { get; set; }
        //public string farmerbak_fhw_name { get; set; }
        //public string farmerbak_farmer_dob { get; set; }

        public class KiosksetupheaderDetails
        {
            //Kiosk set up
            public int kiosk_gid { get; set; }
            public string kiosk_code { get; set; }
            public string kiosk_name { get; set; }
            public string kiosk_billingual { get; set; }
            public string kiosk_village { get; set; }
            public string kiosk_taluk { get; set; }
            public string kiosk_district { get; set; }
            public string kiosk_state { get; set; }
            public string kiosk_pincode { get; set; }
            public string kiosk_fpo { get; set; }
            public string kisok_address { get; set; }
            public string kiosk_notes { get; set; }
            public string kiosk_status { get; set; }
        }
        public class KioskcontactDetails
        {

            //kiosk contact
            public int contact_gid { get; set; }
            public int contact_kiosk_gid { get; set; }
            public string contact_name { get; set; }
            public string contact_designation { get; set; }
            public string contact_email { get; set; }
            public string contact_mobile { get; set; }
            public string contact_landline { get; set; }

        }
        public class KioskAttachmentDetails
        {
            //attachment
            public int attach_gid { get; set; }
            public int attach_ref_gid { get; set; }
            public string attach_docgroup_gid { get; set; }
            public string attach_docuname { get; set; }
            public string attach_descripition { get; set; }
            public string attach_filename { get; set; }

        }
        public class KioskadvertismentDetails
        {
            //advertisment
            public int ad_gid { get; set; }
            public string ad_tran_id { get; set; }
            public string ad_name { get; set; }
            public string ad_date { get; set; }
            public string ad_state { get; set; }
            public string ad_flashscreen { get; set; }
            public int ad_order { get; set; }
            public string ad_status { get; set; }
            public string ad_path { get; set; }
            public string ad_notes { get; set; }
        }


        public class KioskIrrigationHeader
        {
            public int irrigation_gid { get; set; }
            public string farmer_gid { get; set; }
            public string farmer_colldate { get; set; }
            public string  farmer_tranid { get; set; }
            public string farmer_samplests { get; set; }
            public string farmer_sampleid { get; set; }
            public string farmer_sampledrawn { get; set; }
            public string farmer_customerref { get; set; }
            public string farmer_labreportno { get; set; }
            public string farmer_labid { get; set; }
            public string farmer_samplereceived { get; set; }
            public string farmer_analystarted { get; set; }
            public string farmer_analycompleted { get; set; }

            public string farmer_testmethod { get; set; }

            public string farmer_irrigation_rejreason { get; set; }
            public string farmer_irrigation_CropRecom { get; set; }
            public string famer_irrigation_notes { get; set; }
            public string farmer_irrigation_status { get; set; }
            public string farmer_crop_confirm { get; set; }

            public string farmer_irrigation_confirm { get; set; }

             

        }

        //irrigation parameters

        public class KiosksIrrigationParameters
        {
            public string irrigationparam_gid { get; set; }
            public string irrigation_gid { get; set; }
            public string irrigation_parameter { get; set; }
            public string irrigation_uom { get; set; }
            public string irrigation_results { get; set; }

            
        }
        public class KioskcropDetails
        {
            // crop
            public int crop_gid { get; set; }
            public int crop_village_gid { get; set; }
            public int crop_api_id { get; set; }
            public int crop_api_crop_reg_id { get; set; }
            public int crop_api_userid { get; set; }
            public string crop_api_mobileno { get; set; }
            public int crop_api_cropid { get; set; }
            public string crop_api_crop_name { get; set; }
            public int crop_api_village_id { get; set; }
            public string crop_api_message_ta { get; set; }
            public string crop_api_message_en { get; set; }
            public string crop_api_status { get; set; }
            public string crop_api_name { get; set; }
            public string crop_api_village_name { get; set; }
            public int crop_api_block_id { get; set; }
            public string crop_api_block { get; set; }
            public int crop_api_district_id { get; set; }
            public string crop_api_district { get; set; }
            public int crop_api_state_id { get; set; }
            public string crop_api_state { get; set; }

        }
        public class KioskschemesrDetails
        {
            //schemes
            public int scheme_gid { get; set; }
            public string scheme_category { get; set; }
            public string scheme_date { get; set; }
            public string scheme_state { get; set; }
            public string scheme_schname { get; set; }
            public string scheme_description { get; set; }
            public string scheme_keyword { get; set; }
            public string schema_des_locallang { get; set; }
            public string scheme_keyword_locallang { get; set; }
            public string scheme_url { get; set; }
            public string scheme_upload { get; set; }
            public string scheme_status { get; set; }
            public string scheme_notes { get; set; }
            public string scheme_schname_locallang { get; set; }
        }
        public class KiosksoilDetails
        {
            //soil

            public int soil_gid { get; set; }
            public int soil_farmer_gid { get; set; }
            public string farmer_colldate { get; set; }
            public string farmer_tranid { get; set; }
            public string farmer_samplests { get; set; }
            public string farmer_sampleid { get; set; }
            public string farmer_sampledrawn { get; set; }
            public string farmer_customerref { get; set; }
            public string farmer_labreportno { get; set; }
            public string farmer_labid { get; set; }
            public string farmer_samplereceived { get; set; }
            public string farmer_analystarted { get; set; }
            public string farmer_analycompleted { get; set; }
            public string farmer_testmethod { get; set; }
            public string farmer_soil_rejreason { get; set; }
            public string farmer_soil_CropRecom { get; set; }
            public string famer_soil_notes { get; set; }
            public string farmer_soil_status { get; set; }
        }
        public class KiosksoilparamDetails
        {
            //soil parameter
            public int soilparam_gid { get; set; }
            public int soilparam_soil_gid { get; set; }
            public string soil_parameter { get; set; }
            public string soil_uom { get; set; }
            public string soil_results { get; set; }

        }
        public class KioskvideoDetails
        {
            //video

            public int video_gid { get; set; }
            public string video_category { get; set; }
            public string video_title { get; set; }
            public string video_filename { get; set; }
            public string video_filepath { get; set; }
            public string video_source { get; set; }
            public string video_keywords { get; set; }
            public string video_attribute { get; set; }
            public string video_notes { get; set; }

        }
        public class KioskweatherDetails
        {
            //weather

            public int weather_gid { get; set; }
            public int weather_tran_id { get; set; }
            public string weather_date { get; set; }
            public string weather_dist { get; set; }
            public string weather_village { get; set; }
            public string weather_filepath { get; set; }
        }
        public class KioskweatherforecastDetails
        {
            //weather forecast
            public int wfc_gid { get; set; }
            public int wfc_village_gid { get; set; }
            public string wfc_date { get; set; }
            public int wfc_api_vilageid { get; set; }
            public string wfc_tmax { get; set; }
            public string wfc_tmin { get; set; }
            public string wfc_rh1 { get; set; }
            public string wfc_rh2 { get; set; }
            public string wfc_rh_avg { get; set; }
            public string wfc_ws1 { get; set; }
            public string wfc_ws2 { get; set; }
            public string wfc_ws_avg { get; set; }
            public string wfc_ws_rf { get; set; }
        }
        public class KioskfaqDetails
        {
            //faq
            public int faq_gid { get; set; }
            public string faq_category { get; set; }
            public string faq_date { get; set; }
            public string faq_question { get; set; }
            public string faq_answer { get; set; }
            public string faq_keywords { get; set; }
            public string faq_ques_locallang { get; set; }
            public string faq_answer_locallang { get; set; }
            public string faq_keywords_locallang { get; set; }
            public string faq_ans_upload { get; set; }
            public string faq_url { get; set; }
            public string faq_video { get; set; }
            public string faq_videopath { get; set; }
          
        }

        public class KioskUserDetails
        {
            public int user_rowid { get; set; }
            public string orgn_code { get; set; }
            public string user_code { get; set; }
            public string user_name { get; set; }
            public string status_code { get; set; }
            public string role_code { get; set; }
            public string user_pwd { get; set; }
            public string email_id { get; set; }
            public string contact_no { get; set; }
            public string photo_user { get; set; }
            public string valid_till { get; set; }
            public string secquestion_code { get; set; }
            public string secquestion_answer { get; set; }
            public string created_datetime { get; set; }
            public string Password { get; set; }
            public string password_reset { get; set; }
        }


        public class synmaster
        {
            public string syncmaster_rowid { get; set; }
            public string master_data { get; set; }
            public string village_id { get; set; }
            public string district_id { get; set; }
            public  string kiosk_village_gid { get; set; }
            public string kiosk_Master_type { get; set; }
            public string Village_name { get; set; }
            public string district_name { get; set; }
            public string taluk_id { get; set; }
            public string taluk_name { get; set; }
            public string kiosk_taluk_gid { get; set; }
            public string kiosk_panchayat_gid { get; set; }
            public string source { get; set; }
            public string kiosk_district_gid { get; set; }
        }

    }
}
