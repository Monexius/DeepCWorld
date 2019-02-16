﻿using SQLite.Net;
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

    }
}
