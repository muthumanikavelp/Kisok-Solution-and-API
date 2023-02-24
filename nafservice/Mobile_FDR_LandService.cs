using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_LandModel;

namespace nafservice
{
  public  class Mobile_FDR_LandService
    {
        Mobile_FDR_LandDatamodel objdatamodel = new Mobile_FDR_LandDatamodel();
        public string[] NewFarmerLandsave_Srv(SaveFLand ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = objdatamodel.NewFarmerLandsave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }

        public FarmerLandContext GetFarmerLand_srv(string org, string locn, string user, string lang, int In_farmer_gid, string Mysql)
        {
            FarmerLandContext objfinal = new FarmerLandContext();

            List<FarmerLandfecth> ObjFetchAll = new List<FarmerLandfecth>();
            try
            {
                ObjFetchAll = objdatamodel.GetFarmerLand_DB(org, locn, user, lang, In_farmer_gid, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_farmer_gid = In_farmer_gid;
                objfinal.Land = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
    }
}
