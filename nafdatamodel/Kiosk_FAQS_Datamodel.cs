using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Kiosk_FAQS_Model;

namespace nafdatamodel
{
    public class Kiosk_FAQS_Datamodel
    {
        public List<FAQSCategory> GetFAQSCatList(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<FAQSCategory>>(Mysql,
                "Kiosk_fetch_FAQSCategory", t => t.TranslateAsFAQSCatList(), myParamArray);
        }
        public List<FAQSQuestions> GetFAQSQuestions(string org, string locn, string user, string lang, int In_faqscat_Id, string Mysql,string Keyword)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_faqscat_Id",In_faqscat_Id),
                new MySqlParameter("In_Keyword",Keyword),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<FAQSQuestions>>(Mysql,
                "Kiosk_fetch_FAQSQuestion", t => t.TranslateAsFAQSQuestionsret(), myParamArray);
        }
        public FAQSAnswers GetFAQSAnswers(string org, string locn, string user, string lang, int In_faq_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_faq_gid",In_faq_gid),

            };
            return SqlHelper.ExtecuteProcedureReturnData<FAQSAnswers>(Mysql,
                "Kiosk_fetch_FAQSAnswers", t => t.TranslateAsFAQSAnswersret(), myParamArray);
        }

        //SUMMARY List
        public List<FAQSList> GetFAQSList(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),


            };
            return SqlHelper.ExtecuteProcedureReturnData<List<FAQSList>>(Mysql,
                "Kiosk_fetch_FAQSList", t => t.TranslateAsFAQSListsret(), myParamArray);
        }

        //FAQ Save
        public string[] NewFAQSsave_db(SaveFAQS model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userId),
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_faq_gid",model.In_faq_gid),
                new MySqlParameter("In_faq_category",model.In_faq_category),
                new MySqlParameter("In_faq_date",model.In_faq_date),
                new MySqlParameter("In_faq_question",model.In_faq_question),
                new MySqlParameter("In_faq_answer",model.In_faq_answer),
                new MySqlParameter("In_faq_keywords",model.In_faq_keywords),
                new MySqlParameter("In_faq_ques_locallang",model.In_faq_ques_locallang),
                new MySqlParameter("In_faq_answer_locallang",model.In_faq_answer_locallang),
                new MySqlParameter("In_faq_keywords_locallang",model.In_faq_keywords_locallang),
                new MySqlParameter("In_faq_ans_upload",model.In_faq_ans_upload),
                new MySqlParameter("In_mode_flag",model.In_mode_flag),
                new MySqlParameter("In_notes",model.In_notes),
                new MySqlParameter("In_faqurl",model.In_faq_urltype),
                new MySqlParameter("In_video_filenamef",model.In_video_filenamef),
                new MySqlParameter("In_video_filepathf",model.In_video_filepathf),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_FAQS", param);
            return returnvalues;
        }


    }
}
