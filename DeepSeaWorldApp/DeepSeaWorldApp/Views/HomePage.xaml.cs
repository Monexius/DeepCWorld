using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    public partial class HomePage : ContentPage
    {
        string eventName = "init";
        public HomePage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                int currentMinute = DateTime.Now.Minute;
                int currentHour = DateTime.Now.Hour;
                string nextEventTime;
                int nextEventMinute;
                int nextEventHour;
                int startsInMinutes;
                int startsInHours;

                if (currentMinute < 30)
                {
                    nextEventMinute = 30;
                    nextEventHour = currentHour;

                }
                else
                {
                    nextEventMinute = 60;
                    nextEventHour = currentHour;
                }
                nextEventTime = nextEventHour.ToString() + ":" + nextEventMinute.ToString();
                Item item = MockDataStore.getItemByTime(nextEventTime);
                eventName = item.Name;
                //eventName =  //get event name based on the nextEventTime by getting the event where the time variable == nextEventTime
                startsInMinutes = nextEventMinute - currentMinute;
                startsInHours = nextEventHour - currentHour;

                string nextEventStartsIn;

                if (startsInHours < 1)
                {
                    nextEventStartsIn = eventName + " starts in " + startsInMinutes.ToString() + " minutes";
                }
                else if (startsInHours == 1)
                {
                    nextEventStartsIn = eventName + " starts in " + startsInHours.ToString() + " hour " + startsInMinutes.ToString() + " minutes";
                }
                else
                {
                    nextEventStartsIn = eventName + " starts in " + startsInHours.ToString() + " hours " + startsInMinutes.ToString() + " minutes";
                }

                int hourUntilNext = nextEventHour - DateTime.Now.Hour;
                int minuteUntilNext = nextEventMinute - DateTime.Now.Minute;
                Device.BeginInvokeOnMainThread(() => timerText.Text = nextEventStartsIn);
                return true;
            });
        }

        void OnViewMapClicked(object sender, System.EventArgs e)
        {
            //load map page and pass eventName. maybe use modal?
            Navigation.PushAsync(new MapPage(eventName));
        }
        void OnFAQClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FAQPage());
        }
        void OnPromoClicked(object sender, System.EventArgs e)
        {
            string name = promoImage.Source.ToString();
            Navigation.PushAsync(new PromoPage(name));
        }
    }
}
