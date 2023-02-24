using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class Mobile_Kiosk_Irrigation_model
    {
        #region mobile save Irrigation
        public class mobsaveirrigation
        {
            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "irrigation_gid")]
            public int irrigation_gid { get; set; }

            [DataMember(Name = "farmer_gid")]
            public int farmer_gid { get; set; }

            [DataMember(Name = "farmer_code")]
            public string farmer_code { get; set; }

            [DataMember(Name = "farmer_name")]
            public string farmer_name { get; set; }

            [DataMember(Name = "Tran_Id")]
            public string Tran_Id { get; set; }

            [DataMember(Name = "collection_date")]
            public string collection_date { get; set; }

            [DataMember(Name = "sample_status")]
            public string sample_status { get; set; }

            [DataMember(Name = "sample_drawnby")]
            public string sample_drawnby { get; set; }

            [DataMember(Name = "customer_ref")]
            public string customer_ref { get; set; }

            [DataMember(Name = "mode_flag")]
            public string mode_flag { get; set; }
        }

        public class Retrnmesg
        {
            [DataMember(Name = "out_msg")]
            public string out_msg { get; set; }

            [DataMember(Name = "out_result")]
            public string out_result { get; set; }

        }
        #endregion

    }
}
