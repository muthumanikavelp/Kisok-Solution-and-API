using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_Kiosk_Soilcard_model;

namespace nafservice
{
   public class Mobile_Kiosk_Soilcard_service
    {
        Mobile_Kiosk_Soilcard_datamodel objdatamodel = new Mobile_Kiosk_Soilcard_datamodel();
        public string[] newmobsoilcard_Srv(mobsavesoilcard ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newmobsoilcardsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
    }
}
