using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_Kiosk_Irrigation_model;

namespace nafservice
{
   public class Mobile_Kiosk_Irrigation_service
    {
        Mobile_Kiosk_Irrigation_datamodel objdatamodel = new Mobile_Kiosk_Irrigation_datamodel();
        public string[] newmobirrigation_Srv(mobsaveirrigation ObjModel, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            try
            {
                respo = objdatamodel.Newmobirrigationsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
    }
}
