using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Text;

namespace DeepSeaWorldApp.DBClasses
{
    // database data variables for synchronization
    public class DBs
    {

        public class FAQ 
        {
            [JsonProperty("FAQ_ID")]
            public string ID { get; set; }
            [JsonProperty("FAQ_Question")]
            public string FAQ_Question { get; set; }
            [JsonProperty("FAQ_Anwsere")]
            public string FAQ_Anwswere { get; set; }
        }

        // list of data from faq table
        public class FAQList
        {
            public List<FAQ> Faq { get; set; }
        }

        public class Events
        {
            [JsonProperty("Event_ID")]
            int ID { get; set; }
            [JsonProperty("Event_Name")]
            string Event_Name { get; set; }
            [JsonProperty("Event_Description")]
            string Event_Description { get; set; }
            [JsonProperty("Event_IMG")]
            string Event_IMG { get; set; }
            [JsonProperty("Event_Location")]
            string Event_Location { get; set; }
            [JsonProperty("Event_Day")]
            string Event_Day { get; set; }
            [JsonProperty("Event_Time")]
            string Event_Time { get; set; }
        }

        // list of data from events table
        public class EventsList
        {
            public List<Events> Events { get; set; }
        }

        public class Exhibition
        {
            [JsonProperty("Exhibition_ID")]
            int ID { get; set; }
            [JsonProperty("Exhibition_QRCode_Pos")]
            int Exhibition_QRCode_Pos { get; }
            [JsonProperty("Exhibition_Description")]
            string Exhibition_Description { get; set; }
            [JsonProperty("Exhibition_IMG_Name")]
            string Exhibition_IMG_Name { get; set; }
            [JsonProperty("Exhibition_IMG")]
            string Exhibition_IMG { get; set; }
            [JsonProperty("Exhibition_Video_Name")]
            string Exhibition_Video_Name { get; set; }
            [JsonProperty("Exhibition_Video")]
            string Exhibition_Video { get; set; }
            [JsonProperty("Exhibition_Name")]
            string Exhibition_Name { get; set; }
            [JsonProperty("QRCode_Name")]
            string QRCode_Name { get; }
        }

        // list of data from Exhibition table
        public class ExhibitionList
        {
            public List<Exhibition> Exhibitions { get; set; }
        }

        public class Map
        {
            [JsonProperty("Map_ID")]
            int ID { get; set; }
            [JsonProperty("Map_IMG")]
            string Map_IMG { get; set; }
        }

        // list of data from Map table
        public class MapList
        {
            public List<Map> Map { get; set; }
        }

        public class News
        {
            [JsonProperty("News_ID")]
            int ID { get; set; }
            [JsonProperty("News_Title")]
            string News_Title { get; set; }
            [JsonProperty("News_Info")]
            string News_Brief_Info { get; set; }
            [JsonProperty("News_IMG")]
            string News_IMG { get; set; }
            [JsonProperty("News_Article")]
            string News_Article { get; set; }
            [JsonProperty("Notifications")]
            string Notifications { get; set; }
        }

        // list of data from News table
        public class NewsList
        {
            public List<News> News { get; set; }
        }

        public class QRCodes
        {
            [JsonProperty("QRCodes_ID")]
            int ID { get; set; }
            [JsonProperty("QRCodes_Name")]
            string QRCodes_Name { get; set; }
            [JsonProperty("QRCodes_IMG")]
            string QRCodes_IMG { get; set; }
            [JsonProperty("QRCodes_Pos")]
            int QRCodes_Pos { get; set; }
        }

        // list of data from QRCodes table
        public class QRCodesList
        {
            public List<QRCodes> QRs { get; set; }
        }

    }

}
