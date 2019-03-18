using System;

using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item)
        {
            Title = item.Name;
            Item = item;
        }

    }
}
