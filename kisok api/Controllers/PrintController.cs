using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Xml;
using static nafmodel.Kiosk_Soil_Card_model;

namespace kisok_api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string dbstring = "";
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        private IHostingEnvironment _hostingEnvironment;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PrintController)); //Declaring Log4Net.

        public PrintController(IOptions<MySettingsModel> app, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
 
        Kiosk_Soil_Card_Service objRoleService = new Kiosk_Soil_Card_Service();

        [HttpGet("apiSoilCardPrint")]
        public soilprint downloadpdf(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code)
        {

            soilprint objsoilprint = new soilprint();
            string ret_file_path = string.Empty;
            string File_path = "";

            try
            {
                
                
                string filename = _configuration.GetSection("AppSettings")["PrintFileName"].ToString();

                var sptver = filename;
                string FileType = _configuration.GetSection("AppSettings")["FileExtention"].ToString();

                

                var file_ext = FileType;
                string contentpath = _hostingEnvironment.ContentRootPath;
                   logger.Debug("contentpath " + contentpath);
                string FileFolderName = _configuration.GetSection("AppSettings")["FolderName"].ToString();
                Guid guid = Guid.NewGuid();
                string folderName = FileFolderName;
                string fileLocation = Path.Combine(contentpath, folderName);
                // string Clientpath = Path.Combine("/folderName/" + sptver + file_ext);
                string filenamepath= (sptver + guid + "_" + file_ext);
                logger.Debug("filenamepath:" + filenamepath);
                string Clientpath = Path.Combine("/DownloadXLFiles/" + sptver + guid + "_" + file_ext);
                logger.Debug("Clientpath:" + Clientpath);
                string path = Path.Combine(fileLocation + "\\" + sptver + guid + "_" + file_ext);
                logger.Debug("path:" + path);
                string FilePath = string.Empty;
                objsoilprint.path = "";
               
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                
                byte[] filecontent = exportpdf(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, path);

             File_path = _configuration.GetSection("AppSettings")["PDFFilePath"].ToString();
                logger.Debug("File_path:" + File_path);
                File_path = File_path + "/" + filenamepath;
                logger.Debug("concatFile_path:" + File_path);
                objsoilprint.path = File_path;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "   " + "ERROR  : " + ex);
            }
             
            return (objsoilprint);
        }


        //    public byte[] exportpdf(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string path)
        //    {
        //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //        try { 

        //        ArrayList objArr = new ArrayList();
        //        objArr.Add(org);
        //        objArr.Add(locn);
        //        objArr.Add(user);
        //        objArr.Add(lang);
        //        objArr.Add(soil_gid);
        //        AllConnectionString rcon = new AllConnectionString();
        //        this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
        //        soilviewContext ObjList = new soilviewContext();
        //        ObjList = objRoleService.apisoilviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);
        //        // creating document object

        //        var rec = new iTextSharp.text.Rectangle(550, 600);
        //        rec.BackgroundColor = new BaseColor(System.Drawing.Color.White);
        //       // Document doc = new iTextSharp.text.Document(rec, 40f, 40f, 40f, 40f);
        //        Document doc = new Document(PageSize.A4, 10F, 10F, 10F,10F);
        //        doc.SetPageSize(rec);
        //        // iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);

        //        //  PdfWriter writer = PdfWriter.GetInstance(doc, ms);

        //        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
        //        doc.Open();

        //        //Creating paragraph for header
        //        iTextSharp.text.Font mainFont = new iTextSharp.text.Font();
        //        iTextSharp.text.Font boldFont = new iTextSharp.text.Font();
        //        boldFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
        //        iTextSharp.text.Font NormalFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        //        iTextSharp.text.Font NormalFont1 = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

        //        BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
        //        iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 9, 1, iTextSharp.text.BaseColor.BLACK);
        //        BaseFont bfntHead1 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED);
        //        iTextSharp.text.Font fntblack = new iTextSharp.text.Font(bfntHead1, 10, 1, iTextSharp.text.BaseColor.BLACK);
        //        Paragraph prgHeading = new Paragraph();
        //        prgHeading.Alignment = Element.ALIGN_LEFT;

        //        Paragraph prgGeneratedBY = new Paragraph();
        //        PdfPCell Headerlogo = new PdfPCell();
        //        // var image = iTextSharp.text.Image.GetInstance(@"E:\Vadivu\Kiosk web\nafkiosk\kisok api\newheader1.jpg");
        //        var image = iTextSharp.text.Image.GetInstance(_configuration.GetSection("AppSettings")["PDFHeader"]);
        //        logger.Debug("Header Image - " + image);
        //        prgHeading.Alignment = Element.PARAGRAPH;
        //        // image.SetAbsolutePosition(100, 100);
        //        prgHeading.Add(image);
        //        doc.Add(prgHeading);


        //        //// Header 
        //        prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
        //        doc.Add(new Chunk(_configuration.GetSection("AppSettings")["Middleheader"].ToString(), boldFont));

        //        PdfPTable HeaderDetails = new PdfPTable(4);
        //        HeaderDetails.WidthPercentage = 100;
        //        int[] HeaderDetailsCellWidth = { 15, 30, 15, 40 };
        //        HeaderDetails.SetWidths(HeaderDetailsCellWidth);
        //        //Header
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Number", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_tranid, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Description", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].sampledescription, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Report Date", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_samplereceived, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Drawn By", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_sampledrawn, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Unidue Lab Report No", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_labreportno, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Customer's Reference", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_code, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Lab I.D.", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_labid, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample Received On ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_samplereceived, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Started On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_analystarted, NormalFont1)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Analysis Completed On", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_analycompleted, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase("Sample ID", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_sampleid, NormalFont)));
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase(" ", NormalFont1)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails.AddCell(new PdfPCell(new Phrase()));

        //        //Details
        //        PdfPTable HeaderDetails1 = new PdfPTable(5);
        //        HeaderDetails1.WidthPercentage = 100;
        //        int[] HeaderDetailsCellWidth1 = { 15, 30, 15, 25, 30 };
        //        HeaderDetails1.SetWidths(HeaderDetailsCellWidth1);


        //        HeaderDetails1.AddCell(new PdfPCell(new Phrase("S.No.", NormalFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Parameter", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Unit", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Results", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
        //        HeaderDetails1.AddCell(new PdfPCell(new Phrase("Test Method", NormalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });

        //        for (int rows = 0; rows < ObjList.Print.Count; rows++)

        //        {
        //            HeaderDetails1.AddCell(new PdfPCell(new Phrase(new Chunk((rows + 1).ToString()))));
        //            // HeaderDetails1.AddCell(new PdfPCell(new Phrase(objList.Print[0].farmer_sampleid, NormalFont)));
        //            HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].parameter, NormalFont)));
        //            HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].unit, NormalFont)));
        //            HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].result, NormalFont)));
        //            HeaderDetails1.AddCell(new PdfPCell(new Phrase(ObjList.Print[rows].farmer_testmethod, NormalFont)));

        //        }


        //        //header
        //        doc.Add(HeaderDetails);
        //        logger.Debug("Pdf Header - " + HeaderDetails);
        //        Paragraph p7 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
        //        doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

        //        //detail  PDFHeader
        //        doc.Add(HeaderDetails1);
        //        logger.Debug("Pdf Details  - " + HeaderDetails1);
        //        // var footer1 = iTextSharp.text.Image.GetInstance(@"E:\Vadivu\Kiosk web\nafkiosk\kisok api\newfooter1.jpg");
        //        var footer1 = iTextSharp.text.Image.GetInstance(_configuration.GetSection("AppSettings")["PDFFooter"]);
        //        logger.Debug("Footer Image - " + image);
        //        prgHeading.Alignment = Element.PARAGRAPH;
        //        // footer.SetAbsolutePosition(100, 100);
        //        prgGeneratedBY.Add(footer1);



        //        doc.Add(prgGeneratedBY); doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

        //        //    //Notes
        //        doc.Add(new Chunk("\n", NormalFont));
        //        doc.Add(new Chunk("\nNotes :", boldFont));
        //        doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes1"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n  " + _configuration.GetSection("AppSettings")["notes2"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes3"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes4"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n   " + _configuration.GetSection("AppSettings")["notes5"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n. " + _configuration.GetSection("AppSettings")["notes6"].ToString(), NormalFont));
        //        doc.Add(new Chunk("\n  " + _configuration.GetSection("AppSettings")["notes7"].ToString(), NormalFont));
        //        // doc.Add();
        //        doc.Add(new Chunk("\n", NormalFont));
        //        //doc.Add(new Chunk("\n  ", NormalFont1));

        //        doc.Close();
        //        // logger.Debug("doc close");



        //        }
        //        catch(Exception ex)
        //        {
        //            logger.Error("exportpdf -" + ex);
        //           // throw ex;
        //        }
        //        byte[] result = ms.ToArray();
        //        return result;
        //    }


        public byte[] exportpdf(string org, string locn, string user, string lang, int soil_gid, string In_Tran_Id, string In_farmer_code, string path)
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
            ObjList = objRoleService.apisoilviewPrintList(org, locn, user, lang, soil_gid, In_Tran_Id, In_farmer_code, ConString);
            // creating document object
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            var rec = new iTextSharp.text.Rectangle(550, 600);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.White);
            // Document doc = new iTextSharp.text.Document(rec, 40f, 40f, 40f, 40f);
            Document doc = new Document(PageSize.A4, 10F, 10F, 10F, 10F);
            doc.SetPageSize(rec);
            // iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            // rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
            //Document doc = new Document(rec);
            //doc.SetPageSize(iTextSharp.text.PageSize.A4);
            //  PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            //  PdfContentByte  pdfContent = writer.DirectContent;
            //iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(doc.PageSize);
            ////customized border sizes
            //rectangle.Left += doc.LeftMargin - 5;
            //rectangle.Right -= doc.RightMargin - 5;
            //rectangle.Top += doc.TopMargin - 5;
            //rectangle.Bottom += doc.BottomMargin - 5;
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
            prgHeading.Alignment = Element.PARAGRAPH;
            // image.SetAbsolutePosition(100, 100);
            // prgHeading.Add(image);
            // doc.Add(prgHeading);

            //header name
            // string HeaderName = _configuration.GetSection("AppSettings")["PDFFileHeader"].ToString();  
            // prgHeading.Add(new Chunk(HeaderName.ToUpper(), boldFont));
            // doc.Add(prgHeading);
            //// Paragraph prgGeneratedBY = new Paragraph();
            // BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            // iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 10, 1, iTextSharp.text.BaseColor.BLACK);
            // prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
            // //AddressE:\Vadivu\Kiosk web\nafkiosk\kisok api\newfooter1.jpg
            // //second header name
            // string Header = _configuration.GetSection("AppSettings")["Header"].ToString();

            // doc.Add(prgGeneratedBY);

            // prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
            // prgHeading.Add(new Chunk(Header.ToUpper(), boldFont));
            // //prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
            // //doc.Add(new Chunk(Header, boldFont));

            // doc.Add(new Chunk("\nAddress : " + _configuration.GetSection("AppSettings")["SoilCardAddress"].ToString(), NormalFont));
            // doc.Add(new Chunk("\nPhone   : " + _configuration.GetSection("AppSettings")["SoilCardPoneno"].ToString(), NormalFont));
            // doc.Add(new Chunk("\nEmail   : " + _configuration.GetSection("AppSettings")["SoilcardEmail"].ToString(), NormalFont));

            // doc.Add(new Chunk("\n", NormalFont));
            // //Adding a line
            // //ISO
            // Paragraph p1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            // doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            // doc.Add(new Chunk("\n", NormalFont));
            // doc.Add(new Chunk("\n " + _configuration.GetSection("AppSettings")["ISO"].ToString(), NormalFont));
            // doc.Add(new Chunk("\n " + _configuration.GetSection("AppSettings")["ISO1"].ToString(), NormalFont));

            // doc.Add(new Chunk("\n " + _configuration.GetSection("AppSettings")["ISO2"].ToString(), NormalFont));
            var Header = _configuration.GetSection("AppSettings")["PDFHeader1"];


            var image = iTextSharp.text.Image.GetInstance(Header);

            prgHeading.Alignment = Element.PARAGRAPH;
            // image.SetAbsolutePosition(100, 100);
            prgHeading.Add(image);
            doc.Add(prgHeading);
            //Adding a line
            doc.Add(new Chunk("\n", NormalFont));
            //Adding a line
            //ISO
            Paragraph p2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(new Chunk("\n", NormalFont));
            // Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            // doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            // Header 
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
            HeaderDetails.AddCell(new PdfPCell(new Phrase(ObjList.Print[0].farmer_analycompleted, NormalFont)));
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

            //detail 
            doc.Add(HeaderDetails1);


            doc.Add(new Chunk(_configuration.GetSection("AppSettings")["Limit"].ToString(), NormalFont));

            prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
             doc.Add(new Chunk());
              prgGeneratedBY.Add(new Chunk("Authorised Signatory :", NormalFont));
          //  doc.Add(prgGeneratedBY);
            doc.Add(new Chunk("\n", NormalFont));
            prgGeneratedBY.Add(new Chunk("\nQuality Manager    : ", NormalFont));
            doc.Add(prgGeneratedBY);
            // doc.Add(prgGeneratedBY);
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

          //  doc.Add(prgGeneratedBY);
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 101.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

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

    }
}

 