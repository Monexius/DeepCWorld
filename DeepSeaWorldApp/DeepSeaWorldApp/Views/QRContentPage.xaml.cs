using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRContentPage : ContentPage
    {
        ExhibitsViewModel viewModel;

        public QRContentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ExhibitsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var exhibit = args.SelectedItem as Exhibit;
            if (exhibit == null)
                return;
            await Navigation.PushAsync(new FeatureDetailPage(new ExhibitDetailViewModel(exhibit)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Exhibits.Count == 0)
                viewModel.LoadExhibitsCommand.Execute(null);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopAsync();
        }
    }
}