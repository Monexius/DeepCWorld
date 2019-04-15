using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using DeepSeaWorldApp.Models;
using Android.Net;
using DeepSeaWorldApp.Views;
using System.Net;
using static DeepSeaWorldApp.DBClasses.DBs;
using Android.Support.V4.App;
using Android;
using Android.Support.V4.Content;
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
                PermissionCheck(); // storage permission 
                CameraPermissionCheck();
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                app = new App();
                LoadApplication(app);

                DeepSeaWorldSQLiteConnectionAndroid deepSeaWorld = new DeepSeaWorldSQLiteConnectionAndroid();


                MySqlDBCon mySql = new MySqlDBCon();
                DataTb data = new DataTb();
                data = await mySql.MySQLConnection();

                deepSeaWorld.TableAsync();

                foreach (DBClasses.DBs.FAQ f in data.FAQ)
                {
                    await deepSeaWorld.InsertOrUpdateTableAsyncFAQ(f);
                }

                base.OnCreate(savedInstanceState);
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                //var prefs = Application.Context.GetSharedPreferences("name", FileCreationMode.Private);
                //if (!prefs.Contains("FirstExecution"))
                //{
                //    //Do your stuff on first execution here...
                //    var faqs = new List<FAQ>();
                //    var mockFAQ = new List<FAQ>
                //    {
                //        new FAQ {Question="QuestionA", Answer="Answer1" },
                //        new FAQ {Question="QuestionB", Answer="Answer2" },
                //        new FAQ {Question="QuestionC", Answer="Answer3" },

                //    };

                //    foreach (var e in mockFAQ)
                //    {
                //        App.Database.SaveFAQAsync(e);
                //    }
                //    var editor = prefs.Edit();
                //    editor.PutBoolean("FirstExecution", false);
                //    editor.Commit();
                //}

                LoadApplication(new App());

                //List<FAQ> fs = new List<FAQ>();
                //fs = data.FAQ;
                //await deepSeaWorld.InsertOrUpdateTableAsyncFAQDb(fs);


                //List<DataTb> ls = new List<DataTb>();

                //ls.Add(data);
                string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string fileName6 = "pp.txt";
                string fPath6 = Path.Combine(path, fileName6);
                using (StreamWriter st6 = new StreamWriter(fPath6))
                using (JsonWriter writer6 = new JsonTextWriter(st6))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer6, deepSeaWorld.GetItemAsyncFAQ());
                }

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
        private void CameraPermissionCheck()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) == (int)Permission.Granted)
            {
            }
            else
            {
                CameraPermission();
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


        // permit for camera access
        private void CameraPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.Camera))
            {
                var requirePermission = new String[] { Manifest.Permission.Camera };
                ActivityCompat.RequestPermissions(this, requirePermission, (int)RequestedPermission.Granted);
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, (int)RequestedPermission.Required);
            }
        }
    }
}