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
            SQLiteDB db = new SQLiteDB();
            Exhibition ex = new Exhibition();
            if (string.IsNullOrWhiteSpace(result.Text))
            {
                return;
            }
            Device.BeginInvokeOnMainThread(async () =>
            {
                //ex = App.Database.GetExhibitionsAsync(result.Text).Result;
                ex = db.GetItemAsyncExhibitionQR(result.Text).Result;
                Console.WriteLine("EX: " + ex);
                //await Navigation.PushAsync(new NavigationPage(new QRContentPage(result.Text)));
                if (Device.RuntimePlatform == Device.Android)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new VideoPage(ex)));
                }
                else
                {
                    await Navigation.PushAsync(new VideoPage(ex));
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
            IsScanning = true;
            InitializeComponent();
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

