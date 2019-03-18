using System;

using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.ViewModels
{
    public class FeatureDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public FeatureDetailViewModel(Item item = null)
        {
            Title = item?.Time;
            Item = item;
        }
    }
}
