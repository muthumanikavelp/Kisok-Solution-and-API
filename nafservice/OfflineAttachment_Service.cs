using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.OfflineAttachment_Model;

namespace nafservice
{
   public class OfflineAttachment_Service
    {
        public static KioskApplication GetAllKiosk_Srv(KioskContext objfarmer, string Mysql)
        {
            KioskApplication ObjFarmerRoot = new KioskApplication();
            OfflineAttachment_DataModel objDataModel = new OfflineAttachment_DataModel();  
            try
            {
                ObjFarmerRoot = objDataModel.GetAllKiosk_Srv(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
