using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class UploadSignaturemodel
    {
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
        #region list
        public class uploadsigncontext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
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
        public class uploadsign
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
        }
        #endregion
        #region fetch advertisement model       
        public class Uploadsignfetch
        {
            public int signature_rowid { get; set; }
            public string signature_tran_id { get; set; }
            public string signature_name { get; set; }
            public string signature_desgn { get; set; }
            public string signature_image { get; set; }
        }
        public class uploadsignfetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_signature_rowid { get; set; }
            public Uploadsignfetch UploadSign { get; set; }
        }

        public class uploadsignfetchObject
        {
            public uploadsignfetchContext context { get; set; }
        }
        #endregion
        #region Save model

        public class Saveuploadsign
        {
         
            public string orgnId { get; set; } 
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_signature_rowid { get; set; }
            public string In_signature_tran_id { get; set; }
            public string In_signature_name { get; set; }
            public string In_signature_desgn { get; set; }
            public string In_signature_image { get; set; }
            public string In_mode_flag { get; set; }
        }
        #endregion

    
    }
}
