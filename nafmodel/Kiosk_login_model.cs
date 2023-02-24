using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
  public class Kiosk_login_model
    {
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
        #region kioskresetpassowrd       
        public class kioskresetContext
        {           
            public string In_user_code { get; set; }
            public string In_otp { get; set; }
            public string In_email { get; set; }
            public string In_Reponse { get; set; }
            public string instance { get; set; }
        }
        public class kioskresetApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class kioskresetApplication
        {
            public kioskresetContext context { get; set; }
            public kioskresetApplicationException ApplicationException { get; set; }

        }

        #endregion
        #region kiosklogin
        public class kioskLoginContext
        {
            [DataMember(Name = "farmer_gid")]
            public int farmer_gid { get; set; }
            [DataMember(Name = "farmer_code")]
            public string farmer_code { get; set; }
            [DataMember(Name = "farmer_name")]
            public string farmer_name { get; set; } 
            [DataMember(Name = "village_code")]
            public string village_code { get; set; }
            [DataMember(Name = "farmer_village")]
            public string farmer_village { get; set; }
            [DataMember(Name = "panchayat_code")]
            public string panchayat_code { get; set; }
            [DataMember(Name = "farmer_panchayat")]
            public string farmer_panchayat { get; set; }
            [DataMember(Name = "taluk_code")]
            public string taluk_code { get; set; }
            [DataMember(Name = "farmer_taluk")]
            public string farmer_taluk { get; set; }
            [DataMember(Name = "dist_code")]
            public string dist_code { get; set; }
            [DataMember(Name = "farmer_dist")]
            public string farmer_dist { get; set; }
            [DataMember(Name = "state_code")]
            public string state_code { get; set; }
            [DataMember(Name = "farmer_state")]
            public string farmer_state { get; set; }
            [DataMember(Name = "In_Reponse")]
            public string In_Reponse { get; set; }
            [DataMember(Name = "instance")]
            public string instance { get; set; }
            [DataMember(Name = "Mobile_no")]
            public string Mobile_no { get; set; }

            [DataMember(Name = "Password_reset")]
            public string Password_reset { get; set; }
            public string Kamaraj_village_id { get; set; }
            public string Kamaraj_district_id { get; set; }




            [DataMember(Name = "farmer_villageII")]
            public string farmer_villageII { get; set; }

            [DataMember(Name = "farmer_panchayatII")]
            public string farmer_panchayatII { get; set; }

            [DataMember(Name = "farmer_talukII")]
            public string farmer_talukII { get; set; }

            [DataMember(Name = "farmer_distII")]
            public string farmer_distII { get; set; }

            [DataMember(Name = "farmer_stateII")]
            public string farmer_stateII { get; set; }


        }


        #endregion
    }
}
