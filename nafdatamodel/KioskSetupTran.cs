using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using static nafmodel.Kisok_attach_model;
using static nafmodel.Web_KioskSetupModel;
namespace nafdatamodel
{
   public static class KioskSetupTran
    {

        public static SaveKioskheader TranslateAsUser(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new SaveKioskheader();
            if (reader.IsColumnExists("kiosk_gid"))
                item.In_Kiosk_gid = SqlHelper.GetNullableInt32(reader, "kiosk_gid");

            if (reader.IsColumnExists("kiosk_code"))
                item.in_Kiosk_code = SqlHelper.GetNullableString(reader, "kiosk_code");

            if (reader.IsColumnExists("kiosk_name"))
                item.in_Kiosk_name = SqlHelper.GetNullableString(reader, "kiosk_name");

            if (reader.IsColumnExists("kiosk_status"))
                item.in_status_name = SqlHelper.GetNullableString(reader, "kiosk_status");

            if (reader.IsColumnExists("kiosk_fpo"))
                item.in_fpo_name = SqlHelper.GetNullableString(reader, "kiosk_fpo");

            if (reader.IsColumnExists("Bilingual"))
                item.in_Bilingual_code = SqlHelper.GetNullableString(reader, "Bilingual");

            if (reader.IsColumnExists("kisok_address"))
                item.in_Address = SqlHelper.GetNullableString(reader, "kisok_address");

            if (reader.IsColumnExists("kiosk_pincode"))
                item.in_Pincode = SqlHelper.GetNullableString(reader, "kiosk_pincode");

            if (reader.IsColumnExists("Village"))
                item.in_Village = SqlHelper.GetNullableString(reader, "Village");

            if (reader.IsColumnExists("Taluk"))
                item.in_Taluk = SqlHelper.GetNullableString(reader, "Taluk");

            if (reader.IsColumnExists("District"))
                item.in_District = SqlHelper.GetNullableString(reader, "District");

            if (reader.IsColumnExists("State"))
                item.in_State = SqlHelper.GetNullableString(reader, "State");

            if (reader.IsColumnExists("kiosk_notes"))
                item.In_Kiosk_Notes = SqlHelper.GetNullableString(reader, "kiosk_notes");

            

            //if (reader.IsColumnExists("In_mode_flag"))
            //    item.In_mode_flag = SqlHelper.GetNullableString(reader, "S");



            return item;
        }
        public static SaveRMDetail TranslateAsUserdetail(this MySqlDataReader reader1, bool isList = false)
        {
            if (!isList)
            {
                if (!reader1.HasRows)
                    return null;
                reader1.Read();
            }
            var detailitem = new SaveRMDetail();
            if (reader1.IsColumnExists("contact_gid"))
                detailitem.Kiosk_Contactgid = SqlHelper.GetNullableInt32(reader1, "contact_gid");

            if (reader1.IsColumnExists("kiosk_gid"))
                detailitem.Kiosk_id = SqlHelper.GetNullableInt32(reader1, "kiosk_gid");

            if (reader1.IsColumnExists("contact_name"))
                detailitem.in_Name = SqlHelper.GetNullableString(reader1, "contact_name");

            if (reader1.IsColumnExists("contact_designation"))
                detailitem.in_Designation = SqlHelper.GetNullableString(reader1, "contact_designation");

            if (reader1.IsColumnExists("contact_mobile"))
                detailitem.in_Mobile = SqlHelper.GetNullableString(reader1, "contact_mobile");

            if (reader1.IsColumnExists("contact_landline"))
                detailitem.in_Landline = SqlHelper.GetNullableString(reader1, "contact_landline");

            if (reader1.IsColumnExists("contact_email"))
                detailitem.in_eMail = SqlHelper.GetNullableString(reader1, "contact_email");

            return detailitem;
        }

        

        public static SaveKioskheader TranslateAsKioskList(this MySqlDataReader reader)
        {
            var list = new SaveKioskheader();
            while (reader.Read())
            {
                list = TranslateAsUser(reader, true);
            }
            return list;
        }
        public static List<SaveRMDetail> TranslateAskioskdet(this MySqlDataReader reader1)
        {
            var list1 = new List<SaveRMDetail>();
            while (reader1.Read())
            {
                list1.Add(TranslateAsUserdetail(reader1, true));
            }
            return list1;
        }
        


       
    }
}
