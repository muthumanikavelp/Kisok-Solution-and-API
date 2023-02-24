using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class FAQs_Model
    {
        #region list category model
         
        public class FAQSCategory
        {
             
            public string out_faqscategory_Id { get; set; }
            
            public string out_faqscategory { get; set; }

        }
        public class FAQSCategoryContext
        {
            
            public string orgnId { get; set; }

            
            public string locnId { get; set; }

            
            public string userId { get; set; }

          
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
        public class FAQSAnswers
        {
            public int In_faq_gid { get; set; }
            public string out_faq_question { get; set; }
        
            public string out_faq_answer { get; set; }
            public string out_keyword { get; set; }
            public DateTime out_faq_date { get; set; }
            public string out_faqscategory { get; set; }
            public string In_notes { get; set; }
            public string In_faq_ans_upload { get; set; }
            public string In_faq_urltype { get; set; }
            public string In_video_filenamef { get; set; }
            public string In_video_filepathf { get; set; }
        }

        public class FAQSAnswersContext
        {
             
            public string orgnId { get; set; }

       
            public string locnId { get; set; }
 
            public string userId { get; set; }

    
            public string localeId { get; set; }
            
            public int In_faq_gid { get; set; }

            public FAQSAnswers Answers { get; set; }

        }
        //list model
        public class FAQSListContext
        {
      
            public string orgnId { get; set; }

      
            public string locnId { get; set; }

    
            public string userId { get; set; }
             
            public string localeId { get; set; }

            public List<FAQSList> List { get; set; }
            public string In_faq_ans_upload { get; set; }
        }

        public class FAQSList
        {
            public string In_faq_ans_upload { get; set; }
            public string orgnId { get; set; }
            public string In_faq_urltype { get; set; }

            public string locnId { get; set; }


            public string userId { get; set; }

            public string localeId { get; set; }
            public string out_faq_date { get; set; }

            
            public string out_faqscategory { get; set; }
           
            public string out_faq_question { get; set; }

      
            public string out_faq_answer { get; set; }
            public string out_keyword { get; set; }
            public int In_faq_gid { get; set; }
        }
        public class FAQSListRootObject
        {

            public FAQSListContext context { get; set; }

            public FAQSListApplicationException ApplicationException { get; set; }
        }
        public class FAQSListApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }
        #region Save model
        
        public class SaveFAQS
        {
            public string In_faq_urltype { get; set; }
            public string orgnId { get; set; }

            
            public string locnId { get; set; }

           
            public string userId { get; set; }

            
            public string localeId { get; set; }
            
            public int In_faq_gid { get; set; }

             
            public string In_faq_category { get; set; }

          
            public string In_faq_date { get; set; }
           
            public string In_faq_question { get; set; }

             
            public string In_faq_answer { get; set; }
            
            public string In_faq_keywords { get; set; }

            
            public string In_faq_ques_locallang { get; set; }

           
            public string In_faq_answer_locallang { get; set; }

           
            public string In_faq_keywords_locallang { get; set; }
            
            public string In_faq_ans_upload { get; set; }
            
            public string In_mode_flag { get; set; }
            public string In_notes { get; set; }
            public string In_video_filenamef { get; set; }
            public string In_video_filepathf { get; set; }
        }

        #endregion
    }
}
