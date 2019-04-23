
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.ViewModels
{
    public class MapViewModel
    {
        public Events Event { get; }

        public MapViewModel()
        {
            Event = new Events
            {
                Event_Name = "name",
            };
        }
        public MapViewModel(Events e)
        {
            Event = new Events
            {
                Event_Name = "event2",
                Event_Location = e.Event_Location,
                Event_Time = e.Event_Time,
                Event_Description = e.Event_Description,
            };
        }
    }
}

