using System;
using System.Collections.Generic;
using System.Text;
using nafdatamodel;
using static nafmodel.Kiosk_Soil_Card_model;

namespace nafservice
{
   public class Kiosk_Soil_Card_Service
    {
        //private static object log4net;
        //log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Kiosk_Soil_Card_Service)); //Declaring Log4Net.

        Kiosk_Soil_Card_Datamodel objdatamodel = new Kiosk_Soil_Card_Datamodel();

        // soil parameter
        public soilParametersDetailItems getsoliparameters(string conString)
        {
            soilParametersDetailItems obj_ParametersDetailItems = new soilParametersDetailItems();
            List<soilDetailItems> obj_soilDetailItems = new List<soilDetailItems>();
            try
            {
                obj_soilDetailItems = objdatamodel.getsoliparameters(conString);
                obj_ParametersDetailItems.ParametersDetailItems = obj_soilDetailItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_ParametersDetailItems;
        }
        public soilParametersDetailItems getNONNABLsoliparameters(string conString)
        {
            soilParametersDetailItems obj_ParametersDetailItems1 = new soilParametersDetailItems();
            List<soilDetailItems> obj_NONNABLsoilDetailItems = new List<soilDetailItems>();
            try
            {
                obj_NONNABLsoilDetailItems = objdatamodel.getNONNABLsoliparameters(conString);
                obj_ParametersDetailItems1.ParametersDetailItems = obj_NONNABLsoilDetailItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_ParametersDetailItems1;
        }
        public soilListContext GetsoilList_srv(string org, string locn, string lang,int In_farmer_gid, string status, string Mysql)
        {
            soilListContext objfinal = new soilListContext();
            List<soilcardlist> objsoil = new List<soilcardlist>();            
            try
            {
                objsoil = objdatamodel.GetsoilList_db(org, locn,  lang, In_farmer_gid, status, Mysql);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            objfinal.List = objsoil;
            return objfinal;
        }
        public soilviewContext GetsoilviewList(string org, string locn, string user, string lang,int soil_gid, string Mysql)
        {
            soilviewContext objfinal = new soilviewContext();
            soilviewHeader ObjFetchAll = new soilviewHeader();
            List<soilviewDetailItems> ObjFetchdetail = new List<soilviewDetailItems>();
            try
            {
                ObjFetchAll = objdatamodel.GetsoilviewList(org, locn, user, lang, soil_gid, Mysql);
                string Tran_Id = ObjFetchAll.out_Tran_Id;
                ObjFetchdetail = objdatamodel.Getsoilviewdet(org, locn, user, lang, Tran_Id, Mysql);
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

        public string[] Newsoilcardsave_Srv(soilcardsave ObjModel, string Mysql)
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


        //selva
        public string[] GetSoilcardmaxid(soilcardsave ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.GetSoilcardmaxid(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }

        //print list 

        public soilviewContext soilviewPrintList(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string Mysql)
        {
            soilviewContext objfinal = new soilviewContext();
           // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<soilPrintList>  Fetchdetail = new List<soilPrintList>();
            try
            {
                
                Fetchdetail = objdatamodel.soilviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, Mysql);
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
        public soilviewContext apisoilviewPrintList(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string ConString)
        {
            soilviewContext objfinal = new soilviewContext();
            // soilviewPrintList ObjFetchAll = new soilviewPrintList();
            List<soilPrintList> Fetchdetail = new List<soilPrintList>();
            try
            {
               
                Fetchdetail = objdatamodel.apisoilviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);
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
