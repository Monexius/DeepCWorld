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
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Content;

namespace DeepSeaWorldApp.Droid
{
    [Activity(Label = "DeepSeaWorldApp", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        App app;
        bool hasNotified = false;
        System.Timers.Timer timer = new System.Timers.Timer();
        static readonly int REQUEST_CAMERA = 0;
        View layout;

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
                if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.Camera)
                == (int)Permission.Granted)
                {
                    Toast.MakeText(this, "camera permission granted", ToastLength.Long).Show();
                }
                else
                {
                    RequestCameraPermission();
                }
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

        void RequestCameraPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.Camera))
            {
                Snackbar.Make(layout, "Allow Camera Access to scan QR codes",
                    Snackbar.LengthIndefinite).SetAction("OK", new Action<View>(delegate (View obj) {
                        ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, REQUEST_CAMERA);
                    })).Show();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, REQUEST_CAMERA);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // Field, properties, and method for Video Picker
        public static MainActivity Current { private set; get; }

        public static readonly int PickImageId = 1000;

        public TaskCompletionSource<string> PickImageTaskCompletionSource { set; get; }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    // Set the filename as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(data.DataString);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }
    }
}