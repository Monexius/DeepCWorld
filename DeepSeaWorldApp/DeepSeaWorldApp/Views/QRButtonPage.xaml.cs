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
            Navigation.PushAsync(new QRScannerPage());
        }
    }
}
