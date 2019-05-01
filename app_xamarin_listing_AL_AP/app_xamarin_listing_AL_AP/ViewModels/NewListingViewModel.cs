using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Views;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class NewListingViewModel : BaseViewModel
    {
        private MainPage mainPage;
        public Command CreateListingCommand { get; set; }

        public Command GetCategoriesCommand { get; set; }

        private Listing listing = null;

        public Listing Listing
        {
            get { return listing; }
            set { SetProperty(ref listing, value); }
        }

        private List<Category> categories = null;

        public List<Category> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        private Category categorySelected = null;

        public Category CategorySelected
        {
            get { return categorySelected; }
            set { SetProperty(ref categorySelected, value); }
        }

        private async Task<bool> ExecuteCreateListingCommand()
        {
            if (IsBusy)
                return false;

            IsBusy = true;

            Listing.Category = CategorySelected;

            if (await ListingDataStore.AddItemAsync(listing))
            {
                IsBusy = false;
                await mainPage.NavigateFromMenu((int)MenuItemType.Listings);
                return true;
            }

            IsBusy = false;

            return false;
        }

        private async Task ExecuteGetCategoriesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Categories = await CategoryDataStore.GetItemsAsync();

            if (Categories != null)
            {
                Listing.Category = Categories.FirstOrDefault();
                CategorySelected = Listing.Category;
            }
            else
            {
                Categories = new List<Category>();
            }

            IsBusy = false;
        }

        public NewListingViewModel(MainPage mainPage)
        {
            Title = Ressources.AppResources.NewListing;
            this.mainPage = mainPage;
            Listing = new Listing();
            Categories = new List<Category>();
            CreateListingCommand = new Command(async () => await ExecuteCreateListingCommand());
            GetCategoriesCommand = new Command(async () => await ExecuteGetCategoriesCommand());
        }
    }
}