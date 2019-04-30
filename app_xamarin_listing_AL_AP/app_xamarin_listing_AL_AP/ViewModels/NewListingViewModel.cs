using System;
using System.Threading.Tasks;
using app_xamarin_listing_AL_AP.Models;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class NewListingViewModel : BaseViewModel
    {
        private Listing listing = null;

        public Command CreateListingCommand { get; set; }

        public Listing Listing
        {
            get { return listing; }
            set { SetProperty(ref listing, value); }
        }

        private async Task<bool> ExecuteCreateListingCommand()
        {
            if (IsBusy)
                return false;

            IsBusy = true;

            if (await ListingDataStore.AddItemAsync(listing))
            {
                IsBusy = false;
                return true;
            }

            IsBusy = false;

            return false;
        }

        public NewListingViewModel()
        {
            Title = Ressources.AppResources.NewListing;
            Listing = new Listing();
            CreateListingCommand = new Command(async () => await ExecuteCreateListingCommand());
        }
    }
}