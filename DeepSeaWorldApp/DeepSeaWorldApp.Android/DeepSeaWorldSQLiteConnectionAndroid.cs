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
using DeepSeaWorldApp.DBClasses;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DeepSeaWorldApp.Droid.DeepSeaWorldSQLiteConnectionAndroid))]

namespace DeepSeaWorldApp.Droid
{
    public class DeepSeaWorldSQLiteConnectionAndroid : DeepSeaWorldSQLiteInterface 
    {
        
        public DeepSeaWorldSQLiteConnectionAndroid()
        {

        }

        // creating sqlite connection
        public SQLiteConnection CreateConnection()
        {
            string documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sqliteFile = "DeepSeaWorldSQLite.db";
            string path = Path.Combine(documentDir, sqliteFile);
            var conn = new SQLiteConnection(path);
            return conn;
        }


    }
}