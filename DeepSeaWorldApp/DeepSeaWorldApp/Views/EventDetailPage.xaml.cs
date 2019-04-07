using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.ViewModels;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        EventDetailViewModel viewModel;

        public EventDetailPage(EventDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        public EventDetailPage(Event eventEvent)
        {
            InitializeComponent();
            BindingContext = new MapViewModel(eventEvent);
            //get location associated with eventName
            //display different image depending on location, displaying map with that location highlighted
            //using switch case?
        }

        public EventDetailPage()
        {
            InitializeComponent();

            var e = new Event
            {
                Time = "10:30",
                Name = "Event One",
                Location = "Location One"
            };

            viewModel = new EventDetailViewModel(e);
            BindingContext = viewModel;
        }

        void OnMapClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}