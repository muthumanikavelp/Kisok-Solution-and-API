using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using static Kiosk_web.Models.GovtSchemesModel;


namespace Kiosk_web.Controllers
{
    public class GovtSchemesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        private IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public GovtSchemesController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult GovtSchemesForm()
        {
            return View();
        }
        string urlstring = "";
        [HttpPost]
        public ActionResult GovtschemesList([FromBody] SchemesSummary objContext)
        {
            SchemesSummaryContext objList = new SchemesSummaryContext();
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
                    string Urlcon1 = "api/Kiosk_Scheme/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("SchemeSummaryList??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&lang=" + objContext.localeId + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (SchemesSummaryContext)JsonConvert.DeserializeObject(post_data, typeof(SchemesSummaryContext));
                    for (var i = 0; i < objList.Summary.Count; i++)
                    {
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        string contentRootPath = _webHostEnvironment.ContentRootPath;
                        string filename = objList.Summary[i].out_scheme_upload;
                        String[] strarr = filename.Split("\\");
                        int len = strarr.Length;
                        string strfilename = strarr[len - 1];
                        var Folder = _configuration.GetSection("AppSettings")["Attachfolder"].ToString();

                        string Clientpath = Path.Combine("/" + Folder +"/" + strfilename + "");
                        objList.Summary[i].out_scheme_upload = Clientpath;
                    }
                }
            }
            return Json(objList);
        }
      
        [HttpPost]
        public ActionResult GovtSchemesfetch([FromBody] GetSchemedataContext objContext)
        {
            GetSchemedataContext objout = new GetSchemedataContext();
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
                    string Urlcon1 = "api/Kiosk_Scheme/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("GetSchemeGetList?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&In_scheme_gid=" + objContext.In_scheme_gid + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objout = (GetSchemedataContext)JsonConvert.DeserializeObject(post_data, typeof(GetSchemedataContext));
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string contentRootPath = _webHostEnvironment.ContentRootPath;
                    string filename = objout.schemeFetch.out_scheme_upload;
                    String[] strarr = filename.Split("\\");
                    int len = strarr.Length;
                    string strfilename = strarr[len - 1];
                    objout.schemeFetch.out_scheme_upload = strfilename;
                }
            }
            return Json(objout);
        }
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<ActionResult>  GovtSchemesave(string orgnId, string locnId, string userId, string localeId, string In_scheme_gid, string In_scheme_category, string In_scheme_date, string In_scheme_state, string In_scheme_schname, string In_scheme_description, string In_scheme_keyword, string In_scheme_schname_locallang, string In_schema_des_locallang,
            string In_scheme_keyword_locallang, IFormFile uploadFile,string In_scheme_url,  string In_scheme_status, string In_mode_flag)
        {
            string post_data = "";
            SaveScheme objattach = new SaveScheme();

            try
            {
                SaveScheme objContext = new SaveScheme();
                objContext.orgnId = orgnId;
                objContext.userId = userId;
                objContext.locnId = locnId;
                objContext.localeId = localeId;
                objContext.In_scheme_gid = Convert.ToInt32(In_scheme_gid);
                objContext.In_scheme_category = In_scheme_category;
                objContext.In_scheme_date = In_scheme_date;
                objContext.In_scheme_state = In_scheme_state;
                objContext.In_scheme_schname = In_scheme_schname;
                objContext.In_scheme_description = In_scheme_description;
                objContext.In_scheme_keyword = In_scheme_keyword;
                objContext.In_scheme_schname_locallang = In_scheme_schname_locallang;
                objContext.In_schema_des_locallang = In_schema_des_locallang;
                objContext.In_scheme_keyword_locallang = In_scheme_keyword_locallang;
                objContext.In_scheme_url = In_scheme_url;
                objContext.In_scheme_status = In_scheme_status;
                objContext.In_mode_flag = In_mode_flag;
                string filepathextension = "";
                if (uploadFile != null)
                {
                    string filenamenew = "";
                    objattach.In_scheme_upload = uploadFile.FileName;
                    objattach.userId = userId;
                    FileInfo fi = new FileInfo(uploadFile.FileName);
                    string fileextension = fi.Extension;
                    filenamenew = filenamenew + "" + fileextension;
                    string webRootPath = _hostingEnvironment.ContentRootPath;
                    var Root_path = _configuration.GetSection("AppSettings")["Rootpath"].ToString();

                    string folderName = Root_path;
                    webRootPath = Path.Combine(webRootPath, folderName);
                    var Folder = _configuration.GetSection("AppSettings")["Attachfolder"].ToString();

                    folderName = Folder;
                    string fileLocation = Path.Combine(webRootPath, folderName);
                    Guid guid = Guid.NewGuid();
                    filepathextension = Path.Combine(fileLocation, Path.GetFileName(objattach.In_scheme_upload));
                    using (var stream = new FileStream(filepathextension, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(stream);
                    }
                }
                objContext.In_scheme_upload = filepathextension;
              
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
                        string Urlcon1 = "api/Kiosk_Scheme/";
                        client.BaseAddress = new Uri(urlstring + Urlcon1);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                        var response1 = client.PostAsync("Schemesave", content1).Result;
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
    }
}
