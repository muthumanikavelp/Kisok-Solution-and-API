using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Mobile_FDR_LandModel;

namespace nafdatamodel
{
  public static  class LandTransFarmer
    {
        public static FarmerLandfecth TranslateAsFarmerLand(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new FarmerLandfecth();
            if (reader.IsColumnExists("out_farmer_gid"))
                item.out_farmer_gid = SqlHelper.GetNullableInt32(reader, "out_farmer_gid");
            if (reader.IsColumnExists("out_land_gid"))
                item.out_land_gid = SqlHelper.GetNullableInt32(reader, "out_land_gid");            
            if (reader.IsColumnExists("out_farmer_code"))
                item.out_farmer_code = SqlHelper.GetNullableString(reader, "out_farmer_code");
            if (reader.IsColumnExists("out_farmer_name"))
                item.out_farmer_name = SqlHelper.GetNullableString(reader, "out_farmer_name");
            if (reader.IsColumnExists("out_land_type"))
                item.out_land_type = SqlHelper.GetNullableString(reader, "out_land_type");
            if (reader.IsColumnExists("out_land_type_desc"))
                item.out_land_type_desc = SqlHelper.GetNullableString(reader, "out_land_type_desc");
            if (reader.IsColumnExists("out_land_ownership"))
                item.out_land_ownership = SqlHelper.GetNullableString(reader, "out_land_ownership");
            if (reader.IsColumnExists("out_land_ownership_desc"))
                item.out_land_ownership_desc = SqlHelper.GetNullableString(reader, "out_land_ownership_desc");
            if (reader.IsColumnExists("out_land_soiltype"))
                item.out_land_soiltype = SqlHelper.GetNullableString(reader, "out_land_soiltype");
            if (reader.IsColumnExists("out_land_soiltype_desc"))
                item.out_land_soiltype_desc = SqlHelper.GetNullableString(reader, "out_land_soiltype_desc");
            if (reader.IsColumnExists("out_land_irrsou"))
                item.out_land_irrsou = SqlHelper.GetNullableString(reader, "out_land_irrsou");
            if (reader.IsColumnExists("out_land_irrsou_desc"))
                item.out_land_irrsou_desc = SqlHelper.GetNullableString(reader, "out_land_irrsou_desc");
            if (reader.IsColumnExists("out_land_noofacres"))
                item.out_land_noofacres = SqlHelper.GetNullableString(reader, "out_land_noofacres");
            if (reader.IsColumnExists("out_land_longtitude"))
                item.out_land_longtitude = SqlHelper.GetNullableString(reader, "out_land_longtitude");
            if (reader.IsColumnExists("land_surveyno"))
                item.In_land_surveyno = SqlHelper.GetNullableString(reader, "land_surveyno");
            if (reader.IsColumnExists("out_land_latitude"))
                item.out_land_latitude = SqlHelper.GetNullableString(reader, "out_land_latitude");
        
            return item;
        }
        public static List<FarmerLandfecth> TranslateAsFarmerLandList(this MySqlDataReader reader)
        {
            var list = new List<FarmerLandfecth>();
            while (reader.Read())
            {
                list.Add(TranslateAsFarmerLand(reader, true));
            }
            return list;
        }

    }
}
