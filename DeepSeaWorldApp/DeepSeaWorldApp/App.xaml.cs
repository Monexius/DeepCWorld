using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using SQLite;
using DeepSeaWorldApp.Services;
using System.IO;
using System.Collections.Generic;
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
        public static double ScreenWidth;
        public static double ScreenHeight;
        public App()
        {
            DataAsync();
            InitializeComponent();

            MainPage = new StartPage();
        }
        async Task<List<DBs.FAQ>> GetDB()
        {
            SQLiteDB dbcon = new SQLiteDB();
            return await dbcon.GetItemAsyncFAQ();
        }


        protected async void DataAsync()
        {
            SQLiteDB deepSeaWorld = new SQLiteDB();

            MySqlDBCon mySql = new MySqlDBCon();
            DataTb data = new DataTb();
            data = await mySql.MySQLConnection(); // connection and data catch from mySQL db on server
            deepSeaWorld.TableAsync(); // table async - creation of local db tables
            await deepSeaWorld.InsertUpdateTables(data); // insert data to local db

        }

        protected override void OnStart()
        {

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
