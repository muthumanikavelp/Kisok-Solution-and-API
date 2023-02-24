using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using static nafmodel.OfflineVideoList_Model;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using nafmodel;
using System.Configuration;

namespace nafdatamodel
{

    public class OfflineVideoList_Datamodel
    {


        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(OfflineVideoList_Datamodel)); //Declaring Log4Net.



        public static DataConnection MysqlCon;
        
         

        public KioskVideoApplication GetAllKioskVideo_Srv(KioskVideoContext objinvoice, string mysqlcon, string advtfilepath,string  videofilepath,string faqfilepath, string schemesfilepath)
        {
            DataSet ds = new DataSet();

            DataTable Advertisment = new DataTable();
            DataTable video = new DataTable();
            DataTable FAQS = new DataTable();
            DataTable schemes = new DataTable();

            KioskVideoApplication objinvoiceRoot = new KioskVideoApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new KioskVideoContext();

            objinvoiceRoot.context.Advertisment = new List<KioskAdvertisementVideoList>();
            objinvoiceRoot.context.TrainingVideos = new List<KioskTrainingVideoList>();
            objinvoiceRoot.context.FAQS = new List<KioskfaqDetails>();
            objinvoiceRoot.context.schemes = new List<KioskschemesrDetails>();

             



            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("MOB_OfflineVideo_List", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
              // logger.Debug("contentpath " + contentpath);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();


                if (ds.Tables.Count > 0)
                {
                    //Video
                 // logger.Debug("video " );
                     video = ds.Tables[1];
                    for (int i = 0; i < video.Rows.Count; i++)
                    {
                        KioskTrainingVideoList Objlist = new KioskTrainingVideoList();
                        Objlist.video_gid = Convert.ToInt32(video.Rows[i]["video_gid"]);
                        Objlist.video_filename = video.Rows[i]["video_filename"].ToString();
                        Objlist.video_filepath = video.Rows[i]["video_filepath"].ToString();
                        Objlist.video_category = video.Rows[i]["video_category"].ToString();
                       // logger.Debug("vide1" + ds.Tables[1]);
                        //convert to bytes 
                        byte[] fileContent = null;
                        string video_path = Path.Combine(videofilepath + "\\" + Objlist.video_category+ "\\" + Objlist.video_filename);
                        System.IO.FileStream fs = new System.IO.FileStream(video_path, FileMode.Open, FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(video_path).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        Objlist.Video_fileContent = fileContent;
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();
                        //objinvoiceRoot.context.TrainingVideos.Add(Objlist);
                        objinvoiceRoot.context.TrainingVideos.Add(Objlist);
                        logger.Debug("video2 " + ds.Tables[1]);
                        logger.Debug("video2 " + Objlist.Video_fileContent);
                    }

                    //Advertisment
                    Advertisment = ds.Tables[0];
                    for (int i = 0; i < Advertisment.Rows.Count; i++)
                    {
                        
                      //  logger.Debug("advt " );
                        KioskAdvertisementVideoList Objlist = new KioskAdvertisementVideoList();
                        Objlist.ad_gid = Convert.ToInt32(Advertisment.Rows[i]["ad_gid"]);
                        Objlist.ad_path = Advertisment.Rows[i]["ad_path"].ToString();
                        Objlist.ad_name = (Advertisment.Rows[i]["ad_name"].ToString());
                        //convert to bytes
                        byte[] fileContent = null;
                        string ad_path = Path.Combine(advtfilepath + "\\" + Objlist.ad_name);
                        System.IO.FileStream fs = new System.IO.FileStream(ad_path, FileMode.Open, FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(ad_path).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        Objlist.ad_fileContent = fileContent;
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();


                        objinvoiceRoot.context.Advertisment.Add(Objlist);
                     logger.Debug("advert1 " + ds.Tables[0]);
                        logger.Debug("advert1 " + Objlist.ad_fileContent);
                    }

                    ////FAQ

                    FAQS = ds.Tables[2];
                    for (int i = 0; i < FAQS.Rows.Count; i++)
                    {
                       // logger.Debug("faq1"  );
                        KioskfaqDetails Objlist = new KioskfaqDetails();
                        Objlist.faq_gid = Convert.ToInt32(FAQS.Rows[i]["faq_gid"]);
                        Objlist.faq_ans_upload = FAQS.Rows[i]["faq_ans_upload"].ToString();
                        // Objlist.ad_name = (Advertisment.Rows[i]["ad_name"].ToString());
                        //convert to bytes
                        byte[] fileContent = null;
                        string faq_path = Path.Combine(faqfilepath + "\\" + Objlist.faq_ans_upload);

                        System.IO.FileStream fs = new System.IO.FileStream(faq_path, FileMode.Open, FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(faq_path).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        Objlist.faq_fileContent = fileContent;
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();


                        objinvoiceRoot.context.FAQS.Add(Objlist);
                     logger.Debug("faq2 " + ds.Tables[2]);
                        logger.Debug("faq2 " + Objlist.faq_fileContent);
                    }

                    //schemes
                    schemes = ds.Tables[3];
                    for (int i = 0; i < schemes.Rows.Count; i++)
                    {
                      //  logger.Debug("schems1 "  );
                        KioskschemesrDetails Objlist = new KioskschemesrDetails();
                        Objlist.scheme_gid = Convert.ToInt32(schemes.Rows[i]["scheme_gid"]);
                        Objlist.scheme_url = schemes.Rows[i]["scheme_url"].ToString();
                        Objlist.scheme_upload = (schemes.Rows[i]["scheme_upload"].ToString());
                        string filepath = Objlist.scheme_upload;
                        string FileName = filepath.Substring(filepath.LastIndexOf('\\') +1);
                        //convert to bytes
                        byte[] fileContent = null;
                        //string scheme_path = Objlist.scheme_upload;
                        string scheme_path = Path.Combine(schemesfilepath + "\\" + FileName);


                        System.IO.FileStream fs = new System.IO.FileStream(scheme_path, FileMode.Open, FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(scheme_path).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        Objlist.scheme_fileContent = fileContent;
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();


                        objinvoiceRoot.context.schemes.Add(Objlist);
                       logger.Debug("schems2 " + ds.Tables[3]);
                        logger.Debug("schems3 " + Objlist.scheme_fileContent);
                    }



                }


                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
               // logger.Debug("schems2 " + ds.Tables[3]);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objinvoiceRoot;
             
        }



    }
}
