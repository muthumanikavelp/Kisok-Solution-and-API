using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class Attachmentmodel
    {
        public class attchementsave
        {
            public string description { get; set; }
            public string filename { get; set; }
            public string document { get; set; }
            public string userId { get; set; }
            public string locid { get; set; }
            public string filepath { get; set; }
            public int soil_gid { get; set; }
            public string model_flag { get; set; }

        }
        public class attchementfetch
        {
            public string description { get; set; }
            public string filename { get; set; }
            public string document { get; set; }
            public string userId { get; set; }
            public string locid { get; set; }
            public string filepath { get; set; }
            public int attach_gid { get; set; }
            public string model_flag { get; set; }
        }
        public class attachcontext
        {
            public string userId { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public string doc_type { get; set; }
            public string id { get; set; }
            public List<attchementfetch> attach { get; set; }
        }
        public class notessave
        {
            public string locnId { get; set; }
            public string userId { get; set; }
            public string id { get; set; }
            public string notesdata { get; set; }
            public string screenname { get; set; }
            public string model_flag { get; set; }
        }
        public class attachdelete
        {
            public int gid { get; set; }
            public string userID { get; set; }
            public string locId { get; set; }
            public string model_flag { get; set; }
        }
    }
}
