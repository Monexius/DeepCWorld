using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.Services;
using System.IO;
using System.Collections.Generic;
using DeepSeaWorldApp.DBClasses;
using Plugin.LocalNotifications;
using System.Threading.Tasks;
using System;
using static DeepSeaWorldApp.DBClasses.DBs;
using static DeepSeaWorldApp.SQLiteDB;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepSeaWorldApp
{
    public partial class App : Application
    {
        static Database database;
        public static double ScreenWidth;
        public static double ScreenHeight;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
                }
                return database;
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
        }
        async Task<List<DBs.FAQ>> GetDB()
        {
            SQLiteDB dbcon = new SQLiteDB();
            return await dbcon.GetItemAsyncFAQ();
        }
        protected void ScheduleNotifications()
        {
            List<Events> Events = new List<Events>();
            Events = App.database.GetEventsAsync().Result;
            int i = 0;
            foreach (var g in Events)
            {
                DateTime time = Convert.ToDateTime(g.Event_Time);
                DateTime time2 = time.AddMinutes(-5);
                TimeSpan diff1 = time2.Subtract(DateTime.Now);
                TimeSpan zero = TimeSpan.FromSeconds(0);

                if (diff1 > zero)
                {
                    CrossLocalNotifications.Current.Show(g.Event_Name, "starts at " + g.Event_Time, i, DateTime.Now.Add(diff1));
                }
                i++;
            }
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
            //DataAsync();
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
