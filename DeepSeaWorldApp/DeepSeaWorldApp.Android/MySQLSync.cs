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
        public async Task<List<Data>> MySQLConnection()
        {

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/");

           // List<Data> data = new List<Data>();

            var resp = await client.GetAsync(url); // responce from web client service (async with Mysql db)
            JArray content = new JArray();
            content = Loop(resp, content);


            List <Data> data = new List<Data>();
            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

            foreach (JValue tk in content)
            {

                string t = tk.SelectTokens("$..FAQ_ID.*").ToString();


                string fileName = "js3.txt";
                string fPath = Path.Combine(path, fileName);
                using (StreamWriter st = new StreamWriter(fPath))
                using (JsonWriter writer = new JsonTextWriter(st))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, t);
                }

            }



            // test printout of data from mysql database in txt file (will be deleted before development)
                
                string fileName2 = "js2.txt";
                string fPath2 = Path.Combine(path, fileName2);
                using (StreamWriter st = new StreamWriter(fPath2))
                using (JsonWriter writer = new JsonTextWriter(st))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, content);
                }
            
            return data;
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




//JArray faqAr = new JArray();
//IEnumerable eventsAr = new JArray();
//IEnumerable exhibitionAr = new JArray();
//IEnumerable mapAr = new JArray();
//IEnumerable newsAr = new JArray();
//IEnumerable qrAr = new JArray();

//IEnumerable d;

//d = JsonConvert.DeserializeObject<JArray>(data.ToString());

//            //segregating data on tables
//            //foreach (JToken jar in data)
//            //{
//            //    //faqAr = jar.Children();
//            //    //eventsAr = jar.SelectTokens("Event_ID").ToArray();
//            //    //exhibitionAr = jar.SelectTokens("Exhibition_ID").ToArray();
//            //    //mapAr = jar.SelectTokens("Map_ID").ToArray();
//            //    //newsAr = jar.SelectTokens("News_ID").ToArray();
//            //    //qrAr = jar.SelectTokens("QRCodes_ID").ToArray();


//            //    // test printout of data from mysql database in txt file (will be deleted before development)
//            //    string path2 = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
//            //    string fileName = "js1.txt";
//            //    string fPath = Path.Combine(path2, fileName);
//            //    using (StreamWriter st = new StreamWriter(fPath))
//            //    using (JsonWriter writer = new JsonTextWriter(st))
//            //    {
//            //        JsonSerializer serializer = new JsonSerializer();
//            //        serializer.Serialize(writer, jar.SelectTokens("FAQ_ID"));
//            //    }
//            //}

//            //List<DataL> dataList = new List<DataL>();
//            List<Data> dataList1 = new List<Data>();
////DataL dl = new DataL();

////  dataList = JsonConvert.DeserializeObject<List<DataL>>(data.ToString());