using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using DeepSeaWorldApp.Views;
using System.Net;

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
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);
                timer.Start();
                timer.Interval = 2000;
                timer.Elapsed += Timer_Elapsed;
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                app = new App();
                LoadApplication(app);

                MySQLSync s = new MySQLSync();
                s.saveFile(s.MySQLConnection());

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // connection timer
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
            string checkUrl = "http://127.0.0.1";
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(checkUrl);
                webRequest.Timeout = 5000;
                WebResponse webResponse = webRequest.GetResponse();
                webResponse.Close();
                hasNotified = false;

                return true;
            }catch(WebException ex)
            {
                if (!hasNotified)
                    hasNotified = false;
                return false;
            }
        }

    }
}