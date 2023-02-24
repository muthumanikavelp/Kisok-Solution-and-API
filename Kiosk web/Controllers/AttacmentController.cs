using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Kiosk_web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static Kiosk_web.Models.Attachmentmodel;
using static Kiosk_web.Models.SoilcardModel;

namespace Kiosk_web.Controllers
{
    public class AttacmentController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;
#pragma warning disable CS0618 // Type or member is obsolete
        private IHostingEnvironment _hostingEnvironment;
        public AttacmentController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }
        string urlstring = "";
        public IActionResult attachement()
        {
            return View();
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<ActionResult> attachment_saveAsync(IFormFile file, string userID, string description, string document, string locid, string gid, string model_flag)
        {
            string post_data = "";
            string filepathextension = "";
            try
            {
                attchementsave objattach = new attchementsave();

                if (ModelState.IsValid)
                {
                    string filenamenew = "";
                    objattach.filename = file.FileName;
                    objattach.userId = userID;
                    FileInfo fi = new FileInfo(file.FileName);
                    string fileextension = fi.Extension;
                    filenamenew = filenamenew + "" + fileextension;
                    string webRootPath = _hostingEnvironment.ContentRootPath;
                    var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();

                    string folderName = Root_path;
                    webRootPath = Path.Combine(webRootPath, folderName);
                    var Folder = _configuration.GetSection("AppSettings")["Attachfolder"].ToString();

                    folderName = Folder;
                    string fileLocation = Path.Combine(webRootPath, folderName);
                    if (!Directory.Exists(fileLocation))
                    {
                        Directory.CreateDirectory(fileLocation);
                    }
                    Guid guid = Guid.NewGuid();
                    filepathextension = Path.Combine(fileLocation, Path.GetFileName(objattach.filename));
                    using (var stream = new FileStream(filepathextension, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
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
                attchementsave objContext = new attchementsave();
                objContext.soil_gid = Convert.ToInt32(gid);
                objContext.userId = userID;
                objContext.locid = locid;
                objContext.filename = objattach.filename;
                objContext.filepath = filepathextension;
                objContext.description = description;
                objContext.document = document;
                objContext.model_flag = model_flag;               
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
                        string Urlcon1 = "api/Kiosk_attachment/";
                        client.BaseAddress = new Uri(urlstring + Urlcon1);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                        var response1 = client.PostAsync("attachsave", content1).Result;
                        Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                        StreamReader reader1 = new StreamReader(data1);
                        post_data = reader1.ReadToEnd();
                        //objContext = (attchementsave)JsonConvert.DeserializeObject(post_data, typeof(attchementsave));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Json(post_data);
        }

        [HttpPost]
        public ActionResult attachmentList([FromBody] attachcontext objContext)
        {
            attachcontext objList = new attachcontext();
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
                    string Urlcon1 = "api/Kiosk_attachment/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("attachView?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&lang=" + objContext.localeId + "&doc_type=" + objContext.doc_type + "&id=" + objContext.id + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (attachcontext)JsonConvert.DeserializeObject(post_data, typeof(attachcontext));
                    for (var i = 0; i < objList.attach.Count; i++)
                    {
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        string contentRootPath = _webHostEnvironment.ContentRootPath;
                        string filename = objList.attach[i].filename;
                        var Folder = _configuration.GetSection("AppSettings")["Attachfolder"].ToString();

                        string Clientpath = Path.Combine("/uploadedFiles/" + filename + "");
                        objList.attach[i].filepath = Clientpath;
                    }
                }
            }
            return Json(objList);
        }

        [HttpPost]
        public ActionResult attachmentdelete([FromBody] attachdelete objContext)
        {
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
            string post_data = "";
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
                    string Urlcon1 = "api/Kiosk_attachment/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("attachdelete", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    //objContext = (attchementsave)JsonConvert.DeserializeObject(post_data, typeof(attchementsave));
                }
            }
            return Json(post_data);
        }
        [HttpPost]
        public ActionResult notes([FromBody] notessave objContext)
        {
            notessave objout = new notessave();
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
                    string Urlcon1 = "api/Kiosk_attachment/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("notessave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }
    }
}
