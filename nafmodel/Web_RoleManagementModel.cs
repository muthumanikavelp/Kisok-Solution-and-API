using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
    public class Web_RoleManagementModel
    {
        #region List
        public class RoleManagement
        {
            public int out_role_rowid { get; set; }
            public string out_role_code { get; set; }
            public string out_role_name { get; set; }
            public string out_orgn_level { get; set; }
            public string out_orgn_level_desc { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
        }

        public class RoleManagementContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public List<RoleManagement> List { get; set; }
        }

        public class RoleManagementApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }
        }

        public class RoleMangementList
        {
            public RoleManagementContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region SingleFetch
        public class FetchRolManagementHeader
        {
            public string out_role_code { get; set; }
            public string out_role_name { get; set; }
            public string inout_orgn_level { get; set; }
            public string out_orgn_level_desc { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
            public string out_row_timestamp { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class FetchRoleManagementDetail
        {
            public int out_rolemenu_rowid { get; set; }
            public string out_activity_code { get; set; }
            public string out_activity_desc { get; set; }
            public string out_add_perm { get; set; }
            public string out_mod_perm { get; set; }
            public string out_view_perm { get; set; }
            public string out_auth_perm { get; set; }
            public string out_inactivate_perm { get; set; }
            public string out_print_perm { get; set; }
            public string out_deny_perm { get; set; }
        }

        public class FetchRoleManagementContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public FetchRolManagementHeader header { get; set; }
            public List<FetchRoleManagementDetail> detail { get; set; }
        }

        public class RoleManagementFetch
        {
            public FetchRoleManagementContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region SaveInput

        public class SaveRMHeader
        {
            public int inout_role_rowid { get; set; }
            public string in_role_code { get; set; }
            public string in_role_name { get; set; }
            public string in_orgn_level { get; set; }
            public string in_status_code { get; set; }
            public string in_row_timestamp { get; set; }
            public string in_mode_flag { get; set; }
        }

        public class SaveRMDetail
        {
            public int out_rolemenu_rowid { get; set; }
            public string out_activity_code { get; set; }
            public string out_add_perm { get; set; }
            public string out_mod_perm { get; set; }
            public string out_view_perm { get; set; }
            public string out_auth_perm { get; set; }
            public string out_inactivate_perm { get; set; }
            public string out_print_perm { get; set; }
            public string out_deny_perm { get; set; }
        }

        public class SaveRMContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SaveRMHeader header { get; set; }
            public List<SaveRMDetail> detail { get; set; }
        }

        public class SaveRMDocument
        {
            public SaveRMContext context { get; set; }
        }

        public class SaveRMRoot
        {
            public SaveRMDocument document { get; set; }
        }

        #endregion

        #region SaveOutput
        public class RMOutputHeader
        {
            public int inout_role_rowid { get; set; }
        }

        public class RMOutputContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public RMOutputHeader header { get; set; }
        }

        public class RMOutput
        {
            public RMOutputContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
       
        #endregion
    }
    public class ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
}
