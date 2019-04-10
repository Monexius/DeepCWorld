using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;


namespace DeepSeaWorldApp.DBClasses
{
    // database data variables for synchronization
    public class DBs
    {
        [Table("FAQ")]
        public class FAQ 
        {
            [JsonProperty("FAQ_ID")][PrimaryKey]
            public int FAQ_ID { get; set; }
            [JsonProperty("FAQ_Question")]
            public string FAQ_Question { get; set; }
            [JsonProperty("FAQ_Anwswere")]
            public string FAQ_Anwswere { get; set; }
        }


        [Table("Events")]
        public class Events
        {
            [JsonProperty("Event_ID")][PrimaryKey]
            public int Events_ID { get; set; }
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

        [Table("Exhibition")]
        public class Exhibition
        {
            [JsonProperty("Exhibition_ID")][PrimaryKey]
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
            [JsonProperty("QRCodes_Name")]
            public string QRCodes_Name { get; set; }
        }

        [Table("Map")]
        public class Map
        {
            [JsonProperty("Map_ID")][PrimaryKey]
            public int Map_ID { get; set; }
            [JsonProperty("Map_IMG")]
            public string Map_IMG { get; set; }
        }

        [Table("News")]
        public class News
        {
            [JsonProperty("News_ID")][PrimaryKey]
            public int News_ID { get; set; }
            [JsonProperty("News_Title")]
            public string News_Title { get; set; }
            [JsonProperty("News_Brief_Info")]
            public string News_Brief_Info { get; set; }
            [JsonProperty("News_IMG")]
            public string News_IMG { get; set; }
            [JsonProperty("News_Article")]
            public string News_Article { get; set; }
            [JsonProperty("Notification")]
            public string Notifications { get; set; }
        }

        [Table("QRCodes")]
        public class QRCodes
        {
            [JsonProperty("QRCodes_ID")][PrimaryKey]
            public int QRCodes_ID { get; set; }
            [JsonProperty("QRCode_Name")]
            public string QRCodes_Name { get; set; }
            [JsonProperty("QRCode_IMG")]
            public string QRCodes_IMG { get; set; }
            [JsonProperty("QRCodes_Pos")]
            public int QRCodes_Pos { get; set; }
        }

        public class DataTb
        {
            public List<FAQ> FAQ { get; set; }
            public List<Events> Events { get; set; }
            public List<Exhibition> Exhibition { get; set; }
            public List<Map> Map { get; set; }
            public List<News> News { get; set; }
            public List<QRCodes> QRCodes { get; set; }
        }
    }

}
