using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeepSeaWorldApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(DeepSeaWorldSQLiteConnectioniOS))]


namespace DeepSeaWorldApp.iOS
{
    class DeepSeaWorldSQLiteConnectioniOS : DeepSeaWorldSQLiteInterface
    {
        public DeepSeaWorldSQLiteConnectioniOS()
        {

        }

        public SQLite.Net.SQLiteConnection CreateConnection()
        {
            var SQLiteFile = "DeepSeaWorldSQLite.db";

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string directory = Path.Combine(folder, "..", "Library", "Databases");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string path = Path.Combine(directory, SQLiteFile);

            if (!File.Exists(path))
            {
                var existingDB = NSBundle.MainBundle.PathForResource("DeepSeaWorldSQLite", "db");
                File.Copy(existingDB, path);
            }

            var iOSPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(iOSPlatform, path);


            return conn;
        }


    }
}