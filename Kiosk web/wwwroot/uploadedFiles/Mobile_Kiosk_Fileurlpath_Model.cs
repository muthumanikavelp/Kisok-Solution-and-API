using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
   public class Mobile_Kiosk_Fileurlpath_Model
    {

        #region
        public class Mobile_Kiosk_Fileurlpath
        {
            public Mobile_Fileurlpath mobile_Fileurlpaths { get; set; }
        }
        #endregion

        #region  list class
        public class Mobile_Fileurlpath
        {
           /* public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }*/
            public IList<trainingvideo> trainingvideos { get; set; }
            public IList<Advertismentvideo> advertismentvideos { get; set; }
            public IList<Faqfilepath> faqfilepaths { get; set; }
            public IList<Governmentscheme> governmentschemes { get; set; }
        }

        #endregion


        #region trainingvideomodel
        public class trainingvideo
        {
            public int video_gid { get; set; }
            public string video_filename { get; set; }
            public string video_category { get; set; }
            public string video_filepath { get; set; }
            
        }
        #endregion
        #region AdvertismentVideoModel
        public class  Advertismentvideo
        {
            public int ad_gid { get; set; }
            public string ad_name { get; set; }
            public string ad_path { get; set; }
        }
        #endregion
        #region  FAQFilePath
        public class Faqfilepath
        {
            public int faq_gid { get; set; }
            public string faq_ans_upload { get; set; }
        }

        #endregion GovernmentSchemeFilePath
        #region Governmentschemepath
        public class Governmentscheme
        {
            public int scheme_gid { get; set; }
            public string scheme_upload { get; set; }
        }
        #endregion


    }
}
