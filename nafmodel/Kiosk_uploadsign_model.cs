using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class Kiosk_uploadsign_model
    {
        #region uploadsignlist
        public class uploadsigncontext
        {
            public List<uploadsignlist> list { get; set; }
        }
        public class uploadsignlist
        {
            public int signature_rowid { get; set; }
            public string signature_tran_id { get; set; }
            public string signature_name { get; set; }
            public string signature_desgn { get; set; }
            public string signature_image { get; set; }
          
        }
        #endregion

        #region fetch uploadsign model
        [DataContract]
        public class uploadsignfetch
        {

            [DataMember(Name = "signature_rowid")]
            public int signature_rowid { get; set; }

            [DataMember(Name = "signature_tran_id")]
            public string signature_tran_id { get; set; }

            [DataMember(Name = "signature_name")]
            public string signature_name { get; set; }

            [DataMember(Name = "signature_desgn")]
            public string signature_desgn { get; set; }

            [DataMember(Name = "signature_image")]
            public string signature_image { get; set; }

          
        }
        public class uploadsignfetchContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_signature_rowid")]
            public int In_signature_rowid { get; set; }

            public uploadsignfetch uploadsign { get; set; }

        }

        public class uploadsignfetchObject
        {
            public uploadsignfetchContext context { get; set; }
        }
        #endregion

        public class Retrnmesg
        {
            [DataMember(Name = "out_msg")]
            public string out_msg { get; set; }

            [DataMember(Name = "out_result")]
            public string out_result { get; set; }

        }

        #region Save model
        [DataContract]
        public class Saveuploadsign
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_signature_rowid")]
            public int In_signature_rowid { get; set; }

            [DataMember(Name = "In_signature_tran_id")]
            public string In_signature_tran_id { get; set; }

            [DataMember(Name = "In_signature_name")]
            public string In_signature_name { get; set; }
            [DataMember(Name = "In_signature_desgn")]
            public string In_signature_desgn { get; set; }
            
            [DataMember(Name = "In_signature_image")]
            public string In_signature_image { get; set; }
           
            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }
        }
        #endregion
    }
}
