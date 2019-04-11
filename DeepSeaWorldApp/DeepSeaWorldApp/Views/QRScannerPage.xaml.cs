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
            InitializeComponent();
        }


        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (result.Text == "F767-348G56")
                {
                    //await DisplayAlert("Scanned result", result.Text, "if yes");
                    //await Navigation.PopToRootAsync();
                    await Navigation.PushAsync(new QRContentPage());
                }
                else
                {
                    await DisplayAlert("Scanned result", result.Text, "OK");
                }
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_scanView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //_scanView.IsScanning = false;
        }
    }
}

