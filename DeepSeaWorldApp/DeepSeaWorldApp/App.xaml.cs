using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using SQLite;
using DeepSeaWorldApp.Services;
using System.IO;
using Plugin.LocalNotifications;
using System.Collections.Generic;
using DeepSeaWorldApp.Models;
using trackerApp.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepSeaWorldApp
{
    public partial class App : Application
    {
        static FAQDatabase faqdatabase;

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

        }
        protected void LoadData()
        {
            var faqs = new List<FAQ>();
            var mockFAQ = new List<FAQ>
                {
                    new FAQ {Question="Question1", Answer="Answer1" },
                    new FAQ {Question="Question2", Answer="Answer2" },
                    new FAQ {Question="Question3", Answer="Answer3" },

                };

            foreach (var e in mockFAQ)
            {
                App.Database.SaveFAQAsync(e);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //DeepSeaWorldSQLiteConnectionService conn = new DeepSeaWorldSQLiteConnectionService();        

            //if (conn.connTest() == true)
            //{
            //    App.Current.MainPage.DisplayAlert("Connection", "true", "ok");
            //}
            //else
            //{
            //    App.Current.MainPage.DisplayAlert("Connection", "false", "not ok");
            //}


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
