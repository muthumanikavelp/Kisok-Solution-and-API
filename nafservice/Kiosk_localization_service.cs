using nafdatamodel;
using System;
using System.Collections.Generic;
using static nafmodel.kiosk_advertisement_model;
using static nafmodel.Kiosk_localization_model;

namespace nafservice
{
    public class Kiosk_localization_service
    {
        Kiosk_localization_datamodel objdatamodel = new Kiosk_localization_datamodel();
        public localizationcontext Getlocalizationlist_srv(string org, string locn, string user, string lang, string Mysql)
        {

            localizationcontext objfinal = new localizationcontext();

            List<localizationlist> ObjFetchAll = new List<localizationlist>();
            try
            {
                ObjFetchAll = objdatamodel.Getlocalizationlist_db(org, locn, user, lang, Mysql);
                objfinal.list = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
    }
}
