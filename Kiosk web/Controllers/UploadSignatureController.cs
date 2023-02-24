using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Kiosk_web.Models.UploadSignaturemodel;

namespace Kiosk_web.Controllers
{
    public class UploadSignatureController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        string urlstring = "";
        public UploadSignatureController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult UploadSignature()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult uploadsignList([FromBody] uploadsign objContext)
        {
            uploadsigncontext objList = new uploadsigncontext();
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
                    string Urlcon1 = "api/Kiosk_UploadSign/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("UploadSignList?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (uploadsigncontext)JsonConvert.DeserializeObject(post_data, typeof(uploadsigncontext));
                }
            }
            return Json(objList);
        }
        public ActionResult uploadsignfetch([FromBody] uploadsignfetchContext objContext)
        {
            uploadsignfetchContext objList = new uploadsignfetchContext();
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
                    string Urlcon1 = "api/Kiosk_UploadSign/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("UploadSignfetch?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&In_signature_rowid=" + objContext.In_signature_rowid + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (uploadsignfetchContext)JsonConvert.DeserializeObject(post_data, typeof(uploadsignfetchContext));
                }
            }
            return Json(objList);
        }
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<ActionResult> uploadsignsave(IFormFile uploadFile, string userId, string orgnId, string locnId, string localeId, int In_signature_rowid,
         string In_signature_tran_id, string In_signature_name, string In_signature_desgn, string In_signature_image,string In_mode_flag)
        {
            string post_data = "";
            Saveuploadsign objout = new Saveuploadsign();
            try
            {
            Saveuploadsign objContext = new Saveuploadsign();
            objContext.userId = userId;
            objContext.orgnId = orgnId;
            objContext.locnId = locnId;
            objContext.localeId = localeId;
            objContext.In_signature_rowid = Convert.ToInt32(In_signature_rowid);
            objContext.In_signature_tran_id = In_signature_tran_id;
            objContext.In_signature_name = In_signature_name;
            objContext.In_signature_desgn = In_signature_desgn;
            objContext.In_signature_image = In_signature_image;
            objContext.In_mode_flag = In_mode_flag;
            string filepathextension = "";

            if (uploadFile != null)
            {
                string filenamenew = "";
                objContext.In_signature_image = uploadFile.FileName;
                FileInfo fi = new FileInfo(uploadFile.FileName);
                string fileextension = fi.Extension;
                filenamenew = filenamenew + "" + fileextension;
                string webRootPath = _hostingEnvironment.ContentRootPath;
                var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();
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
                filepathextension = Path.Combine(fileLocation, Path.GetFileName(objContext.In_signature_image));
                using (var stream = new FileStream(filepathextension, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }
                    objContext.In_signature_image = filepathextension;
            }

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
                    string Urlcon1 = "api/Kiosk_UploadSign/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("UploadSignsave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
        }
            catch (Exception ex)
            {
            }
            return Json(post_data);
        }

       
    }
}
