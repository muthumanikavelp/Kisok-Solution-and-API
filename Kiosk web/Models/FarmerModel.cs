using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class FarmerModel
    {

        #region SummaryList


        public class FarmerSummary
        {
     
            public int farmer_rowid { get; set; }
            public string farmer_code { get; set; }
            public string farmer_name { get; set; }
            public string sur_name { get; set; }
            public string fhw_name { get; set; }
            public string farmer_dob { get; set; }
            public string farmer_addr1 { get; set; }
            public string farmer_country { get; set; }
            public string farmer_country_desc { get; set; }
            public string farmer_state { get; set; }
            public string farmer_state_desc { get; set; }
            public string farmer_dist { get; set; }
            public string farmer_dist_desc { get; set; }
            public string farmer_taluk { get; set; }
            public string farmer_taluk_desc { get; set; }
            public string farmer_panchayat { get; set; }
            public string farmer_panchayat_desc { get; set; }
            public string farmer_village { get; set; }
            public string farmer_village_desc { get; set; }
            public string Farmer_Mobileno { get; set; }
            public string farmer_pincode { get; set; }
            public string Farmer_InsertedDate { get; set; }

        }
        public class farmerSummaryContext
        {
           
            public string orgnId { get; set; }

          
            public string locnId { get; set; }

         
            public string userId { get; set; }

            
            public string localeId { get; set; }

            public List<FarmerSummary> Summary { get; set; }

        }

        public class farmerSummary
        {

            public string orgnId { get; set; }


            public string locnId { get; set; }


            public string userId { get; set; }


            public string localeId { get; set; }


        }
        #endregion

        #region fetch Land model
 
        public class FarmerLandfecth
        {
    
            public int out_farmer_gid { get; set; }
      
            public int out_land_gid { get; set; }

   
            public string out_farmer_code { get; set; }
      
            public string out_farmer_name { get; set; }
      
            public string out_land_type { get; set; }
 
            public string out_land_type_desc { get; set; }

            public string out_land_ownership { get; set; }
       
            public string out_land_ownership_desc { get; set; }
        
            public string out_land_soiltype { get; set; }
         
            public string out_land_soiltype_desc { get; set; }
          
            public string out_land_irrsou { get; set; }
           
            public string out_land_irrsou_desc { get; set; }
           
            public string out_land_noofacres { get; set; }
          
            public string out_land_longtitude { get; set; }
          
            public string out_land_latitude { get; set; }
        }
        public class FarmerLandContext
        {
         
            public string orgnId { get; set; }

         
            public string locnId { get; set; }

         
            public string userId { get; set; }

       
            public string localeId { get; set; }

          
            public int In_farmer_gid { get; set; }
            public List<FarmerLandfecth> Land { get; set; }

        }

      
        #endregion
    }
}
