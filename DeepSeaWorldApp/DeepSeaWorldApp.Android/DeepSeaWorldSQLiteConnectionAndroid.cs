using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;
using Android.Util;
using Android.Content.Res;

[assembly: Dependency(typeof(DeepSeaWorldApp.Droid.DeepSeaWorldSQLiteConnectionAndroid))]

namespace DeepSeaWorldApp.Droid
{
    public class DeepSeaWorldSQLiteConnectionAndroid : DeepSeaWorldSQLiteInterface 
    {

        MySqlDBCon mySql = new MySqlDBCon();
        DataTb dataT = new DataTb();
        

        public DeepSeaWorldSQLiteConnectionAndroid()
        {

        }

        // creating sqlite connection
        public SQLiteAsyncConnection CreateConnection()
        {
             string documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //AssetManager assets = this.Assets;
            //string documentDir = ;
            string sqliteFile = "DeepSeaWorldSQLite.db";
            string path = Path.Combine(documentDir, sqliteFile);
            var conn = new SQLiteAsyncConnection(path);
            return conn;
        }

        public void TableAsync()
        {
            SQLiteAsyncConnection db = CreateConnection();
            db.CreateTableAsync<FAQ>().Wait();
            db.CreateTableAsync<Events>().Wait();
            db.CreateTableAsync<Exhibition>().Wait();
            db.CreateTableAsync<Map>().Wait();
            db.CreateTableAsync<News>().Wait();
            db.CreateTableAsync<QRCodes>().Wait();
        }

        public Task<List<FAQ>> GetItemAsyncFAQ()
        {
            return CreateConnection().Table<FAQ>().ToListAsync();
        }

        public async Task<FAQL> GetItemAsyncFAQ(int id)
        {
            return await CreateConnection().Table<FAQL>().Where(i => i.FAQ_ID == id).FirstOrDefaultAsync();
        }

        // FAQ table insert update data
        public async Task InsertOrUpdateTableAsyncFAQ(FAQ f)
        {
            FAQL fAQ = new FAQL();

            fAQ.FAQ_Question = f.FAQ_Question;
            fAQ.FAQ_Anwswere = f.FAQ_Anwswere;
            if (fAQ.FAQ_ID != 0)
            {
                await CreateConnection().UpdateAsync(fAQ);
            }
            else
            {
                await CreateConnection().InsertAsync(fAQ);
            }
        }

        // events table insert/update data
        public async Task InsertOrUpdateTableAsyncEvents(Events e)
        {
            EventsL eventsL = new EventsL();

            eventsL.Event_Name = e.Event_Name;
            eventsL.Event_Description = e.Event_Description;
            eventsL.Event_IMG = e.Event_IMG;
            eventsL.Event_Location = e.Event_Location;
            eventsL.Event_Day = e.Event_Day;
            eventsL.Event_Time = e.Event_Time;

            if (eventsL.Events_ID != 0)
            {
                await CreateConnection().UpdateAsync(eventsL);
            }
            else
            {
                await CreateConnection().InsertAsync(eventsL);
            }
        }

        // exhibition table insert/update
        public async Task InsertOrUpdateTableAsyncExhibition(Exhibition ex)
        {
            ExhibitionL exhibitionL = new ExhibitionL();

            exhibitionL.Exhibition_QRCode_Pos = ex.Exhibition_QRCode_Pos;
            exhibitionL.Exhibition_Description = ex.Exhibition_Description;
            exhibitionL.Exhibition_IMG_Name = ex.Exhibition_IMG_Name;
            exhibitionL.Exhibition_IMG = ex.Exhibition_IMG;
            exhibitionL.Exhibition_Video_Name = ex.Exhibition_Video_Name;
            exhibitionL.Exhibition_Video = ex.Exhibition_Video;
            exhibitionL.Exhibition_Name = ex.Exhibition_Name;
            exhibitionL.QRCodes_Name = ex.QRCodes_Name;

            if (exhibitionL.Exhibition_ID != 0)
            {
                await CreateConnection().UpdateAsync(exhibitionL);
            }
            else
            {
                await CreateConnection().InsertAsync(exhibitionL);
            }
        }

        // map table instert/update
        public async Task InsertOrUpdateTableAsyncMap(Map m)
        {
            MapL mapL = new MapL();

            mapL.Map_IMG = m.Map_IMG;
            if (mapL.Map_ID != 0)
            {
                await CreateConnection().UpdateAsync(mapL);
            }
            else
            {
                await CreateConnection().InsertAsync(mapL);
            }
        }

        // news table insert/update
        public async Task InsertOrUpdateTableAsyncNews(News n)
        {
            NewsL newsL = new NewsL();

            newsL.News_Title = n.News_Title;
            newsL.News_Brief_Info = n.News_Brief_Info;
            newsL.News_IMG = n.News_IMG;
            newsL.News_Article = n.News_Article;
            newsL.Notifications = n.Notifications;

            if (newsL.News_ID != 0)
            {
                await CreateConnection().UpdateAsync(newsL);
            }
            else
            {
                await CreateConnection().InsertAsync(newsL);
            }
        }

        // qrcodes table insert/update
        public async Task InsertOrUpdateTableAsyncQRCodes(QRCodes qr)
        {
            QRCodesL qR = new QRCodesL();

            qR.QRCodes_Name = qr.QRCodes_Name;
            qR.QRCodes_IMG = qr.QRCodes_IMG;
            qR.QRCodes_Pos = qr.QRCodes_Pos;

            if (qR.QRCodes_ID != 0)
            {
                await CreateConnection().UpdateAsync(qR);
            }
            else
            {
                await CreateConnection().InsertAsync(qR);
            }
        }

        [Table("FAQ")]
        public class FAQL
        {
            [PrimaryKey, AutoIncrement]
            public int FAQ_ID { get; set; }
            public string FAQ_Question { get; set; }
            public string FAQ_Anwswere { get; set; }
        }

        [Table("Events")]
        public class EventsL
        {
            [PrimaryKey, AutoIncrement]
            public int Events_ID { get; set; }
            public string Event_Name { get; set; }
            public string Event_Description { get; set; }
            public string Event_IMG { get; set; }
            public string Event_Location { get; set; }
            public string Event_Day { get; set; }
            public string Event_Time { get; set; }
        }

        [Table("Exhibition")]
        public class ExhibitionL
        {
            [PrimaryKey, AutoIncrement]
            public int Exhibition_ID { get; set; }
            public int Exhibition_QRCode_Pos { get; set; }
            public string Exhibition_Description { get; set; }
            public string Exhibition_IMG_Name { get; set; }
            public string Exhibition_IMG { get; set; }
            public string Exhibition_Video_Name { get; set; }
            public string Exhibition_Video { get; set; }
            public string Exhibition_Name { get; set; }
            public string QRCodes_Name { get; set; }
        }

        [Table("Map")]
        public class MapL
        {
            [PrimaryKey, AutoIncrement]
            public int Map_ID { get; set; }
            public string Map_IMG { get; set; }
        }

        [Table("News")]
        public class NewsL
        {
            [PrimaryKey, AutoIncrement]
            public int News_ID { get; set; }
            public string News_Title { get; set; }
            public string News_Brief_Info { get; set; }
            public string News_IMG { get; set; }
            public string News_Article { get; set; }
            public string Notifications { get; set; }
        }

        [Table("QRCodes")]
        public class QRCodesL
        {
            [PrimaryKey, AutoIncrement]
            public int QRCodes_ID { get; set; }
            public string QRCodes_Name { get; set; }
            public string QRCodes_IMG { get; set; }
            public int QRCodes_Pos { get; set; }
        }

    }
}