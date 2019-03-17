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
    public class MySQLSync<T> : MySQlSyncInterface<T> where T : class
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        public MySQLSync()
        {

        }

        // connection and retriving data from server database, serialization of data to json  
        public async Task<List<T>> MySQLConnection()
        {

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/");
            var resp = await client.GetAsync(url);
            var content = resp.Content.ReadAsStringAsync().Result;
           
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fpath = Path.Combine(path, "faq.json");
            string json = JsonConvert.SerializeObject(content, Formatting.Indented);
            File.WriteAllText(fpath, json);

            Data = JsonConvert.DeserializeObject<List<T>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            return Data;
        }

        public void SaveFile(Task<List<FAQ>> M)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fpath = Path.Combine(path, "faq.json");
            string json = JsonConvert.SerializeObject(M, Formatting.Indented);
            File.WriteAllText(fpath, json);

            //using (var file = File.Open(fpath, FileMode.Create, FileAccess.Write))
            //using (var strm = new StreamWriter(file))
            //{
            //    strm.Write(M);
            //}
        }
    }

}