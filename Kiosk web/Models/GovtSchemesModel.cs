using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class GovtSchemesModel
    {
     
        
        
        #region Save model
      
        public class SaveScheme
        {
           
            public string orgnId { get; set; }

         
            public string locnId { get; set; }

         
            public string userId { get; set; }

          
            public string localeId { get; set; }
           
            public int In_scheme_gid { get; set; }

           
            public string In_scheme_category { get; set; }

           
            public string In_scheme_date { get; set; }
            public string In_scheme_state { get; set; }
            public string In_scheme_schname { get; set; }

          
            public string In_scheme_description { get; set; }
          
            public string In_scheme_keyword { get; set; }

          
            public string In_scheme_schname_locallang { get; set; }

          
            public string In_schema_des_locallang { get; set; }

         
            public string In_scheme_keyword_locallang { get; set; }
            public string In_scheme_url { get; set; }
            public string In_scheme_upload { get; set; }
           
            public string In_scheme_status { get; set; }
          
            public string In_mode_flag { get; set; }
       
        }

        #endregion
        #region list get scheme 
     
        public class schemeGetdata
        {
          public int out_scheme_id { get; set; }
            public string out_scheme_category { get; set; }
           
            public string out_scheme_date { get; set; }
         
            public string out_scheme_state { get; set; }
          
            public string out_scheme_name { get; set; }
           
            public string out_scheme_description { get; set; }

         
            public string out_scheme_keyword { get; set; }
           
            public string out_scheme_schname_locallang { get; set; }
          
            public string out_schema_des_locallang { get; set; }
          
            public string out_scheme_keyword_locallang { get; set; }
            public string out_scheme_url { get; set; }
            public string out_scheme_upload { get; set; }
        }
        public class GetSchemedataContext
        {
          
            public string orgnId { get; set; }

         
            public string locnId { get; set; }

         
            public string userId { get; set; }

          
            public string localeId { get; set; }
          
            public int In_scheme_gid { get; set; }

            public schemeGetdata schemeFetch { get; set; }
        }


        public class schemeGetRootObject
        {
            public GetSchemedataContext context { get; set; }
        }
        #endregion
        #region list model

        public class SchemesSummary
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int scheme_id { get; set; }
            public string out_scheme_date { get; set; }     
            public string out_scheme_category { get; set; }     
            public string out_scheme_schname { get; set; }         
            public string out_scheme_description { get; set; }        
            public string out_scheme_keyword { get; set; }
            public string out_scheme_url { get; set; }
            public string out_scheme_upload { get; set; }
        }
        public class SchemesSummaryContext
        {
        public List<SchemesSummary> Summary { get; set; }

        }

        public class SchemesSummaryApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class SchemesSummaryRootObject
        {

            public SchemesSummaryContext context { get; set; }

            public SchemesSummaryApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region token
        public class token
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class gettoken
        {
            public string token { get; set; }
        }
        #endregion

       
    }
}
