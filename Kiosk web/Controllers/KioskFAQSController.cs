using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Kiosk_web.Controllers.KioskSetupController;
using static Kiosk_web.Models.FAQs_Model;

namespace Kiosk_web.Controllers
{
    public class KioskFAQSController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        string urlstring = "";
        public KioskFAQSController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult KioskFAQS()
        {
            return View();
        }


        [HttpPost]
        //Summary list
        public ActionResult FAQsList([FromBody] FAQSList objContext)
        {
            FAQSListContext objList = new FAQSListContext();
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
                    string Urlcon1 = "api/Kiosk_FAQS/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("FAQSList??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (FAQSListContext)JsonConvert.DeserializeObject(post_data, typeof(FAQSListContext));

                }
            }
            return Json(objList);
        }

        // To Edit FAQs Fetch

        [HttpPost]
        public ActionResult FAQfetch([FromBody] FAQSAnswersContext objContext)
        {
            FAQSAnswers objList = new FAQSAnswers();
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
                    string Urlcon1 = "api/Kiosk_FAQS/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("FAQSAnswers?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&In_faq_gid=" + objContext.In_faq_gid + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    // objList = (FAQSAnswersContext)JsonConvert.DeserializeObject(post_data, typeof(FAQSAnswersContext));
                }
            }
            return Json(post_data);
        }

        //delete
        [HttpPost]
        public ActionResult DeleteFAQs([FromBody] SaveFAQS objContext)
        {
            SaveFAQS objout = new SaveFAQS();
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
                    string Urlcon1 = "api/Kiosk_FAQS/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("FAQSsave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }


        //FAQs Save

        [HttpPost]

        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<ActionResult> faqattachment_save(IFormFile file,IFormFile file1, string userID, string orgnId, string locnId, string localeId, string model_flag,
            string gid, string In_faq_category, string In_faq_date, string In_faq_question, string In_faq_answer,
            string In_faq_keywords, string In_notes, string In_faq_ques_locallang, string In_faq_answer_locallang, string In_faq_keywords_locallang,string In_faq_urltype)
        {
            string post_data = "";
            string filepathextension = "";
            string filepathextension1 = "";
            try
            {
                SaveFAQS objattach = new SaveFAQS();

                if (file != null && file1!=null)
                {
                    if (ModelState.IsValid)
                    {
                        string filenamenew = "";
                        objattach.In_faq_ans_upload = file.FileName;
                        objattach.userId = userID;
                        FileInfo fi = new FileInfo(file.FileName);
                        string fileextension = fi.Extension;
                        filenamenew = filenamenew + "" + fileextension;
                        string webRootPath = _hostingEnvironment.ContentRootPath;
                        var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();

                        string folderName = Root_path;
                        webRootPath = Path.Combine(webRootPath, folderName);
                        var Folder = _configuration.GetSection("AppSettings")["FAQ"].ToString();
                        folderName = Folder;
                        string fileLocation = Path.Combine(webRootPath, folderName);
                        if (!Directory.Exists(fileLocation))
                        {
                            Directory.CreateDirectory(fileLocation);
                        }
                        Guid guid = Guid.NewGuid();
                        filepathextension = Path.Combine(fileLocation, Path.GetFileName(objattach.In_faq_ans_upload));
                        using (var stream = new FileStream(filepathextension, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        string filenamenew1 = "";
                        objattach.In_video_filenamef = file1.FileName;
                        FileInfo fi1 = new FileInfo(file1.FileName);
                        string fileextension1 = fi1.Extension;
                        filenamenew1 = filenamenew1 + "" + fileextension1;
                        string webRootPath1 = _hostingEnvironment.ContentRootPath;
                        var Root_path1 = _configuration.GetSection("AppSettings")["Rootpath"].ToString();
                        string folderName1 = Root_path1;
                        webRootPath1 = Path.Combine(webRootPath1, folderName1);
                        var Folder1 = _configuration.GetSection("AppSettings")["FAQ"].ToString();
                        folderName1 = Folder1;
                        string fileLocation1 = Path.Combine(webRootPath1, folderName1);
                        if (!Directory.Exists(fileLocation1))
                        {
                            Directory.CreateDirectory(fileLocation1);
                        }
                        Guid guid1 = Guid.NewGuid();
                        filepathextension1 = Path.Combine(fileLocation1, Path.GetFileName(objattach.In_video_filenamef));
                        using (var stream1 = new FileStream(filepathextension1, FileMode.Create))
                        {
                            await file.CopyToAsync(stream1);
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
                    SaveFAQS objContext = new SaveFAQS();
                    objContext.In_faq_gid = Convert.ToInt32(gid);
                    objContext.userId = userID;
                    objContext.orgnId = orgnId;
                    objContext.In_faq_ans_upload = filepathextension;
                    objContext.In_video_filenamef = objattach.In_video_filenamef;
                    objContext.In_video_filepathf = filepathextension1;
                    objContext.locnId = locnId;
                    objContext.localeId = localeId;
                    objContext.In_faq_category = In_faq_category;
                    objContext.In_faq_date = In_faq_date;
                    objContext.In_faq_question = In_faq_question;
                    objContext.In_faq_answer = In_faq_answer;
                    objContext.In_faq_keywords = In_faq_keywords;
                    objContext.In_notes = In_notes;
                    objContext.In_faq_ques_locallang = In_faq_ques_locallang;
                    objContext.In_faq_answer_locallang = In_faq_answer_locallang;
                    objContext.In_faq_keywords_locallang = In_faq_keywords_locallang;
                    objContext.In_faq_urltype = In_faq_urltype;
                    objContext.In_mode_flag = model_flag;
                 
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
                            string Urlcon1 = "api/Kiosk_FAQS/";
                            client.BaseAddress = new Uri(urlstring + Urlcon1);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                            var response1 = client.PostAsync("FAQSsave", content1).Result;
                            Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                            StreamReader reader1 = new StreamReader(data1);
                            post_data = reader1.ReadToEnd();
                            //objContext = (attchementsave)JsonConvert.DeserializeObject(post_data, typeof(attchementsave));
                        }
                    }

                }

                else
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
                    SaveFAQS objContext = new SaveFAQS();
                    objContext.In_faq_gid = Convert.ToInt32(gid);
                    objContext.userId = userID;
                    objContext.orgnId = orgnId;
                    objContext.In_faq_ans_upload = objattach.In_faq_ans_upload;
                    objContext.In_video_filenamef = objattach.In_video_filenamef;
                    objContext.locnId = locnId;
                    objContext.localeId = localeId;
                    objContext.In_faq_category = In_faq_category;
                    objContext.In_faq_date = In_faq_date;
                    objContext.In_faq_question = In_faq_question;
                    objContext.In_faq_answer = In_faq_answer;
                    objContext.In_faq_keywords = In_faq_keywords;
                    objContext.In_notes = In_notes;
                    objContext.In_faq_ques_locallang = In_faq_ques_locallang;
                    objContext.In_faq_answer_locallang = In_faq_answer_locallang;
                    objContext.In_faq_keywords_locallang = In_faq_keywords_locallang;
                    objContext.In_faq_urltype = In_faq_urltype;
                    objContext.In_mode_flag = model_flag;

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
                            string Urlcon1 = "api/Kiosk_FAQS/";
                            client.BaseAddress = new Uri(urlstring + Urlcon1);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                            var response1 = client.PostAsync("FAQSsave", content1).Result;
                            Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                            StreamReader reader1 = new StreamReader(data1);
                            post_data = reader1.ReadToEnd();
                            //objContext = (attchementsave)JsonConvert.DeserializeObject(post_data, typeof(attchementsave));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
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



        //Transulaete
        public JsonResult Language_Translate(string id)
        {
            var toLanguage = "";
            if (_configuration.GetSection("AppSettings")["Instance"].ToString() == "Ta")
            {
                toLanguage = "ta";//tamil
            }
            else
            {
                toLanguage = "hi";//hindi
            }
            var fromLanguage = "en";//english
                                    //var url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", fromLanguage, toLanguage, System.Web.HttpUtility.UrlEncode(id));
                                    //var webClient = new WebClient
                                    //{
                                    //    Encoding = System.Text.Encoding.UTF8
                                    //};
                                    //var result = webClient.DownloadString(url);

            Translator obj_Translator = new Translator();
            string result = "";


            try
            {
                // result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                result = obj_Translator.Translate(id, fromLanguage, toLanguage);
            }
            catch
            {
                return Json("Error");
            }
            return Json(result);

        }
        public class videodeletefile
        {
            public string filepath { get; set; }
        }

    }
}
