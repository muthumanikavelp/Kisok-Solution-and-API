using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static Kiosk_web.Models.Advertisementmodel;
using static Kiosk_web.Models.SoilcardModel;
using static Kiosk_web.Models.tranningvideosmodel;

namespace Kiosk_web.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        string urlstring = "";
        public AdvertisementController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Advertisement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult advertisementList([FromBody] advertisement objContext)
        {
            advertisementcontext objList = new advertisementcontext();
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
                    string Urlcon1 = "api/kiosk_advertisement/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("advertisementList??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (advertisementcontext)JsonConvert.DeserializeObject(post_data, typeof(advertisementcontext));
                }
            }
            return Json(objList);
        }
        public ActionResult advertisementfetch([FromBody] advertisementfetchContext objContext)
        {
            advertisementfetchContext objList = new advertisementfetchContext();
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
                    string Urlcon1 = "api/kiosk_advertisement/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("advertisementfetch?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&In_AD_gid=" + objContext.In_AD_gid + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (advertisementfetchContext)JsonConvert.DeserializeObject(post_data, typeof(advertisementfetchContext));
                }
            }
            return Json(objList);
        }

        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<ActionResult> advtsaveAsync(IFormFile file, string userId, string orgnId, string locnId, string localeId, int In_AD_gid,
           string In_ad_tran_id, string In_ad_date, string In_ad_state,
           string In_display_order, string In_mode_flag,string In_ad_flashscreen)
        {
            SaveAdvertisement objout = new SaveAdvertisement();
            SaveAdvertisement objContext = new SaveAdvertisement();
            objContext.userId = userId;
            objContext.orgnId = orgnId; 
            objContext.locnId = locnId;
            objContext.localeId = localeId;
            objContext.In_AD_gid = In_AD_gid;
            objContext.In_ad_tran_id = In_ad_tran_id;
            objContext.In_ad_state = In_ad_state;
            objContext.In_ad_date = In_ad_date;
            objContext.In_display_order =Convert.ToInt32(In_display_order);           
            objContext.In_mode_flag = In_mode_flag;
            objContext.In_ad_flashscreen = In_ad_flashscreen;
            string filepathextension = "";
            if (file != null)
            {
                string filenamenew = "";
                objContext.In_ad_flashscreen = file.FileName;
                FileInfo fi = new FileInfo(file.FileName);
                string fileextension = fi.Extension;
                filenamenew = filenamenew + "" + fileextension;
                string webRootPath = _hostingEnvironment.ContentRootPath;
                var  Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();
                string folderName = Root_path;
                webRootPath = Path.Combine(webRootPath, folderName);
                var folder = _configuration.GetSection("AppSettings")["Advertfolder"].ToString();
                folderName = folder;
                string fileLocation = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(fileLocation))
                {
                    Directory.CreateDirectory(fileLocation);
                }
                Guid guid = Guid.NewGuid();
                filepathextension = Path.Combine(fileLocation, Path.GetFileName(objContext.In_ad_flashscreen));
                using (var stream = new FileStream(filepathextension, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            objContext.In_ad_path_url = filepathextension;
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
                    string Urlcon1 = "api/kiosk_advertisement/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("Advertisementsave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }

        [HttpPost]
        public ActionResult advertdelete([FromBody] adverdelete objdelete)
        {
            SaveAdvertisement objout = new SaveAdvertisement();
            SaveAdvertisement objContext = new SaveAdvertisement();
            objContext.userId = objdelete.userId;
            objContext.orgnId = objdelete.orgnId;
            objContext.locnId = objdelete.locnId;
            objContext.localeId = objdelete.localeId;
            objContext.In_AD_gid = objdelete.In_AD_gid;
            objContext.In_ad_tran_id = "";
            objContext.In_ad_state = "";
            objContext.In_ad_date = "";
            objContext.In_display_order = 0;
            objContext.In_mode_flag = objdelete.In_mode_flag;
            objContext.In_ad_path_url = "";
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
                    string Urlcon1 = "api/kiosk_advertisement/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("Advertisementsave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }



        //File local Path to delete

        [HttpPost]
        public ActionResult deleteFile([FromBody] videodeletefile objcon, string filepath)
        {
             
            string msg = "";
            string webRootPath = _hostingEnvironment.ContentRootPath;
            var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();

            string folderName = Root_path;
            webRootPath = Path.Combine(webRootPath, folderName);
            var Folder = _configuration.GetSection("AppSettings")["Advertfolder"].ToString();

            folderName = Folder;
            string file = Path.Combine(webRootPath, folderName);
            string fileLocation = Path.Combine(file, objcon.filepath);

            if (System.IO.File.Exists(fileLocation))
            {
                System.IO.File.Delete(fileLocation);
            }
            msg = "sucess";
            return Json(msg);
        }

       
        public class videodeletefile
        {
            public string filepath { get; set; }
        }
    }
}
