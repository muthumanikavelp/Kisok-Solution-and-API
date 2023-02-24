using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_Scheme_model;

namespace nafservice
{
   public class kiosk_Scheme_service
    {
        kiosk_scheme_datamodel objdatamodel = new kiosk_scheme_datamodel();
        public schemeCategoryContext GetSchemeCatList(string org, string locn, string user, string lang, string Mysql )
        {
            schemeCategoryContext objfinal = new schemeCategoryContext();

            List<schemeCategory> ObjFetchAll = new List<schemeCategory>();
            try
            {
                ObjFetchAll = objdatamodel.GetSchemeCatList(org, locn, user, lang, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Category = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public schemeContext Getschemelist_srv(string org, string locn, string user, string lang, int In_schemecat_Id, string Mysql,string keyword)
        {
            schemeContext objfinal = new schemeContext();

            List<schemelist> ObjFetchAll = new List<schemelist>();
            try
            {
                ObjFetchAll = objdatamodel.Getschemelist(org, locn, user, lang, In_schemecat_Id, Mysql, keyword);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_schemecat_Id = In_schemecat_Id;
                objfinal.schemelist = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public GetSchemeContext Getschemedata(string org, string locn, string user, string lang, int In_scheme_gid, string Mysql)
        {
            GetSchemeContext objfinal = new GetSchemeContext();

            schemedata ObjFetchAll = new schemedata();
            try
            {
                ObjFetchAll = objdatamodel.Getschemedata_db(org, locn, user, lang, In_scheme_gid, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_scheme_gid = In_scheme_gid;

                objfinal.schemedata = ObjFetchAll;
               

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public string[] NewSchemesave_Srv(SaveScheme ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = objdatamodel.NewSchemesave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }

        public SchemesSummaryContext GetSchemeSummary_srv(string org, string locn, string user, string lang, string Mysql)
        {
            SchemesSummaryContext objfinal = new SchemesSummaryContext();

            List<SchemesSummary> ObjFetchAll = new List<SchemesSummary>();
            try
            {
                ObjFetchAll = objdatamodel.GetSchemeSummary_db(org, locn, user, lang, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Summary = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public GetSchemedataContext GetschemeGetdata(string org, string locn, string user, string lang, int In_scheme_gid, string Mysql)
        {
            GetSchemedataContext objfinal = new GetSchemedataContext();

           schemeGetdata ObjFetchAll = new schemeGetdata();
            try
            {
                ObjFetchAll = objdatamodel.GetschemeGetdata_db(org, locn, user, lang, In_scheme_gid, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_scheme_gid = In_scheme_gid;
                objfinal.schemeFetch = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
    }
}