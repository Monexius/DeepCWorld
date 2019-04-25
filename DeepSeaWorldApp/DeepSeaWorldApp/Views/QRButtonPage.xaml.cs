using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class QRButtonPage : ContentPage
    {
        public QRButtonPage()
        {
            InitializeComponent();

        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            if(Device.RuntimePlatform == Device.Android)
            {
                Navigation.PushModalAsync(new QRScannerPage());
            }
            else if(Device.RuntimePlatform == Device.iOS)
            {
                Navigation.PushAsync(new QRScannerPage());
            }
        }
    }
}
