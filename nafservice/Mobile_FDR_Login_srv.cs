
using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_Login_model;

namespace nafmodel
{
   public class Mobile_FDR_Login_srv
    {
        public static FDRLoginfetchApplication GetAllFdrLogin_Srv(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd, string Mysql)
        {
            FDRLoginfetchApplication ObjFarmerRoot = new FDRLoginfetchApplication();
            Mobile_FDR_Login_DB objDataModel = new Mobile_FDR_Login_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllFdrLogin_DB(org, locn, user, lang, In_user_code, In_user_pwd,Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static LoginfetchApplication GetAllLogin_Srv(LoginfetchContext objfarmer, string Mysql)
        {
            LoginfetchApplication ObjFarmerRoot = new LoginfetchApplication();
            Mobile_FDR_Login_DB objDataModel = new Mobile_FDR_Login_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllLogin_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static string[] Getforgotpassword_Srv(Application objfarmer, string Mysql)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] respo = { retmsg, retresult };
            Mobile_FDR_Login_DB objDataModel = new Mobile_FDR_Login_DB();
            try
            {
                respo = objDataModel.Getforgotpassword_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
    }
}

