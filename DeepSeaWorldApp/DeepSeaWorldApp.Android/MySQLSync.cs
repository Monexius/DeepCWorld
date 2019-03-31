using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DeepSeaWorldApp.Droid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public async Task<List<Data>> MySQLConnection(Data ts, DataL dataL)
        {

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/");
            
            var resp = await client.GetAsync(url); // responce from web client service (async with Mysql db)
            var content = resp.Content.ReadAsStringAsync().Result;            

            // temporary IList to keep db table tada before serialization
            IList faq = new ArrayList();
            IList events = new ArrayList();
            IList exhibition = new ArrayList();
            IList map = new ArrayList();
            IList news = new ArrayList();
            IList qrcodes = new ArrayList();

            // spliting db data recived web responce service
            faq.Add(content.Split("][")[0]);
            events.Add(content.Split("][")[1]);
            exhibition.Add(content.Split("][")[2]);
            map.Add(content.Split("][")[3]);
            news.Add(content.Split("][")[4]);
            qrcodes.Add(content.Split("][")[5]);


            // preparing data for deserialization
            var fq = faq[0].ToString().Trim().Insert(faq[0].ToString().Length,"]");
            var ev = events[0].ToString().Trim().Insert(0, "[").Insert(events[0].ToString().Length+1,"]");


            // deserializatyion of data in json format to responding classes
            List<FAQ> flist = JsonConvert.DeserializeObject<List<FAQ>>(fq);
            List<Events> elist = JsonConvert.DeserializeObject<List<Events>>(ev);


            // testing writer for files --- to be cut off
            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            string fileName1 = "js1.txt";
            string fileName2 = "js2.txt";
            string fileName3 = "js3.txt";
            string fileName4 = "js4.txt";
            string fileName5 = "js5.txt";
            string fileName6 = "js6.txt";
            string fPath1 = Path.Combine(path, fileName1);
            string fPath2 = Path.Combine(path, fileName2);
            string fPath3 = Path.Combine(path, fileName3);
            string fPath4 = Path.Combine(path, fileName4);
            string fPath5 = Path.Combine(path, fileName5);
            string fPath6 = Path.Combine(path, fileName6);
            using (StreamWriter st = new StreamWriter(fPath1))
            using (StreamWriter st2 = new StreamWriter(fPath2))
            using (StreamWriter st3 = new StreamWriter(fPath3))
            using (StreamWriter st4 = new StreamWriter(fPath4))
            using (StreamWriter st5 = new StreamWriter(fPath5))
            using (StreamWriter st6 = new StreamWriter(fPath6))
            using (JsonWriter writer = new JsonTextWriter(st))
            using (JsonWriter writer2 = new JsonTextWriter(st2))
            using (JsonWriter writer3 = new JsonTextWriter(st3))
            using (JsonWriter writer4 = new JsonTextWriter(st4))
            using (JsonWriter writer5 = new JsonTextWriter(st5))
            using (JsonWriter writer6 = new JsonTextWriter(st6))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, fq);
                serializer.Serialize(writer2, ev);
                serializer.Serialize(writer3, exhibition);
                serializer.Serialize(writer4, map);
                serializer.Serialize(writer5, news);
                serializer.Serialize(writer6, qrcodes);
            }



            // mocup class for returm - will be changed for DataL
            List<Data> list = new List<Data>();

            return list;
        }

        // adding data to json array
        private JArray Loop(HttpResponseMessage msg, JArray s)
        {
            if (msg.Content != null)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                s.Add(data);
            }
            return s;
        }

    }

}

