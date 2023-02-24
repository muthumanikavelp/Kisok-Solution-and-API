using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.SolidCardChecker_Model;

namespace nafservice
{
   public class SolidCardChecker_Service
    {
        SolidCardCheckerDataModel objdatamodel = new SolidCardCheckerDataModel();


        public soilListContext GetsoilList_srvChecker(string org, string locn, string lang, int In_farmer_gid, string status, string Mysql)
        {
            soilListContext objfinal = new soilListContext();
            List<soilcardlist> objsoil = new List<soilcardlist>();
            try
            {
                objsoil = objdatamodel.GetsoilList_dbChecker(org, locn, lang, In_farmer_gid, status, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            objfinal.List = objsoil;
            return objfinal;
        }
        public soilviewContext GetsoilviewListChecker(string org, string locn, string user, string lang, int soil_gid, string Mysql)
        {
            soilviewContext objfinal = new soilviewContext();
            soilviewHeader ObjFetchAll = new soilviewHeader();
            List<soilviewDetailItems> ObjFetchdetail = new List<soilviewDetailItems>();
            try
            {
                ObjFetchAll = objdatamodel.GetsoilviewListChecker(org, locn, user, lang, soil_gid, Mysql);
                string Tran_Id = ObjFetchAll.out_Tran_Id;
                ObjFetchdetail = objdatamodel.GetsoilviewdetChecker(org, locn, user, lang, Tran_Id, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.farmer_code = ObjFetchAll.out_farmer_code;
                objfinal.Header = ObjFetchAll;
                objfinal.Detail = ObjFetchdetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        public string[] Newsoilcardsave_SrvChecker(soilcardsave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newsoilcardsave_dbChecker(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }

        //print list 

        public soilviewContext soilviewPrintListChecker(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string Mysql)
        {
            soilviewContext objfinal = new soilviewContext();
            // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<soilPrintList> Fetchdetail = new List<soilPrintList>();
            try
            {

                Fetchdetail = objdatamodel.soilviewPrintListChecker(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;

                objfinal.Print = Fetchdetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        //Api Print
        public soilviewContext apisoilviewPrintListChecker(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string ConString)
        {
            soilviewContext objfinal = new soilviewContext();
            // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<soilPrintList> Fetchdetail = new List<soilPrintList>();
            try
            {

                Fetchdetail = objdatamodel.apisoilviewPrintListChecker(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;

                objfinal.Print = Fetchdetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
    }
}
