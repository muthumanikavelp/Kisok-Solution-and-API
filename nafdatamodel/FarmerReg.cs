using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_FHeader_model;

namespace nafdatamodel
{
    public static class FarmerReg
    {
        public static FarmerSummary TranslateAsFarmerlist(this MySqlDataReader reader2, bool isList = false)
        {
            if (!isList)
            {
                if (!reader2.HasRows)
                    return null;
                reader2.Read();
            }
            var listitem = new FarmerSummary();
           

            if (reader2.IsColumnExists("farmer_rowid"))
                listitem.farmer_rowid = SqlHelper.GetNullableInt32(reader2, "farmer_rowid");

            if (reader2.IsColumnExists("farmer_code"))
                listitem.farmer_code = SqlHelper.GetNullableString(reader2, "farmer_code");

            if (reader2.IsColumnExists("farmer_name"))
                listitem.farmer_name = SqlHelper.GetNullableString(reader2, "farmer_name");

            if (reader2.IsColumnExists("sur_name"))
                listitem.sur_name = SqlHelper.GetNullableString(reader2, "sur_name");

            if (reader2.IsColumnExists("fhw_name"))
                listitem.fhw_name = SqlHelper.GetNullableString(reader2, "fhw_name");


            if (reader2.IsColumnExists("farmer_dob"))
                listitem.farmer_dob = SqlHelper.GetNullableString(reader2, "farmer_dob");
            if (reader2.IsColumnExists("farmer_addr1"))
                listitem.farmer_addr1 = SqlHelper.GetNullableString(reader2, "farmer_addr1");
            if (reader2.IsColumnExists("farmer_country"))
                listitem.farmer_country = SqlHelper.GetNullableString(reader2, "farmer_country");
            if (reader2.IsColumnExists("farmer_country_desc"))
                listitem.farmer_country_desc = SqlHelper.GetNullableString(reader2, "farmer_country_desc");
            if (reader2.IsColumnExists("farmer_state"))
                listitem.farmer_state = SqlHelper.GetNullableString(reader2, "farmer_state");
            if (reader2.IsColumnExists("farmer_state_desc"))
                listitem.farmer_state_desc = SqlHelper.GetNullableString(reader2, "farmer_state_desc");

            if (reader2.IsColumnExists("farmer_dist"))
                listitem.farmer_dist = SqlHelper.GetNullableString(reader2, "farmer_dist");

            if (reader2.IsColumnExists("farmer_dist_desc"))
                listitem.farmer_dist_desc = SqlHelper.GetNullableString(reader2, "farmer_dist_desc");

            if (reader2.IsColumnExists("farmer_taluk"))
                listitem.farmer_taluk = SqlHelper.GetNullableString(reader2, "farmer_taluk");

            if (reader2.IsColumnExists("farmer_taluk_desc"))
                listitem.farmer_taluk_desc = SqlHelper.GetNullableString(reader2, "farmer_taluk_desc");

            if (reader2.IsColumnExists("farmer_panchayat"))
                listitem.farmer_panchayat = SqlHelper.GetNullableString(reader2, "farmer_panchayat");

            if (reader2.IsColumnExists("farmer_panchayat_desc"))
                listitem.farmer_panchayat_desc = SqlHelper.GetNullableString(reader2, "farmer_panchayat_desc");
            if (reader2.IsColumnExists("farmer_village"))
                listitem.farmer_village = SqlHelper.GetNullableString(reader2, "farmer_village");
            if (reader2.IsColumnExists("farmer_village_desc"))
                listitem.farmer_village_desc = SqlHelper.GetNullableString(reader2, "farmer_village_desc");
            if (reader2.IsColumnExists("farmer_mobileno"))
                listitem.Farmer_Mobileno = SqlHelper.GetNullableString(reader2, "farmer_mobileno");
            if (reader2.IsColumnExists("farmer_pincode"))
                listitem.farmer_pincode = SqlHelper.GetNullableString(reader2, "farmer_pincode");
            if (reader2.IsColumnExists("created_date"))
                listitem.Farmer_InsertedDate = SqlHelper.GetNullableString(reader2, "created_date");



            return listitem;
        }
        public static List<FarmerSummary> TransFarmerList(this MySqlDataReader reader)
        {
            var list = new List<FarmerSummary>();
            while (reader.Read())
            {
                list.Add(TranslateAsFarmerlist(reader, true));
            }
            return list;
        }
    }
}
