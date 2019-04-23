using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;

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
            var exhibition = args.SelectedItem as Exhibition;
            if (exhibition == null)
                return;
            await Navigation.PushAsync(new FeatureDetailPage(new ExhibitDetailViewModel(exhibition)));

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

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Navigation.PopAsync();
        }

        void BackButtonClicked(object sender, System.EventArgs e)
        {
            this.Navigation.PopToRootAsync();
        }
    }
}