using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.Services;
using System.Linq;

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
<<<<<<< HEAD
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
=======
                var events = await DataStore.GetItemsAsync(true);
                //events = events.OrderBy(x => x.Time);
                //change this to be more dynamic and not just based on 30 / 60
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
>>>>>>> parent of 5e07e74... events data synced to app. still duplicates issue
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