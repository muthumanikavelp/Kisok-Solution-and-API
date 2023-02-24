
using MySql.Data.MySqlClient;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_FDR_model;

namespace nafdatamodel
{
    public class Mobile_FDR_Datamodel
    {
        public static DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        //ErrorMessages ObjErrormsg = new ErrorMessages();
        //log4net.ILog //   logger = log4net.LogManager.Get//   logger(typeof(Mobile_FDR_Datamodel)); //Declaring Log4Net. 
        public MFDRApplication GetallFarmerProfileDetail_DB(MFDRContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            MFDRApplication objinvoiceRoot = new MFDRApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new MFDRContext();
            objinvoiceRoot.context.FarmerProfileDetails = new List<FarmerProfileDetails>();

            //MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_fetch_farmerprofiledet", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FarmerProfileDetails objList = new FarmerProfileDetails();
                    objList.sl_no = Convert.ToInt32(dt.Rows[i]["sl_no"]);
                    objList.tab_name = dt.Rows[i]["tab_name"].ToString();
                    objList.dynamic_list = dt.Rows[i]["dynamic_list"].ToString();
                    objinvoiceRoot.context.FarmerProfileDetails.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public MFApplication GetallFarmerbank_DB(MFContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            MFApplication objinvoiceRoot = new MFApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new MFContext();
            objinvoiceRoot.context.BankDtl = new List<MFBankDtl>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_bank_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MFBankDtl objList = new MFBankDtl();
                    objList.bank_rowid = Convert.ToInt32(dt.Rows[i]["bank_rowid"]);
                    objList.bank_code = dt.Rows[i]["bank_code"].ToString();
                    objList.bank_name = dt.Rows[i]["bank_name"].ToString();
                    objList.branch_name = dt.Rows[i]["branch_name"].ToString();
                    objList.ifsc_code = dt.Rows[i]["ifsc_code"].ToString();
                    objList.status_desc = dt.Rows[i]["status_desc"].ToString();
                    objinvoiceRoot.context.BankDtl.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public MFMApplication GetallFarmermaster_DB(MFMContext objinvoice, string mysqlcon)
        {
            DataSet ds = new DataSet();
            
            DataTable Farmerdt = new DataTable();
            DataTable VarietyDt = new DataTable();
            DataTable QualityDt = new DataTable();
            DataTable VehicleDt = new DataTable();
            DataTable DestinationDt = new DataTable();

            MFMApplication objinvoiceRoot = new MFMApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new MFMContext();
            objinvoiceRoot.context.detail = new List<MFMDetail>();
            objinvoiceRoot.context.VarityDt = new List<VarietyDetails>();
            objinvoiceRoot.context.QualityDt = new List<QualityDetails>();
            objinvoiceRoot.context.VehicleDt = new List<VarietyDetails>();
            objinvoiceRoot.context.DestinationDt = new List<VarietyDetails>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_master_definition", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_screen_code", MySqlDbType.VarChar).Value = objinvoice.screen_Id;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (objinvoice.screen_Id.ToUpper() == "FARMER")
                {
                    if (ds.Tables.Count > 0)
                    {
                        Farmerdt = ds.Tables[0];
                        for (int i = 0; i < Farmerdt.Rows.Count; i++)
                        {
                            MFMDetail objList = new MFMDetail();
                            objList.out_master_rowid = Convert.ToInt32(Farmerdt.Rows[i]["out_master_rowid"]);
                            objList.out_parent_code = Farmerdt.Rows[i]["out_parent_code"].ToString();
                            objList.out_master_code = Farmerdt.Rows[i]["out_master_code"].ToString();
                            objList.out_master_description = Farmerdt.Rows[i]["out_master_description"].ToString();
                            objList.out_depend_code = Farmerdt.Rows[i]["out_depend_code"].ToString();
                            objList.out_depend_desc = Farmerdt.Rows[i]["out_depend_desc"].ToString();
                            objList.out_locallang_flag = Farmerdt.Rows[i]["out_locallang_flag"].ToString();
                            objList.out_status_code = Farmerdt.Rows[i]["out_status_code"].ToString();
                            objList.out_status_desc = Farmerdt.Rows[i]["out_status_desc"].ToString();
                            objinvoiceRoot.context.detail.Add(objList);

                        }
                    }

                }
                if (objinvoice.screen_Id.ToUpper() == "FARMERANDPAWHS")
                {
                    if (ds.Tables.Count > 0)
                    {
                        Farmerdt = ds.Tables[0];
                        for (int i = 0; i < Farmerdt.Rows.Count; i++)
                        {
                            MFMDetail objList = new MFMDetail();
                            objList.out_master_rowid = Convert.ToInt32(Farmerdt.Rows[i]["out_master_rowid"]);
                            objList.out_parent_code = Farmerdt.Rows[i]["out_parent_code"].ToString();
                            objList.out_master_code = Farmerdt.Rows[i]["out_master_code"].ToString();
                            objList.out_master_description = Farmerdt.Rows[i]["out_master_description"].ToString();
                            objList.out_depend_code = Farmerdt.Rows[i]["out_depend_code"].ToString();
                            objList.out_depend_desc = Farmerdt.Rows[i]["out_depend_desc"].ToString();
                            objList.out_locallang_flag = Farmerdt.Rows[i]["out_locallang_flag"].ToString();
                            objList.out_status_code = Farmerdt.Rows[i]["out_status_code"].ToString();
                            objList.out_status_desc = Farmerdt.Rows[i]["out_status_desc"].ToString();
                            objinvoiceRoot.context.detail.Add(objList);

                        }

                        VarietyDt = ds.Tables[1];
                        for (int i = 0; i < VarietyDt.Rows.Count; i++)
                        {
                            VarietyDetails Objlist = new VarietyDetails();
                            Objlist.Out_master_rowid = Convert.ToInt32(VarietyDt.Rows[i]["Out_master_rowid"]);
                            Objlist.Out_master_code = VarietyDt.Rows[i]["Out_master_code"].ToString();
                            Objlist.Out_master_desc = VarietyDt.Rows[i]["Out_master_desc"].ToString();
                            objinvoiceRoot.context.VarityDt.Add(Objlist);
                        }

                        QualityDt = ds.Tables[2];
                        for (int i = 0; i < QualityDt.Rows.Count; i++)
                        {
                            QualityDetails ObjList = new QualityDetails();
                            ObjList.Out_qlt_rowid = Convert.ToInt32(QualityDt.Rows[i]["Out_qlt_rowid"]);
                            ObjList.Out_qlt_code = QualityDt.Rows[i]["Out_qlt_code"].ToString();
                            ObjList.Out_qlt_name = QualityDt.Rows[i]["Out_qlt_name"].ToString();
                            ObjList.Out_QualityRange = QualityDt.Rows[i]["Out_QualityRange"].ToString();
                            objinvoiceRoot.context.QualityDt.Add(ObjList);

                        }
                        VehicleDt = ds.Tables[3];
                        for (int i = 0; i < VehicleDt.Rows.Count; i++)
                        {
                            VarietyDetails Objlist = new VarietyDetails();
                            Objlist.Out_master_rowid = Convert.ToInt32(VehicleDt.Rows[i]["Out_master_rowid"]);
                            Objlist.Out_master_code = VehicleDt.Rows[i]["Out_master_code"].ToString();
                            Objlist.Out_master_desc = VehicleDt.Rows[i]["Out_master_desc"].ToString();
                            objinvoiceRoot.context.VehicleDt.Add(Objlist);

                        }
                        DestinationDt = ds.Tables[4];
                        for (int i = 0; i < DestinationDt.Rows.Count; i++)
                        {
                            VarietyDetails Objlist = new VarietyDetails();
                            Objlist.Out_master_rowid = Convert.ToInt32(DestinationDt.Rows[i]["Out_master_rowid"]);
                            Objlist.Out_master_code = DestinationDt.Rows[i]["Out_master_code"].ToString();
                            Objlist.Out_master_desc = DestinationDt.Rows[i]["Out_master_desc"].ToString();
                            objinvoiceRoot.context.DestinationDt.Add(Objlist);

                        }

                    }
                }


                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public docnumApplication GetallFarmerdocnum_DB(docnumContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            docnumApplication objinvoiceRoot = new docnumApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new docnumContext();
            objinvoiceRoot.context.Farmerdocnum = new Farmerdocnum();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_fetch_docno", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add(new MySqlParameter("activity_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("format_value", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                objinvoiceRoot.context.Farmerdocnum.activity_code = (string)cmd.Parameters["activity_code"].Value.ToString();
                objinvoiceRoot.context.Farmerdocnum.format_value = (string)cmd.Parameters["format_value"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
