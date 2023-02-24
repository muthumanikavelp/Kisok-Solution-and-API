using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class kiosk_advertisement_model
    {
        #region advertisementlist
        public class advertisementcontext
        {
            public List<advertisementlist> list { get; set; }            
        }
        public class advertisementlist
        {
            public int adver_gid { get; set; }
            public string tranid { get; set; }
            public string ad_name { get; set; }
            public string ad_state { get; set; }
            public Int64 ad_stategid { get; set; }
            public string flashscreenref { get; set; }
            public string display_order { get; set; }
            public string ad_path_url { get; set; }
        }
        #endregion

        #region fetch advertisement model
        [DataContract]
        public class Advertisementfetch
        {

            [DataMember(Name = "adver_gid")]
            public int adver_gid { get; set; }

            [DataMember(Name = "tranid")]
            public string tranid { get; set; }

            [DataMember(Name = "ad_date")]
            public string ad_date { get; set; }

            [DataMember(Name = "ad_name")]
            public string ad_name { get; set; }

            [DataMember(Name = "ad_state")]
            public string ad_state { get; set; }

            public Int64 ad_stategid { get; set; }

            [DataMember(Name = "ad_flashscreen")]
            public string ad_flashscreen { get; set; }

            [DataMember(Name = "display_order")]
            public string display_order { get; set; }

            [DataMember(Name = "ad_status")]
            public string ad_status { get; set; }
            
            [DataMember(Name = "ad_path_url")]
            public string ad_path_url { get; set; }

            [DataMember(Name = "ad_notes")]
            public string ad_notes { get; set; }

            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
            
        }
        public class advertisementfetchContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_AD_gid")]
            public int In_AD_gid { get; set; }

            public Advertisementfetch Advertisement { get; set; }

        }

        public class advertisementfetchObject
        {
            public advertisementfetchContext context { get; set; }
        }
        #endregion

        public class Retrnmesg
        {
            [DataMember(Name = "out_msg")]
            public string out_msg { get; set; }

            [DataMember(Name = "out_result")]
            public string out_result { get; set; }

        }

        #region Save model
        [DataContract]
        public class SaveAdvertisement
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_AD_gid")]
            public int In_AD_gid { get; set; }

            [DataMember(Name = "In_ad_tran_id")]
            public string In_ad_tran_id { get; set; }

            [DataMember(Name = "In_ad_name")]
            public string In_ad_name { get; set; }
            [DataMember(Name = "In_ad_date")]
            public string In_ad_date { get; set; }
            [DataMember(Name = "In_ad_state")]
            public string In_ad_state { get; set; }
            [DataMember(Name = "In_ad_flashscreen")]
            public string In_ad_flashscreen { get; set; }

            [DataMember(Name = "In_display_order")]
            public int In_display_order { get; set; }
            [DataMember(Name = "In_ad_status")]
            public string In_ad_status { get; set; }

            [DataMember(Name = "In_ad_path_url")]
            public string In_ad_path_url { get; set; }
    
            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
        }
        #endregion
    }
}
