using nafdatamodel;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_uploadsign_model;

namespace nafservice
{
   public class kiosk_uploadsign_service
    {
        kiosk_uploadsign_datamodel objdatamodel = new kiosk_uploadsign_datamodel();
        public uploadsigncontext GetuploadsignList_srv(string org, string locn, string user, string lang, string Mysql)
        {

            uploadsigncontext objfinal = new uploadsigncontext();

            List<uploadsignlist> ObjFetchAll = new List<uploadsignlist>();
            try
            {
                ObjFetchAll = objdatamodel.GetuploadsignList_db(org, locn, user, lang, Mysql);
                objfinal.list = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        public uploadsignfetchContext Getuploadsignfetch_srv(string org, string locn, string user, string lang, int In_signature_rowid, string Mysql)
        {
            uploadsignfetchContext objfinal = new uploadsignfetchContext();

            uploadsignfetch ObjFetchAll = new uploadsignfetch();
            try
            {
                ObjFetchAll = objdatamodel.Getuploadsignfetch_db(org, locn, user, lang, In_signature_rowid, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_signature_rowid = In_signature_rowid;
                objfinal.uploadsign = ObjFetchAll;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        public string[] NewUploadSignsave_Srv(Saveuploadsign ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = objdatamodel.NewUploadSignsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
    }
}
