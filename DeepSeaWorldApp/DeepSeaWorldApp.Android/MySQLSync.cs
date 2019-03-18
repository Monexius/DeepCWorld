using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeepSeaWorldApp.DBClasses;
using DeepSeaWorldApp.Droid;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Json;

[assembly: Dependency(typeof(MySQLSync<>))]
namespace DeepSeaWorldApp.Droid
{
    public class MySQLSync<T> : IMySQlSyncInterface<T> where T : class
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        public MySQLSync()
        {

        }

        // connection and retriving data from server database, serialization of data to json  
        public async Task<List<T>> MySQLConnection(List<T> ts)
        {

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/");
            var resp = await client.GetAsync(url);
            var content = resp.Content.ReadAsStringAsync().Result;

            ts = JsonConvert.DeserializeObject<List<T>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            Data = ts;

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            string fileName = "js1.json";
            string fileName2 = "js2.json";
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

            return ts;
        }

        public async Task SaveCountAsync(int count)
        {

            string backingFile = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "/mypath/");
            string tFile = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "count.txt");
            using (var writer = File.CreateText(backingFile))
            {
                await writer.WriteLineAsync(count.ToString());
            }
        }
    }

}