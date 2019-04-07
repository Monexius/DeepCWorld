using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DeepSeaWorldApp.ViewModels;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Services;

namespace DeepSeaWorldApp.Views
{
    public partial class NewsDetailPage : ContentPage
    {
        NewsDetailViewModel viewModel;

        public NewsDetailPage()
        {
            InitializeComponent();
            BindingContext = new NewsDetailViewModel();
        }

        public NewsDetailPage(string name)
        {
            InitializeComponent();
            BindingContext = new NewsDetailViewModel(name);
        }
        public NewsDetailPage(News news)
        {
            InitializeComponent();
            BindingContext = new NewsDetailViewModel(news);
        }
        public NewsDetailPage(NewsDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


    }
}
