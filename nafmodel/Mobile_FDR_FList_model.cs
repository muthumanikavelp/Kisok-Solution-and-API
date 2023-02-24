using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
   public class Mobile_FDR_FList_model
    {
        #region list
        public class FDRFarmerList
        {
            public int farmer_rowid { get; set; }
            public string farmer_code { get; set; }
            public string farmer_name { get; set; }
            public string farmer_dist { get; set; }
            public string farmer_dist_desc { get; set; }
            public string farmer_taluk { get; set; }
            public string farmer_taluk_desc { get; set; }
            public string farmer_panchayat { get; set; }
            public string farmer_panchayat_desc { get; set; }
            public string farmer_village { get; set; }
            public string farmer_village_desc { get; set; }
        }


        public class FDRFarmerContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public List<FDRFarmerList> List { get; set; }
            public string instance { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
        }
        public class FDRFarmerApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }
        }

        public class FDRFarmerRootObject
        {
            public FDRFarmerContext context { get; set; }
            public FDRFarmerApplicationException ApplicationException { get; set; }
        }
        #endregion
        #region single fetch
        public class FDRHeader
        {
            public int in_farmer_rowid { get; set; }
            public string in_farmer_code { get; set; }
            public int in_version_no { get; set; }
            public string in_photo_farmer { get; set; }
            public string in_farmer_name { get; set; }
            public string in_sur_name { get; set; }
            public string in_fhw_name { get; set; }
            public string in_farmer_dob { get; set; }
            public string in_farmer_addr1 { get; set; }
            public string in_farmer_addr2 { get; set; }
            public string in_farmer_ll_name { get; set; }
            public string in_sur_ll_name { get; set; }
            public string in_fhw_ll_name { get; set; }
            public string in_farmer_ll_addr1 { get; set; }
            public string in_farmer_ll_addr2 { get; set; }
            public string in_farmer_country { get; set; }
            public string in_farmer_country_desc { get; set; }
            public string in_farmer_country_ll_desc { get; set; }
            public string in_farmer_state { get; set; }
            public string in_farmer_state_desc { get; set; }
            public string in_farmer_state_ll_desc { get; set; }
            public string in_farmer_dist { get; set; }
            public string in_farmer_dist_desc { get; set; }
            public string in_farmer_dist_ll_desc { get; set; }
            public string in_farmer_taluk { get; set; }
            public string in_farmer_taluk_desc { get; set; }
            public string in_farmer_taluk_ll_desc { get; set; }
            public string in_farmer_panchayat { get; set; }
            public string in_farmer_panchayat_desc { get; set; }
            public string in_farmer_panchayat_ll_desc { get; set; }
            public string in_farmer_village { get; set; }
            public string in_farmer_village_desc { get; set; }
            public string in_farmer_village_ll_desc { get; set; }
            public string in_farmer_pincode { get; set; }
            public string in_farmer_pincode_desc { get; set; }
            public string in_marital_status { get; set; }
            public string in_marital_status_desc { get; set; }
            public string in_gender_flag { get; set; }
            public string in_gender_flag_desc { get; set; }
            public string in_reg_mobile_no { get; set; }
            public string in_reg_note { get; set; }
            public string in_status_code { get; set; }
            public string in_status_desc { get; set; }
            public string in_mode_flag { get; set; }
            public string in_row_timestamp { get; set; }
        }

        public class FDRKyc
        {
            public int in_farmerkyc_rowid { get; set; }
            public string in_proof_type { get; set; }
            public string in_proof_type_desc { get; set; }
            public string in_proof_doc { get; set; }
            public string in_proof_doc_desc { get; set; }
            public string in_proof_doc_no { get; set; }
            public string in_proof_doc_adharno { get; set; }
            public string in_proof_valid_till { get; set; }
            public string in_status_code { get; set; }
            public string in_status_desc { get; set; }
            public string in_mode_flag { get; set; }
            public string in_photo_kyc { get; set; }
        }

        public class FDRBank
        {
            public int in_farmerbank_rowid { get; set; }
            public string in_bank_acc_no { get; set; }
            public string in_bank_acc_type { get; set; }
            public string in_bank_acc_type_desc { get; set; }
            public string in_bank_code { get; set; }
            public string in_bank_desc { get; set; }
            public string in_branch_code { get; set; }
            public string in_branch_desc { get; set; }
            public string in_ifsc_code { get; set; }
            public string in_dflt_dr_acc { get; set; }
            public string in_dflt_dr_acc_desc { get; set; }
            public string in_dflt_cr_acc { get; set; }
            public string in_dflt_cr_acc_desc { get; set; }
            public string in_status_code { get; set; }
            public string in_status_desc { get; set; }
            public string in_mode_flag { get; set; }
        }

        public class FDRContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public FDRHeader header { get; set; }
            public List<FDRKyc> kyc { get; set; }
            public List<FDRBank> bank { get; set; }
            public string instance { get; set; }
        }

        public class FDRRootObject
        {
            public FDRContext context { get; set; }
            public object ApplicationException { get; set; }
        }
        #endregion

        #region
        public class FarmerQrContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FarmerCode { get; set; }
            public int In_farmer_gid { get; set; }
        }
        #endregion
    }

}

