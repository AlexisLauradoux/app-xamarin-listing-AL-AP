using System;

using app_xamarin_listing_AL_AP.Models;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
