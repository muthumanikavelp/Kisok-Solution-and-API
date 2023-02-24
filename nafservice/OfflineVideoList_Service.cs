using System;
using System.Collections.Generic;
using System.Text;
using log4net.Repository.Hierarchy;
using nafdatamodel;
using static nafmodel.OfflineVideoList_Model;

namespace nafservice
{
    public class OfflineVideoList_Service
    {
        public static KioskVideoApplication GetAllKioskVideo_Srv(KioskVideoContext objfarmer, string Mysql,string advtfilepath, string videofilepath,string faqfilepath, string schemesfilepath)
        {
            KioskVideoApplication ObjFarmerRoot = new KioskVideoApplication();
            OfflineVideoList_Datamodel objDataModel = new OfflineVideoList_Datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllKioskVideo_Srv(objfarmer, Mysql, advtfilepath, videofilepath, faqfilepath, schemesfilepath);
           

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
