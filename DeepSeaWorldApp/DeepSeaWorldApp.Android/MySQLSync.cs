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

[assembly: Dependency(typeof(MySQLSync))]
namespace DeepSeaWorldApp.Droid
{
    class MySQLSync : MySQlSyncInterface
    {

        FAQ faq = new FAQ();
        Uri url = new Uri("http://127.0.0.1:80/scripts/dbContent.php/");

        public MySQLSync()
        {

        }

        public async Task<FAQ> MySQLConnection()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:80");
            var resp = await client.GetAsync(url);

            client.MaxResponseContentBufferSize = 256000;

    
                var content = resp.Content.ReadAsStringAsync().Result;
                faq = JsonConvert.DeserializeObject<FAQ>(content);

            return faq;
        }

        public async Task WriteAsync()
        {
            HttpClient client = new HttpClient();
            var resp = await client.GetAsync(url);
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fpath = Path.Combine(path, "faq.txt");
            string faqF = JsonConvert.SerializeObject(resp, Formatting.Indented);
            File.WriteAllText(fpath, faqF);
        }
    }
}