using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.Mobile_FDR_FList_model;
using QRCoder;
using System.Drawing;
namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_FListController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_FListController)); //Declaring Log4Net.       

        public Mobile_FDR_FListController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("FarmerList")]
        public FDRFarmerRootObject GetFarmerList(FDRFarmerContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FDRFarmerRootObject ObjList = new FDRFarmerRootObject();
            try
            {
                ObjList = Mobile_FDR_FList_srv.GetAllFarmerList_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
        [Authorize]
        [HttpPost("mobFarmerSinglefetch")]
        public FDRRootObject GetmobFarmerSinglefetch(FDRContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FDRRootObject ObjList = new FDRRootObject();
            try
            {
                ObjList = Mobile_FDR_FList_srv.GetmobFarmerSinglefetch_srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("new_farmer_qrcode")]
        public string new_farmer_qr(FarmerQrContext ObjModel)
        {

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            string Qrcode = "";
            FarmerQrContext Objresult = new FarmerQrContext();

            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(ObjModel.FarmerCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);


           

            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return Convert.ToBase64String(stream.ToArray());
                //stream.ToArray();
            }
        }

    }
}