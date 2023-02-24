using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_IrrigationWaterTest_model;

namespace nafservice
{
   public class Kiosk_IrrigationWaterTest_Service
    {
        Kiosk_IrrigationWaterTest_Datamodel objdatamodel = new Kiosk_IrrigationWaterTest_Datamodel();
        public irrigationParametersDetailItems getirrigationparameters(string conString)
        {
            irrigationParametersDetailItems obj_ParametersDetailItems = new irrigationParametersDetailItems();
            List<irrigationDetailItems> obj_irrigationDetailItems = new List<irrigationDetailItems>();
            try
            {
                obj_irrigationDetailItems = objdatamodel.getirrigationparameters(conString);
                obj_ParametersDetailItems.ParametersDetailItems = obj_irrigationDetailItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_ParametersDetailItems;
        }
        public irrigationParametersDetailItems getNONNABLirrigationparameters(string conString)
        {
            irrigationParametersDetailItems obj_ParametersDetailItems = new irrigationParametersDetailItems();
            List<irrigationDetailItems> obj_nonnablirrigationDetailItems = new List<irrigationDetailItems>();
            try
            {
                obj_nonnablirrigationDetailItems = objdatamodel.getNONNABLirrigationparameters(conString);
                obj_ParametersDetailItems.ParametersDetailItems = obj_nonnablirrigationDetailItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_ParametersDetailItems;
        }
        #region
        public irrigationListContext GetsoilList_srv(string org, string locn, string lang,int In_farmer_gid, string status, string Mysql)
        {
            irrigationListContext objfinal = new irrigationListContext();
            List<irrigationlist> objsoil = new List<irrigationlist>();
            try
            {
                objsoil = objdatamodel.GetirrigationList_db(org, locn, lang, In_farmer_gid, status, Mysql);
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
        public string[] Newirrigationsave_Srv(irrigationsave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newirrigationsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
        #endregion

        #region
        public irrigationviewContext GetirrigationviewList(string org, string locn, string user, string lang, int irrigation_gid, string Mysql)
        {
            irrigationviewContext objfinal = new irrigationviewContext();
            irrigationviewHeader ObjFetchAll = new irrigationviewHeader();
            List<irrigationviewDetailItems> ObjFetchdetail = new List<irrigationviewDetailItems>();
            try
            {
                ObjFetchAll = objdatamodel.GetirrigationviewList(org, locn, user, lang, irrigation_gid, Mysql);
                string Tran_Id = ObjFetchAll.out_Tran_Id;
                ObjFetchdetail = objdatamodel.Getirrigationviewdet(org, locn, user, lang, Tran_Id, Mysql);
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

        public irrigationviewContext irrigationviewPrintList(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string Mysql)
        {
            irrigationviewContext objfinal = new irrigationviewContext();
            // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<irrigationPrintList> Fetchdetail = new List<irrigationPrintList>();
            try
            {

                Fetchdetail = objdatamodel.irrigationviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, Mysql);
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

        //prema
        public string[] GetIrrigationmaxid(irrigationsave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.GetIrrigationmaxid(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }


        //Api Print
        public irrigationviewContext apiirrigationviewPrintList(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string ConString)
        {
            irrigationviewContext objfinal = new irrigationviewContext();
            // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<irrigationPrintList> Fetchdetail = new List<irrigationPrintList>();
            try
            {

                Fetchdetail = objdatamodel.apiirrigationviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);
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
