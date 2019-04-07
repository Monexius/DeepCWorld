using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.ViewModels;
using System.Threading.Tasks;

namespace DeepSeaWorldApp.Views
{
    public partial class HomePage : ContentPage
    {
        string eventName = "init";
        public IDataStore<Event> DataStore => DependencyService.Get<IDataStore<Event>>() ?? new MockDataStore();
        Event eventEvent;
        public HomePage()
        {
            InitializeComponent();

            promoImage.Source = "fish1.jpg";
            homebox1.Source = "fish1.jpg";
            homebox2.Source = "fish1.jpg";
            homebox3.Source = "fish1.jpg";
            homebox4.Source = "fish1.jpg";

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                int currentMinute = DateTime.Now.Minute;
                int currentHour = DateTime.Now.Hour;
                string nextEventTime;
                int nextEventMinute;
                int nextEventHour;
                int startsInMinutes;
                int startsInHours;
                string nextEventMinuteString = "00";

                if (currentMinute < 30)
                {
                    nextEventMinute = 30;
                    nextEventMinuteString = "30";
                    nextEventHour = currentHour;

                }
                else
                {
                    nextEventMinute = 60;
                    nextEventMinuteString = "00";
                    nextEventHour = currentHour + 1;
                }

                nextEventTime = nextEventHour.ToString() + ":" + nextEventMinuteString;
                var getevent = GetItemByTime(nextEventTime);
                Event e = getevent.Result;
                eventName = e.Name;
                eventEvent = e;

                //eventName =  //get event name based on the nextEventTime by getting the event where the time variable == nextEventTime
                startsInMinutes = nextEventMinute - currentMinute;
                startsInHours = nextEventHour - currentHour - 1;

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

                Device.BeginInvokeOnMainThread(() => timerText.Text = nextEventStartsIn);
                return true;
            });


        }

        async Task<Event> GetItemByTime(string time)
        {
            return await DataStore.GetItemByTime(time);
        }

        void OnViewMapClicked(object sender, System.EventArgs e)
        {
            //load map page and pass eventName. maybe use modal?
            Navigation.PushAsync(new EventDetailPage(eventEvent));
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
            Navigation.PushAsync(new NewsDetailPage(name));
        }
        void OnBox1Clicked(object sender, System.EventArgs e)
        {

        }
        void OnBox2Clicked(object sender, System.EventArgs e)
        {

        }
        void OnBox3Clicked(object sender, System.EventArgs e)
        {

        }
        void OnBox4Clicked(object sender, System.EventArgs e)
        {

        }

    }
}
