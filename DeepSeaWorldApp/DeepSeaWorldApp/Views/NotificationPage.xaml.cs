using System;
using System.Collections.Generic;
using Plugin.LocalNotifications;
//using UserNotifications;
using Xamarin.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            CrossLocalNotifications.Current.Show("title", "body", 101, DateTime.Now.AddSeconds(30));
        }
    }
}
