using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Console.WriteLine("MainPage");
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainTabbedPage()));
        }
    }
}
