using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_login_model;

namespace nafservice
{
   public class kiosk_login_service
    {
        public static kioskLoginContext GetAllkioskLogin_Srv(string In_user_code, string In_user_pwd, string Mysql)
        {
            kioskLoginContext ObjFarmerRoot = new kioskLoginContext();
            Kiosk_login_datamodel objDataModel = new Kiosk_login_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetkioskLogin_DB(In_user_code, In_user_pwd, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static kioskLoginfetchApplication GetAllkioskforgotpass_Srv(string In_user_code, string In_user_pwd, string ConString )
        {
            kioskLoginfetchApplication ObjFarmerRoot = new kioskLoginfetchApplication();
            Kiosk_login_datamodel objDataModel = new Kiosk_login_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllkioskLogin_DB(In_user_code, In_user_pwd, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static kioskresetApplication GetAllkioskresetpass_Srv(string In_user_code, string ConString)
        {
            kioskresetApplication ObjFarmerRoot = new kioskresetApplication();
            Kiosk_login_datamodel objDataModel = new Kiosk_login_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllkioskresetpass_DB(In_user_code, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
