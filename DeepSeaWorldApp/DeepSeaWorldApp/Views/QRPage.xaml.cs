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
    public partial class QRPage
        {

            public QRPage()
            {
                InitializeComponent();
            }

            public void Handle_OnScanResult(Result result)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Scanned result", result.Text, "OK");
                });
            }

            protected override void OnAppearing()
            {
                base.OnAppearing();

                IsScanning = true;
            }

            protected override void OnDisappearing()
            {
                base.OnDisappearing();

                IsScanning = false;
            }
        }
}

