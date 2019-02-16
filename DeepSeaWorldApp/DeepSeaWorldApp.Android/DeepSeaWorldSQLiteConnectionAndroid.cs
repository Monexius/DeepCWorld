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


        public SQLite.Net.SQLiteConnection CreateConnection()
        {
            var sqliteFile = "DeepSeaWorldSQLite.db";

            string documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentDir, sqliteFile);

            if (!File.Exists(path))
            {
                using (var BinaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFile)))
                {
                    using (var BinaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int lenght = 0;
                        while ((lenght = BinaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            BinaryWriter.Write(buffer, 0, lenght);
                        }
                    }
                }
            }
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(platform, path);

            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Lenght = 256;
            Byte[] buffer = new Byte[Lenght];

            int bytesRead = readStream.Read(buffer, 0, Lenght);

            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Lenght);
            }

            readStream.Close();
            writeStream.Close();

        }

    }
}