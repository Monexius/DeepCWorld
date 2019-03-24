using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DeepSeaWorldApp.Droid;
using Newtonsoft.Json;
using Xamarin.Forms;
using static DeepSeaWorldApp.DBClasses.DBs;

[assembly: Dependency(typeof(MySQLSync<>))]
namespace DeepSeaWorldApp.Droid
{
    public class MySQLSync<T> : IMySQlSyncInterface<T> where T : class
    {

        public MySQLSync()
        {

        }

        // connection and retriving data from server database, serialization of data to json  
        public async Task<DataL> MySQLConnection(Data[] ts, DataL dataL)
        {

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/");
            var resp = await client.GetAsync(url);
            var content = resp.Content.ReadAsStringAsync().Result;

        

            ts = JsonConvert.DeserializeObject<Data[]>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
         

               foreach(Data d in ts)
                {
                    if(d.Equals("FAQ_ID"))
                    {
                        
                    }

                }
            
            

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            string fileName2 = "js3.txt";
            string fileName = "js.txt";
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

            return dataL;
        }



    }

}