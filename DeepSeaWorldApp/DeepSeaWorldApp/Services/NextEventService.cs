using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;
using Xamarin.Forms;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class NextEventService : ContentPage
    {
        public NextEventService()
        {

        }

        public static string GetNextEventTime()
        {

            int currentMinute = DateTime.Now.Minute;
            int currentHour = DateTime.Now.Hour;
            DateTime CurrentTime = DateTime.Now;
            string nextEventTime;
            int nextEventMinute = GetNextEventMinute();
            int nextEventHour = GetNextEventHour();

            nextEventTime = nextEventHour.ToString() + ":" + nextEventMinute.ToString();
            return nextEventTime;
        }

        public static int GetNextEventMinute()
        {
            int currentMinute = DateTime.Now.Minute;
            int nextEventMinute;

            if (currentMinute < 35 && currentMinute >= 1)
            {
                nextEventMinute = 30;
            }
            else
            {
                nextEventMinute = 60;
            }
            return nextEventMinute;
        }

        public static int GetNextEventHour()
        {
            int nextEventMinute = GetNextEventMinute();
            int currentHour = DateTime.Now.Hour;
            int nextEventHour = 0;

            if (nextEventMinute == 30)
            {
                nextEventHour = currentHour;
            }
            else if(nextEventMinute == 60)
            {
                nextEventHour = currentHour;
            }
            return nextEventHour;
        }

        //called from: EventsViewModel
        public static List<Events> GetNextEvents(List<Events> events)
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
                else if (time.TimeOfDay.Hours == now.TimeOfDay.Hours)
                {
                    if (time.TimeOfDay.Minutes > now.TimeOfDay.Minutes)
                    {
                        nextEvents.Add(x);
                    }
                }
            }
            bool NextisEmpty = !nextEvents.Any();
            if (NextisEmpty)
            {
                List<Events> FailEvents = new List<Events>();
                Events fail = new Events { Event_Time = "00:00", Event_Name = "No more events today", Event_Location = "" };
                FailEvents.Add(fail);
                return FailEvents;
            }
            return nextEvents;
        }
    }
}

