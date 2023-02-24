using nafdatamodel;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_Kiosk_Fileurlpath_Model;
namespace nafservice
{
    public class Obj_Mobile_Kiosk_Fileurlpath_Services
    {

         Mobile_Kiosk_Fileurlpath_DataModel obj_Mobile_Kiosk_Fileurlpath_DataModel = new Mobile_Kiosk_Fileurlpath_DataModel();

        public DataSet Fileurlpath(string constring)
        {
            DataSet Dset = new DataSet();
            Mobile_Kiosk_Fileurlpath obj_Mobile_Kiosk_Fileurlpath_Model = new Mobile_Kiosk_Fileurlpath();
            try
            {
                Dset = obj_Mobile_Kiosk_Fileurlpath_DataModel.kiosk_Fileurlpath(constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dset;
        }
    }
}
