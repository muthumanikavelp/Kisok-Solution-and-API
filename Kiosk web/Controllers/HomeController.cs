using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace Kiosk_web.Controllers
{
    public class HomeController : Controller
    {

        public static List<combo_values> combo;
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;
        public HomeController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        string urlstring = "";
        public ActionResult Home()
        {
            //mastercodelist();
            Common.Global.filter_condition = "";
            return View();
        }

        [HttpPost]
        public string displayHelp(string id)
        {
            if (id == "")
                id = "Help.html";
            string url = ConfigurationManager.AppSettings["helpUrl"].ToString() + id;
            return url;
        }

        [HttpPost]
        public string mastercodelist()
        {
            try
            {
                string[] result = { };
                string post_data = "";
                dynamic master_header = new JObject();
                master_header.orgnId = "flexi";
                master_header.locnId= _configuration.GetSection("Appsettings")["Instance"].ToString();
                master_header.userId = "admin";
                master_header.localeId = "en_US";
                master_header.parent_code = "ALL";
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
                    string Urlcon = "api/MasterDefinition/";
                    client.BaseAddress = new Uri(urlstring + Urlcon);                  
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(master_header), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("MasterDefinition_List", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    post_data = reader.ReadToEnd();                   
                    result = (string[])JsonConvert.DeserializeObject(post_data, result.GetType());
                }
                Common.Util.mstlist = result;
            }
            catch (Exception ex)
            {
                //Common.LogTest.TestClass.getLogError(
                //                 Request.RequestContext.RouteData.Values["controller"].ToString(),
                //                 MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return JsonConvert.SerializeObject(Common.Util.mstlist);
        }
        #region MasterCodeScreenId

        public class Master_codeInput
        {
            public string userId { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public string screen_Id { get; set; }
       
        }
        public class MCSIHeader
        {
            public string screen_description { get; set; }
        }

        public class MCSIDetail
        {
            public int out_master_rowid { get; set; }
            public int out_row_slno { get; set; }
            public string out_parent_code { get; set; }
            public string out_parent_description { get; set; }
            public string out_master_code { get; set; }
            public string out_master_description { get; set; }
            public string out_master_ll_description { get; set; }
            public string out_depend_code { get; set; }
            public string out_depend_desc { get; set; }
            public string out_locallang_flag { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
            public string out_row_timestamp { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class MasterCodeScreenID
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public MCSIHeader Header { get; set; }
            public List<MCSIDetail> Detail { get; set; }
        }

        #endregion
        [HttpPost]
         public string screenId_mastercodelist( [FromBody] Master_codeInput input)
        {
            try
            {
                string screen_code = "";
                string orgnId = "";
                string locnId = "";
                string userId = "";
                string localeId = "";
             
                if (input.screen_Id == null)
                {
                    screen_code = "";
                }
                else
                {
                    screen_code = input.screen_Id;
                }
                if (input.orgnId == null)
                {
                    orgnId = "Global";
                }
                else
                {
                    orgnId = input.orgnId;
                }
                if (input.locnId == null)
                {
                    locnId = _configuration.GetSection("Appsettings")["Instance"].ToString();
                }
                else
                {
                    locnId = input.locnId;
                }
                if (input.userId == null)
                {
                    userId = "admin";
                }
                else
                {
                    userId = input.userId;
                }
                if (input.localeId == null)
                {
                    localeId = "en_US";
                }
                else
                {
                    localeId = input.localeId;
                }
                MasterCodeScreenID objList = new MasterCodeScreenID();
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
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                    var response = client.GetAsync("mastercode_screenid?org=" + orgnId + "&locn=" + locnId + "&user=" + userId + "&lang=" + localeId + "&screen_code=" + screen_code + "").Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    post_data = reader.ReadToEnd();
                     objList = (MasterCodeScreenID)JsonConvert.DeserializeObject(post_data, typeof(MasterCodeScreenID));
                    object[] array1 = new object[objList.Detail.Count];
                    for (var i = 0; i < objList.Detail.Count; i++)
                    {
                        array1[i] = objList.Detail[i];
                    }
                    Common.Util.mstScreenlist = array1;
                }
            }
            catch (Exception ex)
            {
                //Common.LogTest.TestClass.getLogError(
                //                Request.RequestContext.RouteData.Values["controller"].ToString(),
                //                MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return JsonConvert.SerializeObject(Common.Util.mstScreenlist);
        }

        //[HttpPost]
        //public string getcode(string mstcode)
        //{
        //    DataTable dt = Common.Util.load_mastercodes(mstcode);
        //    return JsonConvert.SerializeObject(dt);

        //}

        [HttpPost]
        public string getScreenIDcode([FromBody] Master_codeInput input)
        {
            DataTable dt = Common.Util.load_ScreenIDmastercodes(input.screen_Id);
            return JsonConvert.SerializeObject(dt);

        }
        //[HttpPost]
        //public string getScreencode(string deptcode)
        //{
        //    DataTable dt = Common.Util.load_Screenmastercodes(deptcode);
        //    return JsonConvert.SerializeObject(dt);

        //}

        public static object[] mstlist;

        public class combo_values
        {
            public string mastercode { get; set; }
            public string code { get; set; }
            public string description { get; set; }
            public string status { get; set; }
            public string mstcode { get; set; }
        }

        public List<combo_values> Aval_Permission(DataTable dt_Aval)
        {
            List<combo_values> aval_perm = new List<combo_values>();
            foreach (DataRow dr in dt_Aval.Rows)
            {
                combo_values newPerm = new combo_values();

                newPerm.mastercode = dr["mastercode"].ToString();
                newPerm.code = dr["code"].ToString();
                newPerm.description = dr["description"].ToString();
                newPerm.status = dr["status"].ToString();

                aval_perm.Add(newPerm);
            }
            return aval_perm;
        }


        [HttpPost]
        public string javascript_log4j(string formName, string filename, string methodName, string errmsg)
        {
            //Common.LogTest.TestClass.getJavascriptLogerror(formName, filename, methodName, errmsg);
            return "";
        }

    }
}