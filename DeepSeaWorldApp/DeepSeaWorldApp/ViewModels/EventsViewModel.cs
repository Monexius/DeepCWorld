using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
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
                //empty events collection
                Events.Clear();

                //get events from database
                List<Events> events = new List<Events>();
                SQLiteDB db = new SQLiteDB();
                events = db.GetItemAsyncEvents().Result;

                //get next events
                NextEventService n = new NextEventService();
                events = n.GetNextEvents(events).Result;

                //add next events to collection
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