using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.Services;
using System.Linq;
using System.Collections.Generic;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Events> Events { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EventsViewModel()
        {
            Title = "Deep Sea World";
            Events = new ObservableCollection<Events>();
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
                SQLiteDB dbcon = new SQLiteDB();
                List<Events> events = new List<Events>();
                //get list of events from db
                //events = dbcon.GetItemAsyncEvents().Result;
                events = App.EventsDatabase.GetEventsAsync().Result;
                Console.WriteLine("EVENT ONE: " + events[0].Event_Name);
                events = NextEventService.GetNextEvents(events);
                foreach (var e in events)
                {

                    Events.Add(e);
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