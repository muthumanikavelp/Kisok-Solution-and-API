using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static nafmodel.Kiosk_Soil_Card_model;
using static nafmodel.Kisok_attach_model;

namespace nafdatamodel
{
    public static class SoilcardTrans
    {
        public static soilviewHeader TranslateAsUser(this MySqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new soilviewHeader();
            
            if (reader.IsColumnExists("out_farmer_gid"))
                item.out_farmer_gid = SqlHelper.GetNullableInt32(reader, "out_farmer_gid");

            if (reader.IsColumnExists("out_soil_gid"))
                item.out_soil_gid = SqlHelper.GetNullableInt32(reader, "out_soil_gid");

            if (reader.IsColumnExists("out_farmer_code"))
                item.out_farmer_code = SqlHelper.GetNullableString(reader, "out_farmer_code");

            if (reader.IsColumnExists("out_farmer_name"))
                item.out_farmer_name = SqlHelper.GetNullableString(reader, "out_farmer_name");

            if (reader.IsColumnExists("out_Tran_Id"))
                item.out_Tran_Id = SqlHelper.GetNullableString(reader, "out_Tran_Id");

            if (reader.IsColumnExists("out_collection_date"))
                item.out_collection_date = SqlHelper.GetNullableString(reader, "out_collection_date");

            if (reader.IsColumnExists("out_sample_status"))
                item.out_sample_status = SqlHelper.GetNullableString(reader, "out_sample_status");

            if (reader.IsColumnExists("out_reject_reason"))
                item.out_reject_reason = SqlHelper.GetNullableString(reader, "out_reject_reason");

            if (reader.IsColumnExists("out_sample_Id"))
                item.out_sample_Id = SqlHelper.GetNullableString(reader, "out_sample_Id");

            if (reader.IsColumnExists("out_sample_drawnby"))
                item.out_sample_drawnby = SqlHelper.GetNullableString(reader, "out_sample_drawnby");

            if (reader.IsColumnExists("out_customer_ref"))
                item.out_customer_ref = SqlHelper.GetNullableString(reader, "out_customer_ref");

            if (reader.IsColumnExists("out_Lab_reportno"))
                item.out_Lab_reportno = SqlHelper.GetNullableString(reader, "out_Lab_reportno");

            if (reader.IsColumnExists("out_Lab_Id"))
                item.out_Lab_Id = SqlHelper.GetNullableString(reader, "out_Lab_Id");

            if (reader.IsColumnExists("out_customer_ref"))
                item.out_customer_ref = SqlHelper.GetNullableString(reader, "out_customer_ref");

            if (reader.IsColumnExists("out_Analysis_starton"))
                item.out_Analysis_starton = SqlHelper.GetNullableString(reader, "out_Analysis_starton");

            if (reader.IsColumnExists("out_sample_receiveon"))
                item.out_sample_receiveon = SqlHelper.GetNullableString(reader, "out_sample_receiveon");

            if (reader.IsColumnExists("out_Analysis_completeon"))
                item.out_Analysis_completeon = SqlHelper.GetNullableString(reader, "out_Analysis_completeon");

            if (reader.IsColumnExists("out_test_method"))
                item.out_test_method = SqlHelper.GetNullableString(reader, "out_test_method");

            if (reader.IsColumnExists("out_crop_recommendation"))
                item.out_crop_recommendation = SqlHelper.GetNullableString(reader, "out_crop_recommendation");

            if (reader.IsColumnExists("out_soil_status"))
                item.out_soil_status = SqlHelper.GetNullableString(reader, "out_soil_status");
            if (reader.IsColumnExists("out_soil_notes"))
                item.out_soil_notes = SqlHelper.GetNullableString(reader, "out_soil_notes"); 

                item.In_mode_flag = "S";

            if (reader.IsColumnExists("out_crop_confirm"))
                item.out_crop_confirm = SqlHelper.GetNullableString(reader, "out_crop_confirm");
            if (reader.IsColumnExists("out_soil_confirm"))
                item.out_soil_confirm = SqlHelper.GetNullableString(reader, "out_soil_confirm");
            if (reader.IsColumnExists("out_nablnonnabl_param"))
                item.out_nablnonnabl_param = SqlHelper.GetNullableString(reader, "out_nablnonnabl_param");
            return item;
        }
        public static soilviewDetailItems TranslateAsUserdetail(this MySqlDataReader reader1, bool isList = false)
        {
            if (!isList)
            {
                if (!reader1.HasRows)
                    return null;
                reader1.Read();
            }
            var detailitem = new soilviewDetailItems();
            if (reader1.IsColumnExists("out_soilparam_rowid"))
                detailitem.In_soilparam_rowid = SqlHelper.GetNullableInt32(reader1, "out_soilparam_rowid");

            if (reader1.IsColumnExists("out_soil_Id"))
                detailitem.out_soil_Id = SqlHelper.GetNullableString(reader1, "out_soil_Id");

            if (reader1.IsColumnExists("out_soil_Parameter"))
                detailitem.In_soil_Parameter = SqlHelper.GetNullableString(reader1, "out_soil_Parameter");

            if (reader1.IsColumnExists("out_UOM"))
                detailitem.In_soil_uom = SqlHelper.GetNullableString(reader1, "out_UOM");

            if (reader1.IsColumnExists("out_soil_Parameter_desc"))
                detailitem.In_soil_Parameter_desc = SqlHelper.GetNullableString(reader1, "out_soil_Parameter_desc");

            if (reader1.IsColumnExists("out_UOM_desc"))
                detailitem.In_soil_uom_desc = SqlHelper.GetNullableString(reader1, "out_UOM_desc");

            if (reader1.IsColumnExists("out_Soil_Result"))
                detailitem.In_soil_results = SqlHelper.GetNullableString(reader1, "out_Soil_Result");

            
                detailitem.In_mode_flag = "S";

            return detailitem;
        }

        public static soilcardlist TranslateAslist(this MySqlDataReader reader2, bool isList = false)
        {
            if (!isList)
            {
                if (!reader2.HasRows)
                    return null;
                reader2.Read();
            }
            var listitem = new soilcardlist();
            if (reader2.IsColumnExists("orgnId"))
                listitem.orgnId = SqlHelper.GetNullableString(reader2, "orgnId");

            if (reader2.IsColumnExists("locnId"))
                listitem.locnId = SqlHelper.GetNullableString(reader2, "locnId");

            if (reader2.IsColumnExists("localeId"))
                listitem.localeId = SqlHelper.GetNullableString(reader2, "localeId");

            if (reader2.IsColumnExists("In_soil_gid"))
                listitem.In_soil_gid = SqlHelper.GetNullableInt32(reader2, "In_soil_gid");

            if (reader2.IsColumnExists("In_farmer_gid"))
                listitem.In_farmer_gid = SqlHelper.GetNullableInt32(reader2, "In_farmer_gid");

            if (reader2.IsColumnExists("In_farmer_code"))
                listitem.In_farmer_code = SqlHelper.GetNullableString(reader2, "In_farmer_code");

            if (reader2.IsColumnExists("In_farmer_name"))
                listitem.In_farmer_name = SqlHelper.GetNullableString(reader2, "In_farmer_name");

            if (reader2.IsColumnExists("Collection_date"))
                listitem.Collection_date = SqlHelper.GetNullableString(reader2, "Collection_date");

            if (reader2.IsColumnExists("tran_id"))
                listitem.tran_id = SqlHelper.GetNullableString(reader2, "tran_id");

            if (reader2.IsColumnExists("soil_status"))
                listitem.soil_status = SqlHelper.GetNullableString(reader2, "soil_status");

            if (reader2.IsColumnExists("farmer_soil_rejreason"))
                listitem.farmer_soil_rejreason = SqlHelper.GetNullableString(reader2, "farmer_soil_rejreason");

            if (reader2.IsColumnExists("farmer_soil_CropRecom"))
                listitem.farmer_soil_CropRecom = SqlHelper.GetNullableString(reader2, "farmer_soil_CropRecom");

            return listitem;
        }

        public static soilviewHeader TranslateAssoilList(this MySqlDataReader reader)
        {
            var list = new soilviewHeader();
            while (reader.Read())
            {
                list = TranslateAsUser(reader, true);
            }
            return list;
        }
        public static List<soilviewDetailItems> TranslateAssoildet(this MySqlDataReader reader1)
        {
            var list1 = new List<soilviewDetailItems>();
            while (reader1.Read())
            {
                list1.Add(TranslateAsUserdetail(reader1, true));
            }
            return list1;
        }
        public static List<soilcardlist> TranssoilList(this MySqlDataReader reader)
        {
            var list = new List<soilcardlist>();
            while (reader.Read())
            {
                list.Add(TranslateAslist(reader, true));
            }
            return list;
        }

        public static List<attchementfetch> Translateattchementsavedet(this MySqlDataReader reader1)
        {
            var list1 = new List<attchementfetch>();
            while (reader1.Read())
            {
                list1.Add(TranslateAsattachdetail(reader1, true));
            }
            return list1;
        }
        public static attchementfetch TranslateAsattachdetail(this MySqlDataReader reader, bool isList = false)
        {

            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new attchementfetch();
            if (reader.IsColumnExists("attach_gid"))
                item.attach_gid = SqlHelper.GetNullableInt32(reader, "attach_gid");

            if (reader.IsColumnExists("document"))
                item.document = SqlHelper.GetNullableString(reader, "document");

            if (reader.IsColumnExists("filepath"))
                item.filepath = SqlHelper.GetNullableString(reader, "filepath");

            if (reader.IsColumnExists("filename"))
                item.filename = SqlHelper.GetNullableString(reader, "filename");

            if (reader.IsColumnExists("description"))
                item.description = SqlHelper.GetNullableString(reader, "description");

            if (reader.IsColumnExists("userId"))
                item.userId = SqlHelper.GetNullableString(reader, "userId");
            
            
            item.model_flag = "S";

            return item;
        }

        //Print
        public static soilPrintList TranslateAsUserdetailPrint(this MySqlDataReader reader1, bool isList = false)
        {
            if (!isList)
            {
                if (!reader1.HasRows)
                    return null;
                reader1.Read();
            }
            var detailitem = new soilPrintList();
            if (reader1.IsColumnExists("soil_gid"))
                detailitem.soil_gid = SqlHelper.GetNullableInt32(reader1, "soil_gid");

            if (reader1.IsColumnExists("farmer_code"))
                detailitem.farmer_code = SqlHelper.GetNullableString(reader1, "farmer_code");

            if (reader1.IsColumnExists("farmer_name"))
                detailitem.farmer_name = SqlHelper.GetNullableString(reader1, "farmer_name");

            if (reader1.IsColumnExists("farmer_address"))
                detailitem.farmer_address = SqlHelper.GetNullableString(reader1, "farmer_address");

            if (reader1.IsColumnExists("farmer_tranid"))
                detailitem.farmer_tranid = SqlHelper.GetNullableString(reader1, "farmer_tranid");

            if (reader1.IsColumnExists("farmer_sampleid"))
                detailitem.farmer_sampleid = SqlHelper.GetNullableString(reader1, "farmer_sampleid");

            if (reader1.IsColumnExists("farmer_sampledrawn"))
                detailitem.farmer_sampledrawn = SqlHelper.GetNullableString(reader1, "farmer_sampledrawn");

            if (reader1.IsColumnExists("farmer_customerref"))
                detailitem.farmer_customerref = SqlHelper.GetNullableString(reader1, "farmer_customerref");

            if (reader1.IsColumnExists("farmer_labreportno"))
                detailitem.farmer_labreportno = SqlHelper.GetNullableString(reader1, "farmer_labreportno");

            if (reader1.IsColumnExists("sampledescription"))
                detailitem.sampledescription = SqlHelper.GetNullableString(reader1, "sampledescription");

            if (reader1.IsColumnExists("farmer_analystarted"))
                detailitem.farmer_analystarted = SqlHelper.GetNullableString(reader1, "farmer_analystarted");

            if (reader1.IsColumnExists("farmer_analycompleted"))
                detailitem.farmer_analycompleted = SqlHelper.GetNullableString(reader1, "farmer_analycompleted");
            if (reader1.IsColumnExists("farmer_samplereceived"))
                detailitem.farmer_samplereceived = SqlHelper.GetNullableString(reader1, "farmer_samplereceived");
            if (reader1.IsColumnExists("farmer_labid"))
                detailitem.farmer_labid = SqlHelper.GetNullableString(reader1, "farmer_labid");
            if (reader1.IsColumnExists("farmer_testmethod"))
                detailitem.farmer_testmethod = SqlHelper.GetNullableString(reader1, "farmer_testmethod");
            if (reader1.IsColumnExists("parameter"))
                detailitem.parameter = SqlHelper.GetNullableString(reader1, "parameter");
            if (reader1.IsColumnExists("unit"))
                detailitem.unit = SqlHelper.GetNullableString(reader1, "unit");
            if (reader1.IsColumnExists("result"))
                detailitem.result = SqlHelper.GetNullableString(reader1, "result");

            return detailitem;
        }




        public static List<soilPrintList> TranslateAssoildetprint(this MySqlDataReader reader1)
        {
            var list1 = new List<soilPrintList>();
            while (reader1.Read())
            {
                list1.Add(TranslateAsUserdetailPrint(reader1, true));
            }
            return list1;
        }


        public static List<soilDetailItems> TranslateAssoilparadet(this MySqlDataReader reader1)
        {
            var list1 = new List<soilDetailItems>();
            while (reader1.Read())
            {
                list1.Add(TranslateAsUsersoildetail(reader1, true));
            }
            return list1;
        }


        public static soilDetailItems TranslateAsUsersoildetail(this MySqlDataReader reader1, bool isList = false)
        {
            if (!isList)
            {
                if (!reader1.HasRows)
                    return null;
                reader1.Read();
            }
            var detailitem = new soilDetailItems();
            if (reader1.IsColumnExists("out_soilparam_rowid"))
                detailitem.In_soilparam_rowid = SqlHelper.GetNullableInt32(reader1, "out_soilparam_rowid");

            if (reader1.IsColumnExists("out_soil_Id"))
                detailitem.out_soil_Id = SqlHelper.GetNullableString(reader1, "out_soil_Id");

            if (reader1.IsColumnExists("out_soil_Parameter"))
                detailitem.In_soil_Parameter = SqlHelper.GetNullableString(reader1, "out_soil_Parameter");

            if (reader1.IsColumnExists("out_UOM"))
                detailitem.In_soil_uom = SqlHelper.GetNullableString(reader1, "out_UOM");

            if (reader1.IsColumnExists("out_soil_Parameter_desc"))
                detailitem.In_soil_Parameter_desc = SqlHelper.GetNullableString(reader1, "out_soil_Parameter_desc");

            if (reader1.IsColumnExists("out_UOM_desc"))
                detailitem.In_soil_uom_desc = SqlHelper.GetNullableString(reader1, "out_UOM_desc");

            if (reader1.IsColumnExists("out_Soil_Result"))
                detailitem.In_soil_results = SqlHelper.GetNullableString(reader1, "out_Soil_Result");


            detailitem.In_mode_flag = " ";

            return detailitem;
        }
        public static List<soilDetailItems> TranslateAssoilNONNABLparadet(this MySqlDataReader reader1)
        {
            var list1 = new List<soilDetailItems>();
            while (reader1.Read())
            {
                list1.Add(TranslateAsUserNONNABLsoildetail(reader1, true));
            }
            return list1;
        }


        public static soilDetailItems TranslateAsUserNONNABLsoildetail(this MySqlDataReader reader1, bool isList = false)
        {
            if (!isList)
            {
                if (!reader1.HasRows)
                    return null;
                reader1.Read();
            }
            var detailitem = new soilDetailItems();
            if (reader1.IsColumnExists("out_soilparam_rowid"))
                detailitem.In_soilparam_rowid = SqlHelper.GetNullableInt32(reader1, "out_soilparam_rowid");

            if (reader1.IsColumnExists("out_soil_Id"))
                detailitem.out_soil_Id = SqlHelper.GetNullableString(reader1, "out_soil_Id");

            if (reader1.IsColumnExists("out_soil_Parameter"))
                detailitem.In_soil_Parameter = SqlHelper.GetNullableString(reader1, "out_soil_Parameter");

            if (reader1.IsColumnExists("out_UOM"))
                detailitem.In_soil_uom = SqlHelper.GetNullableString(reader1, "out_UOM");

            if (reader1.IsColumnExists("out_soil_Parameter_desc"))
                detailitem.In_soil_Parameter_desc = SqlHelper.GetNullableString(reader1, "out_soil_Parameter_desc");

            if (reader1.IsColumnExists("out_UOM_desc"))
                detailitem.In_soil_uom_desc = SqlHelper.GetNullableString(reader1, "out_UOM_desc");

            if (reader1.IsColumnExists("out_Soil_Result"))
                detailitem.In_soil_results = SqlHelper.GetNullableString(reader1, "out_Soil_Result");


            detailitem.In_mode_flag = " ";

            return detailitem;
        }
    }

}
