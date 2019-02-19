using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeepSeaWorldApp.Droid;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(DeepSeaWorldSQLiteConnectionAndroid))]

namespace DeepSeaWorldApp.Droid
{
    class DeepSeaWorldSQLiteConnectionAndroid : DeepSeaWorldSQLiteInterface
    {
        public DeepSeaWorldSQLiteConnectionAndroid()
        {

        }

        public SQLite.SQLiteConnection CreateConnection()
        {
            var sqliteFile = "DeepSeaWorldSQLite.db";
            string documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentDir, sqliteFile);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

    }
}