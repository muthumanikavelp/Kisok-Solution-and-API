using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_FAQS_Model;

namespace nafservice
{
    public class Kiosk_FAQS_Service
    {

        Kiosk_FAQS_Datamodel objdatamodel = new Kiosk_FAQS_Datamodel();
        public FAQSCategoryContext GetFAQSCatList(string org, string locn, string user, string lang, string Mysql)
        {
            FAQSCategoryContext objfinal = new FAQSCategoryContext();

            List<FAQSCategory> ObjFetchAll = new List<FAQSCategory>();
            try
            {
                ObjFetchAll = objdatamodel.GetFAQSCatList(org, locn, user, lang, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Category = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public FAQSQuestionContext GetFAQSQuestions(string org, string locn, string user, string lang, int In_faqscat_Id, string Mysql,string Keyword)
        {
            FAQSQuestionContext objfinal = new FAQSQuestionContext();

            List<FAQSQuestions> ObjFetchAll = new List<FAQSQuestions>();
            try
            {
                ObjFetchAll = objdatamodel.GetFAQSQuestions(org, locn, user, lang, In_faqscat_Id, Mysql, Keyword);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_faqscat_Id = In_faqscat_Id;
                objfinal.Questions = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        public FAQSAnswersContext GetFAQSAnswers(string org, string locn, string user, string lang, int In_faq_gid, string Mysql)
        {
            FAQSAnswersContext objfinal = new FAQSAnswersContext();

            FAQSAnswers ObjFetchAll = new FAQSAnswers();
            try
            {
                ObjFetchAll = objdatamodel.GetFAQSAnswers(org, locn, user, lang, In_faq_gid, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_faq_gid = In_faq_gid;
                objfinal.Answers = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public FAQSListContext GetFAQSList(string org, string locn, string user, string lang, string Mysql)
        {
            FAQSListContext objfinal = new FAQSListContext();

            List<FAQSList> ObjFetchAll = new List<FAQSList>();
            try
            {
                ObjFetchAll = objdatamodel.GetFAQSList(org, locn, user, lang, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.List = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public string[] NewFAQSsave_Srv(SaveFAQS ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = objdatamodel.NewFAQSsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }

    }
}
