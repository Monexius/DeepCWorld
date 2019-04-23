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
                List<Events> events = new List<Events>();
                SQLiteDB dbcon = new SQLiteDB();
                //get list of events from db
                events = dbcon.GetItemAsyncEvents().Result;
                //Console.WriteLine("ALL EVENTS: ");
                int i = 0;
                foreach (var a in events)
                {
                    //Console.WriteLine(a.Event_Time + " " + i + " " + a.Event_Name);
                    i++;
                }
                events = NextEventService.GetNextEvents(events);
                Console.WriteLine(DateTime.UtcNow);
                Console.WriteLine("NEXT EVENTS: ");
                int k = 0;
                foreach (var a in events)
                {
                    Console.WriteLine(a.Event_Time + " " + k + " " + a.Event_Name);
                    k++;
                }
                foreach (var e in events)
                {

                    Events.Add(e);
                }
                Console.WriteLine(DateTime.UtcNow.Day);
                Console.WriteLine(DateTime.Now.Day);
                Console.WriteLine(DateTime.Now.DayOfWeek);
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