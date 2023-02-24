using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using System.Net;

namespace Kiosk_web.Controllers
{
    public class MastersDefinitionController : Controller
    {
        // GET: MastersDefinition
        public ActionResult MastersDefinition()
        {
            return View();
        }

        private IConfiguration _configuration;
        public MastersDefinitionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string urlstring = "";
        [HttpPost]
        public ActionResult MasterDefinitionList([FromBody]Context objContext)
        {
            RootObject objList = new RootObject();
            string post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
                //  urlstring = _configuration.GetSection("Api_uat")["api_url"].ToString();
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {               
                string Urlcon = "api/Web_MasterDefinition/";
                client.BaseAddress = new Uri(urlstring + Urlcon);              
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");               
                var response = client.PostAsync("MasterDefinition_List", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objList = (RootObject)JsonConvert.DeserializeObject(post_data, typeof(RootObject));
            }
            return Json(objList);
        }
        [HttpPost]
        public ActionResult MasterDefinitionsingle([FromBody]Contextsingle objContext)
        {
            Rootsingle objList = new Rootsingle();
            string post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
                //  urlstring = _configuration.GetSection("Api_uat")["api_url"].ToString();
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {               
                string Urlcon = "api/Web_MasterDefinition/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                // client.BaseAddress = new Uri("http://169.38.77.190:101/api/ICDProduct/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                // var response = client.GetAsync("").Result;
                var response = client.PostAsync("MasterDefinition_SingleFetch", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);   
                post_data = reader.ReadToEnd();
                objList = (Rootsingle)JsonConvert.DeserializeObject(post_data, typeof(Rootsingle));
            }
            return Json(objList);
        }
        [HttpPost]
        public ActionResult MasterDefinitionSave([FromBody]ContextSave objContext)
        {
            Root objRoot = new Root();
            Document objDoc = new Document();
            ContextSave objContextDetails = new ContextSave();
            objContextDetails.userId = objContext.userId;
            objContextDetails.locnId = objContext.locnId;
            objContextDetails.localeId = objContext.localeId;
            objContextDetails.orgnId = objContext.orgnId;
            objContextDetails.header = objContext.header;
            objContextDetails.detail = objContext.detail;


            objDoc.context = objContextDetails;
            objRoot.document = objDoc;
            string post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
               // urlstring = _configuration.GetSection("Api_uat")["api_url"].ToString();
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {
                 
               
                string Urlcon = "api/Web_MasterDefinition/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
               
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objRoot), UTF8Encoding.UTF8, "application/json");
                var response = client.PostAsync("MasterDefinition_Save", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd(); 

            }
            return Json(post_data);
        }

        //Delete:

        [HttpPost]
        public ActionResult MasterDefinitionDelete([FromBody]ContextSave objContext)
        {
            Root objRoot = new Root();
            Document objDoc = new Document();
            ContextSave objContextDetails = new ContextSave();
            objContextDetails.userId = objContext.userId;
            objContextDetails.locnId = objContext.locnId;
            objContextDetails.localeId = objContext.localeId;
            objContextDetails.orgnId = objContext.orgnId;
            objContextDetails.header = objContext.header;
            objContextDetails.detail = objContext.detail;
            objContextDetails.out_master_rowid = objContext.out_master_rowid;
            objContextDetails.out_mode_flag = objContext.out_mode_flag;


            objDoc.context = objContextDetails;
            objRoot.document = objDoc;
            string post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
                // urlstring = _configuration.GetSection("Api_uat")["api_url"].ToString();
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {
                //string Urlcon = "/newmaster";
                //client.BaseAddress = new Uri(urlstring + Urlcon);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpContent content = new StringContent(JsonConvert.SerializeObject(objRoot), UTF8Encoding.UTF8, "application/json");
                //var response = client.PostAsync("", content).Result;
                //Stream data = response.Content.ReadAsStreamAsync().Result;
                //StreamReader reader = new StreamReader(data);
                //post_data = reader.ReadToEnd();

                // urlstring = "http://localhost:51379/api/";
                string Urlcon = "api/Web_MasterDefinition/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                // client.BaseAddress = new Uri("http://169.38.77.190:101/api/ICDProduct/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objRoot), UTF8Encoding.UTF8, "application/json");
                // var response = client.GetAsync("").Result;
                var response = client.PostAsync("MasterDefinition_delete", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();

            }
            return Json(post_data);
        }




        #region Comman Grid List and Field
        //[HttpPost]
        //public string CommanGridField(string GetName)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("master_code", typeof(string));
        //    dt.Columns.Add("description", typeof(string));
        //    var XmlRoleFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //        Path.Combine("Common_Xml_File", "master_sys_enUS.xml"));
        //    XmlDocument xmlload = new XmlDocument();
        //    xmlload.Load(XmlRoleFullPath);
        //    XmlNodeList nodevalue = xmlload.SelectNodes("//root//row[parent_code='" + GetName + "']");
        //    for (int i = 0; i < nodevalue.Count; i++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["master_code"] = nodevalue[i]["master_code"].InnerXml;
        //        dr["description"] = nodevalue[i]["description"].InnerXml;
        //        dt.Rows.Add(dr);
        //    }
        //      return JsonConvert.SerializeObject(dt);
        //}

        #endregion
        #region xml Local DropDown Load
        public string Xmlcmb_Localbind()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("dependent_on", typeof(string));
            var XmlLoadFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                Path.Combine("CommonXml", "UserXml.xml"));
            XmlDocument XmlGetLoad = new XmlDocument();
            XmlGetLoad.Load(XmlLoadFullPath);
            XmlNodeList RoleNodeList = XmlGetLoad.SelectNodes("/UserDetails/dep");
            foreach (XmlNode RoleNodeGetVal in RoleNodeList)
            {
                DataRow dr = DT.NewRow();
                dr["dependent_on"] = RoleNodeGetVal.InnerText;
                DT.Rows.Add(dr);
            }
            return JsonConvert.SerializeObject(DT);
        }
        #endregion

        #region list model

        public class DetailItem
        {
            
            public int out_master_rowid { get; set; }
          
            public string out_parent_code { get; set; }
           
            public string out_parent_descripton { get; set; }
         
            public string out_master_code { get; set; }
            
            public string out_master_description { get; set; }
           
            public string out_master_ll_description { get; set; }
           
            public string out_depend_desc { get; set; }
            
            public string out_status_desc { get; set; }
        }

        public class Context
        {
           
            public string orgnId { get; set; }
           
            public string locnId { get; set; }
           
            public string userId { get; set; }
            
            public string localeId { get; set; }
            public string parent_code { get; set; }
            public List<DetailItem> detail { get; set; }
        }

        public class ApplicationException
        {
           
            public string errorNumber { get; set; }
           
            public string errorDescription { get; set; }
        }

        public class RootObject
        {
           
            public Context context { get; set; }
           
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region singlefetch model
        public class Detail
        {
            
            public int out_master_rowid { get; set; }
          
            public string out_parent_code { get; set; }
         
            public string out_parent_descripton { get; set; }
          
            public string out_master_code { get; set; }
           
            public string out_master_description { get; set; }
            
            public string out_master_ll_description { get; set; }
            public string out_depend_code { get; set; } //ADDED BY VINOTH - ISSUE- DEPEND CODE EMPTY WHILE SAVING
            public string out_depend_desc { get; set; }
           
            public string out_status_desc { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class Contextsingle
        {
            public string orgnId { get; set; }
          
            public string locnId { get; set; }
        
            public string userId { get; set; }
            
            public string localeId { get; set; }
            public string parent_code { get; set; }
            public List<Detail> detail { get; set; }
        }

        public class ApplicationExceptionsingle
        {
          
            public string errorNumber { get; set; }
           
            public string errorDescription { get; set; }
        }

        public class Rootsingle
        {
            
            public Contextsingle context { get; set; }
         
            public ApplicationExceptionsingle ApplicationException { get; set; }
        }
        #endregion
        #region Save model
        public class Header
        {
            /// <summary>
            /// 
            /// </summary>
            public string in_parent_code { get; set; }
        }

        public class DetailSave
        {
            /// <summary>
            /// 
            /// </summary>
             public int out_master_rowid { get; set; }

            
            /// <summary>
            /// 
            /// </summary>
            public int out_row_slno { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_master_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_master_description { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_master_ll_description { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_depend_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_locallang_flag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_status_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_row_timestamp { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_mode_flag { get; set; }
        }

        public class ContextSave
        {
            /// <summary>
            /// 
            /// </summary>
            public string orgnId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string locnId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string localeId { get; set; }
            /// <summary>
            /// 
            /// 
            /// 
            /// </summary>
            public Header header { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DetailSave> detail { get; set; }
            public string out_master_rowid { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class Document
        {
            /// <summary>
            /// 
            /// </summary>
            public ContextSave context { get; set; }
            public ApplicationExceptionsave ApplicationException { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Document document { get; set; }
        }

        public class ApplicationExceptionsave
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }
        #endregion


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
            var url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", fromLanguage, toLanguage, System.Web.HttpUtility.UrlEncode(id));
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);

            }
            catch
            {
                return Json("Error");
            }
            return Json(result);

        }
    }
}