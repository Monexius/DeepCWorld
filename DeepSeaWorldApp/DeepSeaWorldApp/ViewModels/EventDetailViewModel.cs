using System;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.ViewModels
{
    public class EventDetailViewModel : BaseViewModel
    {
        public Events Event { get; }
        public EventDetailViewModel()
        {
            Event = new Events
            {
                Event_Name = "name",
            };
        }
        public EventDetailViewModel(Events e)
        {
            Event = new Events
            {
                Event_Name = e.Event_Name,
                Event_Location = e.Event_Location,
                Event_Time = e.Event_Time,
                Event_Description = e.Event_Description,
            };
        }
    }
}
