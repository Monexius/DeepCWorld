using Xamarin.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class FAQPage : ContentPage
    {
        public FAQPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetFAQsAsync().Result;
        }
    }
}