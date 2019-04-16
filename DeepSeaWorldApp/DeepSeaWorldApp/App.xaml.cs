using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.Views;
using static DeepSeaWorldApp.DBClasses.DBs;
using Xamarin.Forms.Internals;
using System;
using static DeepSeaWorldApp.SQLiteDB;

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
