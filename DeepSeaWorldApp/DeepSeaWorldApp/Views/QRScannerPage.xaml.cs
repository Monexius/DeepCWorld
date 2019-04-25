using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Views
{
    public partial class QRScannerPage
    {

        public QRScannerPage()
        {

        }

        public void Handle_OnScanResult(Result result)
        {
            IsScanning = false;
            //Navigation.PopAsync();
            Exhibition ex = new Exhibition();
            if (string.IsNullOrWhiteSpace(result.Text))
            {
                return;
            }
            Device.BeginInvokeOnMainThread(async () =>
            {
                ex = App.ExhibitionDatabase.GetExhibitionsAsync(result.Text).Result;
                Console.WriteLine("qrvid: " + ex.Exhibition_Video);
                //await Navigation.PushAsync(new NavigationPage(new QRContentPage(result.Text)));
                await Navigation.PushAsync(new VideoPage(ex));
                //if (result.Text == "F767-348G56")
                //{
                //    //await DisplayAlert("Scanned result", result.Text, "if yes");
                //    //await Navigation.PopToRootAsync();
                //    await Navigation.PushAsync(new VideoPage(result.Text));
                //}
                //else
                //{
                //    await DisplayAlert("Scanned result", result.Text, "OK");
                //}
            });
        }

        //void BackButtonClicked(object sender, System.EventArgs e)
        //{
        //    this.Navigation.PopModalAsync();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitializeComponent();
            IsScanning = true;
            //_scanView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            IsScanning = false;
            //_scanView.IsScanning = false;
            //_scanView.Navigation.PopModalAsync();
            //_scanView.Navigation.RemovePage(this);
        }
    }
}

