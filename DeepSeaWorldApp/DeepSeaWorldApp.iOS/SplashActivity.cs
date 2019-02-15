using System;
using Android.App;

namespace DeepSeaWorldApp.Droid
{

    [Activity(Label = "Deep Sea World", Icon = "@drawable/mdpi_320x480_android", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}