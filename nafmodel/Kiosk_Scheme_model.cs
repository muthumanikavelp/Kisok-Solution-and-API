using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class Kiosk_Scheme_model
    {
        #region list Scheme category model
        [DataContract]
        public class schemeCategory
        {
            [DataMember(Name = "out_schemecategory_Id")]
            public string out_schemecategory_Id { get; set; }
            [DataMember(Name = "out_schemecategory")]
            public string out_schemecategory { get; set; }
        }
        public class schemeCategoryContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public List<schemeCategory> Category { get; set; }
        }      

        public class schemeCategoryRootObject
        {
            public schemeCategoryContext context { get; set; }
        }
        #endregion
        #region listschemelist
        [DataContract]
        public class schemelist
        {
            [DataMember(Name = "out_schemecategory_Id")]
            public string out_schemecategory_Id { get; set; }
            [DataMember(Name = "out_scheme_name")]
            public string out_scheme_name { get; set; }
        }
        public class schemeContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_schemecat_Id")]
            public int In_schemecat_Id { get; set; }

            public List<schemelist> schemelist { get; set; }
        }        

        public class schemeRootObject
        {
            public schemeContext context { get; set; }
        }
        #endregion
        #region list get scheme model
        [DataContract]
        public class schemedata
        {
            [DataMember(Name = "out_scheme_name")]
            public string out_scheme_name { get; set; }
            [DataMember(Name = "out_scheme_description")]
            public string out_scheme_description { get; set; }
            [DataMember(Name = "scheme_url")]
            public string scheme_url { get; set; }
            [DataMember(Name = "upload_path")]
            public string upload_path { get; set; }  
        }
        public class GetSchemeContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_scheme_gid")]
            public int In_scheme_gid { get; set; }

            public schemedata schemedata { get; set; }
        }
       

        public class FchemeRootObject
        {
            public GetSchemeContext context { get; set; }          
        }
        #endregion
        #region Save model
        [DataContract]
        public class SaveScheme
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_scheme_gid")]
            public int In_scheme_gid { get; set; }

            [DataMember(Name = "In_scheme_category")]
            public string In_scheme_category { get; set; }

            [DataMember(Name = "In_scheme_date")]
            public string In_scheme_date { get; set; }
            [DataMember(Name = "In_scheme_state")]
            public string In_scheme_state { get; set; }
            [DataMember(Name = "In_scheme_schname")]
            public string In_scheme_schname { get; set; }

            [DataMember(Name = "In_scheme_description")]
            public string In_scheme_description { get; set; }
            [DataMember(Name = "In_scheme_keyword")]
            public string In_scheme_keyword { get; set; }

            [DataMember(Name = "In_scheme_schname_locallang")]
            public string In_scheme_schname_locallang { get; set; }

            [DataMember(Name = "In_schema_des_locallang")]
            public string In_schema_des_locallang { get; set; }

            [DataMember(Name = "In_scheme_keyword_locallang")]
            public string In_scheme_keyword_locallang { get; set; }
            [DataMember(Name = "In_scheme_url")]
            public string In_scheme_url { get; set; }
            [DataMember(Name = "In_scheme_upload")]
            public string In_scheme_upload { get; set; }
            [DataMember(Name = "In_scheme_status")]
            public string In_scheme_status { get; set; }
            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
        }
        public class Retrnmesg
        {
            [DataMember(Name = "out_msg")]
            public string out_msg { get; set; }

            [DataMember(Name = "out_result")]
            public string out_result { get; set; }

        }
        #endregion
        #region list model
        [DataContract]
        public class SchemesSummary
        {
            [DataMember(Name = "scheme_id")]
            public int scheme_id { get; set; }
            [DataMember(Name = "out_scheme_date")]
            public string out_scheme_date { get; set; }

            [DataMember(Name = "out_scheme_category")]
            public string out_scheme_category { get; set; }
            [DataMember(Name = "out_scheme_schname")]
            public string out_scheme_schname { get; set; }

            [DataMember(Name = "out_scheme_description")]
            public string out_scheme_description { get; set; }
            [DataMember(Name = "out_scheme_keyword")]
            public string out_scheme_keyword { get; set; }
            [DataMember(Name = "out_scheme_url")]
            public string out_scheme_url { get; set; }
            [DataMember(Name = "out_scheme_upload")]
            public string out_scheme_upload { get; set; }

        }
        public class SchemesSummaryContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

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
        #region list get scheme model
        [DataContract]
        public class schemeGetdata
        {
            [DataMember(Name = "out_scheme_id")]
            public int out_scheme_id { get; set; }
            [DataMember(Name = "out_scheme_category")]
            public string out_scheme_category { get; set; }
            [DataMember(Name = "out_scheme_date")]
            public string out_scheme_date { get; set; }
            [DataMember(Name = "out_scheme_state")]
            public string out_scheme_state { get; set; }
            [DataMember(Name = "out_scheme_name")]
            public string out_scheme_name { get; set; }
            [DataMember(Name = "out_scheme_description")]
            public string out_scheme_description { get; set; }
        
            [DataMember(Name = "out_scheme_keyword")]
            public string out_scheme_keyword { get; set; }
            [DataMember(Name = "out_scheme_schname_locallang")]
            public string out_scheme_schname_locallang { get; set; }
            [DataMember(Name = "out_schema_des_locallang")]
            public string out_schema_des_locallang { get; set; }
            [DataMember(Name = "out_scheme_keyword_locallang")]
            public string out_scheme_keyword_locallang { get; set; }
            [DataMember(Name = "out_scheme_url")]
            public string out_scheme_url { get; set; }

            [DataMember(Name = "out_scheme_upload")]
            public string out_scheme_upload { get; set; }
            
        }
        public class GetSchemedataContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_scheme_gid")]
            public int In_scheme_gid { get; set; }

            public schemeGetdata schemeFetch { get; set; }
        }


        public class schemeGetRootObject
        {
            public GetSchemedataContext context { get; set; }
        }
        #endregion
       
    }
}
