using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;
using System;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        EventsViewModel viewModel;

        public EventsPage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Events;
            if (item == null)
                return;
            Console.WriteLine(item.Event_Name);
            await Navigation.PushAsync(new EventDetailPage(new EventDetailViewModel(item)));

            // Manually deselect item.
            EventsListView.SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            //InitializeComponent(); 

            BindingContext = viewModel = new EventsViewModel();
            if (viewModel.Events.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}