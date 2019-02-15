using System;

using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Time;
            Item = item;
        }
    }
}
