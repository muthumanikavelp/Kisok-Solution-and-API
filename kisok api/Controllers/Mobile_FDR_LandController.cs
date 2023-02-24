using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.Kiosk_Soil_Card_model;
using static nafmodel.Mobile_FDR_LandModel;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_LandController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        Mobile_FDR_LandService objRoleService = new Mobile_FDR_LandService();
        public Mobile_FDR_LandController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [Authorize]
        [HttpPost("FarmerLandsave")]
        public Retrnmesg newFarmerLandsave(SaveFLand ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            Retrnmesg sucessmsg = new Retrnmesg();
            string[] response = { };
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel);

            try
            {
                response = objRoleService.NewFarmerLandsave_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }

        [Authorize]
        [HttpGet("FarmerLandList")]
        public FarmerLandContext FarmerLandList (string org, string locn, string user, string lang, int In_farmer_gid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_farmer_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FarmerLandContext ObjList = new FarmerLandContext();
            try
            {
                ObjList = objRoleService.GetFarmerLand_srv(org, locn, user, lang, In_farmer_gid, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

    }
}
