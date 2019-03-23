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
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

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
                var getitem = GetItemByTime(nextEventTime);
                Item item = getitem.Result;
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

        async Task<Item> GetItemByTime(string time)
        {
            return await DataStore.GetItemByTime(time);
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
