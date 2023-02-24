using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_login_model;

namespace nafdatamodel
{
    public static class KioskloginTrans
    {
        public static kioskLoginContext TranslateAsUser(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new kioskLoginContext();
            if (reader.IsColumnExists("farmer_gid"))
                item.farmer_gid = SqlHelper.GetNullableInt32(reader, "farmer_gid");
            if (reader.IsColumnExists("farmer_code"))
                item.farmer_code = SqlHelper.GetNullableString(reader, "farmer_code");
            if (reader.IsColumnExists("farmer_name"))
                item.farmer_name = SqlHelper.GetNullableString(reader, "farmer_name");
            if (reader.IsColumnExists("village_code"))
                item.village_code = SqlHelper.GetNullableString(reader, "village_code");
            if (reader.IsColumnExists("farmer_village"))
                item.farmer_village = SqlHelper.GetNullableString(reader, "farmer_village");
            if (reader.IsColumnExists("panchayat_code"))
                item.panchayat_code = SqlHelper.GetNullableString(reader, "panchayat_code");
            if (reader.IsColumnExists("farmer_panchayat"))
                item.farmer_panchayat = SqlHelper.GetNullableString(reader, "farmer_panchayat");
            if (reader.IsColumnExists("taluk_code"))
                item.taluk_code = SqlHelper.GetNullableString(reader, "taluk_code");
            if (reader.IsColumnExists("farmer_taluk"))
                item.farmer_taluk = SqlHelper.GetNullableString(reader, "farmer_taluk");
            if (reader.IsColumnExists("dist_code"))
                item.dist_code = SqlHelper.GetNullableString(reader, "dist_code");
            if (reader.IsColumnExists("farmer_dist"))
                item.farmer_dist = SqlHelper.GetNullableString(reader, "farmer_dist");
            if (reader.IsColumnExists("state_code"))
                item.state_code = SqlHelper.GetNullableString(reader, "state_code");
            if (reader.IsColumnExists("farmer_state"))
                item.farmer_state = SqlHelper.GetNullableString(reader, "farmer_state");
            if (reader.IsColumnExists("In_Reponse"))
                item.In_Reponse = SqlHelper.GetNullableString(reader, "In_Reponse");
            if (reader.IsColumnExists("instance"))
                item.instance = SqlHelper.GetNullableString(reader, "instance");
            if (reader.IsColumnExists("Mobile_no"))
                item.Mobile_no = SqlHelper.GetNullableString(reader, "Mobile_no");
            if (reader.IsColumnExists("password_reset"))
                item.Password_reset = SqlHelper.GetNullableString(reader, "password_reset");
            if (reader.IsColumnExists("village_id"))
                item.Kamaraj_village_id = SqlHelper.GetNullableString(reader, "village_id");
            if (reader.IsColumnExists("district_id"))
                item.Kamaraj_district_id = SqlHelper.GetNullableString(reader, "district_id"); 
            if (reader.IsColumnExists("farmer_villageII"))
                item.farmer_villageII = SqlHelper.GetNullableString(reader, "farmer_villageII"); 
            if (reader.IsColumnExists("farmer_panchayatII"))
                item.farmer_panchayatII = SqlHelper.GetNullableString(reader, "farmer_panchayatII"); 
            if (reader.IsColumnExists("farmer_talukII"))
                item.farmer_talukII = SqlHelper.GetNullableString(reader, "farmer_talukII"); 
            if (reader.IsColumnExists("farmer_distII"))
                item.farmer_distII = SqlHelper.GetNullableString(reader, "farmer_distII"); 
            if (reader.IsColumnExists("farmer_stateII"))
                item.farmer_stateII = SqlHelper.GetNullableString(reader, "farmer_stateII");  

            return item;
        }
       
        public static kioskLoginContext kioskloginList(this MySqlDataReader reader)
        {
            var list = new kioskLoginContext();
            while (reader.Read())
            {
                list = TranslateAsUser(reader, true);
            }
            return list;
        }
        
    }
}

 
