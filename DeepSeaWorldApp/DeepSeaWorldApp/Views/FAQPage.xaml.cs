using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Views
{
    public partial class FAQPage : ContentPage
    {
        //static FAQDatabase database;
        public FAQPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteDB sQLiteDB = new SQLiteDB();
            List<FAQ> faq = new List<FAQ>();
            faq = sQLiteDB.GetItemAsyncFAQ().Result;
            listView.ItemsSource = faq;
            //listView.ItemsSource = App.Database.GetFAQsAsync();
            
            //BindingContext = viewModel = new FAQViewModel();
            //if (viewModel.FAQ.Count == 0)
                //viewModel.LoadItemsCommand.Execute(null);
        }
    }
}