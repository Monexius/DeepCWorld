using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeepSeaWorldApp.ViewModels;
using static DeepSeaWorldApp.DBClasses.DBs;
using DeepSeaWorldApp.FormsVideoLibrary;

namespace DeepSeaWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        ExhibitsViewModel viewModel;

        public VideoPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ExhibitsViewModel();
        }

        public VideoPage(Exhibition ex)
        {
            InitializeComponent();

            BindingContext = viewModel = new ExhibitsViewModel(ex);
            VideoSource vid = VideoSource.FromResource(ex.Exhibition_Video);
            videoPlayer.Source = vid;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}