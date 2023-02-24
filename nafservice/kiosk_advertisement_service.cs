using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.kiosk_advertisement_model;

namespace nafservice
{
   public class kiosk_advertisement_service
    {
        kiosk_advertisement_datamodel objdatamodel = new kiosk_advertisement_datamodel();
        public advertisementcontext GetadvertisementList_srv(string org, string locn, string user, string lang, string Mysql)
        {
          
            advertisementcontext objfinal = new advertisementcontext();

            List<advertisementlist> ObjFetchAll = new List<advertisementlist>();
            try
            {
                ObjFetchAll = objdatamodel.GetadvertisementList_db(org, locn, user, lang, Mysql);
                objfinal.list = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        public advertisementfetchContext GetAdvtfetch_srv(string org, string locn, string user, string lang, int In_AD_gid, string Mysql)
        {
            advertisementfetchContext objfinal = new advertisementfetchContext();

            Advertisementfetch ObjFetchAll = new Advertisementfetch();
            try
            {
                ObjFetchAll = objdatamodel.GetAdvtfetch_db(org, locn, user, lang, In_AD_gid, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_AD_gid = In_AD_gid;
                objfinal.Advertisement = ObjFetchAll;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
    
    public string[] NewAdvertisementsave_Srv(SaveAdvertisement ObjModel, string Mysql)
    {
        string[] respo = { };
        try
        {
            respo = objdatamodel.NewAdvertisementsave_db(ObjModel, Mysql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return respo;
    }
}
}