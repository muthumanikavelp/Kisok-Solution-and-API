using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_Scheme_model;

namespace nafdatamodel
{
    public static class SchemeTrans
    {
        public static schemeCategory TranslateAsFaqsCat(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new schemeCategory();
            if (reader.IsColumnExists("out_schemecategory_Id"))
                item.out_schemecategory_Id = SqlHelper.GetNullableString(reader, "out_schemecategory_Id");
            if (reader.IsColumnExists("out_schemecategory"))
                item.out_schemecategory = SqlHelper.GetNullableString(reader, "out_schemecategory");
            return item;
        }
        public static List<schemeCategory> TranslateAsschemeCatList(this MySqlDataReader reader)
        {
            var list = new List<schemeCategory>();
            while (reader.Read())
            {
               list.Add(TranslateAsFaqsCat(reader, true));
               // list.Add(Translateschemedatades(reader, true));
                
            }
            return list;
        }
        public static schemelist TranslateAsscheme(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new schemelist();
            if (reader.IsColumnExists("out_schemecategory_Id"))
                item.out_schemecategory_Id = SqlHelper.GetNullableString(reader, "out_schemecategory_Id");
            if (reader.IsColumnExists("out_scheme_name"))
                item.out_scheme_name = SqlHelper.GetNullableString(reader, "out_scheme_name");
            return item;
        }
        public static List<schemelist> TranslateAschemelist(this MySqlDataReader reader)
        {
            var list = new List<schemelist>();
            while (reader.Read())
            {
                list.Add(TranslateAsscheme(reader, true));
            }
            return list;
        }
        public static schemedata Translateschemedatades(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new schemedata();
            if (reader.IsColumnExists("out_scheme_name"))
                item.out_scheme_name = SqlHelper.GetNullableString(reader, "out_scheme_name");
            if (reader.IsColumnExists("out_scheme_description"))
                item.out_scheme_description = SqlHelper.GetNullableString(reader, "out_scheme_description");
            if (reader.IsColumnExists("scheme_url"))
                item.scheme_url = SqlHelper.GetNullableString(reader, "scheme_url");
            if (reader.IsColumnExists("upload_path"))
                item.upload_path = SqlHelper.GetNullableString(reader, "upload_path");

             
            return item;
        }
        public static schemedata Translateschemedata(this MySqlDataReader reader)
        {
            var list = new schemedata();
            while (reader.Read())
            {
                list = Translateschemedatades(reader, true);
            }
            return list;
        }
        public static SchemesSummary TranslateAsschemeSummary(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new SchemesSummary();
            if (reader.IsColumnExists("scheme_id"))
                item.scheme_id = SqlHelper.GetNullableInt32(reader, "scheme_id");
            if (reader.IsColumnExists("out_scheme_date"))
                item.out_scheme_date = SqlHelper.GetNullableString(reader, "out_scheme_date");
            if (reader.IsColumnExists("out_scheme_category"))
                item.out_scheme_category = SqlHelper.GetNullableString(reader, "out_scheme_category");
            if (reader.IsColumnExists("out_scheme_schname"))
                item.out_scheme_schname = SqlHelper.GetNullableString(reader, "out_scheme_schname");
            if (reader.IsColumnExists("out_scheme_description"))
                item.out_scheme_description = SqlHelper.GetNullableString(reader, "out_scheme_description");
            if (reader.IsColumnExists("out_scheme_keyword"))
                item.out_scheme_keyword = SqlHelper.GetNullableString(reader, "out_scheme_keyword");
            if (reader.IsColumnExists("out_scheme_url"))
                item.out_scheme_url = SqlHelper.GetNullableString(reader, "out_scheme_url");
            if (reader.IsColumnExists("out_scheme_upload"))
                item.out_scheme_upload = SqlHelper.GetNullableString(reader, "out_scheme_upload");
            return item;
        }
        public static List<SchemesSummary> TranslateAschemeSummaryView(this MySqlDataReader reader)
        {
            var list = new List<SchemesSummary>();
            while (reader.Read())
            {
                list.Add(TranslateAsschemeSummary(reader, true));
            }
            return list;
        }
        public static schemeGetdata TranslateschemedataFetch(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new schemeGetdata();
            
                  if (reader.IsColumnExists("out_scheme_id"))
                item.out_scheme_id = SqlHelper.GetNullableInt32(reader, "out_scheme_id");
            if (reader.IsColumnExists("out_scheme_category"))
                item.out_scheme_category = SqlHelper.GetNullableString(reader, "out_scheme_category");
            if (reader.IsColumnExists("out_scheme_date"))
             item.out_scheme_date = SqlHelper.GetNullableString(reader, "out_scheme_date");
            if (reader.IsColumnExists("out_scheme_state"))
                item.out_scheme_state = SqlHelper.GetNullableString(reader, "out_scheme_state");         
            if (reader.IsColumnExists("out_scheme_name"))
                item.out_scheme_name = SqlHelper.GetNullableString(reader, "out_scheme_name");
            if (reader.IsColumnExists("out_scheme_description"))
                item.out_scheme_description = SqlHelper.GetNullableString(reader, "out_scheme_description");
            if (reader.IsColumnExists("out_scheme_keyword"))
                item.out_scheme_keyword = SqlHelper.GetNullableString(reader, "out_scheme_keyword");
            if (reader.IsColumnExists("out_scheme_schname_locallang"))
                item.out_scheme_schname_locallang = SqlHelper.GetNullableString(reader, "out_scheme_schname_locallang");
            if (reader.IsColumnExists("out_schema_des_locallang"))
                item.out_schema_des_locallang = SqlHelper.GetNullableString(reader, "out_schema_des_locallang");
            if (reader.IsColumnExists("out_scheme_keyword_locallang"))
                item.out_scheme_keyword_locallang = SqlHelper.GetNullableString(reader, "out_scheme_keyword_locallang");
            if (reader.IsColumnExists("out_scheme_url"))
                item.out_scheme_url = SqlHelper.GetNullableString(reader, "out_scheme_url");
            if (reader.IsColumnExists("out_scheme_upload"))
                item.out_scheme_upload = SqlHelper.GetNullableString(reader, "out_scheme_upload");

            return item;
        }
        public static schemeGetdata TranslateschemeGetdata(this MySqlDataReader reader)
        {
            var list = new schemeGetdata();
            while (reader.Read())
            {
                list=TranslateschemedataFetch(reader, true);
            }
            return list;
        }


    }
}
