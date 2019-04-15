using DeepSeaWorldApp.DBClasses;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp
{
    public interface DeepSeaWorldSQLiteInterface
    {
        // SQLite connection
        SQLiteAsyncConnection CreateConnection();

    }
}
