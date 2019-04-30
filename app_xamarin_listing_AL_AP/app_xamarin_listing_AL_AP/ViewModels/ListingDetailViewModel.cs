using System;

using app_xamarin_listing_AL_AP.Models;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class ListingDetailViewModel : BaseViewModel
    {
        private Listing listing = null;

        public Listing Listing
        {
            get { return listing; }
            set { SetProperty(ref listing, value); }
        }

        public ListingDetailViewModel(Listing listing = null)
        {
            Title = Ressources.AppResources.ListingDetails;
            Listing = listing;
        }
    }
}