using System;

using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.ViewModels
{
    public class ExhibitDetailViewModel : BaseViewModel2
    {
        public Exhibit Exhibit { get; set; }
        public ExhibitDetailViewModel(Exhibit exhibit = null)
        {
            Title = exhibit?.Name;
            Exhibit = exhibit;
        }
    }
}
