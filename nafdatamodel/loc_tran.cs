using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_localization_model;

namespace nafdatamodel
{
   public static class loc_tran
    {
        public static localizationlist Translatelocalizationlist(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new localizationlist();
            if (reader.IsColumnExists("activity"))
                item.activity = SqlHelper.GetNullableString(reader, "activity");
            if (reader.IsColumnExists("loc_english"))
                item.loc_english = SqlHelper.GetNullableString(reader, "loc_english");
            if (reader.IsColumnExists("loc_tamil"))
                item.loc_tamil = SqlHelper.GetNullableString(reader, "loc_tamil");
            return item;
        }
        public static List<localizationlist> TranslateAslocalizationlist(this MySqlDataReader reader)
        {
            var list = new List<localizationlist>();
            while (reader.Read())
            {
                list.Add(Translatelocalizationlist(reader, true));
            }
            return list;
        }

    }
}
