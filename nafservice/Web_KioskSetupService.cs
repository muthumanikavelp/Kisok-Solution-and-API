using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


using nafdatamodel;
using nafmodel;



using static nafmodel.Web_KioskSetupModel;
namespace nafservice
{
   public class Web_KioskSetupService
    {

        Web_KioskSetupDataModel kioskDataModelobj = new Web_KioskSetupDataModel();

        // next increment id
        public int NextIncrementid(KioskSave ObjModel,string tablename, string Mysql) // Get Nextgid
        {
            int res = 0;

            res = kioskDataModelobj.NextIncrementid(ObjModel,tablename, Mysql);


            return res;
        }

        // Get Kiosk List
        public KioskList GetKioskList(string org, string locn, string user, string lang, string Mysql )
        {
            KioskList ObjFetchAll = new KioskList();
            int res = 0;
            try
            {
                ObjFetchAll = kioskDataModelobj.GetKioskList(org, locn, user, lang, Mysql);
              //  res = kioskDataModelobj.NextIncrementid(org, locn, user, lang, Mysql, kiosk_code);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjFetchAll;
        }


        //Get Onchange
        
        public KioskList GetKioskonchange(string org, string locn, string user, string lang, string Mysql,string Depend_Code )
        {
            KioskList ObjFetchAll = new KioskList();
            try
            {
                ObjFetchAll = kioskDataModelobj.GetKioskonchange(org,locn, user, lang,  Depend_Code, Mysql);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjFetchAll;
        }

        //Fetch header details

        public KioskSave GetkioskviewList(string org, string locn, string user, string lang, int kiosk_gid, string Mysql)
        {
            KioskSave objfinal = new KioskSave();
            SaveKioskheader ObjFetchAll = new SaveKioskheader();
            List<SaveRMDetail> ObjFetchdetail = new List<SaveRMDetail>();
            try
            {
                ObjFetchAll = kioskDataModelobj.GetKioskheader(org, locn, user, lang, kiosk_gid, Mysql);
                ObjFetchdetail = kioskDataModelobj.GetKioskdetails(org, locn, user, lang, kiosk_gid, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Kiosk_gid= kiosk_gid;
                objfinal.header = ObjFetchAll;
                objfinal.Detail = ObjFetchdetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
         
        //detail list
        public KioskSave GetkioskdetailList(string org, string locn, string user, string lang, int kiosk_gid, string Mysql)
        {
            KioskSave objfinal = new KioskSave();
            SaveKioskheader ObjFetchAll = new SaveKioskheader();
            List<SaveRMDetail> ObjFetchdetail = new List<SaveRMDetail>();
            try
            {
                
                ObjFetchdetail = kioskDataModelobj.GetKioskdetails(org, locn, user, lang, kiosk_gid, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Kiosk_gid = kiosk_gid;
                
                objfinal.Detail = ObjFetchdetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        //Save Header 
        public string[] SaveKioskSetup(KioskSave ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = kioskDataModelobj.SaveKioskSetup(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
        //Kiosk Contact Details
        public string[] SaveKioskSetupDetails(SavesingleContext ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = kioskDataModelobj.SaveKioskSetupDetails(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }

        //kiosk details edit 
        public KioskSave viewkioskdetails(string org, string locn, string user, string lang, int contact_id, string Mysql)
        {
            KioskSave objfinal = new KioskSave();

            List<SaveRMDetail> ObjFetchdetail = new List<SaveRMDetail>();
            try
            {
                ObjFetchdetail = kioskDataModelobj.viewkioskdetails(org, locn, user, lang, contact_id, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Kiosk_Contactgid = contact_id;
                // objfinal.header = ObjFetchAll;
                objfinal.Detail = ObjFetchdetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }


        //kiosk details edit 
        public KioskSave kioskdetailslist(string org, string locn, string user, string lang, int kiosk_gid, string Mysql)
        {
            KioskSave objfinal = new KioskSave();
            SaveKioskheader ObjFetchAll = new SaveKioskheader();
            List<SaveRMDetail> ObjFetchdetail = new List<SaveRMDetail>();
            try
            {
                // ObjFetchAll = kioskDataModelobj.GetKioskheader(org, locn, user, lang, kiosk_gid, Mysql);
                ObjFetchdetail = kioskDataModelobj.kioskdetails(org, locn, user, lang, kiosk_gid, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.Kiosk_gid = kiosk_gid;
                //  objfinal.header = ObjFetchAll;
                objfinal.Detail = ObjFetchdetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

    }
}
