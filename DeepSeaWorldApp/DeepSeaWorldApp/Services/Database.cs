using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Events>().Wait();
            _database.CreateTableAsync<Exhibition>().Wait();
            _database.CreateTableAsync<FAQ>().Wait();
            LoadEventsData();
            LoadExhibitionData();
            LoadFAQData();
        }

        public void LoadEventsData()
        {
            if (_database.Table<Events>().CountAsync().Result == 0)
            {
                // only insert the data if it doesn't already exist
                var events = new List<Events>
                {
                    new Events { Events_ID = 0, Event_Time = "10:30",   Event_Name="Meet a Reptile",                    Event_Location="Shark Classroom",       Event_Day="Daily",                              Event_Description="Meet our selection of reptiles from all over the world", Event_IMG="lizard.jpeg"},
                    new Events { Events_ID = 1, Event_Time = "11:00",   Event_Name="Daily Feed: Rockpool",              Event_Location="The Swamp",             Event_Day="Monday",                             Event_Description="Watch our animals get something to eat",                 Event_IMG="lobster.jpeg"},
                    new Events { Events_ID = 2, Event_Time = "11:00",   Event_Name="Daily Feed: Snapping Turtle/Frogs", Event_Location="Temple of Frogs",       Event_Day="Tuesday",                            Event_Description="Watch our animals get something to eat",                 Event_IMG="frog.jpeg"},
                    new Events { Events_ID = 3, Event_Time = "11:00",   Event_Name="Daily Feed: Amazon",                Event_Location="The Swamp" ,            Event_Day="Wednesday",                          Event_Description="Watch our animals get something to eat",                 Event_IMG="turtle.jpeg"},
                    new Events { Events_ID = 4, Event_Time = "11:00",   Event_Name="Daily Feed: Mangrove",              Event_Location= "Rockpool Main Hall",   Event_Day="Thursday",                           Event_Description="Watch our animals get something to eat",                 Event_IMG="stripedfish.jpeg"},
                    new Events { Events_ID = 5, Event_Time = "11:00",   Event_Name="Daily Feed: Bearded Dragon",        Event_Location= "Shark Classroom",      Event_Day="Friday",                             Event_Description="Watch our animals get something to eat",                 Event_IMG="frog.jpeg"},
                    new Events { Events_ID = 6, Event_Time = "11:00",   Event_Name="Daily Feed: Amazon",                Event_Location= "The Swamp",            Event_Day="Saturday",                           Event_Description="Watch our animals get something to eat",                 Event_IMG="turtle.jpeg"},
                    new Events { Events_ID = 7, Event_Time = "11:00",   Event_Name="Daily Feed: Piranha",               Event_Location= "The Swamp",            Event_Day="Sunday",                             Event_Description="Watch our animals get something to eat",                 Event_IMG="glowfish.jpeg"},
                    new Events { Events_ID = 8, Event_Time = "11:30",   Event_Name="Seal Feed",                         Event_Location= "Seal Harbour",         Event_Day="Daily",                              Event_Description="Watch our seals get something to eat",                   Event_IMG="seal.jpeg"},
                    new Events { Events_ID = 9, Event_Time = "12:00",   Event_Name="Rockpool Encounter",                Event_Location= "Rockpool Main Hall",   Event_Day="Daily",                              Event_Description="Meet our animals at the Rockpool",                       Event_IMG="lizard.jpeg"},
                    new Events { Events_ID = 10, Event_Time = "12:30",  Event_Name="Amazon Adventure",                  Event_Location= "The Swamp",            Event_Day="Daily",                              Event_Description="Join us on an adventure to the Amazon",                  Event_IMG="octopus.jpeg"},
                    new Events { Events_ID = 11, Event_Time = "13:00",  Event_Name="Ocean Feed",                        Event_Location= "Underwater Tunnel",    Event_Day="Daily",                              Event_Description="Watch our animals get something to eat",                 Event_IMG="stripedfish.jpeg"},
                    new Events { Events_ID = 12, Event_Time = "13:30",  Event_Name="Tropical Reef & Seahorse Feed",     Event_Location= "Rockpool Main Hall",   Event_Day="Daily",                              Event_Description="Watch our animals get something to eat",                 Event_IMG="nemo.jpeg"},
                    new Events { Events_ID = 13, Event_Time = "14:00",  Event_Name="Creepy Crawly Encounter",           Event_Location= "Shark Classroom",      Event_Day="Monday, Tuesday, Thursday, Friday",  Event_Description="Meet our creepy crawlies",                               Event_IMG="millipede.jpeg"},
                    new Events { Events_ID = 14, Event_Time = "14:00",  Event_Name="Big Shark Feeds",                   Event_Location= "Underwater Tunnel",    Event_Day="Wednesday, Saturday",                Event_Description="Watch our big sharks get something to eat",              Event_IMG="shark.jpeg"},
                    new Events { Events_ID = 15, Event_Time = "14:00",  Event_Name="Small Shark Feeds",                 Event_Location= "Underwater Tunnel",    Event_Day="Sunday",                             Event_Description="Watch our small sharks and rays get something to eat",   Event_IMG="ray.jpeg"},
                    new Events { Events_ID = 16, Event_Time = "14:30",  Event_Name="Featured Event Talk",               Event_Location= "Shark Classroom",      Event_Day="Daily",                              Event_Description="Featured Event Talk",                                    Event_IMG="shark2.jpeg"},
                    new Events { Events_ID = 17, Event_Time = "15:00",  Event_Name="Seal Feed",                         Event_Location= "Seal Harbour",         Event_Day="Daily",                              Event_Description="Watch our seals get something to eat",                   Event_IMG="seal2.jpeg"},
                    new Events { Events_ID = 18, Event_Time = "15:30",  Event_Name="Meet a Reptile",                    Event_Location= "Shark Classroom",      Event_Day="Daily",                              Event_Description="Meet our selection of reptiles from all over the world", Event_IMG="turtle.jpeg"},
                    new Events { Events_ID = 19, Event_Time = "16:00",  Event_Name="Underwater Safari",                 Event_Location= "Underwater Tunnel",    Event_Day="Daily",                              Event_Description="Join us on an underwater safari",                        Event_IMG="school.jpeg"},
                    new Events { Events_ID = 20, Event_Time = "16:30",  Event_Name="Rockpool Encounter",                Event_Location= "Rockpool Main Hall",   Event_Day="Daily",                              Event_Description="Meet our animals at the Rockpool",                       Event_IMG="lobster.jpeg"},
                    new Events { Events_ID = 21, Event_Time = "17:00",  Event_Name="Creepy Crawly Encounter",           Event_Location= "Shark Classroom",      Event_Day="Saturday, Sunday, Holidays",         Event_Description="Meet our creepy crawlies",                               Event_IMG="millipede.jpeg"},
                };
                foreach (var e in events)
                {
                    _database.InsertAsync(e);
                }
            }
        }

        public void LoadExhibitionData()
        {
            if (_database.Table<Exhibition>().CountAsync().Result == 0)
            {
                // only insert the data if it doesn't already exist
                List<Exhibition> exhibitions = new List<Exhibition>
                {
                    new Exhibition {Exhibition_ID=0,
                                    Exhibition_IMG="seal3.jpeg",
                                    Exhibition_Name="Seals",
                                    Exhibition_Video="sealv.mp4",
                                    Exhibition_IMG_Name="img", Exhibition_Video_Name="vid",
                                    Exhibition_Description="Common seals are skilled predators, believe it or not! By storing oxygen in their muscles and blood, rather than in their lungs, they can dive for up to 30 minutes, searching for their favourite food. They eat plenty of different things, but they love small sea creatures like oily fish, squid, and molluscs the most!",
                                    QRCodes_Name="F767-348G56"},
                    new Exhibition {Exhibition_ID=1,
                                    Exhibition_IMG="shark2.jpeg",
                                    Exhibition_Name="Sand Sharks",
                                    Exhibition_Video="fish.mp4",
                                    Exhibition_IMG_Name="img", Exhibition_Video_Name="vid",
                                    Exhibition_Description="The Sand Tiger shark is the largest shark on display at Deep Sea World and can grow up to three and a half metres in length.\nSand Tiger sharks are also known as grey nurse or ragged tooth sharks and are normally found around Australia, Africa and America.",
                                    QRCodes_Name="F767-459E36"}
                };
                foreach (var e in exhibitions)
                {
                    _database.InsertAsync(e);
                }
            }
        }

        public void LoadFAQData()
        {
            if (_database.Table<FAQ>().CountAsync().Result == 0)
            {
                // only insert the data if it doesn't already exist
                var newFAQ = new FAQ();
                newFAQ.FAQ_ID = 1;
                newFAQ.FAQ_Question = "Question1";
                newFAQ.FAQ_Anwswere = "Answer1";
                _database.InsertAsync(newFAQ);

                var newFAQ2 = new FAQ();
                newFAQ2.FAQ_ID = 2;
                newFAQ2.FAQ_Question = "Question2";
                newFAQ2.FAQ_Anwswere = "Answer2";
                _database.InsertAsync(newFAQ2);

                var newFAQ3 = new FAQ();
                newFAQ3.FAQ_ID = 3;
                newFAQ3.FAQ_Question = "Question3";
                newFAQ3.FAQ_Anwswere = "Answer3";
                _database.InsertAsync(newFAQ3);
            }
        }

        public Task<List<FAQ>> GetFAQsAsync()
        {
            return _database.Table<FAQ>().ToListAsync();
        }

        public Task<FAQ> GetFAQAsync(int id)
        {
            return _database.Table<FAQ>()
                            .Where(i => i.FAQ_ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFAQAsync(FAQ faq)
        {
            if (faq.FAQ_ID != 0)
            {
                return _database.UpdateAsync(faq);
            }
            else
            {
                return _database.InsertAsync(faq);
            }
        }

        public Task<int> DeleteFAQAsync(FAQ faq)
        {
            return _database.DeleteAsync(faq);
        }


        public Task<List<Exhibition>> GetExhibitionsAsync()
        {
            return _database.Table<Exhibition>().ToListAsync();
        }

        public Task<Exhibition> GetExhibitionsAsync(int id)
        {
            return _database.Table<Exhibition>()
                            .Where(i => i.Exhibition_ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Exhibition> GetExhibitionsAsync(string qrcode)
        {
            return _database.Table<Exhibition>()
                            .Where(i => i.QRCodes_Name == qrcode)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveExhibitionAsync(Exhibition exhibition)
        {
            if (exhibition.Exhibition_ID != 0)
            {
                return _database.UpdateAsync(exhibition);
            }
            else
            {
                return _database.InsertAsync(exhibition);
            }
        }

        public Task<int> DeleteExhibitionAsync(Exhibition exhibition)
        {
            return _database.DeleteAsync(exhibition);
        }

        public Task<List<Events>> GetEventsAsync()
        {
            return _database.Table<Events>().ToListAsync();
        }

        public Task<Events> GetEventsAsync(int id)
        {
            return _database.Table<Events>()
                            .Where(i => i.Events_ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEventsAsync(Events events)
        {
            if (events.Events_ID != 0)
            {
                return _database.UpdateAsync(events);
            }
            else
            {
                return _database.InsertAsync(events);
            }
        }

        public Task<int> DeleteEventsAsync(Events events)
        {
            return _database.DeleteAsync(events);
        }
    }
}
