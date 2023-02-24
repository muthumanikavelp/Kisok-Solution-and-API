using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
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

namespace Kiosk_web.Controllers
{
    public class RoleDefinitionController : Controller
    {

        #region Role Definition
        // GET: RoleDefinition
        public ActionResult RoleDefinitionForm()
        {
            return View();
        }
       
        #endregion
        private IConfiguration _configuration;
        public RoleDefinitionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string urlstring = "";
        [HttpPost]
        public ActionResult RoleDefinitionList([FromBody] RoleManagementContext objContext)
        {
            RoleMangementList objList = new RoleMangementList();
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
                string Urlcon = "api/Web_RoleManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("allroles??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "").Result; ;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objList = (RoleMangementList)JsonConvert.DeserializeObject(post_data, typeof(RoleMangementList));
            }
            return Json(objList);
        }
        [HttpPost]        
        public ActionResult RoleDefinitionfetch(string userId, string orgnId, string locnId, string localeId, int role_rowid, string orgn_level)
        {
            RoleManagementFetch objout = new RoleManagementFetch();
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
                string Urlcon = "api/Web_RoleManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                var response = client.GetAsync("roleactivity?org=" + orgnId + "&locn=" + locnId + "&user=" + userId + "&lang=" + localeId + "&role_rowid=" + role_rowid + "&orgn_level=" + orgn_level + "").Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
                objout = (RoleManagementFetch)JsonConvert.DeserializeObject(post_data, typeof(RoleManagementFetch));
            }
            return Json(objout);
        }
        [HttpPost]
        public ActionResult SaveRole([FromBody] SaveRMContext objContext)
        {
            SaveRMRoot objRoot = new SaveRMRoot();
            SaveRMDocument objDoc = new SaveRMDocument();
            SaveRMContext objContextDetails = new SaveRMContext();
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
                //  urlstring = _configuration.GetSection("Api_uat")["api_url"].ToString();
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
            }
            using (var client = new HttpClient())
            {
                string Urlcon = "api/Web_RoleManagement/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(objRoot), UTF8Encoding.UTF8, "application/json");
                // var response = client.GetAsync("newrole").Result;
                var response = client.PostAsync("newrole", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();
            }
            return Json(post_data);
        }
        #region xml data DropDown Load
        public string Xmlcmb_rolebind()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("Code", typeof(string));
            DT.Columns.Add("Description", typeof(string));
            var XmlLoadFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                Path.Combine("CommonXml", "OrglevelXml.xml"));
            var doc = XDocument.Load(XmlLoadFullPath);

            var fldDtl = from flds in doc.Descendants("row") select flds;

            foreach (XElement fld in fldDtl)
            {
                var flds = from fl in fld.Elements() select fl;
                DataRow dr = DT.NewRow();
                foreach (XElement ele in flds)
                {
                    dr[ele.Name.ToString()] = Convert.ToString(ele.Value);
                }
                DT.Rows.Add(dr);
            }



            return JsonConvert.SerializeObject(DT);
        }

        #endregion



        #region Role Information(GetXml Role ID and Name)

        public string RoleInfo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RoleID", typeof(int));
            dt.Columns.Add("RoleName", typeof(string));
            var XmlRoleFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                Path.Combine("Common_Xml_File", "role.xml"));
            XmlDocument xmlobject = new XmlDocument();
            xmlobject.Load(XmlRoleFullPath);
            XmlNodeList RoleNodelist = xmlobject.SelectNodes("/root/row");
            foreach (XmlNode RoleData in RoleNodelist)
            {
                XmlElement getidname = (XmlElement)RoleData;
                DataRow dr = dt.NewRow();
                dr["RoleID"] = Convert.ToInt32(getidname.GetElementsByTagName("role_code")[0].InnerText);
                dr["RoleName"] = getidname.GetElementsByTagName("role_name")[0].InnerText;
                dt.Rows.Add(dr);
            }
            return JsonConvert.SerializeObject(dt);
        }

        #endregion

        #region List
        public class RoleManagement
        {
            public int out_role_rowid { get; set; }
            public string out_role_code { get; set; }
            public string out_role_name { get; set; }
            public string out_orgn_level { get; set; }
            public string out_orgn_level_desc { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
        }

        public class RoleManagementContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public List<RoleManagement> List { get; set; }
        }

        public class RoleManagementApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }
        }

        public class RoleMangementList
        {
            public RoleManagementContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region SingleFetch
        public class FetchRolManagementHeader
        {
            public string out_role_code { get; set; }
            public string out_role_name { get; set; }
            public string inout_orgn_level { get; set; }
            public string out_orgn_level_desc { get; set; }
            public string out_status_code { get; set; }
            public string out_status_desc { get; set; }
            public string out_row_timestamp { get; set; }
            public string out_mode_flag { get; set; }
        }

        public class FetchRoleManagementDetail
        {
            public int out_rolemenu_rowid { get; set; }
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

        public class FetchRoleManagementContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }

            public FetchRolManagementHeader header { get; set; }
            public List<FetchRoleManagementDetail> detail { get; set; }
        }

        public class RoleManagementFetch
        {
            public FetchRoleManagementContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region SaveInput

        public class SaveRMHeader
        {
            public int inout_role_rowid { get; set; }
            public string in_role_code { get; set; }
            public string in_role_name { get; set; }
            public string in_orgn_level { get; set; }
            public string in_status_code { get; set; }
            public string in_row_timestamp { get; set; }
            public string in_mode_flag { get; set; }
        }

        public class SaveRMDetail
        {
            public int out_rolemenu_rowid { get; set; }
            public string out_activity_code { get; set; }
            public string out_add_perm { get; set; }
            public string out_mod_perm { get; set; }
            public string out_view_perm { get; set; }
            public string out_auth_perm { get; set; }
            public string out_inactivate_perm { get; set; }
            public string out_print_perm { get; set; }
            public string out_deny_perm { get; set; }
        }

        public class SaveRMContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SaveRMHeader header { get; set; }
            public List<SaveRMDetail> detail { get; set; }
        }

        public class SaveRMDocument
        {
            public SaveRMContext context { get; set; }
        }

        public class SaveRMRoot
        {
            public SaveRMDocument document { get; set; }
        }

        #endregion

        #region SaveOutput
        public class RMOutputHeader
        {
            public int inout_role_rowid { get; set; }
        }

        public class RMOutputContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public RMOutputHeader header { get; set; }
        }

        public class RMOutput
        {
            public RMOutputContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion
    }
}