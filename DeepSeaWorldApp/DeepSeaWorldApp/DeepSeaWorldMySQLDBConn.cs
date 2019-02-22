using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DeepSeaWorldApp
{
    class DeepSeaWorldMySQLDBConn
    {
        private static string connStr = @"Data Source = localhost; port = 3306; Initial Catalog = queenspark2; User Id = root; password = 'root'";
        public MySqlConnection dbCon = new MySqlConnection(connStr); // MySql database connector
        private DataTable dt;           // data tabel
        private MySqlCommand cmd;       // MySql command

        // open data base connection
        public void DBconn()
        {
            // connection with MySql database
            try
            {
                // checking if connection to database is closed or open and if closed than open connection
                if (dbCon.State == ConnectionState.Closed)
                    dbCon.Open();
            }
            catch (Exception ex)
            {
                // if connection to server hadn't been eastablish display error massege
                string m = "Application could not connect to server";
                string m2 = "Error";
                App.Current.MainPage.DisplayAlert(m, m2, "ok");
            }

        }

    }
}
