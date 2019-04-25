using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;
using System.Threading.Tasks;

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
            timeloc.Text = viewModel.Event.Event_Time + " at " + viewModel.Event.Event_Location;
        }

        public EventDetailPage()
        {
            InitializeComponent();

            var e = new Events
            {
                Event_Time = "00:00",
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