using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static nafmodel.Kisok_attach_model;

namespace nafdatamodel
{
  public class kiosk_attach_datamodel
    {
        public string[] Newsoilcardsave_db(attchementsave model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userId),
                new MySqlParameter("locnId",model.locid),              
                new MySqlParameter("In_soil_gid",model.soil_gid),
                new MySqlParameter("filename",model.filename),
                new MySqlParameter("filepath",model.filepath),
                new MySqlParameter("document",model.document),
                new MySqlParameter("description",model.description),
                new MySqlParameter("mode_flag",model.model_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "kiosk_insupd_attachment", param);
            return returnvalues;
        }
        public List<attchementfetch> Getattchementfetch_db(string org, string locn,string user, string lang, string doc_type, string id, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),
                new MySqlParameter("attach_id",id),
                new MySqlParameter("doc_type",doc_type)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<attchementfetch>>(Mysql,
                "kiosk_fetch_attachment", t => t.Translateattchementsavedet(), myParamArray);
        }
        public string[] Newnotessave_db(notessave model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userId),               
                new MySqlParameter("In_gid",model.id),
                new MySqlParameter("notesdata",model.notesdata),
                new MySqlParameter("screenname",model.screenname),
                new MySqlParameter("mode_flag",model.model_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "kiosk_insupd_notes", param);
            return returnvalues;
        }
        public string[] Newattachdelete_db(attachdelete model, string connString)
        {
            string[] returnvalues = { };
            var outParam = new MySqlParameter("out_msg", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            var outParam1 = new MySqlParameter("out_result", MySqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output
            };
            MySqlParameter[] param = {
                new MySqlParameter("userId",model.userID),
                new MySqlParameter("locnId",model.locId),
                new MySqlParameter("In_soil_gid",model.gid),
                new MySqlParameter("filename",""),
                new MySqlParameter("filepath",""),
                new MySqlParameter("document",""),
                new MySqlParameter("description",""),
                new MySqlParameter("mode_flag",model.model_flag),
                outParam,
                outParam1
            };
            returnvalues = SqlHelper.ExecuteProcedureReturnString(connString, "kiosk_insupd_attachment", param);
            return returnvalues;
        }
    }
}
