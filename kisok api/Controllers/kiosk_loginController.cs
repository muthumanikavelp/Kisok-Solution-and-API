using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using Newtonsoft.Json;
using static nafmodel.Kiosk_login_model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class kiosk_loginController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_LoginController)); //Declaring Log4Net.       

        public kiosk_loginController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        [HttpGet("KioskLogin")]
        public string KioskLogin(string instance, string In_user_code, string In_user_pwd)
        {
            string db = instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            kioskLoginContext ObjList = new kioskLoginContext();
            try
            {
                ObjList = kiosk_login_service.GetAllkioskLogin_Srv(In_user_code, In_user_pwd, ConString);
            }           
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            kioskLoginContext Objfinal = new kioskLoginContext();
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("kioskresetpass")]
        public kioskLoginfetchApplication kioskforgotpass(string instance, string In_user_code, string In_user_pwd)
        {
            string db = instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            kioskLoginfetchApplication ObjList = new kioskLoginfetchApplication();
            try
            {
                ObjList = kiosk_login_service.GetAllkioskforgotpass_Srv(In_user_code, In_user_pwd, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return ObjList;
        }
             
        [HttpGet("kioskforgotpass")]
        public kioskresetApplication kioskresetpass(string instance, string In_user_code)
        {
            string message = "";
            string db = instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            kioskresetApplication ObjList = new kioskresetApplication();
            try
            {
                ObjList = kiosk_login_service.GetAllkioskresetpass_Srv(In_user_code, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }

            string msg = ObjList.context.In_Reponse;
            if (msg == "Sucess")
            {
                string portno = _configuration.GetSection("AppSettings")["SMTPPort"].ToString();
                string otp = GenerateRandomNumber(0, 0, 4, 0);
                string FromEmailId = _configuration.GetSection("Appsettings")["FromEmailId"].ToString();
                string Password = _configuration.GetSection("Appsettings")["Password"].ToString();
                string hos = _configuration.GetSection("Appsettings")["Host"].ToString();
                string userhost = ObjList.context.In_email;
                ObjList.context.In_otp = otp;
                var sub = "OTP";
                var body = otp;
                var smtp = new SmtpClient
                {
                    Host = hos,
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(FromEmailId, Password),
                    EnableSsl = false              
                };
                using (var mess = new MailMessage(FromEmailId, userhost)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                    message = "Mail Sended Sucessfully";
                }
            }
            else
            {
                message = "failed";
            }        
            return ObjList;
        }
    public static string GenerateRandomNumber(int lowercase, int uppercase, int numerics, int specialchars)
    {
        string lowers = "abcdefghijklmnopqrstuvwxyz";
        string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string number = "0123456789";
        string splchars = "~@#$%^&*()_+";

        Random random = new Random();

        string generated = "!";
        for (int i = 1; i <= lowercase; i++)
            generated = generated.Insert(
                random.Next(generated.Length),
                lowers[random.Next(lowers.Length - 1)].ToString()
            );

        for (int i = 1; i <= uppercase; i++)
            generated = generated.Insert(
                random.Next(generated.Length),
                uppers[random.Next(uppers.Length - 1)].ToString()
            );

        for (int i = 1; i <= numerics; i++)
            generated = generated.Insert(
                random.Next(generated.Length),
                number[random.Next(number.Length - 1)].ToString()
            );

        for (int i = 1; i <= specialchars; i++)
            generated = generated.Insert(
                random.Next(generated.Length),
                splchars[random.Next(splchars.Length - 1)].ToString()
            );

        return generated.Replace("!", string.Empty);

    }

}
}
