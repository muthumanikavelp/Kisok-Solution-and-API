using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;

namespace FFI.Controllers
{
    public class ForgotPasswordController : Controller
    {
        //
        // GET: /ForgotPassword/
        public ActionResult ForgotPassword()
        {
            return View();
        }
        private IConfiguration _configuration;
        public ForgotPasswordController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string urlstring = "";
       
        


        public class combo_values
        {
            public string mstcode { get; set; }
        }

       
        public ActionResult SaveForgotPassword([FromBody] Context objContext)
        {
            Application objRoot = new Application();
            Document objDoc = new Document();
            Context objContextDetails = new Context();
            objContextDetails.userId = objContext.userId;
            objContextDetails.locnId = _configuration.GetSection("AppSettings")["Instance"].ToString();
            objContextDetails.localeId ="en_US";
            objContextDetails.orgnId = objContext.orgnId;
            objContextDetails.Header = objContext.Header;

            objDoc.context = objContextDetails;
            objRoot.document = objDoc;

            string post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {
                string Urlcon = "api/Mobile_FDR_Login/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objRoot), UTF8Encoding.UTF8, "application/json");
                var response = client.PostAsync("forgotpassword", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
            }
            return Json(post_data);
        }

        public static object[] mstlist;

        #region save model
        public class Header
        {
            public string user_code { get; set; }
            public string secquestion_code { get; set; }
            public string secquestion_answer { get; set; }
            public string user_pwd { get; set; }
            public string mode_flag { get; set; }

        }
        public class Context
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public Header Header { get; set; }

        }
        public class Document
        {
            public Context context { get; set; }

        }
        public class Application
        {
            public Document document { get; set; }

        }
        #endregion


    }
}