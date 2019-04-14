using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.Services
{
    public class MockDataStore : IDataStore<Event>
    {
        List<Event> events;

        public MockDataStore()
        {
            events = new List<Event>();
            var mockEvents = new List<Event>
            {
                new Event { Id = Guid.NewGuid().ToString(), Time = "10:30", Name="Meet a Reptile", Location="Shark Classroom"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "11:00", Name="Daily Morning Feed", Location="Various"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "12:30", Name="Seal Feed", Location= "Seal Harbour"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "11:30", Name="Rockpool Encounter", Location="Rockpool Main Hall"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "12:00", Name="Seahorse Talk", Location="Rockpool Main Hall"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "13:00", Name="Ocean Feed", Location="Underwater Tunnel"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "13:30", Name="Rain Forest Talk", Location="The Swamp",
                Description="rain forest talk description...", Image="deep_sea.png"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "14:00", Name="Creepy Crawly Encounter", Location="Shark Classroom"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "15:30", Name="Daily Afternoon Feed", Location="Various"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "15:00", Name="Seal Feed", Location="Seal Harbour"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "14:30", Name="Meet a Reptile", Location="Shark Classroom"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "16:00", Name="Underwater Safari", Location="Underwater Tunnel"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "16:30", Name="Rockpool Encounter", Location="Rockpool Main Hall",
                Description="rockpool encounter description...", Image="deep_sea.png"},
                new Event { Id = Guid.NewGuid().ToString(), Time = "17:00", Name="Creepy Crawly Encounter", Location="Shark Classroom",
                Description="creepy crawly encounter description...", Image="deep_sea.png"},
            };
            //order events by time
            var orderByTime = from s in mockEvents
                                orderby s.Time
                                select s;
            foreach (var e in orderByTime)
            {
                //Console.WriteLine("name " + e.Name + " time: " + e.Time);
                events.Add(e);
            }

        }

        public async Task<bool> AddItemAsync(Event e)
        {
            events.Add(e);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Event e)
        {
            var oldEvent = events.Where((Event arg) => arg.Id == e.Id).FirstOrDefault();
            events.Remove(oldEvent);
            events.Add(e);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldEvent = events.Where((Event arg) => arg.Id == id).FirstOrDefault();
            events.Remove(oldEvent);

            return await Task.FromResult(true);
        }

        public async Task<Event> GetItemAsync(string id)
        {
            return await Task.FromResult(events.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(events);
        }

        public async Task<Event> GetItemByTime(string time)
        {
            Event e = new Event();

            Event fail = new Event
            {
                Id = Guid.NewGuid().ToString(),
                Time = "10:30",
                Name = "FAIL",
                Location = "Shark Classroom"
            };
            foreach (var i in events)
            {
                if (i.Time == time)
                {
                    e = i;
                }
            }
            if (e.Name == "")
            {
                e = fail;
            }
            return await Task.FromResult(e);
        }

        public async Task<Event> GetNextEvent()
        {
            DateTime now = DateTime.Now;
            List<Event> nextEvents = new List<Event>();
            Event nextE = new Event();

            foreach (var x in events)
            {
                DateTime time = Convert.ToDateTime(x.Time).AddMinutes(5);
                //if time hasn't passed, add to next events list
                if (time.TimeOfDay.Hours > now.TimeOfDay.Hours)
                {
                    nextEvents.Add(x);
                }
                else if(time.TimeOfDay.Hours == now.TimeOfDay.Hours)
                {
                    if(time.TimeOfDay.Minutes > now.TimeOfDay.Minutes)
                    {
                        nextEvents.Add(x);
                    }
                }
            }
            bool NextisEmpty = !nextEvents.Any();
            if (NextisEmpty)
            {
                Event fail = new Event { Id = Guid.NewGuid().ToString(), Time = "00:00", Name = "No more events today", Location = "" };
                return await Task.FromResult(fail);
            }
            nextE = nextEvents[0]; 

            return await Task.FromResult(nextE);
        }
    }
}