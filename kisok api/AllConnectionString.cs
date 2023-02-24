using nafmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kisok_api
{
    public class AllConnectionString
    {
       public string getRightConString( string loc , MySettingsModel obj)
        {
            string rightConString = "";
            string db = loc.ToUpper();
            if (db.Equals("TA") || db.Equals("TAMIL"))
            {
                rightConString = obj.TNmysqlcon;
            }
            else if (db.Equals("BH") || db.Equals("BIHAR"))
            {
                rightConString = obj.BHmysqlcon;
            }
            else if (db.Equals("OD") || db.Equals("ODISHA"))
            {
                rightConString = obj.ODmysqlcon;
            }            
             else if (db.Equals("UP") || db.Equals("UTTARPRADESH"))          
            {
                rightConString = obj.UPmysqlcon;
            }
            else if (db.Equals("JU") || db.Equals("JAMUI"))
            {
                rightConString = obj.JUmysqlcon;
            }
            return rightConString;

        }

    }
}
