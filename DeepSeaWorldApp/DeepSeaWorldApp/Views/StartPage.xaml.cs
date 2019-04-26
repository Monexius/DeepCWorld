using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new MainPage()));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
