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
    public class MapViewModel
    {
        public Event Event { get; }

        public MapViewModel()
        {
            Event = new Event
            {
                Name = "name",
            };
        }
        public MapViewModel(Event e)
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

