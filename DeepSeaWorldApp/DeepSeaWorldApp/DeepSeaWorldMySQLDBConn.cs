using DeepSeaWorldApp.DBClasses;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Json;
using Xamarin.Forms;
using DeepSeaWorldApp;

namespace DeepSeaWorldApp
{
    class DeepSeaWorldMySQLDBConn 
    {
        Task<FAQ> sync;
        

        public DeepSeaWorldMySQLDBConn()
        {
            sync = DependencyService.Get<MySQlSyncInterface>().MySQLConnection();
        }


        public Boolean syncTest()
        {
            bool tb = false;
            var tab1 = sync.IsCompleted;

            if (tab1 == true)
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
