using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using SQLite;
using DeepSeaWorldApp.Services;
using System.IO;
using System.Collections.Generic;
using DeepSeaWorldApp.Models;
using Newtonsoft.Json;
using DeepSeaWorldApp.DBClasses;
using Xamarin.Essentials;
using Plugin.LocalNotifications;
using System.Threading.Tasks;
using System;
using static DeepSeaWorldApp.DBClasses.DBs;
using Xamarin.Forms.Internals;
using static DeepSeaWorldApp.SQLiteDB;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepSeaWorldApp
{
    public partial class App : Application
    {
        static FAQDatabase faqdatabase;
        public IDataStore<Event> DataStore => DependencyService.Get<IDataStore<Event>>() ?? new MockDataStore();

        public static FAQDatabase Database
        {
            get
            {
                if (faqdatabase == null)
                {
                    faqdatabase = new FAQDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FAQs.db3"));
                }
                return faqdatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            ScheduleNotifications();
            //List<DBs.FAQ> faq = new List<DBs.FAQ>();
            //faq = GetDB().Result;
            //Console.WriteLine("FAQ ZEROOO: " + faq[0].FAQ_Question);
            //Console.WriteLine("0 NAME: " + data.Events[0].Event_Name);
        }
        async Task<List<DBs.FAQ>> GetDB()
        {
            SQLiteDB dbcon = new SQLiteDB();
            return await dbcon.GetItemAsyncFAQ();
        }
        protected void ScheduleNotifications()
        {
            List<Event> Events = new List<Event>();
            Events = GetEvents().Result;
            CrossLocalNotifications.Current.Show(Events[0].Name, "starts at " + Events[0].Time, 101, DateTime.Now.AddSeconds(10));
            int i = 0;
            foreach (var g in Events)
            {
                DateTime time = Convert.ToDateTime(g.Time);
                DateTime time2 = time.AddMinutes(-5);
                TimeSpan diff1 = time2.Subtract(DateTime.Now);
                TimeSpan zero = TimeSpan.FromSeconds(0);

                if(diff1 > zero)
                {
                    CrossLocalNotifications.Current.Show(g.Name, "starts at " + g.Time, i, DateTime.Now.Add(diff1));
                }
                i++;
            }
        }
        async Task<List<Event>> GetEvents()
        {
            var events = await DataStore.GetItemsAsync(true);
            List<Event> Events = new List<Event>();
            foreach (var e in events)
            {
                Events.Add(e);
            }
            return Events;
        }

        protected async void DataAsync()
        {
            SQLiteDB deepSeaWorld = new SQLiteDB();

            MySqlDBCon mySql = new MySqlDBCon();
            DataTb data = new DataTb();
            data = await mySql.MySQLConnection(); // connection and data catch from mySQL db on server
            deepSeaWorld.TableAsync(); // table async - creation of local db tables
            await deepSeaWorld.InsertUpdateTables(data); // insert data to local db

            FAQL fAQL = new FAQL();
            fAQL = await deepSeaWorld.GetItemAsyncFAQ(1);

            Console.WriteLine(fAQL.FAQ_Question);
        }
        protected override void OnStart()
        {
            DataAsync();
            //List<DBs.FAQ> faq = new List<DBs.FAQ>();
            //faq = GetDB().Result;
             //Console.WriteLine("FAQ ZEROOO: " + faq[0].FAQ_Question);
            //Console.WriteLine("0 NAME: " + data.Events[0].Event_Name);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected void OnAppearing()
        {

            MessagingCenter.Subscribe<MainPage>(this, "Internet connection has been lost", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => { App.Current.MainPage.DisplayAlert("No internet Connection", "connection lost", "ok"); });
            });
        }

    }
}
