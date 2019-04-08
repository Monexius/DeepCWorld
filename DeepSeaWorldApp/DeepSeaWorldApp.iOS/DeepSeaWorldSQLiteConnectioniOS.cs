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
using static DeepSeaWorldApp.DBClasses.DBs;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DeepSeaWorldSQLiteConnectioniOS))]


namespace DeepSeaWorldApp.iOS
{
    class DeepSeaWorldSQLiteConnectioniOS : DeepSeaWorldSQLiteInterface
    {

        MySqlDBCon mySql = new MySqlDBCon();
        DataTb dataT = new DataTb();


        public DeepSeaWorldSQLiteConnectioniOS()
        {

        }

        public SQLite.SQLiteAsyncConnection CreateConnection()
        {
            var SQLiteFile = "DeepSeaWorldSQLite.db";

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string directory = Path.Combine(folder, "..", "Library", "Databases");
            string path = Path.Combine(directory, SQLiteFile);
            var conn = new SQLite.SQLiteAsyncConnection(path);
            return conn;
        }

        public void TableAsync()
        {
            SQLiteAsyncConnection db = CreateConnection();
            db.CreateTableAsync<FAQ>().Wait();
            db.CreateTableAsync<Events>().Wait();
            db.CreateTableAsync<Exhibition>().Wait();
            db.CreateTableAsync<Map>().Wait();
            db.CreateTableAsync<News>().Wait();
            db.CreateTableAsync<QRCodes>().Wait();
        }

        //public Task<List<FAQ>> GetItemAsyncFAQ()
        //{
        //    List<FAQ> a = dataT.FAQ;
        //    return CreateConnection().Table<FAQ>().ToListAsync();
        //}

        public async Task<FAQ> GetItemAsyncFAQ()
        {
            dataT = await mySql.MySQLConnection();
            List<FAQ> a = dataT.FAQ;
            FAQ ab = new FAQ();
            ab = a.First();
            return await CreateConnection().Table<FAQ>().Where(i => i.ID == ab.ID).FirstOrDefaultAsync();
        }


        public async Task InsertOrUpdateTableAsync(DataTb a)
        {

            a = await mySql.MySQLConnection();
            List<FAQ> faq = new List<FAQ>();
            faq = a.FAQ;

            foreach (FAQ f in faq)
            {
                if (f.ID != 0)
                {
                    await CreateConnection().UpdateAsync(f);
                }
                else
                {
                    await CreateConnection().InsertAsync(f);
                }
            }
        }

    }
}