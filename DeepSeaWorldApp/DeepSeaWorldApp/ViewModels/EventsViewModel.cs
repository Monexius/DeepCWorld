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
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EventsViewModel()
        {
            Title = "Deep Sea World";
            Events = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Events.Clear();
                var events = await DataStore.GetItemsAsync(true);
                foreach (var e in events)
                {
                    int eventHour = Convert.ToInt32(e.Time.Substring(0, 2));
                    int eventMinute = Convert.ToInt32(e.Time.Substring(3, 2));
                    if (eventHour > NextEventService.GetNextEventHour())
                    {
                        Events.Add(e);
                    }
                    if (eventHour == NextEventService.GetNextEventHour() && eventMinute == 30 && NextEventService.GetNextEventMinute() == 30)
                    {
                        Events.Add(e);
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