using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Kiosk_web.Models;

namespace Kiosk_web.Controllers
{
    public class HelpFilterController : Controller
    {
        public string searchSql = "";
        private string strpath;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        public HelpFilterController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
       
        //public HelpFilterController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        string dbstring = "";
        public ActionResult HelpFilter()
        {
            return View();
        }
        public class helpmodel
        {
            public string search_id { get; set; }
            public string input { get; set; }
            public string row_val { get; set; }
        }
            [HttpPost]
        public string datatypelist([FromBody] helpmodel search_id)
        {
            string search = search_id.search_id;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            DataTable dt = Common.Util.generateInputColumn((webRootPath +"/CommonXml/Help.xml"), search);           
            return JsonConvert.SerializeObject(dt);
        }

        [HttpPost]
        public string datatypedetails([FromBody] helpmodel search_id)
        {
            string search = search_id.search_id;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;           
           DataTable dt = Common.Util.generateOutputColumn((webRootPath + "/CommonXml/Help.xml"), search, "coldesc");
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            return JsonConvert.SerializeObject(dt);
        }

        [HttpPost]
        public string search([FromBody] helpmodel search_id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            DataTable dt_output = Common.Util.generateOutputColumn((webRootPath + "/CommonXml/Help.xml"), search_id.search_id, "column");

            string outputSql = Common.Util.getoutputSqlColumn(dt_output);

            string tabName = Common.Util.getInputTableName((webRootPath + "/CommonXml/Help.xml"), search_id.search_id);

            var dattable = Common.Util.InputDataTable(search_id.input);

            string Where_condition = Common.Util.dttableToQuery(dattable);

            string order_by = Common.Util.getOutputOrderby((webRootPath + "/CommonXml/Help.xml"), search_id.search_id);

            searchSql = " SELECT DISTINCT " + outputSql + " FROM " + tabName ;
         
            var result = search_result(searchSql, Where_condition);
           
            return result;
        }

        public string search_result(string sql_query,string Where_condition)
        {
            try
            {
                if (_configuration.GetSection("AppSettings")["Instance"].ToString() == "Ta")
                {
                    if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
                    {
                        dbstring = _configuration.GetSection("dbtypeTA")["mysqlcon"].ToString();
                    }
                    else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
                    {
                        dbstring = _configuration.GetSection("dbtypeTAUAt")["mysqlcon"].ToString();
                    }
                    else
                    {
                        dbstring = _configuration.GetSection("dbtypeTA")["mysqlcon"].ToString();
                    }
                   
                }
                else if (_configuration.GetSection("AppSettings")["Instance"].ToString() == "bh")
                {
                    dbstring = _configuration.GetSection("dbtypeBA")["mysqlcon"].ToString();
                }
                else if (_configuration.GetSection("AppSettings")["Instance"].ToString() == "od")
                {
                    if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
                    {
                        dbstring = _configuration.GetSection("dbtypeOD")["mysqlcon"].ToString();
                    }
                    else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
                    {
                        dbstring = _configuration.GetSection("dbtypeODUat")["mysqlcon"].ToString();
                    }
                    else
                    {
                        dbstring = _configuration.GetSection("dbtypeOD")["mysqlcon"].ToString();
                    }
                }
                else if (_configuration.GetSection("AppSettings")["Instance"].ToString() == "up")
                {
                    dbstring = _configuration.GetSection("dbtypeUP")["mysqlcon"].ToString();
                }
                else if (_configuration.GetSection("AppSettings")["Instance"].ToString() == "ju")
                {
                    if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
                    {
                        dbstring = _configuration.GetSection("dbtypeJU")["mysqlcon"].ToString();

                    }
                    else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
                    {
                        dbstring = _configuration.GetSection("dbtypeJUUAt")["mysqlcon"].ToString();

                    }
                    else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "PRO")
                    {
                        dbstring = _configuration.GetSection("dbtypeJUPRO")["mysqlcon"].ToString();

                    }

                }

                DataSet response = new DataSet();
                Helpdatamodel objproduct1 = new Helpdatamodel();
                response = objproduct1.search(sql_query, Where_condition, dbstring);

                DataTable dt = response.Tables[0];
                string arr_resultList = ToStringAsXml(dt);

                if (arr_resultList != null)
                {
                    XDocument doc = new XDocument();
                    string obj = "<root>" + arr_resultList + "</root>";
                    doc = XDocument.Parse(obj);

                    XElement setup = (from NewDataSet in doc.Descendants("NewDataSet") select NewDataSet).First();

                    //foreach (XElement xer in setup.Descendants("Table"))
                    //{
                    //    foreach (XElement xe in xer.Descendants())
                    //        dt.Columns.Add(xe.Name.ToString(), typeof(string)); // add columns to your dt
                    //    break;
                    //}
                    var set1rec = (from NewDataSet in doc.Descendants("NewDataSet") select NewDataSet);

                    if (set1rec.Count() > 0)
                    {
                        XElement setup1 = (from NewDataSet in doc.Descendants("NewDataSet") select NewDataSet).First();
                        //foreach (XElement xe2 in setup1.Descendants("Table"))
                        //{
                        //    DataRow dr = dt.NewRow();
                        //    int i = 0;
                        //    foreach (XElement xe in xe2.Descendants())
                        //    {
                        //        dr[i] = xe.Value.ToString();
                        //        i = i + 1;
                        //    }
                        //    dt.Rows.Add(dr);
                        //}
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                    string jsontext = JsonConvert.SerializeObject(dt);

                    return jsontext;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string ToStringAsXml(DataTable ds)
        {
            StringWriter sw = new StringWriter();
            ds.WriteXml(sw, XmlWriteMode.IgnoreSchema);
            string s = sw.ToString();
            return s;
        }
       

        [HttpPost]
        public string onSelection([FromBody] helpmodel search_id)
        {
            try
            {
                dynamic obj = JsonConvert.DeserializeObject(search_id.row_val);

                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public FileResult pdfdownload(string filename)
        {
            string path = "";
            var content_type = "";            
            if (filename == "icdusermanual")
            {
                 //path = Server.MapPath("/user_manual/ICD User Manual_FINAL.pdf");
                content_type = "application/pdf";
            }
            if (filename == "fdrusermanual")
            {
                //path = Server.MapPath("/user_manual/FDR User Manual_FINAL.pdf");
                content_type = "application/pdf";
            }
                return File(path, content_type, filename);
        }


	}
}