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
            dataTb = AddData(dataTb);
            Console.WriteLine(dataTb.Events[0].Event_Name);
            return dataTb;
        }
        public static DataTb AddData(DataTb data)
        {

            var faqs = new List<FAQ>
            {
                new FAQ { FAQ_ID=0,FAQ_Question="question1",FAQ_Anwswere="answer1"}
            };

            var events = new List<Events>
            {
                new Events { Events_ID = 0, Event_Time = "10:30",   Event_Name="Meet a Reptile",                    Event_Location="Shark Classroom",       Event_Day="Daily",                              Event_Description="Meet our selection of reptiles from all over the world", Event_IMG="lizard.jpeg"},
                new Events { Events_ID = 1, Event_Time = "11:00",   Event_Name="Daily Feed: Rockpool",              Event_Location="The Swamp",             Event_Day="Monday",                             Event_Description="Watch our animals get something to eat",                 Event_IMG="lobster.jpeg"},
                new Events { Events_ID = 2, Event_Time = "11:00",   Event_Name="Daily Feed: Snapping Turtle/Frogs", Event_Location="Temple of Frogs",       Event_Day="Tuesday",                            Event_Description="Watch our animals get something to eat",                 Event_IMG="frog.jpeg"},
                new Events { Events_ID = 3, Event_Time = "11:00",   Event_Name="Daily Feed: Amazon",                Event_Location="The Swamp" ,            Event_Day="Wednesday",                          Event_Description="Watch our animals get something to eat",                 Event_IMG="turtle.jpeg"},
                new Events { Events_ID = 4, Event_Time = "11:00",   Event_Name="Daily Feed: Mangrove",              Event_Location= "Rockpool Main Hall",   Event_Day="Thursday",                           Event_Description="Watch our animals get something to eat",                 Event_IMG="stripedfish.jpeg"},
                new Events { Events_ID = 5, Event_Time = "11:00",   Event_Name="Daily Feed: Bearded Dragon",        Event_Location= "Shark Classroom",      Event_Day="Friday",                             Event_Description="Watch our animals get something to eat",                 Event_IMG="lizard.jpeg"},
                new Events { Events_ID = 6, Event_Time = "11:00",   Event_Name="Daily Feed: Amazon",                Event_Location= "The Swamp",            Event_Day="Saturday",                           Event_Description="Watch our animals get something to eat",                 Event_IMG="turtle.jpeg"},
                new Events { Events_ID = 7, Event_Time = "11:00",   Event_Name="Daily Feed: Piranha",               Event_Location= "The Swamp",            Event_Day="Sunday",                             Event_Description="Watch our animals get something to eat",                 Event_IMG="glowfish.jpeg"},
                new Events { Events_ID = 8, Event_Time = "11:30",   Event_Name="Seal Feed",                         Event_Location= "Seal Harbour",         Event_Day="Daily",                              Event_Description="Watch our seals get something to eat",                   Event_IMG="deep_sea.png"},
                new Events { Events_ID = 9, Event_Time = "12:00",   Event_Name="Rockpool Encounter",                Event_Location= "Rockpool Main Hall",   Event_Day="Daily",                              Event_Description="Meet our animals at the Rockpool",                       Event_IMG="deep_sea.png"},
                new Events { Events_ID = 10, Event_Time = "12:30",  Event_Name="Amazon Adventure",                  Event_Location= "The Swamp",            Event_Day="Daily",                              Event_Description="Join us on an adventure to the Amazon",                  Event_IMG="deep_sea.png"},
                new Events { Events_ID = 11, Event_Time = "13:00",  Event_Name="Ocean Feed",                        Event_Location= "Underwater Tunnel",    Event_Day="Daily",                              Event_Description="Watch our animals get something to eat",                 Event_IMG="deep_sea.png"},
                new Events { Events_ID = 12, Event_Time = "13:30",  Event_Name="Tropical Reef & Seahorse Feed",     Event_Location= "Rockpool Main Hall",   Event_Day="Daily",                              Event_Description="Watch our animals get something to eat",                 Event_IMG="deep_sea.png"},
                new Events { Events_ID = 13, Event_Time = "14:00",  Event_Name="Creepy Crawly Encounter",           Event_Location= "Shark Classroom",      Event_Day="Monday, Tuesday, Thursday, Friday",  Event_Description="Meet our creepy crawlies",                               Event_IMG="deep_sea.png"},
                new Events { Events_ID = 14, Event_Time = "14:00",  Event_Name="Big Shark Feeds",                   Event_Location= "Underwater Tunnel",    Event_Day="Wednesday, Saturday",                Event_Description="Watch our big sharks get something to eat",              Event_IMG="deep_sea.png"},
                new Events { Events_ID = 15, Event_Time = "14:00",  Event_Name="Small Shark Feeds",                 Event_Location= "Underwater Tunnel",    Event_Day="Sunday",                             Event_Description="Watch our small sharks and rays get something to eat",   Event_IMG="deep_sea.png"},
                new Events { Events_ID = 16, Event_Time = "14:30",  Event_Name="Featured Event Talk",               Event_Location= "Shark Classroom",      Event_Day="Daily",                              Event_Description="Featured Event Talk",                                    Event_IMG="deep_sea.png"},
                new Events { Events_ID = 17, Event_Time = "15:00",  Event_Name="Seal Feed",                         Event_Location= "Seal Harbour",         Event_Day="Daily",                              Event_Description="Watch our seals get something to eat",                   Event_IMG="deep_sea.png"},
                new Events { Events_ID = 18, Event_Time = "15:30",  Event_Name="Meet a Reptile",                    Event_Location= "Shark Classroom",      Event_Day="Daily",                              Event_Description="Meet our selection of reptiles from all over the world", Event_IMG="deep_sea.png"},
                new Events { Events_ID = 19, Event_Time = "16:00",  Event_Name="Underwater Safari",                 Event_Location= "Underwater Tunnel",    Event_Day="Daily",                              Event_Description="Join us on an underwater safari",                        Event_IMG="deep_sea.png"},
                new Events { Events_ID = 20, Event_Time = "16:30",  Event_Name="Rockpool Encounter",                Event_Location= "Rockpool Main Hall",   Event_Day="Daily",                              Event_Description="Meet our animals at the Rockpool",                       Event_IMG="deep_sea.png"},
                new Events { Events_ID = 21, Event_Time = "17:00",  Event_Name="Creepy Crawly Encounter",           Event_Location= "Shark Classroom",      Event_Day="Saturday, Sunday, Holidays",         Event_Description="Meet our creepy crawlies",                               Event_IMG="deep_sea.png"},
            };

            var exhibition = new List<Exhibition>
            {
                new Exhibition { }
            };

            var map = new List<Map>
            {
                new Map { }
            };
            var news = new List<News>
            {
                new News { }
            };
            var qrcodes = new List<QRCodes>
            {
                new QRCodes { }
            };

            data.FAQ = faqs;
            data.Events = events;
            data.Exhibition = exhibition;
            data.Map = map;
            data.News = news;
            data.QRCodes = qrcodes;
            return data;
        }


    }
}
