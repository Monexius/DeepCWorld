using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        ExhibitsViewModel viewModel;

        public VideoPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ExhibitsViewModel();
        }

        public VideoPage(string qrcode)
        {
            InitializeComponent();

            BindingContext = viewModel = new ExhibitsViewModel(qrcode);
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Navigation.PopAsync();
        }

        void ImageButtonClicked(object sender, System.EventArgs e)
        {
            //to exhibit specific images
        }
        void ImageButton2Clicked(object sender, System.EventArgs e)
        {
            //to exhibit specific facts
        }
    }
}