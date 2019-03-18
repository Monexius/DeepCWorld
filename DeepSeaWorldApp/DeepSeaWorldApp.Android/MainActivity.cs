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
using DeepSeaWorldApp.DBClasses;
using static DeepSeaWorldApp.DBClasses.DBs;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                app = new App();
                LoadApplication(app);

                List<FAQ> ls = new List<FAQ>();
                MySQLSync<FAQ> sync = new MySQLSync<FAQ>();
                await sync.MySQLConnection(ls);

                //sync.SaveCountAsync(5);

                //   SaveFile(ls);



              //  sqLiteSync.InsertUpdate(await sync.MySQLConnection());

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

        //public void SaveFile(List<FAQ> ts)
        //{
        //    string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        //    string fileName = "dbData.txt";
        //    string fileName2 = "dbData2.txt";
        //    string fPath = Path.Combine(path, fileName);
        //    string fPath2 = Path.Combine(path, fileName2);
        //    JsonSerializer serializer = new JsonSerializer();

        //    string json = JsonConvert.SerializeObject(ts);
        //    using (StreamWriter st = new StreamWriter(fPath))
        //    using (JsonWriter writer = new JsonTextWriter(st))
        //    {
        //        serializer.Serialize(writer, json);
        //    }
        //    using (StreamWriter st = new StreamWriter(fPath2))
        //    using (JsonWriter writer = new JsonTextWriter(st))
        //    {
        //        serializer.Serialize(writer, ts);
        //    }
        //}

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
            }catch(WebException ex)
            {
                if (!hasNotified)
                    hasNotified = false;
                return false;
            }
        }

    }
}