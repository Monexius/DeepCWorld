using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using SQLite;
using System.IO;
using Newtonsoft.Json;
using DeepSeaWorldApp.DBClasses;
using Xamarin.Essentials;
using System.Collections.Generic;
using static DeepSeaWorldApp.DBClasses.DBs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepSeaWorldApp
{
    public partial class App : Application
    {
        public object DisplayAllert { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
            DeepSeaWorldMySQLDBConn<DBs> mySQLDataBaseCheck = new DeepSeaWorldMySQLDBConn<DBs>();
            //  mySQLDataBaseCheck.tablesData;

            mySQLDataBaseCheck.SaveFile(mySQLDataBaseCheck.tablesData);

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
