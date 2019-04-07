using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Services;


namespace DeepSeaWorldApp.Views
{
    public partial class FAQPage : ContentPage
    {
        //static FAQDatabase database;
        public FAQPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetFAQsAsync();

        }
    }
}