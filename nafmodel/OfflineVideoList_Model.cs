using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
    public class OfflineVideoList_Model
    {


        public class KioskVideoApplication
        {
            public KioskVideoContext context { get; set; }


        }

        public class KioskVideoContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string instance { get; set; }


            public IList<KioskTrainingVideoList> TrainingVideos { get; set; }
            public IList<KioskAdvertisementVideoList> Advertisment { get; set; }
            public IList<KioskfaqDetails> FAQS { get; set; }
            public IList<KioskschemesrDetails> schemes { get; set; }
        }

        //advertisment
        public class KioskAdvertisementVideoList
        {

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
            public byte[] ad_fileContent { get; set; }
        }


        //Training Videos
        public class KioskTrainingVideoList
        {
            public int video_gid { get; set; }
            public string video_category { get; set; }
            public string video_title { get; set; }
            public string video_filename { get; set; }
            public string video_filepath { get; set; }
            public string video_source { get; set; }
            public string video_keywords { get; set; }
            public string video_attribute { get; set; }
            public string video_notes { get; set; }
            public byte[] Video_fileContent { get; set; }

        }
        //faq
        public class KioskfaqDetails
        {
            
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
            public byte[] faq_fileContent { get; set; }

        }
        //schemes
        public class KioskschemesrDetails
        {
           
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
            public byte[] scheme_fileContent { get; set; }
        }
    }
}
