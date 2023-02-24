using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Kiosk_Scheme_model;

namespace nafdatamodel
{
    public class kiosk_scheme_datamodel
    {       
            public List<schemeCategory> GetSchemeCatList(string org, string locn, string user, string lang, string Mysql)
            {
                MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                 
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<schemeCategory>>(Mysql,
                "Kiosk_fetch_schemeCategory", t => t.TranslateAsschemeCatList(), myParamArray);

            
        }
            public List<schemelist> Getschemelist(string org, string locn, string user, string lang, int In_schemecat_Id, string Mysql,string keyword)
            {
                MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_schemecat_Id",In_schemecat_Id),
                 new MySqlParameter("In_keyword",keyword),
            };
                return SqlHelper.ExtecuteProcedureReturnData<List<schemelist>>(Mysql,
                    "Kiosk_fetch_Schemelist", t => t.TranslateAschemelist(), myParamArray);
            }
            public schemedata Getschemedata_db(string org, string locn, string user, string lang, int In_scheme_gid, string Mysql)
            {
                MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_scheme_gid",In_scheme_gid),

            };
                return SqlHelper.ExtecuteProcedureReturnData<schemedata> (Mysql,
                    "Kiosk_fetch_schemedata", t => t.Translateschemedata(), myParamArray);
            }
            public string[] NewSchemesave_db(SaveScheme model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userId),
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_scheme_gid",model.In_scheme_gid),
                new MySqlParameter("In_scheme_category",model.In_scheme_category),
                new MySqlParameter("In_scheme_date",model.In_scheme_date),
                 new MySqlParameter("In_scheme_state",model.In_scheme_state),
                new MySqlParameter("In_scheme_schname",model.In_scheme_schname),
                new MySqlParameter("In_scheme_description",model.In_scheme_description),
                new MySqlParameter("In_scheme_keyword",model.In_scheme_keyword),
                new MySqlParameter("In_scheme_schname_locallang",model.In_scheme_schname_locallang),
                new MySqlParameter("In_schema_des_locallang",model.In_schema_des_locallang),
                new MySqlParameter("In_scheme_keyword_locallang",model.In_scheme_keyword_locallang),
                 new MySqlParameter("In_scheme_url",model.In_scheme_url),
                new MySqlParameter("In_scheme_upload",model.In_scheme_upload),
                new MySqlParameter("In_scheme_status",model.In_scheme_status),
                new MySqlParameter("In_mode_flag",model.In_mode_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_schemes", param);
            return returnvalues;
        }
        public List<SchemesSummary> GetSchemeSummary_db(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<SchemesSummary>>(Mysql,
                "Kiosk_fetch_SchemeSummary", t => t.TranslateAschemeSummaryView(), myParamArray);
        }

        public schemeGetdata GetschemeGetdata_db(string org, string locn, string user, string lang, int In_scheme_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_scheme_gid",In_scheme_gid),

            };
            return SqlHelper.ExtecuteProcedureReturnData<schemeGetdata>(Mysql,
                "Kiosk_fetch_schemeGetList", t => t.TranslateschemeGetdata(), myParamArray);
        }
    }
    }
