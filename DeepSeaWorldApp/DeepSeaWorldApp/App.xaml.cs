using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using SQLite;
using System.IO;
using Newtonsoft.Json;
using DeepSeaWorldApp.DBClasses;

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

            DeepSeaWorldMySQLDBConn con = new DeepSeaWorldMySQLDBConn();



            if (con.syncTest() == true)
            {
                App.Current.MainPage.DisplayAlert("sync", "true", "ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("sync", "false", "not ok");
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


    }
}
