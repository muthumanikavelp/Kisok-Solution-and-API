using iTextSharp.text;
using iTextSharp.text.pdf;
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
using static Kiosk_web.Models.SolidCardChecker_Model;

namespace Kiosk_web.Controllers
{
    public class SolidCardCheckerController : Controller
    {
        

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SoilCardController)); //Declaring Log4Net.
        private IHostingEnvironment _hostingEnvironment;
        private MySqlConnection con;
        string dbstring = "";
        private IConfiguration _configuration;
        dynamic excel_msg = new JObject();
        public SolidCardCheckerController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult SolidCardChecker()
        {
            return View();
        }
        string urlstring = "";
        private string post_data;

        [HttpPost]
        public ActionResult SoilcardListChecker([FromBody] soilcardlist objContext)
        {
            soilListContext objList = new soilListContext();
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
                    string Urlcon1 = "api/SolidCard_Checker/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("SoilCardListChecker??org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&lang=" + objContext.localeId + "&In_farmer_gid=" + objContext.In_farmer_gid + "&status=" + objContext.soil_status + "").Result; ;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (soilListContext)JsonConvert.DeserializeObject(post_data, typeof(soilListContext));
                }
            }
            return Json(objList);
        }
        [HttpPost]
        public ActionResult SoilcardfetchChecker([FromBody] soilviewContext objContext)
        {
            soilviewContext objout = new soilviewContext();
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
                    string Urlcon1 = "api/SolidCard_Checker/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("SoilCardListViewChecker?org=" + objContext.orgnId + "&locn=" + objContext.locnId + "&user=" + objContext.userId + "&lang=" + objContext.localeId + "&soil_gid=" + objContext.soil_gid + "").Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objout = (soilviewContext)JsonConvert.DeserializeObject(post_data, typeof(soilviewContext));
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

        [HttpPost]
        public ActionResult SoilcardsaveChecker([FromBody] soilcardsave objContext)
        {
            soilcardsave objout = new soilcardsave();
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
                    string Urlcon1 = "api/SolidCard_Checker/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content1 = new StringContent(JsonConvert.SerializeObject(objContext), UTF8Encoding.UTF8, "application/json");
                    var response1 = client.PostAsync("soilcardsaveChecker", content1).Result;
                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                }
            }
            return Json(post_data);
        }
        //Print PDF
        [HttpPost]
        public ActionResult downloadpdf(string Signature_NameP, string Signature_ImPathP, string Headerpart, string Signature_DesgnP)
        {
            excel_msg = "";
            string filename = _configuration.GetSection("AppSettings")["PrintFileName"].ToString();
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
                byte[] filecontent = exportpdf(path, Signature_NameP, Signature_ImPathP, Headerpart, Signature_DesgnP);
                logger.Debug("filecontent - " + filecontent);


                logger.Debug("excel_msg - " + excel_msg.path);
            }
            catch (Exception ex)
            {
                logger.Error("downloadpdf method - " + ex.ToString());
            }

            return Json(excel_msg);
        }

        public class FarmerQrContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FarmerCode { get; set; }
            public int In_farmer_gid { get; set; }
        }

        public byte[] exportpdf(string path, string Signature_NameP, string Signature_ImPathP, string Headerpart, string Signature_DesgnP)
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


            soilviewContext objList = new soilviewContext();
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
                    string Urlcon1 = "api/SolidCard_Checker/";
                    client.BaseAddress = new Uri(urlstring + Urlcon1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response1 = client.GetAsync("SoilCardPrintChecker?org=" + orgnId + "&locn=" + locnId + "&user=" + userId + "&lang=" + localeId + "&In_Tran_Id=" + In_Tran_Id + "&In_farmer_code=" + In_farmer_code + "").Result;

                    Stream data1 = response1.Content.ReadAsStreamAsync().Result;
                    StreamReader reader1 = new StreamReader(data1);
                    post_data = reader1.ReadToEnd();
                    objList = (soilviewContext)JsonConvert.DeserializeObject(post_data, typeof(soilviewContext));


                    // creating document object
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
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
                    iTextSharp.text.Font NormalFont1 = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                    BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 9, 1, iTextSharp.text.BaseColor.BLACK);
                    BaseFont bfntHead1 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fntblack = new iTextSharp.text.Font(bfntHead1, 10, 1, iTextSharp.text.BaseColor.BLACK);
                    Paragraph prgHeading = new Paragraph();
                    Paragraph prgheadingright = new Paragraph();
                    Paragraph prgGeneratedBY = new Paragraph();



                    if (Headerpart == "true")
                    {
                        var Header = _configuration.GetSection("AppSettings")["PDFHeader1"];
                        var image = iTextSharp.text.Image.GetInstance(Header);
                        prgHeading.Alignment = Element.PARAGRAPH;
                        prgHeading.Add(image);
                        doc.Add(prgHeading);
                        //Adding a line
                        Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    }
                    else
                    {
                        var Header = _configuration.GetSection("AppSettings")["PDFHeaderWithout"];
                        var image = iTextSharp.text.Image.GetInstance(Header);
                        prgHeading.Alignment = Element.PARAGRAPH;
                        prgHeading.Add(image);
                        doc.Add(prgHeading);
                    }
                    //QR Code image
                    FarmerQrContext Obj_FarmerQrContext = new FarmerQrContext();

                    Obj_FarmerQrContext.orgnId = HttpContext.Session.GetString("orgId");
                    Obj_FarmerQrContext.locnId = HttpContext.Session.GetString("locnId");
                    Obj_FarmerQrContext.userId = HttpContext.Session.GetString("userId");
                    Obj_FarmerQrContext.localeId = HttpContext.Session.GetString("localeId");
                    Obj_FarmerQrContext.FarmerCode = HttpContext.Session.GetString("In_farmer_code");


                    String base64 = new_farmer_qr(Obj_FarmerQrContext);
                    // var response = base64.Substring(1, base64.Length - 2).Replace(@"\/", "/");
                    string string64 = base64.Replace(@"""", string.Empty);
                    byte[] imageBytes = Convert.FromBase64String(string64);
                    iTextSharp.text.Image QRimage = iTextSharp.text.Image.GetInstance(imageBytes);
                    QRimage.ScaleAbsolute(60f, 60f);
                    Paragraph p9 = new Paragraph();
                    p9.Add(new Chunk(QRimage, 0, 0, true));
                    doc.Add(p9);
                    // Header

                    prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
                    doc.Add(new Chunk("\nTEST REPORT:", boldFont));

                    PdfPTable HeaderDetails = new PdfPTable(4);
                    HeaderDetails.WidthPercentage = 100;
                    int[] HeaderDetailsCellWidth = { 15, 30, 15, 40 };
                    HeaderDetails.SetWidths(HeaderDetailsCellWidth);
                    //Header
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Number", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_tranid, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Description", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].sampledescription, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Date", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analycompleted, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Drawn By", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampledrawn, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Unidue Lab Report No", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_labreportno, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Customer's Reference", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_code, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Lab I.D.", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_labid, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Received On ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_samplereceived, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Started On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analystarted, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Completed On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analycompleted, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample ID", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampleid, NormalFont1)));
                    HeaderDetails.AddCell(new PdfPCell(new Phrase(" ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails.AddCell(new PdfPCell(new Phrase()));

                    //Details
                    PdfPTable HeaderDetails1 = new PdfPTable(5);
                    HeaderDetails1.WidthPercentage = 100;
                    int[] HeaderDetailsCellWidth1 = { 15, 30, 15, 40, 15 };
                    HeaderDetails1.SetWidths(HeaderDetailsCellWidth1);


                    HeaderDetails1.AddCell(new PdfPCell(new Phrase("S No.", NormalFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails1.AddCell(new PdfPCell(new Phrase("Parameter", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails1.AddCell(new PdfPCell(new Phrase("Unit", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails1.AddCell(new PdfPCell(new Phrase("Results", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                    HeaderDetails1.AddCell(new PdfPCell(new Phrase("Test Method", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });

                    for (int rows = 0; rows < objList.Print.Count; rows++)
                    {
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase(new Chunk((rows + 1).ToString()))));
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].parameter, NormalFont)));
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].unit, NormalFont)));
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].result, NormalFont)));
                        HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].farmer_testmethod, NormalFont)));

                    }


                    //header
                    doc.Add(HeaderDetails);
                    Paragraph p7 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    //detail
                    doc.Add(HeaderDetails1);

                    doc.Add(new Chunk("\nDL Detecable Limit -", NormalFont));
                    prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
                    prgGeneratedBY.Add(new Chunk("Authorised Signatory :", NormalFont));
                    var sign_Image = iTextSharp.text.Image.GetInstance(Signature_ImPathP);
                    PdfPCell Imagecell = new PdfPCell();
                    Imagecell.AddElement(sign_Image);
                    sign_Image.ScaleAbsolute(80f, 40f);
                    sign_Image.Alignment = (Element.ALIGN_RIGHT);

                    doc.Add(sign_Image);


                    doc.Add(new Chunk("\n", NormalFont));
                    var sign_name = Signature_NameP;
                    var sign_desgn = Signature_DesgnP;
                    prgGeneratedBY.Add(new Chunk("\n" + sign_desgn, NormalFont));
                    prgGeneratedBY.Add(new Chunk(" :" + sign_name, NormalFont));
                    doc.Add(prgGeneratedBY);
                    doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    //Notes
                    doc.Add(new Chunk("\n", NormalFont));
                    doc.Add(new Chunk("\nNotes :", boldFont));
                    doc.Add(new Chunk("\n.  " + _configuration.GetSection("AppSettings")["notes"].ToString(), NormalFont));
                    doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes1"].ToString(), NormalFont));
                    doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes2"].ToString(), NormalFont));
                    doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes3"].ToString(), NormalFont));
                    doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes4"].ToString(), NormalFont));
                    doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont));

                    doc.Add(new Chunk("\n", NormalFont));


                  
                    doc.Close();

                    byte[] result = ms.ToArray();

                    return result;
                }
            }


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
        ////Print PDF

        //public string downloadpdf()
        //{
        //    excel_msg = "";
        //    string filename = _configuration.GetSection("AppSettings")["PrintFileName"].ToString();
        //    var sptver = filename;
        //    string FileType = _configuration.GetSection("AppSettings")["FileExtention"].ToString();
        //    var file_ext = FileType;
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    logger.Debug("webRootPath -" + webRootPath);
        //    var Download_path = _configuration.GetSection("AppSettings")["soildownload"].ToString();
        //    string folderName = "DownloadXLFiles";
        //    Guid guid = Guid.NewGuid();
        //    string fileLocation = Path.Combine(webRootPath, folderName);
        //    logger.Debug("fileLocation -" + fileLocation);
        //    string Clientpath = Path.Combine("/DownloadXLFiles/" + sptver + guid + "_" + file_ext);
        //    logger.Debug("Clientpath  - " + Clientpath);
        //    string path = Path.Combine(fileLocation, sptver + guid + "_" + file_ext);
        //    logger.Debug(" path -" + path);
        //    excel_msg = Clientpath;
        //    try
        //    {
        //        if (System.IO.File.Exists(path))
        //        {

        //            System.IO.File.Delete(path);
        //        }
        //        byte[] filecontent = exportpdf(path);
        //        logger.Debug("filecontent - " + filecontent);


        //        logger.Debug("excel_msg - " + excel_msg.path);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("downloadpdf method - " + ex.ToString());
        //    }

        //    return JsonConvert.SerializeObject(excel_msg);
        //}
        ////Print PDF
        //public byte[] exportpdf(string path)
        //{

        //    if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
        //    {
        //        urlstring = _configuration.GetSection("Api_dev")["api_url"].ToString();
        //    }
        //    else if (_configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT")
        //    {
        //        urlstring = _configuration.GetSection("Appsettings")["api_url_final"].ToString();
        //    }
        //    else
        //    {
        //        urlstring = _configuration.GetSection("Api_pro")["api_url"].ToString();
        //    }

        //    //session values
        //    var orgnId = HttpContext.Session.GetString("orgId");
        //    var userId = HttpContext.Session.GetString("userId");
        //    var In_Tran_Id = HttpContext.Session.GetString("In_Tran_Id");
        //    var In_farmer_code = HttpContext.Session.GetString("In_farmer_code");
        //    var locnId = HttpContext.Session.GetString("locnId");
        //    var localeId = HttpContext.Session.GetString("localeId");


        //    soilviewContext objList = new soilviewContext();
        //    token objtoken = new token();
        //    gettoken objt = new gettoken();
        //    objtoken.Username = "test";
        //    objtoken.Password = "test";
        //    using (var client1 = new HttpClient())
        //    {
        //        string Urlcon = "Users/";
        //        client1.BaseAddress = new Uri(urlstring + Urlcon);
        //        client1.DefaultRequestHeaders.Accept.Clear();
        //        client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpContent content = new StringContent(JsonConvert.SerializeObject(objtoken), UTF8Encoding.UTF8, "application/json");
        //        var response2 = client1.PostAsync("authenticate", content).Result;
        //        Stream data = response2.Content.ReadAsStreamAsync().Result;
        //        StreamReader reader = new StreamReader(data);
        //        post_data = reader.ReadToEnd();
        //        objt = (gettoken)JsonConvert.DeserializeObject(post_data, typeof(gettoken));
        //        string auth = objt.token;

        //        using (var client = new HttpClient())
        //        {
        //            string Urlcon1 = "api/SolidCard_Checker/";
        //            client.BaseAddress = new Uri(urlstring + Urlcon1);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            var response1 = client.GetAsync("SoilCardPrintChecker?org=" + orgnId + "&locn=" + locnId + "&user=" + userId + "&lang=" + localeId + "&In_Tran_Id=" + In_Tran_Id + "&In_farmer_code=" + In_farmer_code + "").Result;

        //            Stream data1 = response1.Content.ReadAsStreamAsync().Result;
        //            StreamReader reader1 = new StreamReader(data1);
        //            post_data = reader1.ReadToEnd();
        //            objList = (soilviewContext)JsonConvert.DeserializeObject(post_data, typeof(soilviewContext));

        //            System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //            try
        //            {

        //                // creating document object

        //                iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
        //                rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);


        //                Document doc = new Document(rec);
        //                doc.SetPageSize(iTextSharp.text.PageSize.A4);

        //                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

        //                // PdfWriter writer = PdfWriter.GetInstance(doc, ms);
        //                doc.Open();
        //                //  PdfContentByte  pdfContent = writer.DirectContent;
        //                iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(doc.PageSize);
        //                //customized border sizes
        //                rectangle.Left += doc.LeftMargin - 5;
        //                rectangle.Right -= doc.RightMargin - 5;
        //                rectangle.Top -= doc.TopMargin - 5;
        //                rectangle.Bottom += doc.BottomMargin - 5;


        //                //Creating paragraph for header
        //                iTextSharp.text.Font mainFont = new iTextSharp.text.Font();
        //                iTextSharp.text.Font boldFont = new iTextSharp.text.Font();
        //                boldFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
        //                iTextSharp.text.Font NormalFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        //                iTextSharp.text.Font NormalFont1 = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

        //                BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
        //                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 9, 1, iTextSharp.text.BaseColor.BLACK);
        //                BaseFont bfntHead1 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
        //                iTextSharp.text.Font fntblack = new iTextSharp.text.Font(bfntHead1, 10, 1, iTextSharp.text.BaseColor.BLACK);
        //                Paragraph prgHeading = new Paragraph();
        //                Paragraph prgGeneratedBY = new Paragraph();
        //                PdfPCell Headerlogo = new PdfPCell();


        //                var Header = _configuration.GetSection("AppSettings")["PDFHeader1"];


        //                var image = iTextSharp.text.Image.GetInstance(Header);

        //                prgHeading.Alignment = Element.PARAGRAPH;
        //                // image.SetAbsolutePosition(100, 100);
        //                prgHeading.Add(image);
        //                doc.Add(prgHeading);


        //                //// Header
        //                prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
        //                doc.Add(new Chunk(_configuration.GetSection("AppSettings")["Middleheader"].ToString(), boldFont));

        //                PdfPTable HeaderDetails = new PdfPTable(4);
        //                HeaderDetails.WidthPercentage = 100;
        //                int[] HeaderDetailsCellWidth = { 15, 30, 15, 40 };
        //                HeaderDetails.SetWidths(HeaderDetailsCellWidth);
        //                //Header
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Number", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_tranid, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Description", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].sampledescription, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Date", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analycompleted, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Drawn By", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampledrawn, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Unidue Lab Report No", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_labreportno, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Customer's Reference", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_code, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Lab I.D.", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_labid, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Received On ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_samplereceived, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Started On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analystarted, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Completed On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_analycompleted, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample ID", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampleid, NormalFont1)));
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase(" ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails.AddCell(new PdfPCell(new Phrase()));

        //                //Details
        //                PdfPTable HeaderDetails1 = new PdfPTable(5);
        //                HeaderDetails1.WidthPercentage = 100;
        //                int[] HeaderDetailsCellWidth1 = { 15, 30, 15, 40, 15 };
        //                HeaderDetails1.SetWidths(HeaderDetailsCellWidth1);


        //                HeaderDetails1.AddCell(new PdfPCell(new Phrase("S No.", NormalFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails1.AddCell(new PdfPCell(new Phrase("Parameter", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails1.AddCell(new PdfPCell(new Phrase("Unit", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails1.AddCell(new PdfPCell(new Phrase("Results", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
        //                HeaderDetails1.AddCell(new PdfPCell(new Phrase("Test Method", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });

        //                for (int rows = 0; rows < objList.Print.Count; rows++)
        //                {
        //                    HeaderDetails1.AddCell(new PdfPCell(new Phrase(new Chunk((rows + 1).ToString()))));
        //                    // HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampleid, NormalFont)));
        //                    HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].parameter, NormalFont)));
        //                    HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].unit, NormalFont)));
        //                    HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].result, NormalFont)));
        //                    HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[rows].farmer_testmethod, NormalFont)));

        //                }



        //                //header
        //                doc.Add(HeaderDetails);
        //                Paragraph p7 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
        //                doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

        //                //detail
        //                doc.Add(HeaderDetails1);

        //                // var footer = iTextSharp.text.Image.GetInstance(@"E:\Vadivu\Kiosk web\nafkiosk\Kiosk web\wwwroot\newfooter1.jpg");
        //                var footer = (_configuration.GetSection("AppSettings")["PDFFooter1"]);

        //                var footer1 = iTextSharp.text.Image.GetInstance(footer);

        //                prgHeading.Alignment = Element.ALIGN_LEFT;
        //                // footer.SetAbsolutePosition(100, 100);
        //                prgGeneratedBY.Add(footer1);
        //                // doc.Add(prgGeneratedBY);

        //                doc.Add(prgGeneratedBY); doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

        //                doc.Add(new Chunk("\nNotes :", boldFont));
        //                doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes1"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n  " + _configuration.GetSection("AppSettings")["notes2"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes3"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes4"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n   " + _configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes6"].ToString(), NormalFont));
        //                doc.Add(new Chunk("\n  " + _configuration.GetSection("AppSettings")["notes7"].ToString(), NormalFont));


        //                doc.Add(new Chunk("\n", NormalFont));
        //                //doc.Add(new Chunk("\n  ", NormalFont1));
        //                doc.Close();


        //            }
        //            catch (Exception ex)
        //            {
        //                logger.Error("Error -2nd Method -" + ex.ToString());
        //            }
        //            byte[] result = ms.ToArray();

        //            return result;
        //        }
        //    }

        //}
    }
}
