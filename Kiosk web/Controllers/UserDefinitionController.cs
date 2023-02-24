
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;

namespace Kiosk_web.Controllers
{
    public class UserDefinitionController : Controller
    {
        // GET: UserDefinition
        public ActionResult UserDefinitionForm()
        {           
            return View();
        }

        //public IFormFile picture;
        [HttpPost]
        public string User(IFormFile file, string userID)
        {
            dynamic tmp_user = new JObject();
            if (file != null && file.Length > 0)
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.OpenReadStream().CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        tmp_user.result = System.Convert.ToBase64String(array);
                        tmp_user.success = true;
                        tmp_user.msg = "File uploaded successfully";
                    }
                }
                catch (Exception ex)
                {
                    tmp_user.success = false;
                    tmp_user.msg = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                tmp_user.success = false;
                tmp_user.msg = "You have not specified a file.";
            }

            return JsonConvert.SerializeObject(tmp_user);
        }

        private IConfiguration _configuration;
        public UserDefinitionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string urlstring = "";
        public ActionResult userDefinitionList([FromBody]Context objContext)
        {
            RootObject objList = new RootObject();
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
                // string Urlcon = "/alluserrole_list?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId;
                string Urlcon = "api/Web_UserManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                // var response = client.GetAsync("").Result;
                var response = client.GetAsync("alluserrole?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "").Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objList = (RootObject)JsonConvert.DeserializeObject(post_data, typeof(RootObject));

            }
            return Json(objList);
        }
        public ActionResult userroleactivtyList([FromBody]Context objContext)
        {
            userApplication objList = new userApplication();
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
                //string Urlcon = "/userrole_activity?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&user_id=" + objContext.user_id + "&role_code=" + objContext.role_code;
                string Urlcon = "api/Web_UserManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                // var response = client.GetAsync("").Result;
                var response = client.GetAsync("userroleactivity?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&user_id=" + objContext.user_id + "&role_code=" + objContext.role_code + "").Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objList = (userApplication)JsonConvert.DeserializeObject(post_data, typeof(userApplication));

            }
            return Json(objList);
        }
        [HttpPost]
        public ActionResult UserDefinitionfetch([FromBody] Context objContext)
        {
            Application objout = new Application();
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
                // string Urlcon = "/userrole?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&user_code=" + objContext.user_code;
                string Urlcon = "api/Web_UserManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                // var response = client.GetAsync("").Result;
                var response = client.GetAsync("userrole?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&user_code=" + objContext.user_code + "").Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objout = (Application)JsonConvert.DeserializeObject(post_data, typeof(Application));
            }
            return Json(objout);
        }
        [HttpPost]
        public ActionResult SaveUser([FromBody] SContext objContext)
        {
            SApplication objRoot = new SApplication();
            Document objDoc = new Document();
            SContext objContextDetails = new SContext();
            objContextDetails.userId = objContext.userId;
            objContextDetails.locnId = objContext.locnId;
            objContextDetails.localeId = objContext.localeId;
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
                //  urlstring = _configuration.GetSection("Api_uat")["api_url"].ToString();
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {
                //string Urlcon = "/newuserrole";
                string Urlcon = "api/Web_UserManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objRoot), UTF8Encoding.UTF8, "application/json");
                var response = client.PostAsync("newuserrole", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
            }
            return Json(post_data);
        }

        #region xml( BElongs to) user DropDown Load
        public string Xmlcmb_Belongbind()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("Orgl", typeof(string));
            var XmlLoadFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                Path.Combine("CommonXml", "UserXML.xml"));
            XmlDocument XmlGetLoad = new XmlDocument();
            XmlGetLoad.Load(XmlLoadFullPath);
            XmlNodeList RoleNodeList = XmlGetLoad.SelectNodes("/UserDetails/belong");
            foreach (XmlNode RoleNodeGetVal in RoleNodeList)
            {
                DataRow dr = DT.NewRow();
                dr["Orgl"] = RoleNodeGetVal.InnerText;
                DT.Rows.Add(dr);
            }
            return JsonConvert.SerializeObject(DT);
        }
        #endregion
        #region xml User GRId Details
        //public string UserDetails()
        //{

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("user_id", typeof(int));
        //    dt.Columns.Add("user_name", typeof(string));

        //    //var XmlUserFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //    //    Path.Combine("CommonXml", "UserXml.xml"));
        //    var XmlUserFullPath = Path.Combine(Server.MapPath("~/CommonXml/UserXml.xml"));
        //    XmlDocument xmlobject = new XmlDocument();
        //    xmlobject.Load(XmlUserFullPath);
        //    XmlNodeList UserNodelist = xmlobject.SelectNodes("/UserDetails/User");
        //    foreach (XmlNode UserData in UserNodelist)
        //    {
        //        XmlElement getidname = (XmlElement)UserData;
        //        DataRow dr = dt.NewRow();
        //        dr["user_id"] = Convert.ToInt32(getidname.GetElementsByTagName("UserId")[0].InnerText);
        //        dr["user_name"] = getidname.GetElementsByTagName("UserName")[0].InnerText;
        //        dt.Rows.Add(dr);
        //    }
        //    return JsonConvert.SerializeObject(dt);
        //}
        #endregion
        #region list model

        public class List
        {
            public string orgn_code { get; set; }
            public string orgn_desc { get; set; }
            public string user_code { get; set; }
            public string user_name { get; set; }
            public string role_code { get; set; }
            public string role_name { get; set; }
            public string valid_till { get; set; }
            public string contact_no { get; set; }
            public string email_id { get; set; }
            public string status_desc { get; set; }
        }

        public class Context
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string user_id { get; set; }
            public string role_code { get; set; }


            public string user_code { get; set; }
            public List<List> list { get; set; }
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
        #region fetch 
        public class Header
        {
            public string out_orgn_code { get; set; }
            public string out_user_name { get; set; }
            public string out_role_code { get; set; }
            public string out_user_pwd { get; set; }
            public string out_valid_till { get; set; }
            public string out_contact_no { get; set; }
            public string out_email_id { get; set; }
            public string out_profile_photo { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
            public string out_row_timestamp { get; set; }

        }
        public class Detail
        {
            public string out_activity_code { get; set; }
            public string out_activity_desc { get; set; }
            public string out_add_perm { get; set; }
            public string out_mod_perm { get; set; }
            public string out_view_perm { get; set; }
            public string out_auth_perm { get; set; }
            public string out_inactivate_perm { get; set; }
            public string out_print_perm { get; set; }
            public string out_deny_perm { get; set; }

        }
        public class fetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public Header Header { get; set; }
            public IList<Detail> Detail { get; set; }

        }
        public class fApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class Application
        {
            public fetchContext context { get; set; }
            public fApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region fetch r63e
        public class userDetail
        {
            public string out_activity_code { get; set; }
            public string out_activity_desc { get; set; }
            public string out_add_perm { get; set; }
            public string out_mod_perm { get; set; }
            public string out_auth_perm { get; set; }
            public string out_view_perm { get; set; }
            public string out_inactivate_perm { get; set; }
            public string out_print_perm { get; set; }
            public string out_deny_perm { get; set; }

        }
        public class userContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<Detail> detail { get; set; }

        }
        public class userApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class userApplication
        {
            public userContext context { get; set; }
            public userApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region save model
        public class SHeader
        {
            public string In_orgn_code { get; set; }
            public string In_role_code { get; set; }
            public string In_user_code { get; set; }
            public string In_user_name { get; set; }
            public string In_user_pwd { get; set; }
            public string In_valid_till { get; set; }
            public string In_contact_no { get; set; }
            public string In_email_id { get; set; }
            public string In_profile_photo { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }

        }
        public class SContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SHeader Header { get; set; }

        }
        public class Document
        {
            public SContext context { get; set; }

        }
        public class SApplication
        {
            public Document document { get; set; }

        }
        #endregion
    }
}