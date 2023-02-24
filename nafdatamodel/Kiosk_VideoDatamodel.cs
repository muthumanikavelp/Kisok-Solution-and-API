using MySql.Data.MySqlClient;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Kiosk_Video_model;

namespace nafdatamodel
{

    public class Kiosk_VideoDatamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;

        Web_ErrorMessageModel ObjErrormsg = new Web_ErrorMessageModel();

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        public List<VideoCategory> GetVideCatList(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<VideoCategory>>(Mysql,
                "Kiosk_fetch_Category", t => t.TranslateAsVideoCatList(), myParamArray);
        }
        public List<VideoTitle> GetVideTitleList(string org, string locn, string user, string lang, int In_video_gid, string keyword, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_video_gid",In_video_gid),
                 new MySqlParameter("In_keyword",keyword),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<VideoTitle>>(Mysql,
                "Kiosk_Video_CatTitle_List", t => t.TranslateAsVideoTitleList(), myParamArray);
        }
        public List<tranvideoList> GetVideoList(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
             };
            return SqlHelper.ExtecuteProcedureReturnData<List<tranvideoList>>(Mysql,
                "Kiosk_fetch_videoList", t => t.TranslateAsVideoListSum(), myParamArray);
        }

        public string[] NewVideosave_db(SaveVideo model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userId),
                new MySqlParameter("orgnId",model.orgnId),
                new MySqlParameter("locnId",model.locnId),
                new MySqlParameter("localeId",model.localeId),
                new MySqlParameter("In_video_gid",model.In_video_gid),
                new MySqlParameter("In_video_category",model.In_video_category),
                new MySqlParameter("In_video_title",model.In_video_title),
                new MySqlParameter("In_video_filename",model.In_video_filename),
                new MySqlParameter("In_video_filepath",model.In_video_filepath),
                new MySqlParameter("In_video_source",model.In_video_source),
                new MySqlParameter("In_video_keywords",model.In_video_keywords),
                new MySqlParameter("In_video_atttribute",model.In_video_atttribute),
                new MySqlParameter("In_mode_flag",model.In_mode_flag), 
                new MySqlParameter("In_video_titleII",model.In_video_titleII),
                new MySqlParameter("In_video_sourceII",model.In_video_sourceII),
                new MySqlParameter("In_video_keywordsII",model.In_video_keywordsII),

                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "Kiosk_insupd_Video", param);
            return returnvalues;
        }

        public List<attributelist> GetVideoAttributeList_db(string locn, string depend_code, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("In_depend_code",depend_code),
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<attributelist>>(Mysql,
                "kiosk_fetch_attributelist", t => t.TranslateAsVideoAttributeList(), myParamArray);
        }
        public Videofetch GetVideofetch_db(string org, string locn, string user, string lang, int In_video_gid, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("In_video_gid",In_video_gid),

            };
            return SqlHelper.ExtecuteProcedureReturnData<Videofetch>(Mysql,
                "kiosk_fetch_videofetch", t => t.TranslateAsVideofetch(), myParamArray);
        }
    }

}


