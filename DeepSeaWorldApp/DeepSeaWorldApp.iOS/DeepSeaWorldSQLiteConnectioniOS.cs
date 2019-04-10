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
            db.CreateTableAsync<FAQL>().Wait();
            db.CreateTableAsync<Events>().Wait();
            db.CreateTableAsync<Exhibition>().Wait();
            db.CreateTableAsync<Map>().Wait();
            db.CreateTableAsync<News>().Wait();
            db.CreateTableAsync<QRCodes>().Wait();
        }

        public Task<List<FAQL>> GetItemAsyncFAQ()
        {
            return CreateConnection().Table<FAQL>().ToListAsync();
        }

        public async Task<FAQL> GetItemAsyncFAQ(int id)
        {
            return await CreateConnection().Table<FAQL>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }


        public async Task InsertOrUpdateTableAsync(DataTb a)
        {

            FAQL fAQL = new FAQL();

            foreach (FAQ f in a.FAQ)
            {
                fAQL.FAQ_Question = f.FAQ_Question;
                fAQL.FAQ_Anwswere = f.FAQ_Anwswere;
                if (f.FAQ_ID != 0)
                {            
                    await CreateConnection().UpdateAsync(f);
                }
                else
                {
                    await CreateConnection().InsertAsync(f);
                }
            }
        }

        [Table("FAQ")]
        public class FAQL
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string FAQ_Question { get; set; }
            public string FAQ_Anwswere { get; set; }
        }

    }
}