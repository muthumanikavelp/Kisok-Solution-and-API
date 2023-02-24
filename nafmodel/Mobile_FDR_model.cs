using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace nafmodel
{
    public class Mobile_FDR_model
    {
        #region farmer detail
        public class FarmerProfileDetails
        {
            public int sl_no { get; set; }
            public string tab_name { get; set; }
            public string dynamic_list { get; set; }

        }
        public class MFDRContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<FarmerProfileDetails> FarmerProfileDetails { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public string instance { get; set; }

        }
        public class MFDRApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class MFDRApplication
        {
            public MFDRContext context { get; set; }
            public MFDRApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region farmerbank
        public class MFBankDtl
        {
            public int bank_rowid { get; set; }
            public string bank_code { get; set; }
            public string bank_name { get; set; }
            public string branch_name { get; set; }
            public string ifsc_code { get; set; }
            public string status_desc { get; set; }
        }
        public class MFContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<MFBankDtl> BankDtl { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public string instance { get; set; }

        }
        public class MFApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class MFApplication
        {
            public MFContext context { get; set; }
            public MFApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region master fdr

        public class MFMDetail
        {
            public int out_master_rowid { get; set; }
            public string out_parent_code { get; set; }
            public string out_master_code { get; set; }
            public string out_master_description { get; set; }
            public string out_depend_code { get; set; }
            public string out_depend_desc { get; set; }
            public string out_locallang_flag { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
        }
        public class VarietyDetails
        {
            public int Out_master_rowid { get; set; }
            public string Out_master_code { get; set; }
            public string Out_master_desc { get; set; }
        }
        public class QualityDetails
        {
            public int Out_qlt_rowid { get; set; }
            public string Out_qlt_code { get; set; }
            public string Out_qlt_name { get; set; }
            public string Out_QualityRange { get; set; }
        }

        public class MFMContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<MFMDetail> detail { get; set; }
            public IList<VarietyDetails> VarityDt { get; set; }
            public IList<QualityDetails> QualityDt { get; set; }
            public IList<VarietyDetails> VehicleDt { get; set; }
            public IList<VarietyDetails> DestinationDt { get; set; }

            public string screen_Id { get; set; }
            public string module { get; set; }
            public string instance { get; set; }
        }
        public class MFMApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class MFMApplication
        {
            public MFMContext context { get; set; }
            public MFMApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region doc num
        public class Farmerdocnum
        {
            public string activity_code { get; set; }
            public string format_value { get; set; }
        }
        public class docnumContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public Farmerdocnum Farmerdocnum { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public string instance { get; set; }

        }
        public class docnumApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class docnumApplication
        {
            public docnumContext context { get; set; }
            public docnumApplicationException ApplicationException { get; set; }

        }
        #endregion
    }

}
