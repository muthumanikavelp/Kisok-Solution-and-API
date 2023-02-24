using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_uploadsign_model;

namespace nafdatamodel
{
   public static class UploadSignTran
    {
        public static List<uploadsignlist> TranslateUploadsignList(this MySqlDataReader reader)
        {
            var list = new List<uploadsignlist>();
            while (reader.Read())
            {
                list.Add(TranslateUploadsign(reader, true));
            }
            return list;
        }
        public static uploadsignlist TranslateUploadsign(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new uploadsignlist();
            if (reader.IsColumnExists("signature_rowid"))
                item.signature_rowid = SqlHelper.GetNullableInt32(reader, "signature_rowid");
            if (reader.IsColumnExists("signature_tran_id"))
                item.signature_tran_id = SqlHelper.GetNullableString(reader, "signature_tran_id");
            if (reader.IsColumnExists("signature_name"))
                item.signature_name = SqlHelper.GetNullableString(reader, "signature_name");
            if (reader.IsColumnExists("signature_desgn"))
                item.signature_desgn = SqlHelper.GetNullableString(reader, "signature_desgn"); 
            if (reader.IsColumnExists("signature_image"))
                item.signature_image = SqlHelper.GetNullableString(reader, "signature_image");
           
            return item;
        }

        public static uploadsignfetch TranslateUploadsignFetch(this MySqlDataReader reader)
        {
            var list = new uploadsignfetch();
            while (reader.Read())
            {
                list = TranslateUploadsignFetch(reader, true);
            }
            return list;
        }
        public static uploadsignfetch TranslateUploadsignFetch(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new uploadsignfetch();
            if (reader.IsColumnExists("signature_rowid"))
                item.signature_rowid = SqlHelper.GetNullableInt32(reader, "signature_rowid");
            if (reader.IsColumnExists("signature_tran_id"))
                item.signature_tran_id = SqlHelper.GetNullableString(reader, "signature_tran_id");
            if (reader.IsColumnExists("signature_name"))
                item.signature_name = SqlHelper.GetNullableString(reader, "signature_name");
            if (reader.IsColumnExists("signature_desgn"))
                item.signature_desgn = SqlHelper.GetNullableString(reader, "signature_desgn");
            if (reader.IsColumnExists("signature_image"))
                item.signature_image = SqlHelper.GetNullableString(reader, "signature_image");
           
            return item;
        }

    }
}
