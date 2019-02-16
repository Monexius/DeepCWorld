using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepSeaWorldApp
{
    public interface DeepSeaWorldSQLiteInterface
    {
        // SQLite connection
        SQLiteConnection CreateConnection();
    }
}
