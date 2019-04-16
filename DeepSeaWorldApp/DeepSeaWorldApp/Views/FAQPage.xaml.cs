using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    public partial class FAQPage : ContentPage
    {
        //static FAQDatabase database;
        FAQViewModel viewModel;
        public FAQPage()
        {
            InitializeComponent();

        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetFAQsAsync();
            
            //BindingContext = viewModel = new FAQViewModel();
            //if (viewModel.FAQ.Count == 0)
                //viewModel.LoadItemsCommand.Execute(null);
        }
    }
}