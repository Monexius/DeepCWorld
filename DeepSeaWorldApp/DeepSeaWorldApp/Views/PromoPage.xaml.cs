using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DeepSeaWorldApp.ViewModels;
using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Services;

namespace DeepSeaWorldApp.Views
{
    public partial class PromoPage : ContentPage
    {

        public PromoPage()
        {
            InitializeComponent();
            BindingContext = new PromoViewModel();
        }

        public PromoPage(string name)
        {
            InitializeComponent();
            BindingContext = new PromoViewModel(name);
        }


    }
}
