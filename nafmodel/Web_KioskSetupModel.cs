using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
 

namespace nafmodel
{
  public  class Web_KioskSetupModel
    {

        //fetch
        public class KioskFetch
        {
            public int Kiosk_id { get; set; }
            public string  KioskCode { get; set; }
            public string kiosk_Name { get; set; }
            public string Bilingual { get; set; }
            public string Village { get; set; }
            public string Taluk { get; set; }
            public string District { get; set; }
            public string State { get; set; }


            //Dropdown onchange

            public string tk_code { get; set; }
            public string tk_name { get; set; }
            public string dt_code { get; set; }
            public string dt_name { get; set; }
            public string st_code { get; set; }
            public string st_name { get; set; }
            public string village_code { get; set; }
            public string vill_name { get; set; } 
            public string vill_nameII { get; set; }
            public string tk_nameII { get; set; }
            public string dt_nameII { get; set; }
            public string st_nameII { get; set; } 

        }
        // get summary
        public class KioskList
        {
           public UserContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }

        // get summary
        public class UserContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string dependcode { get; set; }
            public List<KioskFetch> list { get; set; }
        }

         
         

        //save
        public class KioskSave
        {
            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

           
            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public SaveKioskheader header { get; set; }
            public List<SaveRMDetail> Detail { get; set; }

            public string detail_formatted { get; set; }

           public string In_mode_flag { get; set; }
            public int Kiosk_gid { get; set; }

            public int Kiosk_Contactgid { get; set; }


            public int Kiosk_id { get; set; }

            public string in_Name { get; set; }

            public string in_Designation { get; set; }

            public string in_eMail { get; set; }

            public string in_Mobile { get; set; }

            public string in_Landline { get; set; }
            public string notes { get; set; }
        }

        



        //save header
        public class SaveKioskheader
        {
            [DataMember(Name = "In_Kiosk_gid")]
            public int In_Kiosk_gid { get; set; }


            [DataMember(Name = "in_Kiosk_code")]
            //  public int In_Kiosk_Id { get; set; }
            public string in_Kiosk_code { get; set; }

            [DataMember(Name = "in_Kiosk_name")]
            public string in_Kiosk_name { get; set; }


            [DataMember(Name = "in_status_name")]
            public string in_status_name { get; set; }


            [DataMember(Name = "in_fpo_name")]
            public string in_fpo_name { get; set; }


            [DataMember(Name = "in_Bilingual_code")]
            public string in_Bilingual_code { get; set; }


            [DataMember(Name = "in_Pincode")]
            public string in_Pincode { get; set; }


            [DataMember(Name = "in_Village")]
            public string in_Village { get; set; }


            [DataMember(Name = "in_Taluk")]
            public string in_Taluk { get; set; }


            [DataMember(Name = "in_District")]
            public string in_District { get; set; }


            [DataMember(Name = "in_State")]
            public string in_State { get; set; }


            [DataMember(Name = "in_Address")]
            public string in_Address { get; set; }

            [DataMember(Name = "In_Kiosk_Notes")]
            public string In_Kiosk_Notes { get; set; }

            //public int Kiosk_Contactgid { get; set; }
            //public int Kiosk_id { get; set; }
            //public string Kiosk_ContactName { get; set; }
            //public string Kiosk_Designation { get; set; }
            //public string Kiosk_email { get; set; }
            //public string Kiosk_MobileNo { get; set; }
            //public string Kiosk_Landline { get; set; }
            public string In_mode_flag { get; set; }
            public string detail_formatted { get; set; }
            //  public List<SaveRMDetail> Detail { get; set; }

        }


        ////Details
        public class SaveRMDetail
        {
            //  public int Kiosk_Contactgid { get; set; }

            //[DataMember(Name = "userId")]
            //public string userId { get; set; }

            //[DataMember(Name = "orgnId")]
            //public string orgnId { get; set; }

            //[DataMember(Name = "locnId")]
            //public string locnId { get; set; }


            //[DataMember(Name = "localeId")]
            //public string localeId { get; set; }
            [DataMember(Name = "Kiosk_Contactgid")]
            public int Kiosk_Contactgid { get; set; }


            [DataMember(Name = "in_Name")]
            public string in_Name { get; set; }
            [DataMember(Name = "in_Designation")]
            public string in_Designation { get; set; }
            [DataMember(Name = "in_eMail")]
            public string in_eMail { get; set; }
            [DataMember(Name = "in_Mobile")]
            public string in_Mobile { get; set; }
            [DataMember(Name = "in_Landline")]
            public string in_Landline { get; set; }
            [DataMember(Name = "Kiosk_id")]
            public int Kiosk_id { get; set; }
          //  public string In_mode_flag { get; set; }

        }



        //edit
        public class RoleManagementFetch
        {
            public UserContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }





        //Contact Details Save
        public class SavesingleContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string In_mode_flag { get; set; }
            public int Kiosk_gid { get; set; }
            public int Kiosk_Contactgid { get; set; }
            public string in_Name { get; set; }
            public string in_Designation { get; set; }
            public string in_eMail { get; set; }
            public string in_Mobile { get; set; }
            public string in_Landline { get; set; }
        }

        public class Retrnmesg
        {
            [DataMember(Name = "out_msg")]
            public string out_msg { get; set; }

            [DataMember(Name = "out_result")]
            public string out_result { get; set; }

        }
    }
}
