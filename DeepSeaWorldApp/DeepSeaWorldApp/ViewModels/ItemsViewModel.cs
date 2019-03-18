using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.Services;

namespace DeepSeaWorldApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Deep Sea World";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    int itemHour = Convert.ToInt32(item.Time.Substring(0, 2));
                    int itemMinute = Convert.ToInt32(item.Time.Substring(3, 2));
                    if (itemHour > NextEventService.GetNextEventHour())
                    {
                        Items.Add(item);
                    }
                    if(itemHour == NextEventService.GetNextEventHour() && itemMinute == 30 && NextEventService.GetNextEventMinute() == 30)
                    {
                        Items.Add(item);
                    }
                }
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