using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
    public class Mobile_FDR_FHeader_model
    {
        #region save farmer header
        public class MFHHeader
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
            public string in_farmer_country { get; set; }
            public string in_farmer_state { get; set; }
            public string in_farmer_dist { get; set; }
            public string in_farmer_taluk { get; set; }
            public string in_farmer_panchayat { get; set; }
            public string in_farmer_village { get; set; }
            public string in_farmer_pincode { get; set; }
            public string in_marital_status { get; set; }
            public string in_gender_flag { get; set; }
            public string in_reg_mobile_no { get; set; }
            public string in_reg_note { get; set; }
            public string in_status_code { get; set; }
            public string in_mode_flag { get; set; }
            public string in_row_timestamp { get; set; }
            public string in_created_by { get; set; }
        }
        public class MFHContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public MFHHeader Header { get; set; }
            public string instance { get; set; }
        }
        public class MFHDocument
        {
            public MFHContext context { get; set; }
            public MFHApplicationException ApplicationException { get; set; }
        }
        public class MFHApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class MFHApplication
        {
            public MFHDocument document { get; set; }

        }
        #endregion

        #region kycsave
        public class MFKKYC
        {
            public string in_farmer_code { get; set; }
            public string in_farmer_name { get; set; }
            public int in_farmerkyc_rowid { get; set; }
            public string in_proof_type { get; set; }
            public string in_proof_doc { get; set; }
            public string in_proof_doc_no { get; set; }
            public string in_proof_doc_adharno { get; set; }
            public string in_proof_valid_till { get; set; }
            public string in_status_code { get; set; }
            public string in_mode_flag { get; set; }
            public string in_created_by { get; set; }
            public string in_modified_by { get; set; }
            public string in_photo_kyc { get; set; }
        }
        public class MFKContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public MFKKYC KYC { get; set; }
            public string instance { get; set; }
        }
        public class MFKDocument
        {
            public MFKContext context { get; set; }

            public MFKApplicationException ApplicationException { get; set; }
        }
        public class MFKApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class MFKApplication
        {
            public MFKDocument document { get; set; }

        }
        #endregion
        #region bank save
        public class MFBBank
        {
            public string in_farmer_code { get; set; }
            public int in_farmerbank_rowid { get; set; }
            public string in_bank_acc_no { get; set; }
            public string in_bank_acc_type { get; set; }
            public string in_bank_code { get; set; }
            public string in_branch_code { get; set; }
            public string in_ifsc_code { get; set; }
            public string in_dflt_dr_acc { get; set; }
            public string in_dflt_cr_acc { get; set; }
            public string in_status_code { get; set; }
            public string in_mode_flag { get; set; }
            public string in_created_by { get; set; }
            public string in_modified_by { get; set; }
        }
        public class MFBContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public MFBBank Bank { get; set; }
            public string instance { get; set; }
        }
        public class MFBDocument
        {
            public MFBContext context { get; set; }

            public MFBApplicationException ApplicationException { get; set; }
        }
        public class MFBApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class MFBApplication
        {
            public MFBDocument document { get; set; }

        }
        #endregion

        #region SummaryList

        [DataContract]
        public class FarmerSummary
        {
            [DataMember(Name = "farmer_rowid")]
            public int farmer_rowid { get; set; }
            [DataMember(Name = "farmer_code")]
            public string farmer_code { get; set; }
            [DataMember(Name = "farmer_name")]
            public string farmer_name { get; set; }
            [DataMember(Name = "sur_name")]
            public string sur_name { get; set; }
            [DataMember(Name = "fhw_name")]
            public string fhw_name { get; set; }
            [DataMember(Name = "farmer_dob")]
            public string farmer_dob { get; set; }
            [DataMember(Name = "farmer_addr1")]
            public string farmer_addr1 { get; set; }
            [DataMember(Name = "farmer_country")]
            public string farmer_country { get; set; }
            [DataMember(Name = "farmer_country_desc")]
            public string farmer_country_desc { get; set; }
            [DataMember(Name = "farmer_state")]
            public string farmer_state { get; set; }
            [DataMember(Name = "farmer_state_desc")]
            public string farmer_state_desc { get; set; }
            [DataMember(Name = "farmer_dist")]
            public string farmer_dist { get; set; }
            [DataMember(Name = "farmer_dist_desc")]
            public string farmer_dist_desc { get; set; }
            [DataMember(Name = "farmer_taluk")]
            public string farmer_taluk { get; set; }
            [DataMember(Name = "farmer_taluk_desc")]
            public string farmer_taluk_desc { get; set; }
            [DataMember(Name = "farmer_panchayat")]
            public string farmer_panchayat { get; set; }
            [DataMember(Name = "farmer_panchayat_desc")]
            public string farmer_panchayat_desc { get; set; }
            [DataMember(Name = "farmer_village")]
            public string farmer_village { get; set; }
            [DataMember(Name = "farmer_village_desc")]
            public string farmer_village_desc { get; set; }
            [DataMember(Name = "Farmer_Mobileno")]
            public string Farmer_Mobileno { get; set; }
            [DataMember(Name = "farmer_pincode")]
            public string farmer_pincode { get; set; }
            [DataMember(Name = "Farmer_InsertedDate")]
            public string Farmer_InsertedDate { get; set; }


        }
        public class farmerSummaryContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public List<FarmerSummary> Summary { get; set; }

        }

        public class FarmerSummaryApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class SchemesSummaryRootObject
        {

            public farmerSummaryContext context { get; set; }

            public FarmerSummaryApplicationException ApplicationException { get; set; }
        }
        #endregion



    }





}
