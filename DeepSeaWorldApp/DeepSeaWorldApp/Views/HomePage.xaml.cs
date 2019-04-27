using System;
using Xamarin.Forms;
using DeepSeaWorldApp.Services;
using DeepSeaWorldApp.ViewModels;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Views
{
    public partial class HomePage : ContentPage
    {
        Events nextE = new Events();

        public HomePage()
        {
            Notifications n = new Notifications();
            n.ScheduleNotifications();
            Console.WriteLine("homepage start");
            InitializeComponent();

                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    //get next event
                    var next = GetNextEvent();
                    nextE = next.Result;

                    //new code to get "starts in" time
                    DateTime time = Convert.ToDateTime(nextE.Event_Time);   //time of next event
                    DateTime time2 = time.AddMinutes(1);                    //add 1 minute to round up
                    TimeSpan diff1 = time2.Subtract(DateTime.Now);          //difference between next event and current time

                    //set UI elements based on next event object
                    eventNameText.Text = nextE.Event_Name;
                    eventImage.Source = nextE.Event_IMG;

                    //next event text display changes
                    if (nextE.Event_Name.Equals("No more events today"))
                    {
                        eventTimeText.Text = "";
                        eventBridgeText.Text = "";
                    }
                    else if (diff1.Hours < 1)
                    {
                        if (diff1.Minutes < 1)
                        {
                            eventTimeText.Text = "has started";
                            eventBridgeText.Text = "";
                        }
                        else if (diff1.Minutes == 1)
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Minutes + " minute");
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Minutes + " minutes");
                        }
                    }
                    else if (diff1.Hours == 1)
                    {
                        if (diff1.Minutes == 0)
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hour");
                        }
                        else if (diff1.Minutes == 1)
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hour " + diff1.Minutes + " minute");
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hour " + diff1.Minutes + " minutes");
                        }
                    }
                    else
                    {
                        if (diff1.Minutes == 0)
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hours");
                        }
                        else if (diff1.Minutes == 1)
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hours " + diff1.Minutes + " minute");
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => eventTimeText.Text = diff1.Hours + " hours " + diff1.Minutes + " minutes");
                        }
                    }
                    return true;

                });


            }

            //when next event timer frame is tapped
            void NextEventTapped(object sender, System.EventArgs e)
            {
                Navigation.PushAsync(new EventDetailPage(new EventDetailViewModel(nextE)));
            }

            //when QR code info frame is tapped
            void QRTapped(object sender, System.EventArgs e)
            {
                Navigation.PushAsync(new QRScannerPage());
            }

            async Task<Events> GetNextEvent()
            {
                NextEventService n = new NextEventService();
                return await n.GetNextEvent();
            }

        }


    }

