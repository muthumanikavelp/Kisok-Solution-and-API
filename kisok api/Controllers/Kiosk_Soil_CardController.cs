using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using nafservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using static nafmodel.Kiosk_Soil_Card_model;
using System.IO;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Hosting.Internal;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mime;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_Soil_CardController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        Kiosk_Soil_Card_Service objRoleService = new Kiosk_Soil_Card_Service();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Kiosk_Soil_CardController)); //Declaring Log4Net.
        public Kiosk_Soil_CardController(IOptions<MySettingsModel> app, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }





        #region

        //introduced code by Venkat getsolidparameters grid values 2021-04-21

        [Authorize]
        [HttpGet("getsoliparameters")]
        public soilParametersDetailItems getsoliparameters(string org, string locn, string lang, string status)
        {
            soilParametersDetailItems obj_soilDetailItems = new soilParametersDetailItems();
            try
            {
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
                obj_soilDetailItems = objRoleService.getsoliparameters(ConString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_soilDetailItems;
        }

        [Authorize]
        [HttpGet("getNONNABLsoliparameters")]
        public soilParametersDetailItems getNONNABLsoliparameters(string org, string locn, string lang, string status)
        {
            soilParametersDetailItems obj_NONNABLsoilDetailItems = new soilParametersDetailItems();
            try
            {
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
                obj_NONNABLsoilDetailItems = objRoleService.getNONNABLsoliparameters(ConString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_NONNABLsoilDetailItems;
        }
        #endregion
        [Authorize]
        [HttpGet("SoilCardListView")]
        public soilviewContext soilviewList(string org, string locn, string user, string lang,int soil_gid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(soil_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            soilviewContext ObjList = new soilviewContext();
            try
            {
                ObjList = objRoleService.GetsoilviewList(org, locn, user, lang, soil_gid, ConString);              

            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [Authorize]
        [HttpGet("SoilCardList")]
        public soilListContext soilList(string org, string locn, string lang, int In_farmer_gid, string status)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(lang);
            objArr.Add(status);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            soilListContext ObjList = new soilListContext();
            try
            {
                ObjList = objRoleService.GetsoilList_srv(org, locn, lang, In_farmer_gid, status, ConString);
            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }


        [Authorize]
        [HttpPost("SoilCardLastInsertid")]
        public Retrnmesg SoilCardLastInsertid(soilcardsave ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.Detail);
            ObjModel.detail_formatted = jsonString;
            try
            {
                response = objRoleService.GetSoilcardmaxid(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }



        [Authorize]
        [HttpPost("soilcardsave")]
        public Retrnmesg newsoilcardsave(soilcardsave ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string[] response = { retmsg, retresult };
            Retrnmesg sucessmsg = new Retrnmesg();
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.Detail);
            ObjModel.detail_formatted = jsonString;
            try
            {
                response = objRoleService.Newsoilcardsave_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            sucessmsg.out_msg = response[0];
            sucessmsg.out_result = response[1];
            return sucessmsg;
        }

        //print list
        [Authorize]
        [HttpGet("SoilCardPrint")]
        public soilviewContext soilviewPrintList(string org, string locn, string user, string lang, int soil_gid,string In_Tran_Id, string In_farmer_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(soil_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            soilviewContext ObjList = new soilviewContext();
            try
            {
                ObjList = objRoleService.soilviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }



        //Venkat Added 16-03-2021

        #region
        [HttpGet("kioskEmailsent")]
        public kioskSolidcardPdfAndEmail kioskresetpass(string org, string locn, string user, string lang,
            string email, string In_farmer_code, int soil_gid, string In_Tran_Id, string In_user_code)
        {
            kioskSolidcardPdfAndEmail ObjList = new kioskSolidcardPdfAndEmail();
            try { 
            string message = "";
          // string db = Instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            string filename = _configuration.GetSection("AppSettings")["PrintFileName"].ToString();

            var sptver = filename;
            string FileType = _configuration.GetSection("AppSettings")["FileExtention"].ToString();
            string File_path = "";

            
           
                var file_ext = FileType;
                string contentpath = _hostingEnvironment.ContentRootPath;
                //  logger.Debug("contentpath " + contentpath);
                string FileFolderName = _configuration.GetSection("AppSettings")["FolderName"].ToString();
                string folderName = FileFolderName;
                string fileLocation = Path.Combine(contentpath, folderName);
                string Clientpath = Path.Combine("/folderName/" + sptver + file_ext);
                string path = Path.Combine(fileLocation + "\\" + sptver + file_ext);
                string FilePath = string.Empty;
               

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

               byte[] filecontent = exportpdf(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, path);
               File_path = _configuration.GetSection("AppSettings")["SolidPath"].ToString();
              logger.Debug("File_path -" + File_path);
           // File_path = "../kisok api/videos/Soil_Card_Print.Pdf";
            //string msg = ObjList.In_Reponse;


            string portno = _configuration.GetSection("AppSettings")["SMTPPort"].ToString();
                logger.Debug("portno -" + portno);
                string FromEmailId = _configuration.GetSection("Appsettings")["FromEmailId"].ToString();
                logger.Debug("FromEmailId -" + FromEmailId);
                string Password = _configuration.GetSection("Appsettings")["Password"].ToString();
               logger.Debug("Password -" + Password);
               string hos = _configuration.GetSection("Appsettings")["Host"].ToString();
               logger.Debug("hos -" + hos);
                string userhost = email;
               logger.Debug("userhost -" + userhost);
               string sub = _configuration.GetSection("AppSettings")["Subject"].ToString();
              logger.Debug("sub -" + sub);
               string body = _configuration.GetSection("AppSettings")["Body"].ToString();
               logger.Debug("body -" + body);
               var smtp = new SmtpClient
                {
                    Host = hos,
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(FromEmailId, Password),
                    EnableSsl = true
                };

                    logger.Debug("smtp - " + smtp);
                
                MailMessage mess = new MailMessage(FromEmailId, userhost);
                logger.Debug("mess - " + mess);
                  Attachment attachment = new Attachment(File_path);
              //  Attachment attachment = new Attachment("D:/Kiosk/nafkiosk-vadivu/kisok api/videos/Soil_Card_Print.pdf");
                logger.Debug("File_path - " + File_path);
                mess.Subject = sub;
                 logger.Debug("mess.Subject - " + mess.Subject);
                mess.Body = body;
                mess.Attachments.Add(attachment);
                {
                logger.Debug("send -");
                    smtp.Send(mess);
                    ObjList.In_Reponse = "Mail Sended Sucessfully";
                }

            }
            catch(Exception ex)
            {
                logger.Error("Exception - " + ex);
            }
            return ObjList;
        }

        #endregion

        #region
        public byte[] exportpdf(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string path)
        {
            //logger.Debug("export start - 10 jan 23");
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(soil_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            soilviewContext ObjList = new soilviewContext();
            ObjList = objRoleService.apisoilviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);
            // creating document object
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            var rec = new iTextSharp.text.Rectangle(550, 600);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.White);
            // Document doc = new iTextSharp.text.Document(rec, 40f, 40f, 40f, 40f);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 10F, 10F, 10F, 10F);
            doc.SetPageSize(rec);
            

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
           
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
            prgHeading.Alignment = Element.ALIGN_LEFT;

            Paragraph prgGeneratedBY = new Paragraph();
            PdfPCell Headerlogo = new PdfPCell();
            // var image = iTextSharp.text.Image.GetInstance(@"E:\Vadivu\Kiosk web\nafkiosk\kisok api\newheader1.jpg");
            //var image = iTextSharp.text.Image.GetInstance(_configuration.GetSection("AppSettings")["PDFHeader"]);

            var image = iTextSharp.text.Image.GetInstance(_configuration.GetSection("AppSettings")["PDFHeader1"]);


            prgHeading.Alignment = Element.PARAGRAPH;
            // image.SetAbsolutePosition(100, 100);
            prgHeading.Add(image);
            doc.Add(prgHeading);

            prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
            doc.Add(new Chunk(_configuration.GetSection("AppSettings")["Middleheader"].ToString(), boldFont));

            PdfPTable HeaderDetails = new PdfPTable(4);
            HeaderDetails.WidthPercentage = 100;
            int[] HeaderDetailsCellWidth = { 15, 30, 15, 40 };
            HeaderDetails.SetWidths(HeaderDetailsCellWidth);
            //Header
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Number", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_tranid, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Description", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].sampledescription, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Date", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_samplereceived, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Drawn By", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_sampledrawn, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Unidue Lab Report No", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_labreportno, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Customer's Reference", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_code, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Lab I.D.", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_labid, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Received On ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_samplereceived, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Started On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_analystarted, NormalFont1)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Completed On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_analycompleted, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample ID", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_sampleid, NormalFont)));
            HeaderDetails.AddCell(new PdfPCell(new Phrase(" ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails.AddCell(new PdfPCell(new Phrase()));

            //Details
            PdfPTable HeaderDetails1 = new PdfPTable(5);
            HeaderDetails1.WidthPercentage = 100;
            int[] HeaderDetailsCellWidth1 = { 15, 30, 15, 25, 30 };
            HeaderDetails1.SetWidths(HeaderDetailsCellWidth1);


            HeaderDetails1.AddCell(new PdfPCell(new Phrase("S.No.", NormalFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails1.AddCell(new PdfPCell(new Phrase("Parameter", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails1.AddCell(new PdfPCell(new Phrase("Unit", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails1.AddCell(new PdfPCell(new Phrase("Results", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
            HeaderDetails1.AddCell(new PdfPCell(new Phrase("Test Method", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });

            for (int rows = 0; rows < ObjList.Print.Count; rows++)

            {
                HeaderDetails1.AddCell(new PdfPCell(new Phrase(new Chunk((rows + 1).ToString()))));
                // HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampleid, NormalFont)));
                HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].parameter, NormalFont)));
                HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].unit, NormalFont)));
                HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].result, NormalFont)));
                HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].farmer_testmethod, NormalFont)));

            }


            //header
            doc.Add(HeaderDetails);
            Paragraph p7 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

            //detail  PDFHeader
            doc.Add(HeaderDetails1);

            // var footer1 = iTextSharp.text.Image.GetInstance(@"E:\Vadivu\Kiosk web\nafkiosk\kisok api\newfooter1.jpg");
            var footer1 = iTextSharp.text.Image.GetInstance(_configuration.GetSection("AppSettings")["PDFFooter"]);
            prgHeading.Alignment = Element.PARAGRAPH;
            // footer.SetAbsolutePosition(100, 100);
            prgGeneratedBY.Add(footer1);

          
            doc.Add(prgGeneratedBY); doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

            //    //Notes
            doc.Add(new Chunk("\n", NormalFont));
            doc.Add(new Chunk("\nNotes :", boldFont));
            doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes"].ToString(), NormalFont));
            doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes1"].ToString(), NormalFont));
            doc.Add(new Chunk("\n  " + _configuration.GetSection("AppSettings")["notes2"].ToString(), NormalFont));
            doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes3"].ToString(), NormalFont));
            doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes4"].ToString(), NormalFont));
            doc.Add(new Chunk("\n   " + _configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont));
            doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes6"].ToString(), NormalFont));
            doc.Add(new Chunk("\n  " + _configuration.GetSection("AppSettings")["notes7"].ToString(), NormalFont));
            // doc.Add();
            doc.Add(new Chunk("\n", NormalFont));
            //doc.Add(new Chunk("\n  ", NormalFont1));

            doc.Close();
            // logger.Debug("doc close");

            byte[] result = ms.ToArray();
            return result;

        }
        #endregion















    }
}
