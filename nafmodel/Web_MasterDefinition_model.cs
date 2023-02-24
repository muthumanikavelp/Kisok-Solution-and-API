using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
   public class Web_MasterDefinition_model
    {
        #region list model

        public class MasterDetailItem
        {

            public int out_master_rowid { get; set; }

            public string out_parent_code { get; set; }

            public string out_parent_descripton { get; set; }

            public string out_master_code { get; set; }

            public string out_master_description { get; set; }

            public string out_master_ll_description { get; set; }

            public string out_depend_desc { get; set; }

            public string out_status_desc { get; set; }
        }

        public class MasterContext
        {

            public string orgnId { get; set; }

            public string locnId { get; set; }

            public string userId { get; set; }

            public string localeId { get; set; }
            public string parent_code { get; set; }
            public List<MasterDetailItem> detail { get; set; }
        }

        public class MasterApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class MasterRootObject
        {

            public MasterContext context { get; set; }

            public MasterApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region singlefetch model
        public class Master_FDetail
        {

            public int out_master_rowid { get; set; }

            public string out_parent_code { get; set; }

            public string out_parent_descripton { get; set; }

            public string out_master_code { get; set; }

            public string out_master_description { get; set; }

            public string out_master_ll_description { get; set; }

            public string out_depend_desc { get; set; }

            public string out_status_desc { get; set; }
            public string out_mode_flag { get; set; }
            public string out_depend_code { get; set; }
        }
        public class Master_FContext
        {
            public string orgnId { get; set; }

            public string locnId { get; set; }

            public string userId { get; set; }

            public string localeId { get; set; }
            public string parent_code { get; set; }
            public List<Master_FDetail> detail { get; set; }
        }
        public class Master_FApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }
        public class Master_FRoot
        {

            public Master_FContext context { get; set; }

            public Master_FApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region Save model
        public class Master_HeaderSave
        {
            public string in_parent_code { get; set; }
        }

        public class Master_DetailSave
        {
            /// <summary>
            /// 
            /// </summary>
            public int out_master_rowid { get; set; }
            public int out_row_slno { get; set; }
            public string out_master_code { get; set; }
            public string out_master_description { get; set; }
            public string out_master_ll_description { get; set; }
            public string out_depend_code { get; set; }
            public string out_locallang_flag { get; set; }
            public string out_status_code { get; set; }
            public string out_row_timestamp { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class Master_ContextSave
        {
            /// <summary>
            /// 
            /// </summary>
            public string orgnId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string locnId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string localeId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Master_HeaderSave header { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Master_DetailSave> detail { get; set; }

            public string out_master_rowid { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class Master_DocumentSave
        {
            public Master_ContextSave context { get; set; }

            public ApplicationExceptionsave ApplicationException { get; set; }
        }

        public class Master_RootSave
        {
            /// <summary>
            /// 
            /// </summary>
            public Master_DocumentSave document { get; set; }
        }

        public class ApplicationExceptionsave
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }
        }
        #endregion

        #region MasterCodeScreenId
        public class MCSIHeader
        {
            public string screen_description { get; set; }
        }

        public class MCSIDetail
        {
            public int out_master_rowid { get; set; }
            public int out_row_slno { get; set; }
            public string out_parent_code { get; set; }
            public string out_parent_description { get; set; }
            public string out_master_code { get; set; }
            public string out_master_description { get; set; }
            public string out_master_ll_description { get; set; }
            public string out_depend_code { get; set; }
            public string out_depend_desc { get; set; }
            public string out_locallang_flag { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
            public string out_row_timestamp { get; set; }
            public string out_mode_flag { get; set; }
            public string kamaraj_village_id { get; set; }
            public string Kamaraj_district_id { get; set; }
        }

        public class MasterCodeScreenID
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public MCSIHeader Header { get; set; }
            public List<MCSIDetail> Detail { get; set; }
        }

        #endregion
    }
}
