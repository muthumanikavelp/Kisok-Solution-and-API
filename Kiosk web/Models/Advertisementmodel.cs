using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class Advertisementmodel
    {
        #region list
        public class advertisementcontext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public List<advertisementlist> list { get; set; }
        }
        public class advertisementlist
        {
            public int adver_gid { get; set; }
            public string tranid { get; set; }
            public string ad_name { get; set; }
            public string ad_state { get; set; }
            public  Int64 ad_stategid { get; set; }
            public string flashscreenref { get; set; }
            public string display_order { get; set; }
            public string ad_path_url { get; set; }
        }
        public class advertisement
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
        }
        #endregion

        #region fetch advertisement model       
        public class Advertisementfetch
        {
            public int adver_gid { get; set; }
            public string tranid { get; set; }
            public string ad_state { get; set; }
            public Int64 ad_stategid { get; set; }
            public string display_order { get; set; }
            public string ad_status { get; set; }
            public string ad_path_url { get; set; }
            public string ad_date { get; set; }
            public string ad_notes { get; set; }
            public string In_mode_flag { get; set; }
        }
        public class advertisementfetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_AD_gid { get; set; }
            public Advertisementfetch Advertisement { get; set; }
        }

        public class advertisementfetchObject
        {
            public advertisementfetchContext context { get; set; }
        }
        #endregion

        #region Save model      
        public class SaveAdvertisement
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_AD_gid { get; set; }
            public string In_ad_tran_id { get; set; }
            public string In_ad_name { get; set; }
            public string In_ad_date { get; set; }
            public string In_ad_state { get; set; }
            public string In_ad_flashscreen { get; set; }
            public int In_display_order { get; set; }
            public string In_ad_status { get; set; }
            public string In_ad_path_url { get; set; }
            public string In_mode_flag { get; set; }
        }
        #endregion

        #region delete model       
        public class adverdelete
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_AD_gid { get; set; }
            public string In_mode_flag { get; set; }
        }

        #endregion
    }
}
