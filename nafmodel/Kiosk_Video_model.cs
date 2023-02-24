using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nafmodel
{
  public  class Kiosk_Video_model
    {
        #region list category model
        [DataContract]
        public class VideoCategory
        {
            [DataMember(Name = "out_categoryId")]
            public string out_categoryId { get; set; }
            [DataMember(Name = "out_category")]
            public string out_category { get; set; }
        }
        public class videocatContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }

            public List<VideoCategory> category { get; set; }

        }

        public class videoCategoryApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class videoCategoryRootObject
        {

            public videocatContext context { get; set; }

            public videoCategoryApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region list Title model
        [DataContract]
        public class VideoTitle
        {

            [DataMember(Name = "out_title")]
            public string out_title { get; set; }
            [DataMember(Name = "out_file_Name")]
            public string out_file_Name { get; set; }
            public string video_category { get; set; }
           public string video_filename { get; set; }
          public string out_titleII { get; set; }
        }
        public class videoTitleContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_video_gid")]
            public int In_video_gid { get; set; }

            public List<VideoTitle> Title { get; set; }

        }

        public class videoTitleApplicationException
        {

            public string errorNumber { get; set; }

            public string errorDescription { get; set; }
        }

        public class videoTitleRootObject
        {

            public videoTitleContext context { get; set; }

            public videoTitleApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region View Summary model
        [DataContract]
        public class trancontext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }
            [DataMember(Name = "locnId")]
            public string locnId { get; set; }
            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "userId")]
            public string userId { get; set; }
            public List<tranvideoList> List { get; set; }
        }
        public class tranvideoList
        {
            [DataMember(Name = "video_gid")]
            public int video_gid { get; set; }
            [DataMember(Name = "videodate")]
            public string videodate { get; set; }
            [DataMember(Name = "title")]
            public string title { get; set; }
            [DataMember(Name = "category")]
            public string category { get; set; }
            [DataMember(Name = "filename")]
            public string filename { get; set; }
        }
        #endregion

        #region Save model
        [DataContract]
        public class SaveVideo
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_video_gid")]
            public int In_video_gid { get; set; }

            [DataMember(Name = "In_video_category")]
            public string In_video_category { get; set; }

            [DataMember(Name = "In_video_title")]
            public string In_video_title { get; set; }
            [DataMember(Name = "In_video_filename")]
            public string In_video_filename { get; set; }

            [DataMember(Name = "In_video_filepath")]
            public string In_video_filepath { get; set; }
            [DataMember(Name = "In_video_source")]
            public string In_video_source { get; set; }

            [DataMember(Name = "In_video_keywords")]
            public string In_video_keywords { get; set; }

            [DataMember(Name = "In_video_atttribute")]
            public string In_video_atttribute { get; set; }

            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }

            [DataMember(Name = "In_video_titleII")]
            public string In_video_titleII { get; set; }
            [DataMember(Name = "In_video_sourceII")]
            public string In_video_sourceII { get; set; }
            [DataMember(Name = "In_video_keywordsII")]
            public string In_video_keywordsII { get; set; }
             
        }

        #endregion

        #region attribute list
        public class attributecontext
        {
            [DataMember(Name = "depend_code")]
            public string depend_code { get; set; }
            [DataMember(Name = "locn")]
            public string locn { get; set; }
            public List<attributelist> list { get; set; }
        }
        public class attributelist
        {
            [DataMember(Name = "master_code")]
            public string master_code { get; set; }
            [DataMember(Name = "master_name")]
            public string master_name { get; set; }
        }
        #endregion

        #region fetch video model
        [DataContract]
        public class Videofetch
        {

            [DataMember(Name = "In_video_gid")]
            public int In_video_gid { get; set; }

            [DataMember(Name = "In_video_filename")]
            public string In_video_filename { get; set; }

            [DataMember(Name = "In_mode_flag")]
            public string In_mode_flag { get; set; }

            [DataMember(Name = "In_video_category")]
            public string In_video_category { get; set; }

            [DataMember(Name = "In_video_title")]
            public string In_video_title { get; set; }

            [DataMember(Name = "In_video_source")]
            public string In_video_source { get; set; }

            [DataMember(Name = "In_video_keywords")]
            public string In_video_keywords { get; set; }

            [DataMember(Name = "In_video_atttribute")]
            public string In_video_atttribute { get; set; }

            [DataMember(Name = "In_video_filepath")]
            public string In_video_filepath { get; set; }

            [DataMember(Name = "In_video_titleII")]
            public string In_video_titleII { get; set; }

            [DataMember(Name = "In_video_sourceII")]
            public string In_video_sourceII { get; set; }

            [DataMember(Name = "In_video_keywordsII")]
            public string In_video_keywordsII { get; set; }


        }
        public class videofetchContext
        {
            [DataMember(Name = "orgnId")]
            public string orgnId { get; set; }

            [DataMember(Name = "locnId")]
            public string locnId { get; set; }

            [DataMember(Name = "userId")]
            public string userId { get; set; }

            [DataMember(Name = "localeId")]
            public string localeId { get; set; }
            [DataMember(Name = "In_video_gid")]
            public int In_video_gid { get; set; }

            public Videofetch Vfetch { get; set; }

        }
       
        public class videofetchObject
        {
            public videofetchContext context { get; set; }           
        }
        #endregion
    }
}
