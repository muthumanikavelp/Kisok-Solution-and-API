using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_FAQS_Model;

namespace nafdatamodel
{
    public static class FAQS_Trans
    {
        public static FAQSCategory TranslateAsFaqsCat(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new FAQSCategory();
            if (reader.IsColumnExists("out_faqscategory_Id"))
                item.out_faqscategory_Id = SqlHelper.GetNullableString(reader, "out_faqscategory_Id");
            if (reader.IsColumnExists("out_faqscategory"))
                item.out_faqscategory = SqlHelper.GetNullableString(reader, "out_faqscategory");
            return item;
        }
        public static List<FAQSCategory> TranslateAsFAQSCatList(this MySqlDataReader reader)
        {
            var list = new List<FAQSCategory>();
            while (reader.Read())
            {
                list.Add(TranslateAsFaqsCat(reader, true));
            }
            return list;
        }

        public static FAQSQuestions TranslateAsFaqsQuestions(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new FAQSQuestions();
            if (reader.IsColumnExists("out_faqscategory_Id"))
                item.out_faqscategory_Id = SqlHelper.GetNullableString(reader, "out_faqscategory_Id");
            if (reader.IsColumnExists("out_faq_question"))
                item.out_faq_question = SqlHelper.GetNullableString(reader, "out_faq_question");
            return item;
        }
        public static List<FAQSQuestions> TranslateAsFAQSQuestionsret(this MySqlDataReader reader)
        {
            var list = new List<FAQSQuestions>();
            while (reader.Read())
            {
                list.Add(TranslateAsFaqsQuestions(reader, true));
            }
            return list;
        }

        public static FAQSAnswers TranslateAsFaqsAnswers(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new FAQSAnswers();
            if (reader.IsColumnExists("In_faq_gid"))
                item.In_faq_gid = SqlHelper.GetNullableInt32(reader, "In_faq_gid");
            if (reader.IsColumnExists("out_faq_question"))
                item.out_faq_question = SqlHelper.GetNullableString(reader, "out_faq_question");
            if (reader.IsColumnExists("out_faq_answer"))
                item.out_faq_answer = SqlHelper.GetNullableString(reader, "out_faq_answer");
            if (reader.IsColumnExists("out_keyword"))
                item.out_keyword = SqlHelper.GetNullableString(reader, "out_keyword");
            if (reader.IsColumnExists("out_faq_date"))
                item.out_faq_date = SqlHelper.GetNullableString(reader, "out_faq_date");
            if (reader.IsColumnExists("out_faqscategory"))
                item.out_faqscategory = SqlHelper.GetNullableString(reader, "out_faqscategory");
            if (reader.IsColumnExists("filepath"))
                item.In_faq_ans_upload = SqlHelper.GetNullableString(reader, "filepath");
            if (reader.IsColumnExists("faq_notes"))
                item.In_notes = SqlHelper.GetNullableString(reader, "faq_notes");
            if (reader.IsColumnExists("faq_ques_locallang"))
                item.In_faq_ques_locallang = SqlHelper.GetNullableString(reader, "faq_ques_locallang");
            if (reader.IsColumnExists("faq_answer_locallang"))
                item.In_faq_answer_locallang = SqlHelper.GetNullableString(reader, "faq_answer_locallang");
            if (reader.IsColumnExists("faq_keywords_locallang"))
                item.In_faq_keywords_locallang = SqlHelper.GetNullableString(reader, "faq_keywords_locallang");
            if (reader.IsColumnExists("faq_url"))
                item.In_faq_urltype = SqlHelper.GetNullableString(reader, "faq_url");
            if (reader.IsColumnExists("faq_video"))
                item.In_video_filenamef = SqlHelper.GetNullableString(reader, "faq_video");
            if (reader.IsColumnExists("faq_filepath"))
                item.In_video_filepathf = SqlHelper.GetNullableString(reader, "faq_filepath");

            return item;
        }
        public static FAQSAnswers  TranslateAsFAQSAnswersret(this MySqlDataReader reader)
        {
            var list = new FAQSAnswers();
            while (reader.Read())
            {
                list=TranslateAsFaqsAnswers(reader, true);
                
            }
            return list;
        }

        public static FAQSList TranslateAsFaqsList(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new FAQSList();
            if (reader.IsColumnExists("In_faq_gid"))
                item.In_faq_gid = SqlHelper.GetNullableInt32 (reader, "In_faq_gid");
            if (reader.IsColumnExists("out_faq_date"))
                item.out_faq_date = SqlHelper.GetNullableString(reader, "out_faq_date");
            if (reader.IsColumnExists("out_faqscategory"))
                item.out_faqscategory = SqlHelper.GetNullableString(reader, "out_faqscategory");
            if (reader.IsColumnExists("out_faq_question"))
                item.out_faq_question = SqlHelper.GetNullableString(reader, "out_faq_question");
            if (reader.IsColumnExists("out_faq_answer"))
                item.out_faq_answer = SqlHelper.GetNullableString(reader, "out_faq_answer");
            if (reader.IsColumnExists("out_keyword"))
                item.out_keyword = SqlHelper.GetNullableString(reader, "out_keyword");
            if (reader.IsColumnExists("faq_url"))
                item.In_faq_urltype = SqlHelper.GetNullableString(reader, "faq_url");

            return item;
        }
        public static List<FAQSList> TranslateAsFAQSListsret(this MySqlDataReader reader)
        {
            var list = new List<FAQSList>();
            while (reader.Read())
            {
                list.Add(TranslateAsFaqsList(reader, true));
            }
            return list;
        }
    }
}
