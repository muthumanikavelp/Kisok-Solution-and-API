using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk_web.Models
{
    public class tranningvideosmodel
    {
        #region list
        public class trancontext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public string userId { get; set; }
            public List<tranvideoList> List { get; set; }
        }
        public class tranvideoList
        {
            public int video_gid { get; set; }
            public string videodate { get; set; }
            public string title { get; set; }
            public string category { get; set; }
            public string filename { get; set; }
        }
        #endregion
        #region attribute
        public class attribute 
        {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string localeId { get; set; }
        public string userId { get; set; }
        public string depend_code { get; set; }       
    }
        public class attributecontext
        {         
            public string depend_code { get; set; }            
            public string locn { get; set; }
            public List<attributelist> list { get; set; }
        }       
        public class attributelist
    {        
        public string master_code { get; set; }      
        public string master_name { get; set; }
    }
        #endregion

        #region Save model       
        public class SaveVideo
        {           
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_video_gid { get; set; }
            public string In_video_category { get; set; }
            public string In_video_title { get; set; }
            public string In_video_filename { get; set; }
            public string In_video_filepath { get; set; }
            public string In_video_source { get; set; }
            public string In_video_keywords { get; set; }
            public string In_video_atttribute { get; set; }
            public string In_mode_flag { get; set; } 
            public string In_video_titleII { get; set; } 
            public string In_video_sourceII { get; set; } 
            public string In_video_keywordsII { get; set; }

        }

        #endregion
        #region delete model       
        public class videodelete
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_video_gid { get; set; }           
            public string In_mode_flag { get; set; }
        }

        #endregion

        #region video fetch
        #region fetch video model       
        public class Videofetch
        {
            public int In_video_gid { get; set; }
            public string In_video_filename { get; set; }
            public string In_mode_flag { get; set; }
            public string In_video_category { get; set; }
            public string In_video_title { get; set; }
            public string In_video_source { get; set; }
            public string In_video_keywords { get; set; }
            public string In_video_atttribute { get; set; }
            public string In_video_filepath { get; set; }
            public string In_video_titleII { get; set; }
            public string In_video_sourceII { get; set; }
            public string In_video_keywordsII { get; set; }
        }
        public class videofetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_video_gid { get; set; }
            public Videofetch Vfetch { get; set; }
        }

        public class videofetchObject
        {
            public videofetchContext context { get; set; }
        }
        #endregion

        #endregion
    }
}
