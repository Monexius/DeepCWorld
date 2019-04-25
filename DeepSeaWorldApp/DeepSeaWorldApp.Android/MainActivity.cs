using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Net;
using DeepSeaWorldApp.Views;
using System.Net;
using static DeepSeaWorldApp.DBClasses.DBs;
using Android.Support.V4.App;
using Android;
using Android.Support.V4.Content;

namespace DeepSeaWorldApp.Droid
{
    [Activity(Label = "DeepSeaWorldApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        App app;
        bool hasNotified = false;
        System.Timers.Timer timer = new System.Timers.Timer();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                //toolbar at top of the screen
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);

                //QR scanner init
                ZXing.Net.Mobile.Forms.Android.Platform.Init();

                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                app = new App();

                //get and set screen width and height of device
                var width = Resources.DisplayMetrics.WidthPixels;
                var height = Resources.DisplayMetrics.HeightPixels;
                var density = Resources.DisplayMetrics.Density;
                App.ScreenWidth = (width - 0.5f) / density;
                App.ScreenHeight = (height - 0.5f) / density;

                LoadApplication(app);

                // SQLite connection, table creation, update, insert and get class
                //DeepSeaWorldSQLiteConnectionAndroid deepSeaWorld = new DeepSeaWorldSQLiteConnectionAndroid();

                //MySqlDBCon mySql = new MySqlDBCon();
                //DataTb data = new DataTb();
                //data = await mySql.MySQLConnection(); // connection and data catch from mySQL db on server
                //deepSeaWorld.TableAsync(); // table async - creation of local db tables
                //await deepSeaWorld.InsertUpdateTables(data); // insert data to local db

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}