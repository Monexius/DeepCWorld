using System;

using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.ViewModels
{
    public class FeatureDetailViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public FeatureDetailViewModel(Event e = null)
        {
            Title = e?.Time;
            Event = e;
        }
    }
}
