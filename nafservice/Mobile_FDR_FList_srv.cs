using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_FList_model;

namespace nafmodel
{
  public class Mobile_FDR_FList_srv
    {
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_FList_srv)); //Declaring Log4Net. 
        public static FDRFarmerRootObject GetAllFarmerList_Srv(FDRFarmerContext objfarmer, string Mysql)
        {
            FDRFarmerRootObject ObjFarmerRoot = new FDRFarmerRootObject();
            Mobile_FDR_FList_DB objDataModel = new Mobile_FDR_FList_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllFarmerList_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FDRRootObject GetmobFarmerSinglefetch_srv(FDRContext objfarmer, string Mysql)
        {
            FDRRootObject ObjFarmerRoot = new FDRRootObject();
            Mobile_FDR_FList_DB objDataModel = new Mobile_FDR_FList_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetmobFarmerSinglefetch_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
