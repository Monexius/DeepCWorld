using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeepSeaWorldApp
{
    public class DeepSeaWorldSQLiteConnectionService
    {
        SQLiteConnection dbConn;

        public DeepSeaWorldSQLiteConnectionService()
        {
            dbConn = DependencyService.Get<DeepSeaWorldSQLiteInterface>().CreateConnection();

        }

        public Boolean connTest()
        {
            bool tb = false;
            var tab1 = dbConn.GetTableInfo("map");

            if (tab1 == null)
            {
                tb = false;
            }
            else
            {
                tb = true;
            }

            return tb;
        }
    }



}
