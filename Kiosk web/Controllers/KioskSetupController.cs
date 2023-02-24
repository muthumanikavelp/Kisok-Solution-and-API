using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Data;
using Newtonsoft.Json;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Configuration;

namespace Kiosk_web.Controllers
{
    public class KioskSetupController : Controller
    {
       // NextIncrementId_Service nextidobj = new NextIncrementId_Service();
        // GET: KioskSetup
        public IActionResult KioskSetup(KioskContext objContext)
        {
              return View();
        }


        private IConfiguration _configuration;
        public KioskSetupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        //Get Kiosk List 
        string urlstring = "";
        [HttpPost]
        public ActionResult KioskSetupList([FromBody] KioskContext objContext)
        {
            KioskList objList = new KioskList();
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
               // string kiosk_code = _configuration.GetSection("AppSettings")["NextKiosksetup_gid"].ToString();

                string Urlcon = "api/Web_KioskSetup/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 var response = client.GetAsync("KioskList??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId +   "").Result;

                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objList = (KioskList)JsonConvert.DeserializeObject(post_data, typeof(KioskList));
            }
            return Json(objList);
        }


        //Kiosk Set up Onchange
        string urlstring1 = "";
        [HttpPost]
        public ActionResult KioskSetuponchange([FromBody] KioskContext objContext)
        {
            KioskList objList = new KioskList();
            string post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring1 = _configuration.GetSection("Api_dev")["api_url"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
                 urlstring1 = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring1 = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {
                string Urlcon = "api/Web_KioskSetup/";
                client.BaseAddress = new Uri(urlstring1 + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 var response = client.GetAsync("Kioskonchange??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&Depend_Code=" + objContext.dependcode + "").Result;
                
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objList = (KioskList)JsonConvert.DeserializeObject(post_data, typeof(KioskList));
            }
            return Json(objList);
        }
        //TO edit
        [HttpPost]
        public ActionResult Kioskfetch([FromBody] SaveRMContext objContext)
        {
            SaveRMContext objout = new SaveRMContext();
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
            token objtoken = new token();
            gettoken objt = new gettoken();
            objtoken.Username = "test";
            objtoken.Password = "test";
            using (var client1 = new HttpClient())
            {
                string Urlcon = "Users/";
                client1.BaseAddress = new Uri(urlstring + Urlcon);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objtoken), UTF8Encoding.UTF8, "application/json");
                var response = client1.PostAsync("authenticate", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objt = (gettoken)JsonConvert.DeserializeObject(post_data, typeof(gettoken));
                string auth = objt.token;

                using (var client = new HttpClient())
                {
                    string Urlcon1 = "api/Web_KioskSetup/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("Fetchkiosk?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&Kiosk_id=" + objContext.Kiosk_gid + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                 }
            }
            return Json(post_data);
        }

         
        ////Save  header
        [HttpPost]
        public ActionResult SaveKiosk([FromBody] SaveRMContext objContext)
        {
            SaveRMRoot objRoot = new SaveRMRoot();
            SaveRMDocument objDoc = new SaveRMDocument();
            SaveRMContext objContextDetails = new SaveRMContext();
            objContextDetails.userId = objContext.userId;
            objContextDetails.locnId = objContext.locnId;
            objContextDetails.localeId = objContext.localeId;
            objContextDetails.orgnId = objContext.orgnId;
            objContextDetails.header = objContext.header;
            objContextDetails.Detail = objContext.Detail;
            objContextDetails.In_mode_flag = objContext.In_mode_flag;
            objContextDetails.notes = objContext.notes;

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
                string Urlcon = "api/Web_KioskSetup/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
               
              var response = client.PostAsync("Save_Kiosk", content).Result;


                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
            }
            return Json(post_data);
        }


        //Kiosk Contact Details
        [HttpPost]
        public ActionResult KioskContactDetails([FromBody] SavesingleContext test )
        {
             SaveRMRoot objRoot = new SaveRMRoot();
            SaveRMDocument objDoc = new SaveRMDocument();
            SaveRMContext objContextDetails = new SaveRMContext();
         objContextDetails.userId = test.userId;
            objContextDetails.locnId = test.locnId;
            objContextDetails.localeId = test.localeId;
            objContextDetails.orgnId = test.orgnId;
            objContextDetails.in_Name = test.in_Name;
            objContextDetails.in_Designation = test.in_Designation;
            objContextDetails.in_eMail = test.in_eMail;
            objContextDetails.in_Mobile = test.in_Mobile;
            objContextDetails.in_Landline = test.in_Landline;
            objContextDetails.Kiosk_Contactgid =Convert.ToInt32(test.Kiosk_Contactgid);
            objContextDetails.Kiosk_id = Convert.ToInt32(test.Kiosk_gid);
            objContextDetails.In_mode_flag = test.In_mode_flag; 
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
                string Urlcon = "api/Web_KioskSetup/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(test), UTF8Encoding.UTF8, "application/json");

                var response = client.PostAsync("SaveContact_Kiosk", content).Result;


                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
            }
            return Json(post_data);
        }

        //kiosk contact details edit

        //TO edit
        [HttpPost]
        public ActionResult Kioskviewfetch([FromBody] SaveRMContext objContext)
        {
            SaveRMContext objout = new SaveRMContext();
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
            token objtoken = new token();
            gettoken objt = new gettoken();
            objtoken.Username = "test";
            objtoken.Password = "test";
            using (var client1 = new HttpClient())
            {
                string Urlcon = "Users/";
                client1.BaseAddress = new Uri(urlstring + Urlcon);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objtoken), UTF8Encoding.UTF8, "application/json");
                var response = client1.PostAsync("authenticate", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objt = (gettoken)JsonConvert.DeserializeObject(post_data, typeof(gettoken));
                string auth = objt.token;

                using (var client = new HttpClient())
                {
                    string Urlcon1 = "api/Web_KioskSetup/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("viewFetchkiosk?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&Kiosk_id=" + objContext.Kiosk_gid + "&contact_id=" + objContext.Kiosk_Contactgid +  "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }


        //details list
        [HttpPost]
        public ActionResult Kioskdetailslist([FromBody] KioskSave objContext)
        {
            SaveRMContext objout = new SaveRMContext();
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
            token objtoken = new token();
            gettoken objt = new gettoken();
            objtoken.Username = "test";
            objtoken.Password = "test";
            using (var client1 = new HttpClient())
            {
                string Urlcon = "Users/";
                client1.BaseAddress = new Uri(urlstring + Urlcon);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objtoken), UTF8Encoding.UTF8, "application/json");
                var response = client1.PostAsync("authenticate", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objt = (gettoken)JsonConvert.DeserializeObject(post_data, typeof(gettoken));
                string auth = objt.token;

                using (var client = new HttpClient())
                {
                    string Urlcon1 = "api/Web_KioskSetup/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("kioskdetailslist?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&Kiosk_id=" + objContext.Kiosk_gid + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }

        // Model
        public class RoleManagementFetch
        {
            public KioskContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }






        public class KioskContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string dependcode { get; set; }
            public string kiosk_gid { get; set; }
            public List<KioskFetch> List { get; set; }
        }
        public class KioskList
        {
            public KioskContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        public class KioskFetch
        {
            
            public int Kiosk_id { get; set; }
            public string  KioskCode { get; set; }
            public string kiosk_Name { get; set; }
            public string Bilingual { get; set; }
            public string Village { get; set; }
            public string Taluk { get; set; }
            public string District { get; set; }
            public string State { get; set; }


            //Dropdown onchange

            public string tk_code { get; set; }
            public string tk_name { get; set; }
            public string dt_code { get; set; }
            public string dt_name { get; set; }
            public string st_code { get; set; }
            public string st_name { get; set; }
            public string village_code { get; set; }
            public string vill_name { get; set; }



        }

        //Contact Details Save
        public class SavesingleContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }          
            public string In_mode_flag { get; set; }
            public int Kiosk_gid { get; set; }
            public int Kiosk_Contactgid { get; set; }          
            public string in_Name { get; set; }
            public string in_Designation { get; set; }
            public string in_eMail { get; set; }
            public string in_Mobile { get; set; }
            public string in_Landline { get; set; }
        }
             
            public class SaveRMContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SaveKioskheader header { get; set; }
            public List<SaveRMDetail> Detail { get; set; }
            public string In_mode_flag { get; set; }
           public int  Kiosk_gid { get; set; }
            public string  notes { get; set; }

            public int Kiosk_Contactgid { get; set; }


            public int Kiosk_id { get; set; }

            public string in_Name { get; set; }

            public string in_Designation { get; set; }

            public string in_eMail { get; set; }

            public string in_Mobile { get; set; }

            public string in_Landline { get; set; }
        }



        public class SaveKioskheader
        {
            public string userId { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public int In_Kiosk_gid { get; set; }
            public string in_Kiosk_code { get; set; }
            public string in_Kiosk_name { get; set; }
            public string in_status_name { get; set; }
            public string in_fpo_name { get; set; }
            public string in_Bilingual_code { get; set; }
            public string in_Pincode { get; set; }
            public string in_Village { get; set; }
            public string in_Taluk { get; set; }
            public string in_District { get; set; }
            public string in_State { get; set; }
            public string in_Address { get; set; }
            public string  Kiosk_Notes { get; set; }
             
            public string In_mode_flag { get; set; }
            public string detail_formatted { get; set; }


        }

        public class SaveRMDetail
        {
            //public string userId { get; set; }
            //public string orgnId { get; set; }
            //public string locnId { get; set; }
            //public string localeId { get; set; }
            public int Kiosk_Contactgid { get; set; }


            public int Kiosk_id { get; set; }

            public string in_Name { get; set; }

            public string in_Designation { get; set; }

            public string in_eMail { get; set; }

            public string in_Mobile { get; set; }

            public string in_Landline { get; set; }
           // public string In_mode_flag { get; set; }
        }
        public class SaveRMRoot
        {
            public SaveRMDocument document { get; set; }
        }


        public class SaveRMDocument
        {
            public SaveRMContext context { get; set; }
        }

        #region token
        public class token
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class gettoken
        {
            public string token { get; set; }
        }
        #endregion

        //save
        public class KioskSave
        {
             
            public string userId { get; set; }
 
            public string orgnId { get; set; }

 
            public string locnId { get; set; }


           
            public string localeId { get; set; }

            public SaveKioskheader header { get; set; }
            public List<SaveRMDetail> Detail { get; set; }

            public string detail_formatted { get; set; }

            public string In_mode_flag { get; set; }
            public int Kiosk_gid { get; set; }

            public int Kiosk_Contactgid { get; set; }


            public int Kiosk_id { get; set; }

            public string in_Name { get; set; }

            public string in_Designation { get; set; }

            public string in_eMail { get; set; }

            public string in_Mobile { get; set; }

            public string in_Landline { get; set; }
            public string notes { get; set; }
        }


    }
}
