using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;
using SQLitePCL.lib;
using static DeepSeaWorldApp.DBClasses.DBs;

[assembly: Dependency(typeof(DeepSeaWorldApp.Droid.DeepSeaWorldSQLiteConnectionAndroid))]

namespace DeepSeaWorldApp.Droid
{
    public class DeepSeaWorldSQLiteConnectionAndroid : DeepSeaWorldSQLiteInterface 
    {
        
        public DeepSeaWorldSQLiteConnectionAndroid()
        {

        }

        // creating sqlite connection
        public SQLiteAsyncConnection CreateConnection()
        {
        


            string documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sqliteFile = "DeepSeaWorldSQLite.db";
            string path = Path.Combine(documentDir, sqliteFile);
            var conn = new SQLiteAsyncConnection(path);
            return conn;
        }

        public Task<List<FAQ>> GetItemAsync()
        {
            return CreateConnection().Table<FAQ>().ToListAsync();
        }

        //public Task<int> SaveItemAsync(FAQList f)
        //{

        //    if(f.Faq.First().ID != 0)
        //    {
        //        return CreateConnection().UpdateAsync(f.Faq);
        //    }else
        //    {
        //        return CreateConnection().InsertAsync(f.Faq);
        //    }
        //}


    }
}