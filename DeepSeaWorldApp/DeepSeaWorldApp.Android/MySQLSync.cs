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

[assembly: Dependency(typeof(MySQLSync))]
namespace DeepSeaWorldApp.Droid
{
    class MySQLSync : MySQlSyncInterface
    {

        public MySQLSync()
        {

        }

        // connection and retriving data from server database, serialization of data to json  
        public async Task<List<FAQ>> MySQLConnection()
        {
            RootObject root = new RootObject();
            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/"); 
            var resp = await client.GetAsync(url);
            client.MaxResponseContentBufferSize = 256000;
            
            // checking responce from the server if responce is succesfull retrive data to json
            if(resp.IsSuccessStatusCode)
            { 
                var content = resp.Content.ReadAsStringAsync().Result;
                root.faq = JsonConvert.DeserializeObject<List<FAQ>>(content);
            }
            return root.faq;
        }

        //public void SaveFile(Task<List<FAQ>> M)
        //{
        //    string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        //    string fpath = Path.Combine(path, "faq.json");
        //    using (var file = File.Open(fpath, FileMode.Create, FileAccess.Write))
        //    using (var strm = new StreamWriter(file))
        //    {
        //        strm.Write(M);
        //    }
        //}
    }
}