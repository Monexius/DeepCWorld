using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class QRScannerPage
    {

        public QRScannerPage()
        {

        }


        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //await Navigation.PushAsync(new NavigationPage(new QRContentPage(result.Text)));
                if (result.Text == "F767-348G56")
                {
                    //await DisplayAlert("Scanned result", result.Text, "if yes");
                    //await Navigation.PopToRootAsync();
                    await Navigation.PushAsync(new VideoPage(result.Text));
                }
                else
                {
                    await DisplayAlert("Scanned result", result.Text, "OK");
                }
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
            //_scanView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //_scanView.IsScanning = false;
            //_scanView.Navigation.PopModalAsync();
            //_scanView.Navigation.RemovePage(this);
        }
    }
}

