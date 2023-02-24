using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_model;

namespace nafmodel
{
   public class Mobile_FDR_servicecs
    {
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_servicecs)); //Declaring Log4Net. 
        public static MFDRApplication GetAllFarmerProfileDetail_Srv(MFDRContext objfarmer, string Mysql)
        {
            MFDRApplication ObjFarmerRoot = new MFDRApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFarmerProfileDetail_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static MFApplication GetAllFarmerbank_Srv(MFContext objfarmer, string Mysql)
        {
            MFApplication ObjFarmerRoot = new MFApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFarmerbank_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static MFMApplication GetAllFarmermaster_Srv(MFMContext objfarmer, string Mysql)
        {
            MFMApplication ObjFarmerRoot = new MFMApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFarmermaster_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static docnumApplication GetAllFarmerdocnum_Srv(docnumContext objfarmer, string Mysql)
        {
            docnumApplication ObjFarmerRoot = new docnumApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFarmerdocnum_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

    }
}
