using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class Kiosk_FAQS_Model
    {
        #region list category model
        [DataContract]
        public class FAQSCategory
        {
            [DataMember(Name = "out_faqscategory_Id")]
            public string out_faqscategory_Id { get; set; }
            [DataMember(Name = "out_faqscategory")]
            public string out_faqscategory { get; set; }
        }
        public class FAQSCategoryContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public List<FAQSCategory> Category { get; set; }

        }

        public class FAQSCategoryApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class FAQSCategoryRootObject
        {

            public FAQSCategoryContext context { get; set; }

            public FAQSCategoryApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region list Questions model
        [DataContract]
        public class FAQSQuestions
        {
            [DataMember(Name = "out_faqscategory_Id")]
            public string out_faqscategory_Id { get; set; }
            [DataMember(Name = "out_faq_question")]
            public string out_faq_question { get; set; }
        }
        public class FAQSQuestionContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_faqscat_Id")]
            public int In_faqscat_Id { get; set; }

            public List<FAQSQuestions> Questions { get; set; }

        }

        public class FAQSQuestionApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class FAQSQuestionRootObject
        {

            public FAQSQuestionContext context { get; set; }

            public FAQSQuestionApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region list Answers model
        [DataContract]
        public class FAQSAnswers
        {
            [DataMember(Name = "out_faq_question")]
            public string out_faq_question { get; set; }
            [DataMember(Name = "out_faq_answer")]
            public string out_faq_answer { get; set; }
            [DataMember(Name = "out_faq_date")]
            public string out_faq_date { get; set; }
            [DataMember(Name = "out_keyword")]
            public string out_keyword { get; set; }
            [DataMember(Name = "out_faqscategory")]
            public string out_faqscategory { get; set; }
            [DataMember(Name = "In_faq_gid")]
            public int In_faq_gid { get; set; }
            [DataMember(Name = "In_notes")]
            public string In_notes { get; set; }
            [DataMember(Name = "In_faq_ans_upload")]
            public string In_faq_ans_upload { get; set; }
            [DataMember(Name = "In_video_filenamef")]
            public string In_video_filenamef { get; set; }
            [DataMember(Name = "In_video_filepathf")]
            public string In_video_filepathf { get; set; }
            [DataMember(Name = "In_faq_ques_locallang")]
            public string In_faq_ques_locallang { get; set; }

            [DataMember(Name = "In_faq_answer_locallang")]
            public string In_faq_answer_locallang { get; set; }

            [DataMember(Name = "In_faq_keywords_locallang")]
            public string In_faq_keywords_locallang { get; set; }
            [DataMember(Name = "In_faq_urltype")]
            public string In_faq_urltype { get; set; }
        }
        public class FAQSAnswersContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_faq_gid")]
            public int In_faq_gid { get; set; }

            public FAQSAnswers Answers { get; set; }

        }

        public class FAQSAnswersApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class FAQSAnswersRootObject
        {

            public FAQSAnswersContext context { get; set; }

            public FAQSAnswersApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region list model
        [DataContract]
        public class FAQSList
        {
            [DataMember(Name = "In_faq_gid")]
            public int In_faq_gid { get; set; }
            [DataMember(Name = "out_faq_date")]
            public string out_faq_date { get; set; }

            [DataMember(Name = "out_faqscategory")]
            public string out_faqscategory { get; set; }
            [DataMember(Name = "out_faq_question")]
            public string out_faq_question { get; set; }

            [DataMember(Name = "out_faq_answer")]
            public string out_faq_answer { get; set; }

            [DataMember(Name = "out_keyword")]
            public string out_keyword { get; set; }
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_faq_urltype")]
            public string In_faq_urltype { get; set; }
            [DataMember(Name = "In_video_filenamef")]
            public string In_video_filenamef { get; set; }
            [DataMember(Name = "In_video_filepathf")]
            public string In_video_filepathf { get; set; }
        }
        public class FAQSListContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public List<FAQSList> List { get; set; }

        }

        public class FAQSListApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class FAQSListRootObject
        {

            public FAQSListContext context { get; set; }

            public FAQSListApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region Save model
        [DataContract]
        public class SaveFAQS
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_faq_gid")]
            public int In_faq_gid { get; set; }

            [DataMember(Name = "In_faq_category")]
            public string In_faq_category { get; set; }

            [DataMember(Name = "In_faq_date")]
            public string In_faq_date { get; set; }
            [DataMember(Name = "In_faq_question")]
            public string In_faq_question { get; set; }

            [DataMember(Name = "In_faq_answer")]
            public string In_faq_answer { get; set; }
            [DataMember(Name = "In_faq_keywords")]
            public string In_faq_keywords { get; set; }

            [DataMember(Name = "In_faq_ques_locallang")]
            public string In_faq_ques_locallang { get; set; }

            [DataMember(Name = "In_faq_answer_locallang")]
            public string In_faq_answer_locallang { get; set; }

            [DataMember(Name = "In_faq_keywords_locallang")]
            public string In_faq_keywords_locallang { get; set; }
            [DataMember(Name = "In_faq_ans_upload")]
            public string In_faq_ans_upload { get; set; }
            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
            [DataMember(Name = "In_notes")]
            public string In_notes { get; set; }
            [DataMember(Name = "In_faq_urltype")]
            public string In_faq_urltype { get; set; }
            [DataMember(Name = "In_video_filenamef")]
            public string In_video_filenamef { get; set; }
            [DataMember(Name = "In_video_filepathf")]
            public string In_video_filepathf { get; set; }
        }

        #endregion

    }
}
