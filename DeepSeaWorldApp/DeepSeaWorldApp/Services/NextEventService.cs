using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;
using Xamarin.Forms;

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

    }
}

