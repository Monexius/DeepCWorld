using System;
using System.Collections.Generic;
using DeepSeaWorldApp.iOS;
using Xamarin.Forms;
using SQLite;
using System.IO;
using static DeepSeaWorldApp.DBClasses.DBs;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DeepSeaWorldSQLiteConnectioniOS))]

namespace DeepSeaWorldApp.iOS
{
    class DeepSeaWorldSQLiteConnectioniOS : DeepSeaWorldSQLiteInterface
    {

        MySqlDBCon mySql = new MySqlDBCon();
        DataTb dataT = new DataTb();


        public DeepSeaWorldSQLiteConnectioniOS()
        {

        }

        // creating sqlite connection
        public SQLite.SQLiteAsyncConnection CreateConnection()
        {
            var SQLiteFile = "DeepSeaWorldSQLite.db";

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string directory = Path.Combine(folder, "..", "Library", "Databases");
            string path = Path.Combine(directory, SQLiteFile);
            var conn = new SQLite.SQLiteAsyncConnection(path);
            return conn;
        }


        // Creating Tables in local db
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


        // Insert, update all tables in local db
        public async Task InsertUpdateTables(DataTb data)
        {
            foreach (FAQ f in data.FAQ)
            {
                await InsertOrUpdateTableAsyncFAQ(f);
            }

            foreach (Events e in data.Events)
            {
                await InsertOrUpdateTableAsyncEvents(e);
            }

            foreach (Exhibition ex in data.Exhibition)
            {
                await InsertOrUpdateTableAsyncExhibition(ex);
            }

            foreach (Map m in data.Map)
            {
                await InsertOrUpdateTableAsyncMap(m);
            }

            foreach (News n in data.News)
            {
                await InsertOrUpdateTableAsyncNews(n);
            }

            foreach (QRCodes qr in data.QRCodes)
            {
                await InsertOrUpdateTableAsyncQRCodes(qr);
            }
        }

        // Get local db table items from FAQ 
        public Task<List<FAQ>> GetItemAsyncFAQ()
        {
            return CreateConnection().Table<FAQ>().ToListAsync();
        }

        // Get local db table items from Events
        public Task<List<Events>> GetItemAsyncEvents()
        {
            return CreateConnection().Table<Events>().ToListAsync();
        }

        // Get local db table items from Exhibition
        public Task<List<Exhibition>> GetItemAsyncExhibition()
        {
            return CreateConnection().Table<Exhibition>().ToListAsync();
        }

        // Get local db table items from Map
        public Task<List<Map>> GetItemAsyncMap()
        {
            return CreateConnection().Table<Map>().ToListAsync();
        }

        // Get local db table items from News
        public Task<List<News>> GetItemAsyncNews()
        {
            return CreateConnection().Table<News>().ToListAsync();
        }

        // Get local db table items from QRCodes
        public Task<List<QRCodes>> GetItemAsyncQRCodes()
        {
            return CreateConnection().Table<QRCodes>().ToListAsync();
        }

        // Get local db item from FAQ table depending on id
        public Task<FAQL> GetItemAsyncFAQ(int id)
        {
            return CreateConnection().Table<FAQL>().Where(i => i.FAQ_ID == id).FirstOrDefaultAsync();
        }

        // Get local db item from Events table depending on id
        public Task<EventsL> GetItemAsyncEvents(int id)
        {
            return CreateConnection().Table<EventsL>().Where(i => i.Events_ID == id).FirstOrDefaultAsync();
        }

        // Get local db item from Exhibition table depending on id
        public Task<ExhibitionL> GetItemAsyncExhibition(int id)
        {
            return CreateConnection().Table<ExhibitionL>().Where(i => i.Exhibition_ID == id).FirstOrDefaultAsync();
        }

        // Get local db item from Map table depending on id
        public Task<MapL> GetItemAsyncMap(int id)
        {
            return CreateConnection().Table<MapL>().Where(i => i.Map_ID == id).FirstOrDefaultAsync();
        }

        // Get local db item from News table depending on id
        public Task<NewsL> GetItemAsyncNews(int id)
        {
            return CreateConnection().Table<NewsL>().Where(i => i.News_ID == id).FirstOrDefaultAsync();
        }

        // Get local db item from QRCodes table depending on id
        public Task<QRCodesL> GetItemAsyncQRCodes(int id)
        {
            return CreateConnection().Table<QRCodesL>().Where(i => i.QRCodes_ID == id).FirstOrDefaultAsync();
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

        // FAQ table class 
        [Table("FAQ")]
        public class FAQL
        {
            [PrimaryKey, AutoIncrement]
            public int FAQ_ID { get; set; }
            public string FAQ_Question { get; set; }
            public string FAQ_Anwswere { get; set; }
        }

        // Events table class 
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

        // Exhibition table class 
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

        // Map table class 
        [Table("Map")]
        public class MapL
        {
            [PrimaryKey, AutoIncrement]
            public int Map_ID { get; set; }
            public string Map_IMG { get; set; }
        }

        // News table class 
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

        // QRCodes table class 
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