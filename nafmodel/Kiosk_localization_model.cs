using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
  public class Kiosk_localization_model
    {
        #region localizationlist
        public class localizationcontext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            public List<localizationlist> list { get; set; }
        }
        public class localizationlist
        {           
            [DataMember(Name = "activity")]
            public string activity { get; set; }
            [DataMember(Name = "loc_english")]
            public string loc_english { get; set; }
            [DataMember(Name = "loc_tamil")]
            public string loc_tamil { get; set; }
         }
        #endregion
    }
}
