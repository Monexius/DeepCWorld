using DeepSeaWorldApp.DBClasses;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Json;
using Xamarin.Forms;
using DeepSeaWorldApp;

namespace DeepSeaWorldApp
{
    class DeepSeaWorldMySQLDBConn<T> where T : class 
    {
        public List<T> sync;
        readonly Task<List<T>> TsAsync;

        public DeepSeaWorldMySQLDBConn()
        {
          //  TsAsync = DependencyService.Get<IMySQlSyncInterface<T>>().MySQLConnection(sync);
     //       sync = DependencyService.Get<IMySQlSyncInterface<T>>().Data;
        }

       public List<T> tablesData
        {
            get => sync;
            set => this.tablesData = TsAsync.Result;
        }

        public void SaveFile(List<T> ts)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileName = "dbData.txt";
            string fileName2 = "dbData2.txt";
            string fPath = Path.Combine(path, fileName);
            string fPath2 = Path.Combine(path, fileName2);
            JsonSerializer serializer = new JsonSerializer();
    
            string json = JsonConvert.SerializeObject(ts);
            using (StreamWriter st = new StreamWriter(fPath))
            using (JsonWriter writer = new JsonTextWriter(st))
            {
                serializer.Serialize(writer, json);
            }
            using (StreamWriter st = new StreamWriter(fPath2))
            using (JsonWriter writer = new JsonTextWriter(st))
            {
                serializer.Serialize(writer, ts);
            }
        }
    }

}
