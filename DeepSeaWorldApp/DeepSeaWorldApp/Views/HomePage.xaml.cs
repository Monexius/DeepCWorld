using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.ViewModels;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Views
{
    public partial class HomePage : ContentPage
    {
        //get event data
        public IDataStore<Events> DataStore => DependencyService.Get<IDataStore<Events>>() ?? new MockDataStore();
        //Events eventEvent;
        public HomePage()
        {
            InitializeComponent();
            Console.WriteLine("Homepage");
            //promoImage.Source = "fish1.jpg";
            //homebox1.Source = "fish1.jpg";
            //homebox2.Source = "fish1.jpg";
            //homebox3.Source = "fish1.jpg";
            //homebox4.Source = "fish1.jpg";
            eventNameText.Text = "event";
            eventTimeText.Text = "time";

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                var next = GetNextEvent();
                Events nextE = next.Result;

                //new code to get starts in time
                DateTime time = Convert.ToDateTime(nextE.Event_Time);
                DateTime time2 = time.AddMinutes(1);
                TimeSpan diff1 = time2.Subtract(DateTime.Now);

                eventNameText.Text = nextE.Event_Name;
                eventBridgeText.Text = "starts in";
                if (nextE.Event_Name.Equals("No more events today"))
                {
                    eventTimeText.Text = "";
                    eventBridgeText.Text = "";
                }
                else if (diff1.Hours < 1)
                {
                    if (diff1.Minutes < 1)
                    {
                        eventTimeText.Text = "has started";
                        eventBridgeText.Text = "";
                    }
                    else if (diff1.Minutes == 1)
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Minutes + " minute");
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Minutes + " minutes");
                    }
                }
                else if (diff1.Hours == 1)
                {
                    if(diff1.Minutes == 0)
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hour");
                    }
                    else if(diff1.Minutes == 1)
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hour " + diff1.Minutes + " minute");
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hour " + diff1.Minutes + " minutes");
                    }
                }
                else
                {
                    if (diff1.Minutes == 0)
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hours");
                    }
                    else if (diff1.Minutes == 1)
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hours " + diff1.Minutes + " minute");
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hours " + diff1.Minutes + " minutes");
                    }
                }
                return true;
            });


        }

        async Task<Events> GetItemByTime(string time)
        {
            return await DataStore.GetItemByTime(time);
        }
        async Task<Events> GetNextEvent()
        {
            return await DataStore.GetNextEvent();
        }

        void OnViewMapClicked(object sender, System.EventArgs e)
        {
            //load map page and pass eventName. maybe use modal?
            Navigation.PushAsync(new EventDetailPage());
        }

        void OnBox3Clicked(object sender, System.EventArgs e)
        {

        }
        void OnBox4Clicked(object sender, System.EventArgs e)
        {

        }

    }


}
