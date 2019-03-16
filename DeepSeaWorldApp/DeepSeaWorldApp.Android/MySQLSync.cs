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

        List<FAQ> faq = new List<FAQ>();
        Uri url = new Uri("http://127.0.0.1:80/scripts/dbContent.php");
        

        public MySQLSync()
        {

        }

        public async Task<List<FAQ>> MySQLConnection()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:80/scripts/dbConector.php");
            var resp = await client.GetAsync(url);

            client.MaxResponseContentBufferSize = 256000;
    
                var content = resp.Content.ReadAsStringAsync().Result;
                faq = JsonConvert.DeserializeObject<List<FAQ>>(content);

            return faq;
        }


        public void saveFile(Task<List<FAQ>> M)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fpath = Path.Combine(path, "faq.json");
            using (var file = File.Open(fpath, FileMode.Create, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.Write(M);
            }
        }
    }
}