using MySql.Data.MySqlClient;
using System.Collections.Generic;
using static nafmodel.Kiosk_localization_model;

namespace nafdatamodel
{
    public class Kiosk_localization_datamodel
    {
        public List<localizationlist> Getlocalizationlist_db(string org, string locn, string user, string lang, string Mysql)
        {
            MySqlParameter[] myParamArray = {
                new MySqlParameter("userId",user),
                new MySqlParameter("orgnId",org),
                new MySqlParameter("locnId",locn),
                new MySqlParameter("localeId",lang),

            };
            return SqlHelper.ExtecuteProcedureReturnData<List<localizationlist>>(Mysql,
                "Kiosk_fetch_localization", t => t.TranslateAslocalizationlist(), myParamArray);
        }
    }
}
