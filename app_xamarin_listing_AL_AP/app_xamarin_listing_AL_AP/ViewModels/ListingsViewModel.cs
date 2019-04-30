using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Views;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class ListingsViewModel : BaseViewModel
    {
        private ObservableCollection<Listing> listings = null;

        public ObservableCollection<Listing> Listings
        {
            get { return listings; }
            set { SetProperty(ref listings, value); }
        }

        public Command LoadItemsCommand { get; set; }

        public ListingsViewModel()
        {
            Title = Ressources.AppResources.Listings;
            Listings = new ObservableCollection<Listing>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Listings.Clear();
                foreach (var item in await ListingDataStore.GetItemsAsync())
                {
                    Listings.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}