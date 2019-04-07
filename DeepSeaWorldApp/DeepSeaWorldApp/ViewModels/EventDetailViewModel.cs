using System;

using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.ViewModels
{
    public class EventDetailViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public EventDetailViewModel()
        {
            Event = new Event
            {
                Name = "name",
            };
        }
        public EventDetailViewModel(Event e)
        {
            Event = new Event
            {
                Name = e.Name,
                Location = e.Location,
                Time = e.Time,
                Description = e.Description,
                Image = e.Image,
            };
        }
    }
}
