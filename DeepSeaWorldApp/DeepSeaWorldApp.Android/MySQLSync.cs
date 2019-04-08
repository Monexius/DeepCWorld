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
        public async Task<DataTb> MySQLConnection()
        {

            DataTb dataTb = new DataTb();

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
            var ex = exhibition[0].ToString().Trim().Insert(0, "[").Insert(exhibition[0].ToString().Length+1, "]");
            var mp = map[0].ToString().Trim().Insert(0, "[").Insert(map[0].ToString().Length+1, "]");
            var nws = news[0].ToString().Trim().Insert(0, "[").Insert(news[0].ToString().Length+1, "]");
            var qr = qrcodes[0].ToString().Trim().Insert(0, "[");


            // deserializatyion of data in json format to responding classes
            List<FAQ> flist = JsonConvert.DeserializeObject<List<FAQ>>(fq);
            List<Events> elist = JsonConvert.DeserializeObject<List<Events>>(ev);
            List<Exhibition> exlist = JsonConvert.DeserializeObject<List<Exhibition>>(ex);
            List<Map> mlist = JsonConvert.DeserializeObject<List<Map>>(mp);
            List<News> nlist = JsonConvert.DeserializeObject<List<News>>(nws);
            List<QRCodes> qrlist = JsonConvert.DeserializeObject<List<QRCodes>>(qr);

            dataTb.FAQ = flist;
            dataTb.Events = elist;
            dataTb.Exhibition = exlist;
            dataTb.Map = mlist;
            dataTb.News = nlist;
            dataTb.QRCodes = qrlist;


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
                serializer.Serialize(writer, flist);
                serializer.Serialize(writer2, elist);
                serializer.Serialize(writer3, exlist);
                serializer.Serialize(writer4, mlist);
                serializer.Serialize(writer5, nlist);
                serializer.Serialize(writer6, dataTb);
            }

            return dataTb;
        }

    }

}

