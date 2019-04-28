using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class NextEventService : ContentPage
    {
        public NextEventService()
        {

        }



        //called from: EventsViewModel
        public Task<List<Events>> GetNextEvents(List<Events> events)
        {
            DateTime now = DateTime.Now;
            List<Events> nextEvents = new List<Events>();
            bool holidays = false;

            foreach (var x in events)
            {
                DateTime time = Convert.ToDateTime(x.Event_Time).AddMinutes(5);
                //if time hasn't passed, add to next events list
                if ((x.Event_Day.Contains("Daily")) || (x.Event_Day.Contains(now.DayOfWeek.ToString()))
                        || (x.Event_Day.Contains("Holidays") && holidays == true))
                {
                    if (time.TimeOfDay.Hours > now.TimeOfDay.Hours)
                    {
                        nextEvents.Add(x);
                    }
                    else if (time.TimeOfDay.Hours == now.TimeOfDay.Hours)
                    {
                        if (time.TimeOfDay.Minutes > now.TimeOfDay.Minutes)
                        {
                            nextEvents.Add(x);
                        }
                    }
                }
            }
            bool NextisEmpty = !nextEvents.Any();
            if (NextisEmpty)
            {
                List<Events> FailEvents = new List<Events>();
                Events fail = new Events { Event_Time = "00:00", Event_Name = "No more events today", Event_Location = "" };
                FailEvents.Add(fail);
                return Task.FromResult(FailEvents);
            }
            return Task.FromResult(nextEvents);
        }
        public async Task<Events> GetNextEvent()
        {
            List<Events> events = new List<Events>();
            SQLiteDB db = new SQLiteDB();
            events = db.GetItemAsyncEvents().Result;
            events = GetNextEvents(events).Result;
            return await Task.FromResult(events[0]);

        }
    }
}

