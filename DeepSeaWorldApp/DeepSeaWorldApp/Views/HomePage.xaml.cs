using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.ViewModels;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;
using DeepSeaWorldApp.DBClasses;

namespace DeepSeaWorldApp.Views
{
    public partial class HomePage : ContentPage
    {
        //get event data
        public IDataStore<Event> DataStore => DependencyService.Get<IDataStore<Event>>() ?? new MockDataStore();
        Event eventEvent;
        public HomePage()
        {
            InitializeComponent();
            //Console.WriteLine("TEST 6");
            ////events list
            //List<DBs.Events> events = new List<DBs.Events>();
            //Console.WriteLine("TEST 7");
            //SQLiteDB dbcon = new SQLiteDB();
            //Console.WriteLine("TEST 8");
            //get list of events from db

            //events = dbcon.GetItemAsyncEvents().Result;
            //int i = 0;
            //foreach(var e in events)
            //{
            //    Console.WriteLine("EVENT: " + i + " " + e.Event_Name);
            //    i++;
            //}
            //Console.WriteLine("TEST 9");
            //Console.WriteLine("EVENT ZEROOO: " + events[0].Event_Name);

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
                Event nextE = next.Result;

                //new code to get starts in time
                DateTime time = Convert.ToDateTime(nextE.Time);
                DateTime time2 = time.AddMinutes(1);
                TimeSpan diff1 = time2.Subtract(DateTime.Now);

                eventNameText.Text = nextE.Name;
                eventBridgeText.Text = "starts in";
                if (nextE.Name.Equals("No more events today"))
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

        async Task<List<DBs.Events>> GetEventsDB()
        {
            SQLiteDB dbcon = new SQLiteDB();
            return await dbcon.GetItemAsyncEvents();
        }

        async Task<Event> GetItemByTime(string time)
        {
            return await DataStore.GetItemByTime(time);
        }
        async Task<Event> GetNextEvent()
        {
            return await DataStore.GetNextEvent();
        }

        void OnViewMapClicked(object sender, System.EventArgs e)
        {
            //load map page and pass eventName. maybe use modal?
            Navigation.PushAsync(new EventDetailPage(eventEvent));
        }

        void OnBox1Clicked(object sender, System.EventArgs e)
        {
            string name = homebox1.Source.ToString();
            Navigation.PushAsync(new NewsDetailPage(name));
        }
        void OnBox2Clicked(object sender, System.EventArgs e)
        {
            string name = homebox2.Source.ToString();
            Navigation.PushAsync(new NewsDetailPage(name));
        }
        void OnBox3Clicked(object sender, System.EventArgs e)
        {

        }
        void OnBox4Clicked(object sender, System.EventArgs e)
        {

        }

    }


}
