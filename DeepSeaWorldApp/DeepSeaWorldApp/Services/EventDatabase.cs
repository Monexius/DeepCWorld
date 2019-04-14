using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using DeepSeaWorldApp.Models;
using System.IO;
using System;
using Xamarin.Forms;

namespace DeepSeaWorldApp.Services
{
    public class EventDatabase
    {
        readonly SQLiteAsyncConnection _database;
        List<Event> events;

        public EventDatabase(string dbPath)
        {

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Event>().Wait();

            events = new List<Event>();
            var mockEvents = new List<Event>
            {
                new Event { Id = Guid.NewGuid().ToString(), Time = "10:30", Name="Meet a Reptile", Location="Shark Classroom"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "11:00", Name="Daily Morning Feed", Location="Various"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "11:30", Name="Seal Feed", Location= "Seal Harbour"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "12:00", Name="Rockpool Encounter", Location="Rockpool Main Hall"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "12:30", Name="Seahorse Talk", Location="Rockpool Main Hall"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "13:00", Name="Ocean Feed", Location="Underwater Tunnel"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "13:30", Name="Rain Forest Talk", Location="The Swamp",
                Description="rain forest talk description...", Image="deep_sea.png"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "14:00", Name="Creepy Crawly Encounter", Location="Shark Classroom"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "14:30", Name="Daily Afternoon Feed", Location="Various"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "15:00", Name="Seal Feed", Location="Seal Harbour"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "15:30", Name="Meet a Reptile", Location="Shark Classroom"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "16:00", Name="Underwater Safari", Location="Underwater Tunnel"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "16:30", Name="Rockpool Encounter", Location="Rockpool Main Hall",
                Description="rockpool encounter description...", Image="deep_sea.png"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "17:00", Name="Creepy Crawly Encounter", Location="Shark Classroom",
                Description="creepy crawly encounter description...", Image="deep_sea.png"},
            };

            //int count = 1;
            foreach (var e in mockEvents)
            {
                //events.Add(e);
                SaveEventAsync(e);
            }
        }

        public Task<List<Event>> GetEventsAsync()
        {
            return _database.Table<Event>().ToListAsync();
        }

        public Task<Event> GetEventAsync(int id)
        {
            return _database.Table<Event>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEventAsync(Event e)
        {
            if (e.ID != 0)
            {
                return _database.UpdateAsync(e);
            }
            else
            {
                return _database.InsertAsync(e);
            }
        }

        public Task<int> DeleteEventAsync(Event e)
        {
            return _database.DeleteAsync(e);
        }
    }
}
