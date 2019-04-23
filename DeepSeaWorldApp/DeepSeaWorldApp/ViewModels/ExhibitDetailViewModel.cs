using System;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.ViewModels
{
    public class ExhibitDetailViewModel : BaseViewModel2
    {
        public Exhibition Exhibition { get; set; }
        public ExhibitDetailViewModel(Exhibition exhibition = null)
        {
            Title = exhibition?.Exhibition_Name;
            Exhibition = exhibition;
        }
    }
}
