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
        public ObservableCollection<Listing> Listings { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ListingsViewModel()
        {
            Title = app_xamarin_listing_AL_AP.Ressources.AppResources.Listings;
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
                foreach (var item in await DataStore.GetItemsAsync())
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