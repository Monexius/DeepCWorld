using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;


namespace DeepSeaWorldApp.DBClasses
{
    // database data variables for synchronization
    public class DBs
    {

        public class FAQ 
        {
            [JsonProperty("FAQ_ID")][PrimaryKey]
            public int ID { get; set; }
            [JsonProperty("FAQ_Question")]
            public string FAQ_Question { get; set; }
            [JsonProperty("FAQ_Anwswere")]
            public string FAQ_Anwswere { get; set; }
        }

        // list of data from faq table
        public class FAQList
        {
            public FAQ[] Faq { get; set; }
        }

        public class Events
        {
            [JsonProperty("Event_ID")][PrimaryKey]
            public int ID { get; set; }
            [JsonProperty("Event_Name")]
            public string Event_Name { get; set; }
            [JsonProperty("Event_Description")]
            public string Event_Description { get; set; }
            [JsonProperty("Event_IMG")]
            public string Event_IMG { get; set; }
            [JsonProperty("Event_Location")]
            public string Event_Location { get; set; }
            [JsonProperty("Event_Day")]
            public string Event_Day { get; set; }
            [JsonProperty("Event_Time")]
            public string Event_Time { get; set; }
        }

        // list of data from events table
        public class EventsList
        {
            public Events[] Events { get; set; }
        }

        public class Exhibition
        {
            [JsonProperty("Exhibition_ID")][PrimaryKey]
            public int ID { get; set; }
            [JsonProperty("Exhibition_QRCode_Pos")]
            public int Exhibition_QRCode_Pos { get; }
            [JsonProperty("Exhibition_Description")]
            public string Exhibition_Description { get; set; }
            [JsonProperty("Exhibition_IMG_Name")]
            public string Exhibition_IMG_Name { get; set; }
            [JsonProperty("Exhibition_IMG")]
            public string Exhibition_IMG { get; set; }
            [JsonProperty("Exhibition_Video_Name")]
            public string Exhibition_Video_Name { get; set; }
            [JsonProperty("Exhibition_Video")]
            public string Exhibition_Video { get; set; }
            [JsonProperty("Exhibition_Name")]
            public string Exhibition_Name { get; set; }
            [JsonProperty("QRCode_Name")]
            public string QRCode_Name { get; }
        }

        // list of data from Exhibition table
        public class ExhibitionList
        {
            public Exception[] Exhibitions { get; set; }
        }

        public class Map
        {
            [JsonProperty("Map_ID")][PrimaryKey]
            public int ID { get; set; }
            [JsonProperty("Map_IMG")]
            public string Map_IMG { get; set; }
        }

        // list of data from Map table
        public class MapList
        {
            public Map[] Map { get; set; }
        }

        public class News
        {
            [JsonProperty("News_ID")][PrimaryKey]
            public int ID { get; set; }
            [JsonProperty("News_Title")]
            public string News_Title { get; set; }
            [JsonProperty("News_Info")]
            public string News_Brief_Info { get; set; }
            [JsonProperty("News_IMG")]
            public string News_IMG { get; set; }
            [JsonProperty("News_Article")]
            public string News_Article { get; set; }
            [JsonProperty("Notifications")]
            public string Notifications { get; set; }
        }

        // list of data from News table
        public class NewsList
        {
            public News[] News { get; set; }
        }

        public class QRCodes
        {
            [JsonProperty("QRCodes_ID")][PrimaryKey]
            public int ID { get; set; }
            [JsonProperty("QRCodes_Name")]
            public string QRCodes_Name { get; set; }
            [JsonProperty("QRCodes_IMG")]
            public string QRCodes_IMG { get; set; }
            [JsonProperty("QRCodes_Pos")]
            public int QRCodes_Pos { get; set; }
        }

        // list of data from QRCodes table
        public class QRCodesList
        {
            public QRCodes[] QRs { get; set; }
        }



        public class Data
        {
            [JsonProperty("FAQ_ID")]
            [PrimaryKey]
            public string FAQ_ID { get; set; }
            [JsonProperty("FAQ_Question")]
            public string FAQ_Question { get; set; }
            [JsonProperty("FAQ_Anwsere")]
            public string FAQ_Anwswere { get; set; }

            [JsonProperty("Event_ID")]
            [PrimaryKey]
            public int Event_ID { get; set; }
            [JsonProperty("Event_Name")]
            public string Event_Name { get; set; }
            [JsonProperty("Event_Description")]
            public string Event_Description { get; set; }
            [JsonProperty("Event_IMG")]
            public string Event_IMG { get; set; }
            [JsonProperty("Event_Location")]
            public string Event_Location { get; set; }
            [JsonProperty("Event_Day")]
            public string Event_Day { get; set; }
            [JsonProperty("Event_Time")]
            public string Event_Time { get; set; }

            [JsonProperty("Exhibition_ID")]
            [PrimaryKey]
            public int Exhibition_ID { get; set; }
            [JsonProperty("Exhibition_QRCode_Pos")]
            public int Exhibition_QRCode_Pos { get; }
            [JsonProperty("Exhibition_Description")]
            public string Exhibition_Description { get; set; }
            [JsonProperty("Exhibition_IMG_Name")]
            public string Exhibition_IMG_Name { get; set; }
            [JsonProperty("Exhibition_IMG")]
            public string Exhibition_IMG { get; set; }
            [JsonProperty("Exhibition_Video_Name")]
            public string Exhibition_Video_Name { get; set; }
            [JsonProperty("Exhibition_Video")]
            public string Exhibition_Video { get; set; }
            [JsonProperty("Exhibition_Name")]
            public string Exhibition_Name { get; set; }
            [JsonProperty("QRCode_Name")]
            public string QRCode_Name { get; }

            [JsonProperty("Map_ID")]
            [PrimaryKey]
            public int Map_ID { get; set; }
            [JsonProperty("Map_IMG")]
            public string Map_IMG { get; set; }

            [JsonProperty("News_ID")]
            [PrimaryKey]
            public int News_ID { get; set; }
            [JsonProperty("News_Title")]
            public string News_Title { get; set; }
            [JsonProperty("News_Info")]
            public string News_Brief_Info { get; set; }
            [JsonProperty("News_IMG")]
            public string News_IMG { get; set; }
            [JsonProperty("News_Article")]
            public string News_Article { get; set; }
            [JsonProperty("Notifications")]
            public string Notifications { get; set; }

            [JsonProperty("QRCodes_ID")]
            [PrimaryKey]
            public int QRCodes_ID { get; set; }
            [JsonProperty("QRCodes_Name")]
            public string QRCodes_Name { get; set; }
            [JsonProperty("QRCodes_IMG")]
            public string QRCodes_IMG { get; set; }
            [JsonProperty("QRCodes_Pos")]
            public int QRCodes_Pos { get; set; }
        }

        public class dbList
        {
            public List<Data> DataList { get; set; }
        }

        public class DataL
        {
            public List<FAQList> fList { get; set; }
            public List<EventsList> eList { get; set; }
            public List<ExhibitionList> exList { get; set; }
            public List<MapList> mList { get; set; }
            public List<NewsList> nList { get; set; }
            public List<QRCodesList> qrList { get; set; }
        }

        //public class dbList2
        //{
        //    public List<DataL> DataList2 { get; set; }
        //}



    }

}
