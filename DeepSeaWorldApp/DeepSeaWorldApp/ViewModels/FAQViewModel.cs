using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;
using Xamarin.Forms;

namespace DeepSeaWorldApp.ViewModels
{
    public class FAQViewModel : ContentPage
    {
        public ObservableCollection<FAQ> FAQ { get; set; }
        public Command LoadItemsCommand { get; set; }
        public FAQViewModel()
        {
            Title = "Frequently Asked Questions";
            FAQ = new ObservableCollection<FAQ>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FAQ.Clear();
                var faqs = await App.Database.GetFAQsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

