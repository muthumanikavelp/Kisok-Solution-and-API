using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.OfflineAttachment_Model;
namespace nafdatamodel
{
   public class OfflineAttachment_DataModel
    {
        public static DataConnection MysqlCon;



        public KioskApplication GetAllKiosk_Srv(KioskContext objinvoice, string mysqlcon)
        {
            DataSet ds = new DataSet();

            DataTable faq = new DataTable();
            DataTable video = new DataTable();
            DataTable schemes = new DataTable();
            DataTable soil = new DataTable();
            DataTable soilparam = new DataTable();
            DataTable kioskheader = new DataTable();
            DataTable contactdetail = new DataTable();

            DataTable farmer = new DataTable();
            DataTable land = new DataTable();
            DataTable attachment = new DataTable();
            DataTable weather = new DataTable();
            DataTable weatherdetails = new DataTable();
            DataTable masterheader = new DataTable();
            DataTable masterheaderdetails = new DataTable();
            DataTable localize = new DataTable();
            DataTable user = new DataTable();
            DataTable advertisment = new DataTable();
            DataTable irrigationheader = new DataTable();
            DataTable irrigationparmeter = new DataTable();
            DataTable synmas = new DataTable();


            KioskApplication objinvoiceRoot = new KioskApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new KioskContext();
            objinvoiceRoot.context.faq = new List<KioskfaqDetails>();
            objinvoiceRoot.context.video = new List<KioskvideoDetails>();
            objinvoiceRoot.context.schemes = new List<KioskschemesrDetails>();
            objinvoiceRoot.context.soil = new List<KiosksoilDetails>();
            objinvoiceRoot.context.soilparam = new List<KiosksoilparamDetails>();
            objinvoiceRoot.context.kioskheader = new List<KiosksetupheaderDetails>();
            objinvoiceRoot.context.contactdetail = new List<KioskcontactDetails>();
            objinvoiceRoot.context.farmer = new List<KioskfarmerDetails>();
            objinvoiceRoot.context.land = new List<KioskLandDetails>();
              objinvoiceRoot.context.attachment = new List<KioskAttachmentDetails>();
            objinvoiceRoot.context.weather = new List<KioskweatherDetails>();
            objinvoiceRoot.context.weatherdetails = new List<KioskweatherforecastDetails>();
            objinvoiceRoot.context.masterheader  = new List<KioskmasterheadereDetails>();
            objinvoiceRoot.context.masterheaderdetails = new List<KioskmasterDetails>();
            objinvoiceRoot.context.localize = new List<KiosklocalizationDetails>();
            objinvoiceRoot.context.user = new List<KioskUserDetails>();
            objinvoiceRoot.context.advertisment = new List<KioskadvertismentDetails>();
            objinvoiceRoot.context.Irrigationheader = new List<KioskIrrigationHeader>();
            objinvoiceRoot.context.Irrigationparameters = new List<KiosksIrrigationParameters>();
            objinvoiceRoot.context.synmas = new List<synmaster>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_Attachments_Offline", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                //cmd.Parameters.Add("in_screen_code", MySqlDbType.VarChar).Value = objinvoice.screen_Id;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                
                
                    if (ds.Tables.Count > 0)
                    {

                    //FAQ
                    faq = ds.Tables[28];
                        for (int i = 0; i < faq.Rows.Count; i++)
                        {
                        KioskfaqDetails objList = new KioskfaqDetails();
                            objList.faq_gid = Convert.ToInt32(faq.Rows[i]["faq_gid"]);
                            objList.faq_category = faq.Rows[i]["faq_category"].ToString();
                            objList.faq_date = faq.Rows[i]["faq_date"].ToString();
                            objList.faq_question = faq.Rows[i]["faq_question"].ToString();
                            objList.faq_answer = faq.Rows[i]["faq_answer"].ToString();
                            objList.faq_keywords = faq.Rows[i]["faq_keywords"].ToString();
                            objList.faq_ques_locallang = faq.Rows[i]["faq_ques_locallang"].ToString();
                            objList.faq_answer_locallang  = faq.Rows[i]["faq_answer_locallang"].ToString();
                            objList.faq_keywords_locallang = faq.Rows[i]["faq_keywords_locallang"].ToString();
                        objList.faq_ans_upload = faq.Rows[i]["faq_ans_upload"].ToString();
                        objList.faq_url = faq.Rows[i]["faq_url"].ToString();
                        objList.faq_video = faq.Rows[i]["faq_video"].ToString();
                        objList.faq_videopath = faq.Rows[i]["faq_videopath"].ToString();
                       
                        objinvoiceRoot.context.faq.Add(objList);

                        }

                        //Video

                    video = ds.Tables[27];
                    for (int i = 0; i < video.Rows.Count; i++)
                    {
                        KioskvideoDetails Objlist = new KioskvideoDetails();
                        Objlist.video_gid = Convert.ToInt32(video.Rows[i]["video_gid"]);
                        Objlist.video_category = video.Rows[i]["video_category"].ToString();
                        Objlist.video_title = video.Rows[i]["video_title"].ToString();
                        Objlist.video_filename = video.Rows[i]["video_filename"].ToString();
                        Objlist.video_filepath = video.Rows[i]["video_filepath"].ToString();
                        Objlist.video_source = video.Rows[i]["video_source"].ToString();
                        Objlist.video_keywords = video.Rows[i]["video_keywords"].ToString();
                        Objlist.video_attribute = video.Rows[i]["video_attribute"].ToString();
                        Objlist.video_notes = video.Rows[i]["video_notes"].ToString();
                        objinvoiceRoot.context.video.Add(Objlist);
                    }
                    //schemes

                    schemes = ds.Tables[24];
                    for (int i = 0; i < schemes.Rows.Count; i++)
                    {
                        KioskschemesrDetails ObjList = new KioskschemesrDetails();
                        ObjList.scheme_gid = Convert.ToInt32(schemes.Rows[i]["scheme_gid"]);
                        ObjList.scheme_category = schemes.Rows[i]["scheme_category"].ToString();
                        ObjList.scheme_date = schemes.Rows[i]["scheme_date"].ToString();
                        ObjList.scheme_state = schemes.Rows[i]["scheme_state"].ToString(); 
                        ObjList.scheme_schname = schemes.Rows[i]["scheme_schname"].ToString();
                        ObjList.scheme_description = schemes.Rows[i]["scheme_description"].ToString();
                        ObjList.scheme_keyword = schemes.Rows[i]["scheme_keyword"].ToString();
                        ObjList.scheme_schname_locallang = schemes.Rows[i]["scheme_schname_locallang"].ToString();
                        ObjList.schema_des_locallang = schemes.Rows[i]["schema_des_locallang"].ToString();
                        ObjList.scheme_keyword_locallang = schemes.Rows[i]["scheme_keyword_locallang"].ToString();
                        ObjList.scheme_url = schemes.Rows[i]["scheme_url"].ToString();
                        ObjList.scheme_upload = schemes.Rows[i]["scheme_upload"].ToString();
                        ObjList.scheme_status = schemes.Rows[i]["scheme_status"].ToString();
                        ObjList.scheme_notes = schemes.Rows[i]["scheme_notes"].ToString();

                        objinvoiceRoot.context.schemes.Add(ObjList);

                    }
                    //soil

                    soil = ds.Tables[25];
                    for (int i = 0; i < soil.Rows.Count; i++)
                    {
                        KiosksoilDetails Objlist = new KiosksoilDetails();
                        Objlist.soil_gid = Convert.ToInt32(soil.Rows[i]["soil_gid"]);
                        Objlist.soil_farmer_gid = Convert.ToInt32(soil.Rows[i]["farmer_gid"].ToString());
                        Objlist.farmer_colldate = soil.Rows[i]["farmer_colldate"].ToString();
                        Objlist.farmer_tranid = soil.Rows[i]["farmer_tranid"].ToString();
                        Objlist.farmer_samplests = soil.Rows[i]["farmer_samplests"].ToString();
                        Objlist.farmer_sampleid = soil.Rows[i]["farmer_sampleid"].ToString();
                        Objlist.farmer_sampledrawn = soil.Rows[i]["farmer_sampledrawn"].ToString();
                        Objlist.farmer_customerref = soil.Rows[i]["farmer_customerref"].ToString();
                        Objlist.farmer_labreportno = soil.Rows[i]["farmer_labreportno"].ToString();
                        Objlist.farmer_labid = soil.Rows[i]["farmer_labid"].ToString();
                        Objlist.farmer_samplereceived = soil.Rows[i]["farmer_samplereceived"].ToString();
                        Objlist.farmer_analystarted = soil.Rows[i]["farmer_analystarted"].ToString();
                        Objlist.farmer_analycompleted = soil.Rows[i]["farmer_analycompleted"].ToString();
                        Objlist.farmer_testmethod = soil.Rows[i]["farmer_testmethod"].ToString();
                        Objlist.farmer_soil_rejreason = soil.Rows[i]["farmer_soil_rejreason"].ToString();
                        Objlist.farmer_soil_CropRecom = soil.Rows[i]["farmer_soil_CropRecom"].ToString();
                        Objlist.famer_soil_notes = soil.Rows[i]["famer_soil_notes"].ToString();
                        Objlist.farmer_soil_status = soil.Rows[i]["farmer_soil_status"].ToString();
                        objinvoiceRoot.context.soil.Add(Objlist);

                    }

                    //soil parameter
                    soilparam = ds.Tables[26];
                    for (int i = 0; i < soilparam.Rows.Count; i++)
                    {
                        KiosksoilparamDetails Objlist = new KiosksoilparamDetails();
                        Objlist.soilparam_gid = Convert.ToInt32(soilparam.Rows[i]["soilparam_gid"]);
                        Objlist.soilparam_soil_gid = Convert.ToInt32(soilparam.Rows[i]["soil_gid"].ToString());
                        Objlist.soil_parameter = soilparam.Rows[i]["soil_parameter"].ToString();
                        Objlist.soil_uom = soilparam.Rows[i]["soil_uom"].ToString();
                        Objlist.soil_results = soilparam.Rows[i]["soil_results"].ToString();
                        objinvoiceRoot.context.soilparam.Add(Objlist);

                    }
                    //kiosk header

                    kioskheader = ds.Tables[19];
                    for (int i = 0; i < kioskheader.Rows.Count; i++)
                    {
                        KiosksetupheaderDetails Objlist = new KiosksetupheaderDetails();
                        Objlist.kiosk_gid = Convert.ToInt32(kioskheader.Rows[i]["kiosk_gid"]);
                        Objlist.kiosk_code =  (kioskheader.Rows[i]["kiosk_code"].ToString());
                        Objlist.kiosk_name = kioskheader.Rows[i]["kiosk_name"].ToString();
                        Objlist.kiosk_billingual = kioskheader.Rows[i]["kiosk_billingual"].ToString();
                        Objlist.kiosk_village = kioskheader.Rows[i]["kiosk_village"].ToString();
                        Objlist.kiosk_taluk = kioskheader.Rows[i]["kiosk_taluk"].ToString();
                        Objlist.kiosk_district = kioskheader.Rows[i]["kiosk_district"].ToString();
                        Objlist.kiosk_state = kioskheader.Rows[i]["kiosk_state"].ToString();
                        Objlist.kiosk_pincode = kioskheader.Rows[i]["kiosk_pincode"].ToString();
                        Objlist.kiosk_fpo = kioskheader.Rows[i]["kiosk_fpo"].ToString();
                        Objlist.kisok_address = kioskheader.Rows[i]["kisok_address"].ToString();
                        Objlist.kiosk_notes = kioskheader.Rows[i]["kiosk_notes"].ToString();
                        Objlist.kiosk_status = kioskheader.Rows[i]["kiosk_status"].ToString();
 
                        objinvoiceRoot.context.kioskheader.Add(Objlist);

                    }
                    //kiosk detail

                    contactdetail = ds.Tables[20];
                    for (int i = 0; i < contactdetail.Rows.Count; i++)
                    {
                        KioskcontactDetails Objlist = new KioskcontactDetails();
                        Objlist.contact_gid = Convert.ToInt32(contactdetail.Rows[i]["contact_gid"]);
                        Objlist.contact_kiosk_gid = Convert.ToInt32(contactdetail.Rows[i]["kiosk_gid"].ToString());
                        Objlist.contact_name = contactdetail.Rows[i]["contact_name"].ToString();
                        Objlist.contact_designation = contactdetail.Rows[i]["contact_designation"].ToString();
                        Objlist.contact_email = contactdetail.Rows[i]["contact_email"].ToString();
                        Objlist.contact_mobile = contactdetail.Rows[i]["contact_mobile"].ToString();
                        Objlist.contact_landline = contactdetail.Rows[i]["contact_landline"].ToString();
                        objinvoiceRoot.context.contactdetail.Add(Objlist);

                    }

                    //farmer
                    farmer = ds.Tables[3];
                    for (int i = 0; i < farmer.Rows.Count; i++)
                    {
                        KioskfarmerDetails Objlist = new KioskfarmerDetails();
                        Objlist.farmer_rowid = Convert.ToInt32(farmer.Rows[i]["farmer_rowid"]);
                        Objlist.farmer_code = (farmer.Rows[i]["farmer_code"].ToString());
                        Objlist.version_no = Convert.ToInt32(farmer.Rows[i]["version_no"].ToString());
                        Objlist.farmer_name = farmer.Rows[i]["farmer_name"].ToString();
                        Objlist.sur_name = farmer.Rows[i]["sur_name"].ToString();
                        Objlist.fhw_name = farmer.Rows[i]["fhw_name"].ToString();
                        Objlist.farmer_dob = farmer.Rows[i]["farmer_dob"].ToString();
                        Objlist.farmer_addr1 = farmer.Rows[i]["farmer_addr1"].ToString();
                        Objlist.farmer_addr2 = farmer.Rows[i]["farmer_addr2"].ToString();
                        Objlist.farmer_ll_name = farmer.Rows[i]["farmer_ll_name"].ToString();
                        Objlist.sur_ll_name = farmer.Rows[i]["sur_ll_name"].ToString();
                        Objlist.fhw_ll_name = farmer.Rows[i]["fhw_ll_name"].ToString();
                        Objlist.farmer_ll_addr1 = farmer.Rows[i]["farmer_ll_addr1"].ToString();
                        Objlist.farmer_ll_addr2 = farmer.Rows[i]["farmer_ll_addr2"].ToString();
                        Objlist.farmer_country = farmer.Rows[i]["farmer_country"].ToString();
                        Objlist.farmer_state = farmer.Rows[i]["farmer_state"].ToString();
                        Objlist.farmer_dist = farmer.Rows[i]["farmer_dist"].ToString();
                        Objlist.farmer_taluk = farmer.Rows[i]["farmer_taluk"].ToString();
                        Objlist.farmer_panchayat = farmer.Rows[i]["farmer_panchayat"].ToString();
                        Objlist.farmer_village = farmer.Rows[i]["farmer_village"].ToString();
                        Objlist.farmer_pincode = farmer.Rows[i]["farmer_pincode"].ToString();
                        Objlist.marital_status = farmer.Rows[i]["marital_status"].ToString();
                        Objlist.gender_flag = farmer.Rows[i]["gender_flag"].ToString();
                        Objlist.reg_mobile_no = farmer.Rows[i]["reg_mobile_no"].ToString();
                        //  Objlist.photo_farmer = farmer.Rows[i]["photo_farmer"].ToString();
                        Objlist.reg_note = farmer.Rows[i]["reg_note"].ToString();
                        Objlist.status_code = farmer.Rows[i]["status_code"].ToString();
                        objinvoiceRoot.context.farmer.Add(Objlist);

                    }
                    //land
                    land = ds.Tables[5];
                    for (int i = 0; i < land.Rows.Count; i++)
                    {
                        KioskLandDetails Objlist = new KioskLandDetails();
                        Objlist.land_gid = Convert.ToInt32(land.Rows[i]["land_gid"]);
                        Objlist.land_type = (land.Rows[i]["land_type"].ToString());
                        Objlist.farmer_gid = Convert.ToInt32(land.Rows[i]["farmer_gid"].ToString());
                        Objlist.land_ownership = land.Rows[i]["land_ownership"].ToString();
                        Objlist.land_type = land.Rows[i]["land_soiltype"].ToString();
                        Objlist.land_irrsou = land.Rows[i]["land_irrsou"].ToString();
                        Objlist.land_noofacres = land.Rows[i]["land_noofacres"].ToString();
                        Objlist.land_longtitude = land.Rows[i]["land_longtitude"].ToString();
                        Objlist.land_latitude = land.Rows[i]["land_latitude"].ToString();
                        
                        objinvoiceRoot.context.land.Add(Objlist);

                    }

                    // attachment
                    attachment = ds.Tables[21];
                    for (int i = 0; i < attachment.Rows.Count; i++)
                    {
                        KioskAttachmentDetails Objlist = new KioskAttachmentDetails();
                        Objlist.attach_gid = Convert.ToInt32(attachment.Rows[i]["attach_gid"]);
                        Objlist.attach_ref_gid = Convert.ToInt32(attachment.Rows[i]["attach_ref_gid"].ToString());
                        Objlist.attach_docgroup_gid = (attachment.Rows[i]["attach_docgroup_gid"].ToString());
                        Objlist.attach_docuname = attachment.Rows[i]["attach_docuname"].ToString();
                        Objlist.attach_descripition = attachment.Rows[i]["attach_descripition"].ToString();
                        Objlist.attach_filename = attachment.Rows[i]["attach_filename"].ToString();
                       
                        objinvoiceRoot.context.attachment.Add(Objlist);

                    }
                    //// weather
                    //weather = ds.Tables[3];
                    //for (int i = 0; i < weather.Rows.Count; i++)
                    //{
                    //    KioskweatherDetails Objlist = new KioskweatherDetails();
                    //    Objlist.weather_gid = Convert.ToInt32(weather.Rows[i]["weather_gid"]);
                    //    Objlist.weather_tran_id = Convert.ToInt32(weather.Rows[i]["weather_tran_id"].ToString());
                    //    Objlist.weather_date = (weather.Rows[i]["weather_date"].ToString());
                    //    Objlist.weather_dist = weather.Rows[i]["weather_dist"].ToString();
                    //    Objlist.weather_village = weather.Rows[i]["weather_village"].ToString();
                    //    Objlist.weather_filepath = weather.Rows[i]["weather_filepath"].ToString();
                         

                    //    objinvoiceRoot.context.weather.Add(Objlist);

                    //}

                    ////weather forecast

                    //weatherdetails = ds.Tables[3];
                    //for (int i = 0; i < weatherdetails.Rows.Count; i++)
                    //{
                    //    KioskweatherforecastDetails Objlist = new KioskweatherforecastDetails();
                    //    Objlist.wfc_gid = Convert.ToInt32(weatherdetails.Rows[i]["wfc_gid"]);
                    //    Objlist.wfc_village_gid = Convert.ToInt32(weatherdetails.Rows[i]["wfc_village_gid"].ToString());
                    //    Objlist.wfc_date = (weatherdetails.Rows[i]["wfc_date"].ToString());
                    //    Objlist.wfc_api_vilageid = Convert.ToInt32(weatherdetails.Rows[i]["wfc_api_vilageid"].ToString());
                    //    Objlist.wfc_tmax = weatherdetails.Rows[i]["wfc_tmax"].ToString();
                    //    Objlist.wfc_tmin = weatherdetails.Rows[i]["wfc_tmin"].ToString();
                    //      Objlist.wfc_rh1 = weatherdetails.Rows[i]["wfc_rh1"].ToString();
                    //    Objlist.wfc_rh2 = weatherdetails.Rows[i]["wfc_rh2"].ToString();
                    //    Objlist.wfc_rh_avg = weatherdetails.Rows[i]["wfc_rh_avg"].ToString();
                    //    Objlist.wfc_ws1 = weatherdetails.Rows[i]["wfc_ws1"].ToString();
                    //    Objlist.wfc_ws2 = weatherdetails.Rows[i]["wfc_ws2"].ToString();
                    //    Objlist.wfc_ws_avg = weatherdetails.Rows[i]["wfc_ws_avg"].ToString();
                    //    Objlist.wfc_rh_avg = weatherdetails.Rows[i]["wfc_rh_avg"].ToString();
                    //    Objlist.wfc_ws1 = weatherdetails.Rows[i]["wfc_ws1"].ToString();
                    //    Objlist.wfc_ws2 = weatherdetails.Rows[i]["wfc_ws2"].ToString();
                    //    Objlist.wfc_ws_avg = weatherdetails.Rows[i]["wfc_ws_avg"].ToString();
                    //      Objlist.wfc_ws_rf = weatherdetails.Rows[i]["wfc_ws_rf"].ToString();
                    //    objinvoiceRoot.context.weatherdetails.Add(Objlist);

                    //}

                    //master
                    masterheader = ds.Tables[8];
                    for (int i = 0; i < masterheader.Rows.Count; i++)
                    {
                        KioskmasterheadereDetails Objlist = new KioskmasterheadereDetails();
                        Objlist.master_rowid = Convert.ToInt32(masterheader.Rows[i]["master_rowid"]);
                        Objlist.master_code =  (masterheader.Rows[i]["master_code"].ToString());
                        Objlist.parent_code = (masterheader.Rows[i]["parent_code"].ToString());
                        Objlist.depend_code =  (masterheader.Rows[i]["depend_code"].ToString());
                        Objlist.locallang_flag = masterheader.Rows[i]["locallang_flag"].ToString();
                        Objlist.master_row_slno = Convert.ToInt32(masterheader.Rows[i]["row_slno"].ToString());
                        Objlist.status_code = masterheader.Rows[i]["status_code"].ToString();
                          objinvoiceRoot.context.masterheader.Add(Objlist);

                    }

                    //master details

                    masterheaderdetails = ds.Tables[9];
                    for (int i = 0; i < masterheaderdetails.Rows.Count; i++)
                    {
                        KioskmasterDetails Objlist = new KioskmasterDetails();
                        Objlist.mastertranslate_rowid= Convert.ToInt32(masterheaderdetails.Rows[i]["mastertranslate_rowid"]);
                        Objlist.mastertranslate_master_code = (masterheaderdetails.Rows[i]["master_code"].ToString());
                        Objlist.mastertranslate_parent_code = (masterheaderdetails.Rows[i]["parent_code"].ToString());
                        Objlist.mastertranslate_lang_code = (masterheaderdetails.Rows[i]["lang_code"].ToString());
                        Objlist.master_name = masterheaderdetails.Rows[i]["master_name"].ToString();
                        objinvoiceRoot.context.masterheaderdetails.Add(Objlist);

                    }

                    //localization


                    localize = ds.Tables[7];
                    for (int i = 0; i < localize.Rows.Count; i++)
                    {
                        KiosklocalizationDetails Objlist = new KiosklocalizationDetails();
                        Objlist.localizationtranslate_rowid = Convert.ToInt32(localize.Rows[i]["localizationtranslate_rowid"]);
                        Objlist.localizationtranslate_activity_code = (localize.Rows[i]["activity_code"].ToString());
                        Objlist.control_code = (localize.Rows[i]["control_code"].ToString());
                        Objlist.data_field = (localize.Rows[i]["data_field"].ToString());
                        Objlist.lang_code = localize.Rows[i]["lang_code"].ToString();

                        Objlist.control_value = localize.Rows[i]["control_value"].ToString();
                        
                        objinvoiceRoot.context.localize.Add(Objlist);

                    }

                    //user 


                    user = ds.Tables[16];
                    for (int i = 0; i < user.Rows.Count; i++)
                    {
                        KioskUserDetails Objlist = new KioskUserDetails();
                        Objlist.user_rowid = Convert.ToInt32(user.Rows[i]["user_rowid"]);
                        Objlist.orgn_code = (user.Rows[i]["orgn_code"].ToString());
                        Objlist.user_code = (user.Rows[i]["user_code"].ToString());
                        Objlist.user_name = (user.Rows[i]["user_name"].ToString());
                        Objlist.status_code = user.Rows[i]["status_code"].ToString();
                        Objlist.role_code = user.Rows[i]["role_code"].ToString();

                        Objlist.user_pwd = user.Rows[i]["user_pwd"].ToString();
                        Objlist.email_id = user.Rows[i]["email_id"].ToString();
                        Objlist.contact_no = user.Rows[i]["contact_no"].ToString();
                        //Objlist.photo_user = user.Rows[i]["photo_user"].ToString();
                        Objlist.valid_till = user.Rows[i]["valid_till"].ToString();
                        Objlist.secquestion_code = user.Rows[i]["secquestion_code"].ToString();

                        Objlist.secquestion_answer = user.Rows[i]["secquestion_answer"].ToString();
                        Objlist.Password = user.Rows[i]["Password"].ToString();
                        Objlist.password_reset = user.Rows[i]["password_reset"].ToString();
                        //Objlist.secquestion_code = user.Rows[i]["secquestion_code"].ToString();
                        objinvoiceRoot.context.user.Add(Objlist);

                    }

                    //Irrigation Header
                     irrigationheader = ds.Tables[32];
                    for (int i = 0; i < irrigationheader.Rows.Count; i++)
                    {
                       KioskIrrigationHeader Objlist = new KioskIrrigationHeader();
                        Objlist.irrigation_gid = Convert.ToInt32(irrigationheader.Rows[i]["irrigation_gid"]);
                        Objlist.farmer_gid =  (irrigationheader.Rows[i]["farmer_gid"].ToString());
                        Objlist.farmer_colldate = (irrigationheader.Rows[i]["farmer_colldate"].ToString());
                        Objlist.farmer_tranid = (irrigationheader.Rows[i]["farmer_tranid"].ToString());
                        Objlist.farmer_samplests = irrigationheader.Rows[i]["farmer_samplests"].ToString();
                        Objlist.farmer_sampleid = irrigationheader.Rows[i]["farmer_sampleid"].ToString();

                        Objlist.farmer_sampledrawn =  (irrigationheader.Rows[i]["farmer_sampledrawn"].ToString());
                        Objlist.farmer_customerref = irrigationheader.Rows[i]["farmer_customerref"].ToString();
                        Objlist.farmer_labreportno = irrigationheader.Rows[i]["farmer_labreportno"].ToString();
                        //Objlist.photo_user = user.Rows[i]["photo_user"].ToString();
                        Objlist.farmer_samplereceived = irrigationheader.Rows[i]["farmer_samplereceived"].ToString();
                        Objlist.farmer_analystarted = irrigationheader.Rows[i]["farmer_analystarted"].ToString();
                        Objlist.farmer_analycompleted = irrigationheader.Rows[i]["farmer_analycompleted"].ToString();
                        Objlist.farmer_testmethod = irrigationheader.Rows[i]["farmer_testmethod"].ToString();
                        Objlist.farmer_irrigation_rejreason = irrigationheader.Rows[i]["farmer_irrigation_rejreason"].ToString(); 
                        Objlist.farmer_irrigation_CropRecom = irrigationheader.Rows[i]["farmer_irrigation_CropRecom"].ToString();
                        Objlist.famer_irrigation_notes = irrigationheader.Rows[i]["famer_irrigation_notes"].ToString();
                        Objlist.farmer_irrigation_status = irrigationheader.Rows[i]["farmer_irrigation_status"].ToString();
                        Objlist.farmer_crop_confirm = irrigationheader.Rows[i]["farmer_crop_confirm"].ToString();
                        Objlist.farmer_irrigation_confirm = irrigationheader.Rows[i]["farmer_irrigation_confirm"].ToString();

                        objinvoiceRoot.context.Irrigationheader.Add(Objlist);

                    }

                    //Irrigation Parameters
                    irrigationparmeter = ds.Tables[33];
                    for (int i = 0; i < irrigationparmeter.Rows.Count; i++)
                    {
                         KiosksIrrigationParameters Objlist = new KiosksIrrigationParameters();
                        Objlist.irrigationparam_gid = irrigationparmeter.Rows[i]["irrigationparam_gid"].ToString();
                        Objlist.irrigation_gid = (irrigationparmeter.Rows[i]["irrigation_gid"].ToString());
                        Objlist.irrigation_parameter = (irrigationparmeter.Rows[i]["irrigation_parameter"].ToString());
                        Objlist.irrigation_uom = (irrigationparmeter.Rows[i]["irrigation_uom"].ToString());
                        Objlist.irrigation_results = irrigationparmeter.Rows[i]["irrigation_results"].ToString();
                        
                        objinvoiceRoot.context.Irrigationparameters.Add(Objlist);

                    }


                    // Syn Master
                     synmas = ds.Tables[18];
                    for (int i = 0; i <  synmas.Rows.Count; i++)
                    {
                         synmaster Objlist = new synmaster();
                        Objlist.syncmaster_rowid =  synmas.Rows[i]["syncmaster_rowid"].ToString();
                        Objlist.master_data = (synmas.Rows[i]["master_data"].ToString());
                        Objlist.village_id = (synmas.Rows[i]["village_id"].ToString());
                        Objlist.district_id = (synmas.Rows[i]["district_id"].ToString());
                        Objlist.source = (synmas.Rows[i]["source"].ToString());

                        Objlist.kiosk_district_gid = (synmas.Rows[i]["kiosk_district_gid"].ToString());


                        Objlist.kiosk_village_gid = synmas.Rows[i]["kiosk_village_gid"].ToString();

                        Objlist.kiosk_Master_type = synmas.Rows[i]["kiosk_Master_type"].ToString();
                        Objlist.Village_name = synmas.Rows[i]["Village_name"].ToString();
                        Objlist.district_name = synmas.Rows[i]["district_name"].ToString();
                        Objlist.taluk_id = synmas.Rows[i]["taluk_id"].ToString();
                        Objlist.taluk_name = synmas.Rows[i]["taluk_name"].ToString();
                        Objlist.kiosk_taluk_gid = synmas.Rows[i]["kiosk_taluk_gid"].ToString();
                        Objlist.kiosk_panchayat_gid = synmas.Rows[i]["kiosk_panchayat_gid"].ToString();
                        

                        objinvoiceRoot.context.synmas.Add(Objlist);

                    }


                }



                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
