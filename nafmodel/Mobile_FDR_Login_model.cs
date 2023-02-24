using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
    public class Mobile_FDR_Login_model
    {
        #region detailfetch
        public class FDRLoginfetch
        {
            public string In_user_code1 { get; set; }
            public string In_user_name { get; set; }
            public string In_role_code { get; set; }
            public string In_role_name { get; set; }
            public string In_orgn_code { get; set; }
            public string In_location { get; set; }
            public string In_Reponse { get; set; }
        }
        public class FDRLoginfetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public FDRLoginfetch FDRLoginfetch { get; set; }
            public string instance { get; set; }
            public string In_user_code { get; set; }
            public string In_user_pwd { get; set; }

        }
        public class FDRLoginfetchApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class FDRLoginfetchApplication
        {
            public FDRLoginfetchContext context { get; set; }
            public FDRLoginfetchApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region loginfetch
        public class Loginfetch
        {

            public string In_parent_code { get; set; }
            public string In_orgn_desc { get; set; }
            public string In_orgn_code { get; set; }
        }
        public class LoginfetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public List<Loginfetch> List { get; set; }
            public string In_user_code { get; set; }
            public string In_user_pwd { get; set; }
            public string In_Reponse { get; set; }
            public string instance { get; set; }
        }
        public class LoginfetchApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class LoginfetchApplication
        {
            public LoginfetchContext context { get; set; }
            public LoginfetchApplicationException ApplicationException { get; set; }

        }

        #endregion

        #region forgot save model
        public class Header
        {
            public string user_code { get; set; }
            public string secquestion_code { get; set; }
            public string secquestion_answer { get; set; }
            public string user_pwd { get; set; }
            public string mode_flag { get; set; }

        }
        public class Context
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public Header Header { get; set; }

        }
        public class Document
        {
            public Context context { get; set; }

        }
        public class Application
        {
            public Document document { get; set; }

        }
        #endregion
    }

}


