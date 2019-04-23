using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        EventDetailViewModel viewModel;

        public EventDetailPage(EventDetailViewModel viewModel)
        {
            InitializeComponent();
            Console.WriteLine("in eventdetailpage: " + viewModel.Event.Event_Name);
            BindingContext = this.viewModel = viewModel;
        }
        public EventDetailPage(Events eventEvent)
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

            var e = new Events
            {
                Event_Time = "10:30",
                Event_Name = "Event One",
                Event_Location = "Location One"
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