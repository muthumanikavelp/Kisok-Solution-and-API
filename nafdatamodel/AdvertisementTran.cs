using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.kiosk_advertisement_model;

namespace nafdatamodel
{
   public static class AdvertisementTran
    {
        public static List<advertisementlist> TranslateAsadvertisementList(this MySqlDataReader reader)
        {
            var list = new List<advertisementlist>();
            while (reader.Read())
            {
                list.Add(TranslateAsadvertisement(reader, true));
            }
            return list;
        }
        public static advertisementlist TranslateAsadvertisement(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new advertisementlist();
            if (reader.IsColumnExists("adver_gid"))
                item.adver_gid = SqlHelper.GetNullableInt32(reader, "adver_gid");
            if (reader.IsColumnExists("tranid"))
                item.tranid = SqlHelper.GetNullableString(reader, "tranid");
            if (reader.IsColumnExists("flashscreenref"))
                item.flashscreenref = SqlHelper.GetNullableString(reader, "flashscreenref");            
            if (reader.IsColumnExists("ad_name"))
                item.ad_name = SqlHelper.GetNullableString(reader, "ad_name");
            if (reader.IsColumnExists("ad_state"))
                item.ad_state = SqlHelper.GetNullableString(reader, "ad_state");
            if (reader.IsColumnExists("ad_stategid"))
                item.ad_stategid = SqlHelper.GetNullableInt32(reader, "ad_stategid");
            if (reader.IsColumnExists("display_order"))
                item.display_order = SqlHelper.GetNullableString(reader, "display_order");
            if (reader.IsColumnExists("ad_path_url"))
                item.ad_path_url = SqlHelper.GetNullableString(reader, "ad_path_url");
            return item;
        }

        public static Advertisementfetch TranslateAsadvertisementListFetch(this MySqlDataReader reader)
        {
            var list = new Advertisementfetch();
            while (reader.Read())
            {
                list = TranslateAsadvertisementFetch(reader, true);
            }
            return list;
        }
        public static Advertisementfetch TranslateAsadvertisementFetch(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Advertisementfetch();
            if (reader.IsColumnExists("adver_gid"))
                item.adver_gid = SqlHelper.GetNullableInt32(reader, "adver_gid");
            if (reader.IsColumnExists("ad_name"))
                item.ad_name = SqlHelper.GetNullableString(reader, "ad_name");
            if (reader.IsColumnExists("tranid"))
                item.tranid = SqlHelper.GetNullableString(reader, "tranid");
            if (reader.IsColumnExists("ad_date"))
                item.ad_date = SqlHelper.GetNullableString(reader, "ad_date");
            if (reader.IsColumnExists("ad_state"))
                item.ad_state = SqlHelper.GetNullableString(reader, "ad_state");
            if (reader.IsColumnExists("ad_stategid"))
                item.ad_stategid = SqlHelper.GetNullableInt32(reader, "ad_stategid");
            if (reader.IsColumnExists("ad_flashscreen"))
                item.ad_flashscreen = SqlHelper.GetNullableString(reader, "ad_flashscreen");
            if (reader.IsColumnExists("display_order"))
                item.display_order = SqlHelper.GetNullableString(reader, "display_order");
            if (reader.IsColumnExists("ad_status"))
                item.ad_status = SqlHelper.GetNullableString(reader, "ad_status");
            if (reader.IsColumnExists("ad_path_url"))
                item.ad_path_url = SqlHelper.GetNullableString(reader, "ad_path_url");
            if (reader.IsColumnExists("ad_notes"))
                item.ad_notes = SqlHelper.GetNullableString(reader, "ad_notes");
            if (reader.IsColumnExists("In_mode_flag"))
                item.In_mode_flag = SqlHelper.GetNullableString(reader, "In_mode_flag");
            return item;
        }


    }


}
