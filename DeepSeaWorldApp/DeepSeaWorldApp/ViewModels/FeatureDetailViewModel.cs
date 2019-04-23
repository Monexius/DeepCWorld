using System;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.ViewModels
{
    public class FeatureDetailViewModel : BaseViewModel
    {
        public Events Event { get; set; }
        public FeatureDetailViewModel(Events e = null)
        {
            Title = e?.Event_Time;
            Event = e;
        }
    }
}
