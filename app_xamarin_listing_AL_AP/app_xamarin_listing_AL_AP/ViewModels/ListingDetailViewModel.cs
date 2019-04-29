using System;

using app_xamarin_listing_AL_AP.Models;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class ListingDetailViewModel : BaseViewModel
    {
        public Listing Listing { get; set; }

        public ListingDetailViewModel(Listing listing = null)
        {
            Listing = listing;
        }
    }
}