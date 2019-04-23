using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;

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
            var exhibition = new Exhibition
            {
                Exhibition_Name = "Name 1",
                Exhibition_IMG = "image 1",
                Exhibition_Description = "text 1",
                Exhibition_Video = "text 2",
            };

            viewModel = new ExhibitDetailViewModel(exhibition);
            BindingContext = viewModel;
        }
    }
}