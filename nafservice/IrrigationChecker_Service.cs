using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.IrrigationChecker_Model;

namespace nafservice
{
   public  class IrrigationChecker_Service
    {
        IrrigationChecker_DataModel objdatamodel = new IrrigationChecker_DataModel();
        public irrigationParametersDetailItems getirrigationparametersChecker(string conString)
        {
            irrigationParametersDetailItems obj_ParametersDetailItems = new irrigationParametersDetailItems();
            List<irrigationDetailItems> obj_irrigationDetailItems = new List<irrigationDetailItems>();
            try
            {
                obj_irrigationDetailItems = objdatamodel.getirrigationparametersChecker(conString);
                obj_ParametersDetailItems.ParametersDetailItems = obj_irrigationDetailItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_ParametersDetailItems;
        }

        #region
        public irrigationListContext GetsoilList_srvChecker(string org, string locn, string lang, string status, string Mysql)
        {
            irrigationListContext objfinal = new irrigationListContext();
            List<irrigationlist> objsoil = new List<irrigationlist>();
            try
            {
                objsoil = objdatamodel.GetirrigationList_dbChecker(org, locn, lang, status, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            objfinal.List = objsoil;
            return objfinal;
        }
        #endregion

        #region
        public string[] Newirrigationsave_SrvChecker(irrigationsave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newirrigationsave_dbChecker(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
        #endregion

        #region
        public irrigationviewContext GetirrigationviewListChecker(string org, string locn, string user, string lang, int irrigation_gid, string Mysql)
        {
            irrigationviewContext objfinal = new irrigationviewContext();
            irrigationviewHeader ObjFetchAll = new irrigationviewHeader();
            List<irrigationviewDetailItems> ObjFetchdetail = new List<irrigationviewDetailItems>();
            try
            {
                ObjFetchAll = objdatamodel.GetirrigationviewListChecker(org, locn, user, lang, irrigation_gid, Mysql);
                string Tran_Id = ObjFetchAll.out_Tran_Id;
                ObjFetchdetail = objdatamodel.GetirrigationviewdetChecker(org, locn, user, lang, Tran_Id, Mysql);
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
        #endregion

        #region
        //print list 

        public irrigationviewContext irrigationviewPrintListChecker(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string Mysql)
        {
            irrigationviewContext objfinal = new irrigationviewContext();
            // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<irrigationPrintList> Fetchdetail = new List<irrigationPrintList>();
            try
            {

                Fetchdetail = objdatamodel.irrigationviewPrintListChecker(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, Mysql);
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
        #endregion
    }
}
