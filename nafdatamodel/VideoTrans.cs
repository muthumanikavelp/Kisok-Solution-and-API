using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_Video_model;

namespace nafdatamodel
{
    public static class VideoTrans
    {
        public static VideoCategory TranslateAsCategory(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new VideoCategory();
            if (reader.IsColumnExists("out_categoryId"))
                item.out_categoryId = SqlHelper.GetNullableString(reader, "out_categoryId");
            if (reader.IsColumnExists("out_category"))
                item.out_category = SqlHelper.GetNullableString(reader, "out_category");
            return item;
        }
        public static List<VideoCategory> TranslateAsVideoCatList(this MySqlDataReader reader)
        {
            var list = new List<VideoCategory>();
            while (reader.Read())
            {
                list.Add(TranslateAsCategory(reader, true));
            }
            return list;
        }
        public static VideoTitle TranslateAsTitle(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new VideoTitle();
            if (reader.IsColumnExists("out_title"))
                item.out_title = SqlHelper.GetNullableString(reader, "out_title");
            if (reader.IsColumnExists("out_file_Name"))
                item.out_file_Name = SqlHelper.GetNullableString(reader, "out_file_Name");

            if (reader.IsColumnExists("video_category"))
                item.video_category = SqlHelper.GetNullableString(reader, "video_category");
            if (reader.IsColumnExists("video_filename"))
                item.video_filename = SqlHelper.GetNullableString(reader, "video_filename");
            if (reader.IsColumnExists("out_titleII"))
                item.out_titleII = SqlHelper.GetNullableString(reader, "out_titleII");

            return item;
        }
        public static List<VideoTitle> TranslateAsVideoTitleList(this MySqlDataReader reader)
        {
            var list = new List<VideoTitle>();
            while (reader.Read())
            {
                list.Add(TranslateAsTitle(reader, true));
            }
            return list;
        }

        public static tranvideoList TranslateVideoList(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new tranvideoList();
            if (reader.IsColumnExists("out_date"))
                item.video_gid = SqlHelper.GetNullableInt32(reader, "out_video_gid");
            if (reader.IsColumnExists("out_date"))
                item.videodate = SqlHelper.GetNullableString(reader, "out_date");
            if (reader.IsColumnExists("out_Videocategory"))
                item.category = SqlHelper.GetNullableString(reader, "out_Videocategory");
            if (reader.IsColumnExists("out_Videotitle"))
                item.title = SqlHelper.GetNullableString(reader, "out_Videotitle");
            if (reader.IsColumnExists("out_Videofilename"))
                item.filename = SqlHelper.GetNullableString(reader, "out_Videofilename");
            return item;
        }
        public static List<tranvideoList> TranslateAsVideoListSum(this MySqlDataReader reader)
        {
            var list = new List<tranvideoList>();
            while (reader.Read())
            {
                list.Add(TranslateVideoList(reader, true));
            }
            return list;
        }
        public static List<attributelist> TranslateAsVideoAttributeList(this MySqlDataReader reader)
        {
            var list = new List<attributelist>();
            while (reader.Read())
            {
                list.Add(TranslateVideoAttributeList(reader, true));
            }
            return list;
        }
        public static attributelist TranslateVideoAttributeList(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new attributelist();           
            if (reader.IsColumnExists("master_code"))
                item.master_code = SqlHelper.GetNullableString(reader, "master_code");
            if (reader.IsColumnExists("master_name"))
                item.master_name = SqlHelper.GetNullableString(reader, "master_name");            
            return item;
        }

        public static Videofetch TranslateAsvideo(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Videofetch();
            if (reader.IsColumnExists("In_video_gid"))
                item.In_video_gid = SqlHelper.GetNullableInt32(reader, "In_video_gid");
            if (reader.IsColumnExists("In_video_filename"))
                item.In_video_filename = SqlHelper.GetNullableString(reader, "In_video_filename");
            if (reader.IsColumnExists("In_video_filepath"))
                item.In_video_filepath = SqlHelper.GetNullableString(reader, "In_video_filepath");
            if (reader.IsColumnExists("In_mode_flag"))
                item.In_mode_flag = SqlHelper.GetNullableString(reader, "In_mode_flag");
            if (reader.IsColumnExists("In_video_category"))
                item.In_video_category = SqlHelper.GetNullableString(reader, "In_video_category");
            if (reader.IsColumnExists("In_video_title"))
                item.In_video_title = SqlHelper.GetNullableString(reader, "In_video_title");
            if (reader.IsColumnExists("In_video_source"))
                item.In_video_source = SqlHelper.GetNullableString(reader, "In_video_source");
            if (reader.IsColumnExists("In_video_keywords"))
                item.In_video_keywords = SqlHelper.GetNullableString(reader, "In_video_keywords");
            if (reader.IsColumnExists("In_video_atttribute"))
                item.In_video_atttribute = SqlHelper.GetNullableString(reader, "In_video_atttribute");

            if (reader.IsColumnExists("In_video_titleII"))
                item.In_video_titleII = SqlHelper.GetNullableString(reader, "In_video_titleII");
            if (reader.IsColumnExists("In_video_sourceII"))
                item.In_video_sourceII = SqlHelper.GetNullableString(reader, "In_video_sourceII");
            if (reader.IsColumnExists("In_video_keywordsII"))
                item.In_video_keywordsII = SqlHelper.GetNullableString(reader, "In_video_keywordsII"); 

            return item;
        }
        public static Videofetch TranslateAsVideofetch(this MySqlDataReader reader)
        {
            var list = new Videofetch();
            while (reader.Read())
            {
                list=TranslateAsvideo(reader, true);
            }
            return list;
        }
    }
}
