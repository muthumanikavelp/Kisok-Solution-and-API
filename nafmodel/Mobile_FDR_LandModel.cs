using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
   public class Mobile_FDR_LandModel
    {
        #region SaveFarmer Land model
        [DataContract]
        public class SaveFLand
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_land_gid")]
            public int In_land_gid { get; set; }

            [DataMember(Name = "In_farmer_gid")]
            public string In_farmer_gid { get; set; }          

            [DataMember(Name = "In_land_type")]
            public string In_land_type { get; set; }
            [DataMember(Name = "In_land_ownership")]
            public string In_land_ownership { get; set; }

            [DataMember(Name = "In_land_soiltype")]
            public string In_land_soiltype { get; set; }
            [DataMember(Name = "In_land_irrsou")]
            public string In_land_irrsou { get; set; }

            [DataMember(Name = "In_land_noofacres")]
            public string In_land_noofacres { get; set; }

            [DataMember(Name = "In_land_longtitude")]
            public string In_land_longtitude { get; set; }

            [DataMember(Name = "In_land_latitude")]
            public string In_land_latitude { get; set; }
           
            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }

            [DataMember(Name = "In_land_surveyno")]
            public string In_land_surveyno { get; set; }
            
        }

        #endregion
        #region fetch list model
        [DataContract]
        public class FarmerLandfecth
        {
            [DataMember(Name = "out_farmer_gid")]
            public int out_farmer_gid { get; set; }
            [DataMember(Name = "out_land_gid")]
            public int out_land_gid { get; set; }

            [DataMember(Name = "out_farmer_code")]
            public string out_farmer_code { get; set; }
            [DataMember(Name = "out_farmer_name")]
            public string out_farmer_name { get; set; }
            [DataMember(Name = "out_land_type")]
            public string out_land_type { get; set; }
            [DataMember(Name = "out_land_type_desc")]
            public string out_land_type_desc { get; set; }
            [DataMember(Name = "out_land_ownership")]
            public string out_land_ownership { get; set; }
            [DataMember(Name = "out_land_ownership_desc")]
            public string out_land_ownership_desc { get; set; }
            [DataMember(Name = "out_land_soiltype")]
            public string out_land_soiltype { get; set; }
            [DataMember(Name = "out_land_soiltype_desc")]
            public string out_land_soiltype_desc { get; set; }
            [DataMember(Name = "out_land_irrsou")]
            public string out_land_irrsou { get; set; }
            [DataMember(Name = "out_land_irrsou_desc")]
            public string out_land_irrsou_desc { get; set; }
            [DataMember(Name = "out_land_noofacres")]
            public string out_land_noofacres { get; set; }
            [DataMember(Name = "out_land_longtitude")]
            public string out_land_longtitude { get; set; }
            [DataMember(Name = "out_land_latitude")]
            public string out_land_latitude { get; set; }
            [DataMember(Name = "In_land_surveyno")]
            public string In_land_surveyno { get; set; }

        }
        public class FarmerLandContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            [DataMember(Name = "In_farmer_gid")]
            public int In_farmer_gid { get; set; }
            public List<FarmerLandfecth> Land { get; set; }

        }

        public class FarmerLandApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class FarmerLandRootObject
        {

            public FarmerLandContext context { get; set; }

            public FarmerLandApplicationException ApplicationException { get; set; }
        }
        #endregion
    }
}
