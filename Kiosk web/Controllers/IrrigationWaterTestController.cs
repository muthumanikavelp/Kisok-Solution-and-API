using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Kiosk_web.Models.IrrigationWaterTestModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Kiosk_web.Controllers
{
    public class IrrigationWaterTestController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(IrrigationWaterTestController)); //Declaring Log4Net.
        private IHostingEnvironment _hostingEnvironment;
        private MySqlConnection con;
        string dbstring = "";
        private IConfiguration _configuration;
        dynamic excel_msg = new JObject();
        public IrrigationWaterTestController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult IrrigationWaterTest()
        {
            return View();
        }
        string urlstring = "";
        private string post_data;

        #region
        //venkat introduced  by code get soliparameters new button click 2021-04-21
        [HttpPost]
        public ActionResult getirrigationparameters([FromBody] irrigationlist objContext)
        {
            irrigationParametersDetailItems obj_soilparalist = new irrigationParametersDetailItems();
            string Post_data = "";
            try
            {

                if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
                {
                    urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
                }
                else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
                {
                    urlstring = _configuration.GetSection("AppSettings")["api_url_final"].ToString();
                }
                else
                {
                    urlstring = _configuration.GetSection("AppSettings")["api_url"].ToString();
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
                        string urlcon = "api/Kiosk_IrrigationWaterTest/";
                        client.BaseAddress = new Uri(urlstring + urlcon);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response1 = client.GetAsync("getirrigationparameters?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&lang=" + objContext.localeId + "&status=" + objContext.irrigation_status + "").Result;
                        Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                        StreamReader reader1 = new StreamReader(data1);
                        post_data = reader1.ReadToEnd();
                        obj_soilparalist = (irrigationParametersDetailItems)JsonConvert.DeserializeObject(post_data, typeof(irrigationParametersDetailItems));
                    }


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(obj_soilparalist);
        }

        [HttpPost]
        public ActionResult getNONNABLirrigationparameters([FromBody] irrigationlist objContext)
        {
            irrigationParametersDetailItems obj_soilparalist = new irrigationParametersDetailItems();
            string Post_data = "";
            try
            {

                if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
                {
                    urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
                }
                else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
                {
                    urlstring = _configuration.GetSection("AppSettings")["api_url_final"].ToString();
                }
                else
                {
                    urlstring = _configuration.GetSection("AppSettings")["api_url"].ToString();
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
                        string urlcon = "api/Kiosk_IrrigationWaterTest/";
                        client.BaseAddress = new Uri(urlstring + urlcon);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response1 = client.GetAsync("getNONNABLirrigationparameters?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&lang=" + objContext.localeId + "&status=" + objContext.irrigation_status + "").Result;
                        Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                        StreamReader reader1 = new StreamReader(data1);
                        post_data = reader1.ReadToEnd();
                        obj_soilparalist = (irrigationParametersDetailItems)JsonConvert.DeserializeObject(post_data, typeof(irrigationParametersDetailItems));
                    }


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(obj_soilparalist);
        }
        #endregion
        #region irrigation list 
        [HttpPost]
        public ActionResult irrigationList([FromBody] irrigationlist objContext)
        {

            irrigationContext objList = new irrigationContext();
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
                    string Urlcon1 = "api/Kiosk_IrrigationWaterTest/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("IrrigationList??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&lang=" + objContext.localeId + "&In_farmer_gid=" + objContext.In_farmer_gid + "&status=" + objContext.irrigation_status + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (irrigationContext)JsonConvert.DeserializeObject(post_data, typeof(irrigationContext));
                }
            }
            return Json(objList);
        }
        #endregion
        #region IrrigationSave
        [HttpPost]
        public ActionResult irrigationsave([FromBody] irrigationsave objContext)
        {
            irrigationsave objout = new irrigationsave();
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
                    string Urlcon1 = "api/Kiosk_IrrigationWaterTest/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("irrigationsave", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }
        #endregion
        #region irrigation Fetch
        [HttpPost]
        public ActionResult irrigationfetch([FromBody] irrigationviewContext objContext)
        {
            irrigationviewContext objout = new irrigationviewContext();
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
                    string Urlcon1 = "api/Kiosk_IrrigationWaterTest/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("IrrigationListView?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&irrigation_gid=" + objContext.irrigation_gid + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objout = (irrigationviewContext)JsonConvert.DeserializeObject(post_data, typeof(irrigationviewContext));
                    HttpContext.Session.SetString("orgId", objout.orgnId);
                    HttpContext.Session.SetString("userId", objout.userId);
                    HttpContext.Session.SetString("In_farmer_code", objout.farmer_code);
                    HttpContext.Session.SetString("In_Tran_Id", objout.header.out_Tran_Id);
                    HttpContext.Session.SetString("locnId", objout.locnId);
                    HttpContext.Session.SetString("localeId", objout.localeId);
                }
            }
            return Json(objout);
        }
        #endregion
        //Print PDF
        #region
        public ActionResult downloadpdf(string Signature_NameP, string Signature_ImPathP, string Headerpart,string Signature_DesgnP, string notewith)
        {
            excel_msg = "";
            string filename = _configuration.GetSection("AppSettings")["PrintIrrigation"].ToString();
            var sptver = filename;
            string FileType = _configuration.GetSection("AppSettings")["FileExtention"].ToString();
            var file_ext = FileType;
            string webRootPath = _hostingEnvironment.WebRootPath;
            logger.Debug("webRootPath -" + webRootPath);
            var Download_path = _configuration.GetSection("AppSettings")["soildownload"].ToString();
            string folderName = "DownloadXLFiles";
            Guid guid = Guid.NewGuid();
            string fileLocation = Path.Combine(webRootPath, folderName);
            logger.Debug("fileLocation -" + fileLocation);
            string Clientpath = Path.Combine("/DownloadXLFiles/" + sptver + guid + "_" + file_ext);
            logger.Debug("Clientpath  - " + Clientpath);
            string path = Path.Combine(fileLocation, sptver + guid + "_" + file_ext);
            logger.Debug(" path -" + path);
            excel_msg = Clientpath;
            try
            {
                if (System.IO.File.Exists(path))
                {

                    System.IO.File.Delete(path);
                }
                byte[] filecontent = exportpdf(path, Signature_NameP, Signature_ImPathP, Headerpart, Signature_DesgnP,notewith);
                logger.Debug("filecontent - " + filecontent);


                logger.Debug("excel_msg - " + excel_msg.path);
            }
            catch (Exception ex)
            {
                logger.Error("downloadpdf method - " + ex.ToString());
            }

            return Json(excel_msg);
        }
        #endregion
        public class FarmerQrContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FarmerCode { get; set; }
            public int In_farmer_gid { get; set; }
        }
        #region
        public byte[] exportpdf(string path, string Signature_NameP, string Signature_ImPathP, string Headerpart,string Signature_DesgnP, string notewith)
        {
            try
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

                //session values
                var orgnId = HttpContext.Session.GetString("orgId");
                var userId = HttpContext.Session.GetString("userId");
                var In_Tran_Id = HttpContext.Session.GetString("In_Tran_Id");
                var In_farmer_code = HttpContext.Session.GetString("In_farmer_code");
                var locnId = HttpContext.Session.GetString("locnId");
                var localeId = HttpContext.Session.GetString("localeId");


                irrigationviewContext objList = new irrigationviewContext();
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
                    var response2 = client1.PostAsync("authenticate", content).Result;
                    Stream data = response2.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    post_data = reader.ReadToEnd();
                    objt = (gettoken)JsonConvert.DeserializeObject(post_data, typeof(gettoken));
                    string auth = objt.token;

                    using (var client = new HttpClient())
                    {
                        string Urlcon1 = "api/Kiosk_IrrigationWaterTest/";
                        client.BaseAddress = new Uri(urlstring + Urlcon1);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response1 = client.GetAsync("Irrigationprint?org=" + orgnId + "&locn=" + locnId + "&user=" + userId + "&lang=" + localeId + "&In_Tran_Id=" + In_Tran_Id + "&In_farmer_code=" + In_farmer_code + "").Result;

                        Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                        StreamReader reader1 = new StreamReader(data1);
                        post_data = reader1.ReadToEnd();
                        objList = (irrigationviewContext)JsonConvert.DeserializeObject(post_data, typeof(irrigationviewContext));

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        //try
                        //{

                        // creating document object

                        iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
                        rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);


                        Document doc = new Document(rec);
                        doc.SetPageSize(iTextSharp.text.PageSize.A4);
                        // PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                        doc.Open();
                        //  PdfContentByte  pdfContent = writer.DirectContent;
                        iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(doc.PageSize);
                        //customized border sizes
                        rectangle.Left += doc.LeftMargin - 5;
                        rectangle.Right -= doc.RightMargin - 5;
                        rectangle.Top -= doc.TopMargin - 5;
                        rectangle.Bottom += doc.BottomMargin - 5;

                        //Creating paragraph for header
                        iTextSharp.text.Font mainFont = new iTextSharp.text.Font();
                        iTextSharp.text.Font boldFont = new iTextSharp.text.Font();
                        boldFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font NormalFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font NormalFont1 = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font NormalFont3 = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font NormalFontW = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                        iTextSharp.text.Font NormalFontb = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 9, 1, iTextSharp.text.BaseColor.BLACK);
                        BaseFont bfntHead1 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fntblack = new iTextSharp.text.Font(bfntHead1, 10, 1, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font NormalFontsign = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font black1 = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.GRAY);
                        Paragraph prgHeading = new Paragraph();
                        Paragraph prgheadingright = new Paragraph();
                        Paragraph prgGeneratedBY = new Paragraph();

                        PdfPTable table1 = new PdfPTable(3);
                        int[] table1CellWidth = { 4, 9, 8 };
                        table1.WidthPercentage = 100;
                        table1.SetWidths(table1CellWidth);

                        if (Headerpart == "true")
                        {
                            var imageleft = _configuration.GetSection("AppSettings")["PDFNAFLOGO"];
                            /*iTextSharp.text.Image imagel = iTextSharp.text.Image.GetInstance(imageleft);
                            imagel.Alignment = (Element.ALIGN_LEFT);
                            imagel.WidthPercentage = 100;
                            PdfPCell cellimage = new PdfPCell();
                            cellimage.Border = 0;
                            cellimage.AddElement(imagel);
                            cellimage.VerticalAlignment = (Element.ALIGN_LEFT);
                            cellimage.HasBorder(iTextSharp.text.Rectangle.NO_BORDER);
                            table1.AddCell(cellimage);*/

                            iTextSharp.text.Image imagel = iTextSharp.text.Image.GetInstance(imageleft);
                            imagel.Alignment = (Element.ALIGN_LEFT);
                            imagel.WidthPercentage = 100;
                            PdfPCell cellimage = new PdfPCell();
                            cellimage.Border = 0;
                            cellimage.AddElement(imagel);
                            table1.AddCell(cellimage);

                            PdfPCell cell1 = new PdfPCell();
                            cell1.Border = 0;
                            //iTextSharp.text.Font green = new iTextSharp.text.Font(boldFont, 17, 1, iTextSharp.text.BaseColor.GREEN);
                            var greenColour = new BaseColor(39, 115, 36);
                            iTextSharp.text.Font Cmpname = FontFactory.GetFont("Arial", 17, iTextSharp.text.Font.NORMAL, greenColour);
                            //iTextSharp.text.Font green = Cmpname;
                            Chunk redText = new Chunk("NATIONAL AGRO FOUNDATION", Cmpname);

                            Paragraph pb = new Paragraph();
                            pb.Alignment = (Element.ALIGN_LEFT);

                            pb.Add(redText);
                            cell1.AddElement(pb);
                            //BaseFont Headb = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
                            //iTextSharp.text.Font grey = new iTextSharp.text.Font(Headb, 13, 1, iTextSharp.text.BaseColor.GRAY);
                            iTextSharp.text.Font grey = FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.GRAY);
                            Chunk text2 = new Chunk("Laboratary Services Division", grey);
                            Paragraph p2 = new Paragraph();
                            p2.Alignment = (Element.ALIGN_LEFT);
                            //p2.SetLeading(1f, 1f);
                            p2.Add(text2);
                            cell1.NoWrap = true;
                            cell1.AddElement(p2);

                            Chunk text3 = new Chunk("Anna University Tharamani Campus,", black1);
                            Paragraph p3 = new Paragraph();
                            p3.Alignment = (Element.ALIGN_LEFT);
                            //p3.SetLeading(1f, 1f);
                            p3.Add(text3);
                            cell1.AddElement(p3);
                            Chunk text4 = new Chunk("CSIR Road, Tharamani, Chennai-600113", black1);
                            Paragraph p4 = new Paragraph();
                            p4.Alignment = (Element.ALIGN_LEFT);
                            //p4.SetLeading(1f, 1f);
                            p4.Add(text4);
                            cell1.AddElement(p4);
                            Chunk text5 = new Chunk("India.", black1);
                            Paragraph p5 = new Paragraph();
                            p5.Alignment = (Element.ALIGN_LEFT);
                            p5.Add(text5);
                            cell1.AddElement(p5);
                            //BaseFont HeadR = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
                            iTextSharp.text.Font black5 = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
                            Chunk text6 = new Chunk("Phone: +91-44-22542598/+91-90807-11501", black5);
                            Paragraph p6 = new Paragraph();
                            //p6.Alignment = (Element.ALIGN_LEFT);
                            p6.SetLeading(2f, 2f);
                            p6.Add(text6);
                            cell1.AddElement(p6);

                            Chunk text7 = new Chunk("Email: labservices@nationalagro.org", black5);
                            Paragraph pp7 = new Paragraph();
                            pp7.Alignment = (Element.ALIGN_LEFT);
                            pp7.SetLeading(1.2f, 1.2f);
                            pp7.Add(text7);
                            cell1.AddElement(pp7);

                            Chunk text8 = new Chunk("Website: www.nationalagro.org", black5);
                            Paragraph p8 = new Paragraph();
                            p8.Alignment = (Element.ALIGN_LEFT);
                            p8.SetLeading(1.2f, 1.2f);
                            p8.Add(text8);
                            cell1.AddElement(p8);

                            //Chunk cellimageR = new Chunk(imageR.ToString(), black5);
                            ////cellimageR.AddElement(imageR);
                            //imageR.ScaleAbsolute(60f, 100f);
                            //imageR.Alignment = (Element.ALIGN_TOP);
                            //imageR.Alignment = (Element.ALIGN_RIGHT); 
                            //cell1.AddElement(imageR);

                            cell1.VerticalAlignment = (Element.ALIGN_TOP);
                            //  cell1.HasBorder(iTextSharp.text.Rectangle.NO_BORDER);
                            //cell1.PaddingLeft = 10;
                            table1.AddCell(cell1);

                            var imageright = _configuration.GetSection("AppSettings")["PDFNABLLOGO"];
                            iTextSharp.text.Image imageR = iTextSharp.text.Image.GetInstance(imageright);
                            //imageR.ScaleAbsolute(40f, 70f);
                            imageR.Alignment = (Element.ALIGN_TOP);
                            imageR.Alignment = (Element.ALIGN_RIGHT);
                            imageR.WidthPercentage = 30;
                            PdfPCell cellimageR1 = new PdfPCell();
                            cellimageR1.Border = 0;
                            //cellimageR1.VerticalAlignment = -10;
                            cellimageR1.AddElement(imageR);

                            //cellimageR.Border = 0;
                            //table1.AddCell(imageR);

                            //doc.Add(table1);

                            //PdfPTable table2 = new PdfPTable(2);
                            //int[] table2CellWidth = { 3, 3 };
                            //table2.WidthPercentage = 100;
                            //table2.SetWidths(table2CellWidth);

                            //BaseFont HeadR1 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
                            iTextSharp.text.Font black6 = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
                            //PdfPCell cell1R = new PdfPCell();
                            Chunk text11 = new Chunk("Accredited as per ISO/IEC 17025:2017 Standard", black6);
                            Paragraph p11 = new Paragraph();
                            p11.Alignment = (Element.ALIGN_RIGHT);
                            p11.SetLeading(2f, 2f);
                            //p11.Alignment = (Element.ALIGN_BOTTOM);
                            p11.Add(text11);

                            cellimageR1.AddElement(p11);

                            Chunk text12 = new Chunk("by National Accreditation Board for Testing and", black6);
                            Paragraph p12 = new Paragraph();
                            p12.Alignment = (Element.ALIGN_RIGHT);
                            //p12.Alignment = (Element.ALIGN_BOTTOM);
                            p12.SetLeading(1.2f, 1.2f);
                            p12.Add(text12);
                            cellimageR1.AddElement(p12);
                            //  Font black12 = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
                            Chunk text13 = new Chunk("Calibration Laboratories (NABL),a Constituent", black6);
                            Paragraph p13 = new Paragraph();
                            p13.Alignment = (Element.ALIGN_RIGHT);
                            //p13.Alignment = (Element.ALIGN_BOTTOM);                        
                            p13.SetLeading(1.2f, 1.2f);
                            p13.Add(text13);
                            cellimageR1.AddElement(p13);
                            // Font black13 = new Font(Font.FontFamily.Arial, 10, Font.NORMAL, BaseColor.BLACK);
                            Chunk text14 = new Chunk("Board of Quality Council Of India(QCI)", black6);
                            Paragraph p14 = new Paragraph();
                            p14.Alignment = (Element.ALIGN_RIGHT);
                            //p14.Alignment = (Element.ALIGN_BOTTOM);
                            p14.SetLeading(1.2f, 1.2f);
                            p14.Add(text14);
                            cellimageR1.AddElement(p14);
                            cellimageR1.HorizontalAlignment = Element.ALIGN_RIGHT; // ramya addedo n 28 jul 22
                            cellimageR1.VerticalAlignment = (Element.ALIGN_RIGHT);
                            cellimageR1.HasBorder(iTextSharp.text.Rectangle.NO_BORDER);
                            table1.AddCell(cellimageR1);

                            //PdfPCell cellnextpara = new PdfPCell();
                            //cellnextpara.PaddingLeft=(10);

                            // ramya commentted on 31 may 22
                            // Chunk text6 = new Chunk("Phone: +91-44-22542598/+91-90807-11501", black5);
                            // Paragraph p6 = new Paragraph();
                            // p6.Alignment=(Element.ALIGN_LEFT);
                            // p6.Add(text6);
                            // cellnextpara.AddElement(p6);

                            // Chunk text7 = new Chunk("Email: labservices@nationalagro.org", black5);
                            // Paragraph pp7 = new Paragraph();
                            // pp7.Alignment=(Element.ALIGN_LEFT);
                            // pp7.Add(text7);
                            // cellnextpara.AddElement(pp7);

                            // Chunk text8 = new Chunk("Website: www.nationalagro.org", black5);
                            // Paragraph p8 = new Paragraph();
                            // p8.Alignment=(Element.ALIGN_LEFT);
                            // p8.Add(text8);
                            // cellnextpara.AddElement(p8);

                            // cellnextpara.VerticalAlignment=(Element.ALIGN_TOP);
                            //// cellnextpara.HasBorder(iTextSharp.text.Rectangle.NO_BORDER);
                            // table2.AddCell(cellnextpara);



                            //PdfPCell cellnextpara1 = new PdfPCell();
                            //  cellnextpara1.setPaddingLeft(20);


                            //  BaseFont HeadR1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
                            //  iTextSharp.text.Font black6 = new iTextSharp.text.Font(HeadR1, 10, 1, iTextSharp.text.BaseColor.BLACK);

                            //  Chunk text11 = new Chunk("Accredited as per ISO/IEC 17025:2017 Standard", black6);
                            //  Paragraph p11 = new Paragraph();
                            //  p11.Alignment=(Element.ALIGN_RIGHT);
                            //  p11.Add(text11);
                            //  cellnextpara1.AddElement(p11);

                            //  Chunk text12 = new Chunk("by National Accreditation Board for Testing and", black6);
                            //  Paragraph p12 = new Paragraph();
                            //  p12.Alignment = (Element.ALIGN_RIGHT);
                            //  p12.Add(text12);
                            //  cellnextpara1.AddElement(p12);
                            ////  Font black12 = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
                            //  Chunk text13 = new Chunk("Calibration Laboratories (NABL),a constituent", black6);
                            //  Paragraph p13 = new Paragraph();
                            //  p13.Alignment=(Element.ALIGN_RIGHT);
                            //  p13.Add(text13);
                            //  cellnextpara1.AddElement(p13);
                            // // Font black13 = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
                            //  Chunk text14 = new Chunk("Board of Quality Council Of India(QCI)", black6);
                            //  Paragraph p14 = new Paragraph();
                            //  p14.Alignment=(Element.ALIGN_RIGHT);
                            //  p14.Add(text14);
                            //  cellnextpara1.AddElement(p14);

                            //  cellnextpara1.VerticalAlignment=(Element.ALIGN_MIDDLE);
                            ////  cellnextpara1.HasBorder(iTextSharp.text.Rectangle.NO_BORDER);
                            //  table2.AddCell(cellnextpara1);

                            //  doc.Add(table2);
                            //ramya end
                            //var Header = _configuration.GetSection("AppSettings")["PDFHeader1"];
                            //var image = iTextSharp.text.Image.GetInstance(Header);
                            //prgHeading.Alignment = Element.PARAGRAPH;
                            //prgHeading.Add(image);
                            //doc.Add(prgHeading);
                            ////Adding a line
                            //Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                            //doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                        }
                        else
                        {
                            var Header = _configuration.GetSection("AppSettings")["PDFHeaderWithout"];
                            var image = iTextSharp.text.Image.GetInstance(Header);
                            prgHeading.Alignment = Element.PARAGRAPH;
                            prgHeading.Add(image);
                            doc.Add(prgHeading);
                        }

                        // Header
                        //string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Arial.ttf";
                        //BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
                        //iTextSharp.text.Font font = new iTextSharp.text.Font(basefont, 24, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE);
                        ////prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
                        Paragraph ptest = new Paragraph();
                        PdfPCell celltestcap = new PdfPCell();
                        celltestcap.Colspan = 2;
                        ptest.Alignment = Element.ALIGN_RIGHT;
                        ptest.Add(new Chunk("TEST REPORT", boldFont));
                        celltestcap.AddElement(ptest);
                        celltestcap.Border = 0;
                        table1.AddCell(celltestcap);
                        //doc.Add(test);

                        //QR Code image
                        FarmerQrContext Obj_FarmerQrContext = new FarmerQrContext();

                        Obj_FarmerQrContext.orgnId = HttpContext.Session.GetString("orgId");
                        Obj_FarmerQrContext.locnId = HttpContext.Session.GetString("locnId");
                        Obj_FarmerQrContext.userId = HttpContext.Session.GetString("userId");
                        Obj_FarmerQrContext.localeId = HttpContext.Session.GetString("localeId");
                        Obj_FarmerQrContext.FarmerCode = HttpContext.Session.GetString("In_farmer_code");
                        iTextSharp.text.Font pageno = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        String base64 = new_farmer_qr(Obj_FarmerQrContext);
                        string string64 = base64.Replace(@"""", string.Empty);
                        byte[] imageBytes = Convert.FromBase64String(string64);
                        iTextSharp.text.Image QRimage = iTextSharp.text.Image.GetInstance(imageBytes);
                        QRimage.ScaleAbsolute(50f, 50f);
                        PdfPCell cellQR = new PdfPCell();
                        Paragraph p9 = new Paragraph();
                        p9.Alignment = Element.ALIGN_RIGHT;
                        //p9.Alignment = Element.ALIGN_TOP;
                        //p9.Alignment = Element.ALIGN_TOP; // ramya added on 28 jul 22
                        p9.Add(new Chunk("Page 1 of 1", pageno));
                        p9.Add(new Chunk(QRimage, 0, 0, true));
                        //doc.Add(p9);
                        cellQR.AddElement(p9);
                        cellQR.Border = 0;
                        table1.AddCell(cellQR);

                        doc.Add(table1);

                        PdfPTable HeaderDetails = new PdfPTable(4);
                        HeaderDetails.WidthPercentage = 100;
                        int[] HeaderDetailsCellWidth = { 20, 30, 20, 25 };
                        HeaderDetails.SetWidths(HeaderDetailsCellWidth);

                        //Header

                        iTextSharp.text.Font grey1 = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        //iTextSharp.text.Font grey1 = new iTextSharp.text.Font(HeadH, 8, 1, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font grey2 = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                        PdfPCell Hcell1 = new PdfPCell();
                        //Hcell1.BorderColorLeft = BaseColor.BLACK;
                        //Hcell1.BorderWidthLeft = 2f;
                        //Hcell1.BorderColorRight = BaseColor.BLACK;
                        //Hcell1.BorderWidthRight = 1f;
                        //Hcell1.BorderColorTop = BaseColor.BLACK;
                        //Hcell1.BorderWidthTop = 1f;
                        Hcell1.Rowspan = 3;
                        Hcell1.Colspan = 2;
                        Hcell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Chunk redText1 = new Chunk("Issued To :\n", grey2);
                        Chunk redTextr = new Chunk(objList.Print[0].farmer_name + ",\n" + objList.Print[0].farmer_address, grey1);
                        Paragraph pb1 = new Paragraph();
                        pb1.Alignment = (Element.ALIGN_LEFT);
                        pb1.Add(redText1);
                        pb1.Add(redTextr);
                        pb1.SetLeading(1f, 1f);
                        Hcell1.AddElement(pb1);
                        HeaderDetails.AddCell(Hcell1);

                        PdfPCell Hcell2 = new PdfPCell();
                        //Hcell2.Border = 2;
                        Hcell2.BorderColorBottom = BaseColor.BLACK;
                        Hcell2.BorderWidthBottom = 1f;
                        Hcell2.BorderColorRight = BaseColor.BLACK;
                        Hcell2.BorderWidthRight = 1f;
                        Hcell2.Colspan = 2;
                        Hcell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Chunk hredText2 = new Chunk("Sample Description : ", grey2);
                        Chunk hredTextr = new Chunk(objList.Print[0].sampledescription, grey1);
                        Paragraph hpb2 = new Paragraph();
                        hpb2.Alignment = (Element.ALIGN_LEFT);
                        hpb2.Add(hredText2);
                        hpb2.Add(hredTextr);
                        hpb2.SetLeading(1f, 1f);
                        Hcell2.AddElement(hpb2);
                        HeaderDetails.AddCell(Hcell2);

                        PdfPCell Hcell3 = new PdfPCell();
                        //Hcell3.Border = 2;
                        //Hcell3.Border = 3;
                        Hcell3.BorderColorLeft = BaseColor.BLACK;
                        Hcell3.BorderWidthLeft = 1f;
                        //Hcell3.BorderColorRight = BaseColor.BLACK;
                        //Hcell3.BorderWidthRight = 1f;
                        Hcell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Chunk hredText3 = new Chunk("Sample Drawn By", grey2);
                        Paragraph hpb3 = new Paragraph();
                        hpb3.Alignment = (Element.ALIGN_LEFT);
                        hpb3.Add(hredText3);
                        hpb3.SetLeading(1f, 1f);
                        Hcell3.AddElement(hpb3);
                        HeaderDetails.AddCell(Hcell3);

                        PdfPCell Hcell4 = new PdfPCell();
                        Hcell4.BorderColorRight = BaseColor.BLACK;
                        Hcell4.BorderWidthRight = 1f;
                        Hcell4.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Chunk hredText4 = new Chunk(objList.Print[0].farmer_sampledrawn, grey1);

                        Paragraph hpb4 = new Paragraph();
                        hpb4.Alignment = (Element.ALIGN_LEFT);
                        hpb4.Add(hredText4);
                        hpb4.SetLeading(1f, 1f);
                        Hcell4.AddElement(hpb4);
                        HeaderDetails.AddCell(Hcell4);

                        PdfPCell Hcell5 = new PdfPCell();
                        //Hcell5.Border = 2; 
                        Hcell5.BorderColorLeft = BaseColor.BLACK;
                        Hcell5.BorderWidthLeft = 1f;
                        //Hcell5.BorderColorRight = BaseColor.BLACK;
                        //Hcell5.BorderWidthRight = 1f;
                        Hcell5.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Chunk hredText5 = new Chunk("Customer's Reference", grey2);

                        Paragraph hpb5 = new Paragraph();
                        hpb5.Alignment = (Element.ALIGN_LEFT);
                        hpb5.Add(hredText5);
                        hpb5.SetLeading(1f, 1f);
                        Hcell5.AddElement(hpb5);
                        HeaderDetails.AddCell(Hcell5);

                        PdfPCell Hcell6 = new PdfPCell();
                        //Hcell6.Border = 2;                    
                        Hcell6.BorderColorRight = BaseColor.BLACK;
                        Hcell6.BorderWidthRight = 1f;
                        Hcell6.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Chunk hredText6 = new Chunk(objList.Print[0].farmer_customerref, grey1);

                        Paragraph hpb6 = new Paragraph();
                        hpb6.Alignment = (Element.ALIGN_LEFT);
                        hpb6.Add(hredText6);
                        hpb6.SetLeading(1f, 1f);
                        Hcell6.AddElement(hpb6);
                        HeaderDetails.AddCell(Hcell6);

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Number  ", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_tranid, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Received on ", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_samplereceived, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY, BorderWidthLeft = 1f, BorderColorLeft = BaseColor.BLACK });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Date  ", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analycompleted, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Started on", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analystarted, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Unique Lab Report No.", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_labreportno, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Completed on", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analycompleted, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Lab ID", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_labid, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample ID", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampleid, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Discipline", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Chemical", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Group", grey2)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        //HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmergroup, NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails.AddCell(new PdfPCell(new Phrase("Water", grey1)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        doc.Add(HeaderDetails);
                        Paragraph pnewline = new Paragraph();
                        pnewline.Add(new Chunk("\n", boldFont));
                        doc.Add(pnewline);

                        //Details
                        PdfPTable HeaderDetails1 = new PdfPTable(5);
                        HeaderDetails1.WidthPercentage = 100;
                        int[] HeaderDetailsCellWidth1 = { 8, 28, 13, 14, 52 };
                        HeaderDetails1.SetWidths(HeaderDetailsCellWidth1);

                        HeaderDetails1.AddCell(new PdfPCell(new Phrase("S. No.", NormalFontb)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Parameter", NormalFontb)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Unit", NormalFontb)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Results", NormalFontb)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Test Method", NormalFontb)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });

                        for (int rows = 0; rows < objList.Print.Count; rows++)
                        {
                            HeaderDetails1.AddCell(new PdfPCell(new Phrase(new Chunk((rows + 1).ToString(), NormalFont1))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].parameter, NormalFont1)));
                            HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].unit, NormalFont1)) { HorizontalAlignment = Element.ALIGN_CENTER });
                            HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].result, NormalFont1)) { HorizontalAlignment = Element.ALIGN_CENTER });
                            HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].farmer_testmethod, NormalFont3)));
                        }

                        //header

                        //Paragraph p7 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        //doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                        //detail
                        doc.Add(HeaderDetails1);
                        PdfPTable tdfoot = new PdfPTable(2);
                        PdfPCell cellf = new PdfPCell();
                        cellf.Border = 0;
                        cellf.Rowspan = 3;
                        Paragraph pf1 = new Paragraph();
                        pf1.Add(new Chunk("\nDL - Detecable Limit", NormalFontsign));
                        pf1.Alignment = Element.ALIGN_LEFT;
                        cellf.AddElement(pf1);
                        tdfoot.AddCell(cellf);

                        PdfPCell cellf2 = new PdfPCell();
                        cellf2.Border = 0;
                        Paragraph pf2 = new Paragraph();
                        pf2.Add(new Chunk("Authorised Signatory ", NormalFontsign));
                        pf2.Alignment = Element.ALIGN_RIGHT;
                        cellf2.AddElement(pf2);
                        tdfoot.AddCell(cellf2);

                        //var sign_Image = iTextSharp.text.Image.GetInstance(Signature_ImPathP);
                        //PdfPCell Imagecell = new PdfPCell();
                        //Imagecell.Border = 0;
                        //Imagecell.AddElement(sign_Image); 
                        //sign_Image.Alignment= (Element.ALIGN_RIGHT);
                        //sign_Image.WidthPercentage = 10;


                        iTextSharp.text.Image sign_Image = iTextSharp.text.Image.GetInstance(Signature_ImPathP);
                        sign_Image.Alignment = (Element.ALIGN_RIGHT);
                        sign_Image.WidthPercentage = 40;
                        PdfPCell Imagecell = new PdfPCell();
                        Imagecell.Border = 0;
                        //cellimageR1.VerticalAlignment = -10;
                        Imagecell.AddElement(sign_Image);
                        tdfoot.AddCell(Imagecell);

                        //  doc.Add(new Chunk("\n", NormalFont));
                        var sign_name = Signature_NameP;
                        var sign_desgn = Signature_DesgnP;
                        PdfPCell cellf3 = new PdfPCell();
                        cellf3.Border = 0;
                        cellf3.PaddingTop = -10;
                        Paragraph psign = new Paragraph();
                        psign.Add(new Chunk("\n" + sign_desgn, NormalFontsign));
                        psign.Add(new Chunk(" :" + sign_name + "\n\n", NormalFontsign));
                        psign.Alignment = Element.ALIGN_RIGHT;
                        cellf3.AddElement(psign);
                        tdfoot.AddCell(cellf3);

                        doc.Add(tdfoot);
                        // doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                        //Notes
                        // ramya added on 14 jul 22
                        if (notewith == "Yes")
                        {
                            iTextSharp.text.Font whitenote = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);
                            iTextSharp.text.Font greydot = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.GRAY);
                            iTextSharp.text.Font NormalFont2 = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                            //doc.Add(new Chunk("\n", NormalFont));
                            PdfPTable tablef = new PdfPTable(1);
                            tablef.WidthPercentage = 100;
                            //List list = new List(List.ORDERED, 20f);

                            //list.SetListSymbol("\u2022");

                            //list.IndentationLeft = 1f;

                            //list.Add(_configuration.GetSection("AppSettings")["notes"].ToString());
                            //list.Add(_configuration.GetSection("AppSettings")["notes1"].ToString());
                            //list.Add(_configuration.GetSection("AppSettings")["notes2"].ToString());
                            //list.Add(_configuration.GetSection("AppSettings")["notes3"].ToString());
                            //list.Add(_configuration.GetSection("AppSettings")["notes4"].ToString());
                            //list.Add(_configuration.GetSection("AppSettings")["notes5"].ToString());

                            tablef.AddCell(new PdfPCell(new Phrase("                                                                                x-------x\n\n\n\n", NormalFontsign))).Border = 0;
                            /*tablef.AddCell(new PdfPCell(new Phrase("Note:" + "." + _configuration.GetSection("AppSettings")["notes"].ToString() + "."
                                + _configuration.GetSection("AppSettings")["notes1"].ToString() + "." + _configuration.GetSection("AppSettings")["notes2"].ToString() + "."
                                + _configuration.GetSection("AppSettings")["notes3"].ToString() + "." + _configuration.GetSection("AppSettings")["notes4"].ToString() + "."
                                + _configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont2))
                            {
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                Padding = 5,
                                BackgroundColor = BaseColor.GRAY
                            }).Border = 0;*/

                            PdfPCell pNotec = new PdfPCell();
                            //Hcell2.Border = 2;
                            pNotec.BackgroundColor = BaseColor.GRAY;
                            pNotec.Border = 0;
                            Chunk Notetxt1 = new Chunk("Note: ", NormalFont2);
                            Chunk Notetxt2 = new Chunk(" .", whitenote);
                            Chunk Notetxt3 = new Chunk(_configuration.GetSection("AppSettings")["notes"].ToString(), NormalFont2);
                            Chunk Notetxt4 = new Chunk(" .", whitenote);
                            Chunk Notetxt5 = new Chunk(_configuration.GetSection("AppSettings")["notes1"].ToString(), NormalFont2);
                            Chunk Notetxt6 = new Chunk(" .", whitenote);
                            Chunk Notetxt7 = new Chunk(_configuration.GetSection("AppSettings")["notes2"].ToString(), NormalFont2);
                            Chunk Notetxt8 = new Chunk(" .", whitenote);
                            Chunk Notetxt9 = new Chunk(_configuration.GetSection("AppSettings")["notes3"].ToString(), NormalFont2);
                            Chunk Notetxt10 = new Chunk(" .", whitenote);
                            Chunk Notetxt11 = new Chunk(_configuration.GetSection("AppSettings")["notes4"].ToString(), NormalFont2);
                            Chunk Notetxt12 = new Chunk(" .", whitenote);
                            Chunk Notetxt13 = new Chunk(_configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont2);
                            Chunk Notetxt14 = new Chunk(". ", greydot);
                            Paragraph notep = new Paragraph();
                            notep.Alignment = (Element.ALIGN_LEFT);
                            //notep.Alignment = Element.ALIGN_JUSTIFIED;
                            notep.Add(Notetxt1);
                            notep.Add(Notetxt2); notep.Add(Notetxt3);
                            notep.Add(Notetxt4); notep.Add(Notetxt5);
                            notep.Add(Notetxt6); notep.Add(Notetxt7);
                            notep.Add(Notetxt8); notep.Add(Notetxt9);
                            notep.Add(Notetxt10); notep.Add(Notetxt11);
                            notep.Add(Notetxt12); notep.Add(Notetxt13); notep.Add(Notetxt14);
                            notep.SetLeading(0.5f, 0.5f);
                            pNotec.AddElement(notep);
                            tablef.AddCell(pNotec);

                            doc.Add(tablef);
                            //doc.Add(list);
                        }

                        //doc.Add(new Chunk("\n", NormalFont));
                        //doc.Add(new Chunk("\nNotes :", boldFont) );
                        //doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes"].ToString(), NormalFont));
                        //doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes1"].ToString(), NormalFont));
                        //doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes2"].ToString(), NormalFont));
                        //doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes3"].ToString(), NormalFont));
                        //doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes4"].ToString(), NormalFont));
                        //doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont));

                        //doc.Add(new Chunk("\n", NormalFont));

                        doc.Close();

                        byte[] result = ms.ToArray();

                        return result;
                    }
                }
            }
            catch(Exception ex)
            {

                return null;
            }


        }
        #endregion
        //prema
        [HttpPost]
        public ActionResult IrregationLastInsertid([FromBody] irrigationlist objContext)
        {
            irrigationsave objout = new irrigationsave();
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
                    string Urlcon1 = "api/Kiosk_IrrigationWaterTest/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("IrrigationLastInsertid", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }
        private string new_farmer_qr(FarmerQrContext Obj_FarmerQrContext)
        {
            String post_data = "";
            if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
                dbstring = _configuration.GetSection("dbtypeTA")["mysqlcon"].ToString();
            }
            else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
            {
                urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
                dbstring = _configuration.GetSection("dbtypeTA")["mysqlcon"].ToString();
            }
            else
            {
                urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
                dbstring = _configuration.GetSection("dbtypeTA")["mysqlcon"].ToString();
            }

            using (var client = new HttpClient())
            {
                string Urlcon = "api/Mobile_FDR_FList/";
                client.BaseAddress = new Uri(urlstring + Urlcon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(JsonConvert.SerializeObject(Obj_FarmerQrContext), UTF8Encoding.UTF8, "application/json");
                //var response = client.GetAsync("").Result;
                var response = client.PostAsync("new_farmer_qrcode", content).Result;
                Stream data = response.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                post_data = reader.ReadToEnd();

            }
            return post_data;


        }
         
    }
}
