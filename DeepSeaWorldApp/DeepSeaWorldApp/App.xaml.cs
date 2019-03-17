using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using SQLite;
using System.IO;
using Newtonsoft.Json;
using DeepSeaWorldApp.DBClasses;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepSeaWorldApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {

            // Handle when your app starts
            DeepSeaWorldSQLiteConnectionService conn = new DeepSeaWorldSQLiteConnectionService();        

            if (conn.connTest() == true)
            {
                App.Current.MainPage.DisplayAlert("Connection", "true", "ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Connection", "false", "not ok");
            }


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
