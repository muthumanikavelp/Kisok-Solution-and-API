using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kisok_attach_model;

namespace nafservice
{
   public class kiosk_attach_service
    {
        kiosk_attach_datamodel objdatamodel = new kiosk_attach_datamodel();
       
        public string[] newattachsave_Srv(attchementsave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newsoilcardsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
        public attchement Getattchementfetch_srv(string org, string locn,string user, string lang, string doc_type , string id, string Mysql)
        {
            attchement objfinal = new attchement();
            List<attchementfetch> objsoil = new List<attchementfetch>();
            try
            {
                objsoil = objdatamodel.Getattchementfetch_db(org, locn, user, lang,doc_type, id, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            objfinal.attach = objsoil;
            return objfinal;
        }
        public string[] newnotessave_Srv(notessave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newnotessave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
        public string[] newattachdelete_Srv(attachdelete ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newattachdelete_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
    }
}
