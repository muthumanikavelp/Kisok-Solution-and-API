using MySql.Data.MySqlClient;
using nafmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Mobile_FDR_FHeader_model;

namespace nafdatamodel
{
   public class Mobile_FDR_FHeader_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        //ErrorMessages ObjErrormsg = new ErrorMessages();
        public MFHDocument SaveNewMobileFarmerHeader_DB(MFHApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            MFHDocument objProcessDoc = new MFHDocument();
            objProcessDoc.context = new MFHContext();
            objProcessDoc.context.Header = new MFHHeader();
            objProcessDoc.ApplicationException = new MFHApplicationException();
            string in_farmer_rowid1 = "";
            string in_farmer_code1 = "";
            string in_version_no1 = "";
            try
            {
                MysqlCon.con.Close();
                MySqlCommand cmd = new MySqlCommand("FDRMOB_insupd_farmer_registration", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.in_version_no;
                cmd.Parameters.Add("in_photo_farmer", MySqlDbType.LongText).Value = ObjFarmer.document.context.Header.in_photo_farmer;
                cmd.Parameters.Add("in_farmer_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_name;
                cmd.Parameters.Add("in_sur_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_sur_name;
                cmd.Parameters.Add("in_fhw_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_fhw_name;
                cmd.Parameters.Add("in_farmer_dob", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_dob;
                cmd.Parameters.Add("in_farmer_addr1", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_addr1;
                cmd.Parameters.Add("in_farmer_addr2", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_addr2;
                cmd.Parameters.Add("in_farmer_country", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_country;
                cmd.Parameters.Add("in_farmer_state", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_state;
                cmd.Parameters.Add("in_farmer_dist", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_dist;
                cmd.Parameters.Add("in_farmer_taluk", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_taluk;
                cmd.Parameters.Add("in_farmer_panchayat", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_panchayat;
                cmd.Parameters.Add("in_farmer_village", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_village;
                cmd.Parameters.Add("in_farmer_pincode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_pincode;
                cmd.Parameters.Add("in_marital_status", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_marital_status;
                cmd.Parameters.Add("in_gender_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_gender_flag;
                cmd.Parameters.Add("in_reg_mobile_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_reg_mobile_no;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_row_timestamp;
                cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_created_by;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.instance;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
               // cmd.Parameters.Add("In_instance", MySqlDbType.VarChar).Value = ObjFarmer.document.context.instance;

                cmd.Parameters.Add(new MySqlParameter("in_farmer_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_version_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();
                if (ret > 0)
                {
                    in_farmer_rowid1 = (string)cmd.Parameters["in_farmer_rowid1"].Value;
                    in_farmer_code1 = (string)cmd.Parameters["in_farmer_code1"].Value;
                    in_version_no1 = (string)cmd.Parameters["in_version_no1"].Value;

                    objProcessDoc.context.Header.in_farmer_rowid = Convert.ToInt32(in_farmer_rowid1);
                    objProcessDoc.context.Header.in_farmer_code = in_farmer_code1;
                    objProcessDoc.context.Header.in_version_no = Convert.ToInt32(in_version_no1);
                }
                else
                {
                    objProcessDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objProcessDoc.ApplicationException.errorDescription = (string)cmd.Parameters["errorNo"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return objProcessDoc;
        }

        public List<FarmerSummary> GetFarmerList_db(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<FarmerSummary>>(Mysql,
                "FDRMOB_fetch_farmer_reg_list", t => t.TransFarmerList(), myParamArray);
        }
    }
}