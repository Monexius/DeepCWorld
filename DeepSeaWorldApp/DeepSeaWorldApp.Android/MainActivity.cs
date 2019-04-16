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

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);
                timer.Start();
                timer.Interval = 2000;
                timer.Elapsed += Timer_Elapsed;
                PermissionCheck(); // storage permission 
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                app = new App();
                LoadApplication(app);

                //// SQLite connection, table creation, update, insert and get class
                //DeepSeaWorldSQLiteConnectionAndroid deepSeaWorld = new DeepSeaWorldSQLiteConnectionAndroid();

                //MySqlDBCon mySql = new MySqlDBCon();
                //DataTb data = new DataTb();
                //data = await mySql.MySQLConnection(); // connection and data catch from mySQL db on server
                //deepSeaWorld.TableAsync(); // table async - creation of local db tables
                //await deepSeaWorld.InsertUpdateTables(data); // insert data to local db

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // networrk connection timer
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            timer.Stop();
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            if(networkInfo.Type == ConnectivityType.Wifi || networkInfo.Type == ConnectivityType.Mobile && !CheckInternetConnection() && !hasNotified)
            {
                hasNotified = true;
                Xamarin.Forms.MessagingCenter.Send<MainPage>(app.MainPage as MainPage, "Internet Connection has been lost");
            }else
            {
                Xamarin.Forms.MessagingCenter.Send<MainPage>(app.MainPage as MainPage, "Internet Connection");
            }
            timer.Start();
        }

        // network connection check
        public bool CheckInternetConnection()
        {
            string checkUrl = "http://10.0.2.2";
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(checkUrl);
                webRequest.Timeout = 5000;
                WebResponse webResponse = webRequest.GetResponse();
                webResponse.Close();
                hasNotified = false;

                return true;
            }catch (WebException)
            {
                if (!hasNotified)
                    hasNotified = false;
                return false;
            }
        }

        // checking access to storage
        private void PermissionCheck()
        {
            if(ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            {
            }else
            {
                StoragePermission();
            }
        }

        // permit for storage access
        private void StoragePermission()
        {
            if(ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.WriteExternalStorage))
            {
                var requirePermission = new String[] { Manifest.Permission.WriteExternalStorage };
                ActivityCompat.RequestPermissions(this, requirePermission, (int)RequestedPermission.Granted);
            }else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage }, (int)RequestedPermission.Required);
            }
        }

    }
}