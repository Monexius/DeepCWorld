﻿using DeepSeaWorldApp.DBClasses;
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
        Task<List<FAQ>> sync;

        public DeepSeaWorldMySQLDBConn()
        {
            sync = DependencyService.Get<MySQlSyncInterface>().MySQLConnection();

        }

    }

}
