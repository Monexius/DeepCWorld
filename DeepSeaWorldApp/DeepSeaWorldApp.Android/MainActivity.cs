using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.Droid
{
    [Activity(Label = "DeepSeaWorldApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

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
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}