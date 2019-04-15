using DeepSeaWorldApp;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using static DeepSeaWorldApp.DBClasses.DBs;

[assembly: Dependency(typeof(MySqlDBCon))]
namespace DeepSeaWorldApp
{
    public class MySqlDBCon 
    {
        public MySqlDBCon()
        {

        }

        // connection and retriving data from server database, serialization of data to json  
        public async Task<DataTb> MySQLConnection()
        {
            Console.WriteLine("MySQLConnection");
            DataTb dataTb = new DataTb();

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://10.0.2.2/scripts/dbContent.php");
            client.BaseAddress = new Uri("http://10.0.2.2/");

            var resp = await client.GetAsync(url); // responce from web client service (async with Mysql db)
            string content = resp.Content.ReadAsStringAsync().Result;

            // temporary IList to keep db table tada before serialization
            IList faq = new ArrayList();
            IList events = new ArrayList();
            IList exhibition = new ArrayList();
            IList map = new ArrayList();
            IList news = new ArrayList();
            IList qrcodes = new ArrayList();

            // spliting db data recived web responce service
            faq.Add(content.Split(']')[0]);
            events.Add(content.Split(']')[1]);
            exhibition.Add(content.Split(']')[2]);
            map.Add(content.Split(']')[3]);
            news.Add(content.Split(']')[4]);
            qrcodes.Add(content.Split(']')[5]);


            // preparing data for deserialization
            var fq = faq[0].ToString().Trim().Insert(faq[0].ToString().Length, "]");
            var ev = events[0].ToString().Trim().Insert(events[0].ToString().Length, "]");
            var ex = exhibition[0].ToString().Trim().Insert(exhibition[0].ToString().Length, "]");
            var mp = map[0].ToString().Trim().Insert(map[0].ToString().Length, "]");
            var nws = news[0].ToString().Trim().Insert(news[0].ToString().Length, "]");
            var qr = qrcodes[0].ToString().Trim().Insert(qrcodes[0].ToString().Length, "]");


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
            foreach (var e in dataTb.Events)
            {
                Console.WriteLine(e);
            }


            return dataTb;
        }



    }
}
