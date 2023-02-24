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
using static Kiosk_web.Models.SoilcardModel;
using static Kiosk_web.Models.tranningvideosmodel;
using System.Net;

namespace Kiosk_web.Controllers
{
    public class TranningvideosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        string urlstring = "";
        public TranningvideosController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Tranningvideos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult tranvideoList([FromBody] trancontext objContext)
        {
            trancontext objList = new trancontext();
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
                    string Urlcon1 = "api/Kiosk_Video/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("VideoListSummary??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (trancontext)JsonConvert.DeserializeObject(post_data, typeof(trancontext));
                }
            }
            return Json(objList);
        }
        public ActionResult categoryattribute([FromBody] attribute objContext)
        {
            attributecontext objList = new attributecontext();
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
                    string Urlcon1 = "api/Kiosk_Video/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("VideoAttributeList?&locn=" + objContext.locnId + "&depend_code=" + objContext.depend_code + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (attributecontext)JsonConvert.DeserializeObject(post_data, typeof(attributecontext));
                }
            }
            return Json(objList);
        }
        //tranvideosaveAsync
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<ActionResult> tranvideosaveAsync(IFormFile file, string userId, string orgnId, string locnId, string localeId, int In_video_gid,
        string In_video_category, string In_video_title,string In_video_source, string In_video_keywords, string In_video_atttribute, string In_mode_flag, string In_video_titleII, string In_video_sourceII, string In_video_keywordsII)
        {
            SaveVideo objout = new SaveVideo();
            SaveVideo objContext = new SaveVideo();
            objContext.userId = userId;
            objContext.orgnId = orgnId;
            objContext.locnId = locnId;
            objContext.localeId = localeId;
            objContext.In_video_gid = In_video_gid;
            objContext.In_video_category = In_video_category;
            objContext.In_video_title = In_video_title;
            objContext.In_video_source = In_video_source;
            objContext.In_video_keywords = In_video_keywords;
            objContext.In_video_atttribute = In_video_atttribute;
            objContext.In_mode_flag = In_mode_flag;
            objContext.In_video_titleII = In_video_titleII;
            objContext.In_video_sourceII = In_video_sourceII;
            objContext.In_video_keywordsII = In_video_keywordsII;
            string filepathextension = "";
            if (file != null)
            {
                string filenamenew = "";
                objContext.In_video_filename = file.FileName;
                FileInfo fi = new FileInfo(file.FileName);
                string fileextension = fi.Extension;
                filenamenew = filenamenew + "" + fileextension;
                string webRootPath = _hostingEnvironment.ContentRootPath;
                var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();
                string folderName = Root_path;
                webRootPath = Path.Combine(webRootPath, folderName);
                folderName = objContext.In_video_category;
                string fileLocation = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(fileLocation))
                {
                    Directory.CreateDirectory(fileLocation);
                }
                Guid guid = Guid.NewGuid();
                filepathextension = Path.Combine(fileLocation, Path.GetFileName(objContext.In_video_filename));
                using (var stream = new FileStream(filepathextension, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            objContext.In_video_filepath = filepathextension;
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
                    string Urlcon1 = "api/Kiosk_Video/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("Videosave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }

        [HttpPost]
        public ActionResult tranvideodelete([FromBody] videodelete objdelete)
        {
            SaveVideo objout = new SaveVideo();
            SaveVideo objContext = new SaveVideo();
            objContext.userId = objdelete.userId;
            objContext.orgnId = objdelete.orgnId;
            objContext.locnId = objdelete.locnId;
            objContext.localeId = objdelete.localeId;
            objContext.In_video_gid = objdelete.In_video_gid;
            objContext.In_video_category = "";
            objContext.In_video_title = "";
            objContext.In_video_source = "";
            objContext.In_video_keywords = "";
            objContext.In_video_atttribute = "";
            objContext.In_mode_flag = objdelete.In_mode_flag;
            objContext.In_video_filepath = "";
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
                    string Urlcon1 = "api/Kiosk_Video/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("Videosave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }

        public ActionResult tranvideofetch([FromBody] videofetchContext objContext)
        {
            videofetchContext objList = new videofetchContext();
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
                    string Urlcon1 = "api/Kiosk_Video/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("Videofetch?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&In_video_gid=" + objContext.In_video_gid + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (videofetchContext)JsonConvert.DeserializeObject(post_data, typeof(videofetchContext));
                }
            }
            return Json(objList);
        }
        public ActionResult deletevideo([FromBody] videodeletefile objcon)
        {
            string msg = "";

            string webRootPath = _hostingEnvironment.ContentRootPath;
            var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();

            string folderName = Root_path;
            webRootPath = Path.Combine(webRootPath, folderName);
            var Folder = _configuration.GetSection("AppSettings")["FAQ"].ToString();

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
