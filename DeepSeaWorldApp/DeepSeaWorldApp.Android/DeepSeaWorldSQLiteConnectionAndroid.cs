using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;
using Android.Util;
using Android.Content.Res;

[assembly: Dependency(typeof(DeepSeaWorldApp.Droid.DeepSeaWorldSQLiteConnectionAndroid))]

namespace DeepSeaWorldApp.Droid
{
    public class DeepSeaWorldSQLiteConnectionAndroid : DeepSeaWorldSQLiteInterface 
    {

        MySqlDBCon mySql = new MySqlDBCon();
        DataTb dataT = new DataTb();
        

        public DeepSeaWorldSQLiteConnectionAndroid()
        {

        }

        // creating sqlite connection
        public SQLiteAsyncConnection CreateConnection()
        {
             string documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //AssetManager assets = this.Assets;
            //string documentDir = ;
            string sqliteFile = "DeepSeaWorldSQLite.db";
            string path = Path.Combine(documentDir, sqliteFile);
            var conn = new SQLiteAsyncConnection(path);
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
                    Log.Debug("TABLE UPDATE","Table update");
                }
                else
                {
                    await CreateConnection().InsertAsync(f);
                    Log.Debug("TABLE UPDATE", "Table update");
                }
            }
        }

    }
}