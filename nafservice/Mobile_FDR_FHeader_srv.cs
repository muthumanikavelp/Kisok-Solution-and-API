using nafdatamodel;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_FHeader_model;

namespace nafservice
{
   public class Mobile_FDR_FHeader_srv
    {
        Mobile_FDR_FHeader_DB objfdrheader = new Mobile_FDR_FHeader_DB();
        public static MFHDocument SaveNewMobileFarmerHeader_Srv(MFHApplication objmodel, string MysqlCon)
        {
            MFHDocument IUOShareRefund = new MFHDocument();
            try
            {
                Mobile_FDR_FHeader_DB objDataModel = new Mobile_FDR_FHeader_DB();
                IUOShareRefund = objDataModel.SaveNewMobileFarmerHeader_DB(objmodel, MysqlCon);
                return IUOShareRefund;
            }
            catch (Exception ex)
            {
                // //   logger.Error(ex.ToString());
                throw ex;
            }
        }
        public farmerSummaryContext GetFarmerList_srv(string org, string locn, string user, string lang, string Mysql)
        {
            farmerSummaryContext objfinal = new farmerSummaryContext();
            List<FarmerSummary> objsoil = new List<FarmerSummary>();
            try
            {
                objsoil = objfdrheader.GetFarmerList_db(org, locn, user, lang, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            objfinal.Summary = objsoil;
            return objfinal;
        }

    }
}