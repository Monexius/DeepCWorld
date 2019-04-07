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
    public partial class NewsPage : ContentPage
    {
        NewsViewModel viewModel;

        public NewsPage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as News;
            if (item == null)
                return;
            await Navigation.PushAsync(new NewsDetailPage(new NewsDetailViewModel(item)));

            // Manually deselect item.
            NewsListView.SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            //InitializeComponent(); 

            BindingContext = viewModel = new NewsViewModel();
            if (viewModel.News.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}