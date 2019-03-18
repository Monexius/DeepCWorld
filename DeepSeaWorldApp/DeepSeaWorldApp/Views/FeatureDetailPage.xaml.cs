using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeatureDetailPage : ContentPage
    {
        ExhibitDetailViewModel viewModel;

        public FeatureDetailPage(ExhibitDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public FeatureDetailPage()
        {
            InitializeComponent();
            var exhibit = new Exhibit
            {
                Name = "Name 1",
                Image1 = "image 1",
                Text1 = "text 1",
                Text2 = "text 2",
                Text3 = "text 3"
            };

            viewModel = new ExhibitDetailViewModel(exhibit);
            BindingContext = viewModel;
        }
    }
}