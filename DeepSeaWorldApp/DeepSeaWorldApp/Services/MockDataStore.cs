using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class MockDataStore : IDataStore<Events>
    {
        List<Events> events;

        public MockDataStore()
        {
            events = new List<Events>();
            var mockEvents = new List<Events>
            {
                new Events { Events_ID = 0, Event_Time = "10:30", Event_Name="Meet a Reptile", Event_Location="Shark Classroom"},
                new Events { Events_ID = 1, Event_Time = "11:00", Event_Name="Daily Morning Feed", Event_Location="Various"},
                new Events { Events_ID = 2, Event_Time = "12:30", Event_Name="Seal Feed", Event_Location= "Seal Harbour"}
            };
            //order events by time
            var orderByTime = from s in mockEvents
                                orderby s.Event_Time
                                select s;
            foreach (var e in orderByTime)
            {
                //Console.WriteLine("name " + e.Name + " time: " + e.Time);
                events.Add(e);
            }

        }

        public async Task<bool> AddItemAsync(Events e)
        {
            events.Add(e);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Events e)
        {
            var oldEvent = events.Where((Events arg) => arg.Id == e.Id).FirstOrDefault();
            events.Remove(oldEvent);
            events.Add(e);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldEvent = events.Where((Events arg) => arg.Events_ID == id).FirstOrDefault();
            events.Remove(oldEvent);

            return await Task.FromResult(true);
        }

        public async Task<Events> GetItemAsync(int id)
        {
            return await Task.FromResult(events.FirstOrDefault(s => s.Events_ID == id));
        }

        public async Task<IEnumerable<Events>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(events);
        }

        public async Task<Events> GetItemByTime(string time)
        {
            Events e = new Events();

            Events fail = new Events
            {
                Events_ID = 100,
                Event_Time = "10:30",
                Event_Name = "FAIL",
                Event_Location = "Shark Classroom"
            };
            foreach (var i in events)
            {
                if (i.Event_Time == time)
                {
                    e = i;
                }
            }
            if (e.Event_Name == "")
            {
                e = fail;
            }
            return await Task.FromResult(e);
        }

        public async Task<Events> GetNextEvent()
        {
            DateTime now = DateTime.Now;
            List<Events> nextEvents = new List<Events>();
            Events nextE = new Events();

            foreach (var x in events)
            {
                DateTime time = Convert.ToDateTime(x.Event_Time).AddMinutes(5);
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
                Events fail = new Events { Events_ID = 100, Event_Time = "00:00", Event_Name = "No more events today", Event_Location = "" };
                return await Task.FromResult(fail);
            }
            nextE = nextEvents[0]; 

            return await Task.FromResult(nextE);
        }
    }
}