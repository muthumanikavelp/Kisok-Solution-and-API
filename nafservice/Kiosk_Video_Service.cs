using nafdatamodel;
using System;
using System.Collections.Generic;
using System.Text;
using nafmodel;
using static nafmodel.Kiosk_Video_model;

namespace nafservice
{
  public  class Kiosk_Video_Service
    {
        Kiosk_VideoDatamodel objdatamodel = new Kiosk_VideoDatamodel();
        public videocatContext GetVideCatList(string org, string locn, string user, string lang, string Mysql)
        {
            videocatContext objfinal = new videocatContext();
          
            List<VideoCategory> ObjFetchAll = new List<VideoCategory>();
            try
            {
                ObjFetchAll = objdatamodel.GetVideCatList(org, locn, user, lang, Mysql);
               
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.category = ObjFetchAll;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public videoTitleContext GetVideTitleList(string org, string locn, string user, string lang,int In_video_gid, string keyword, string Mysql)
        {
            videoTitleContext objfinal = new videoTitleContext();

            List<VideoTitle> ObjFetchAll = new List<VideoTitle>();
            try
            {
                ObjFetchAll = objdatamodel.GetVideTitleList(org, locn, user, lang, In_video_gid, keyword, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_video_gid = In_video_gid;
                objfinal.Title = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public trancontext GetVideoList(string org, string locn, string user, string lang, string Mysql)
        {
            trancontext objfinal = new trancontext();

            List<tranvideoList> ObjFetchAll = new List<tranvideoList>();
            try
            {
                ObjFetchAll = objdatamodel.GetVideoList(org, locn, user, lang, Mysql);

                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.List = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }

        public string[] NewVideosave_Srv(SaveVideo ObjModel, string Mysql)
        {
            string[] respo = { };
            try
            {
                respo = objdatamodel.NewVideosave_db(ObjModel, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respo;
        }
        public attributecontext GetVideoAttributeList_srv(string locn, string depend_code, string Mysql)
        {
            attributecontext objfinal = new attributecontext();

            List<attributelist> ObjFetchAll = new List<attributelist>();
            try
            {
                ObjFetchAll = objdatamodel.GetVideoAttributeList_db(locn, depend_code, Mysql);
                                
                objfinal.list = ObjFetchAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
        public videofetchContext GetVideofetch_srv(string org, string locn, string user, string lang, int In_video_gid, string Mysql)
        {
            videofetchContext objfinal = new videofetchContext();

            Videofetch ObjFetchAll = new Videofetch();
            try
            {
                ObjFetchAll = objdatamodel.GetVideofetch_db(org, locn, user, lang, In_video_gid, Mysql);
                objfinal.orgnId = org;
                objfinal.userId = user;
                objfinal.locnId = locn;
                objfinal.localeId = lang;
                objfinal.In_video_gid = In_video_gid;
                objfinal.Vfetch = ObjFetchAll;
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

            return objfinal;
        }
    }
}
