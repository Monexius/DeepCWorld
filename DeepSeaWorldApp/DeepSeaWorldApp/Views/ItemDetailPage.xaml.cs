using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Time = "10:30",
                Name = "Event One",
                Location = "Location One"
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        void OnMapClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}