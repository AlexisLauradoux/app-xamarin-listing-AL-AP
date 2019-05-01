﻿using System;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Views;
using System.Linq;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class ListingsViewModel : BaseViewModel
    {
        private ObservableCollection<Listing> listingsAll = null;
        private ObservableCollection<Listing> listings = null;

        public ObservableCollection<Listing> Listings
        {
            get { return listings; }
            set { SetProperty(ref listings, value); }
        }

        public Command LoadItemsCommand { get; set; }

        public Command SearchCommand { get; set; }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        public ListingsViewModel()
        {
            Title = Ressources.AppResources.Listings;
            Listings = new ObservableCollection<Listing>();
            listingsAll = new ObservableCollection<Listing>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SearchCommand = new Command(async () => await ExecuteSearchCommand());
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
                    listingsAll.Add(item);
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

        private async Task ExecuteSearchCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Listings.Clear();

            if (SearchText == string.Empty)
            {
                foreach (var item in listingsAll)
                {
                    Listings.Add(item);
                }
            }
            else
            {
                foreach (var item in listingsAll.Where(x => x.CategoryName.ToLower().Contains(SearchText.ToLower()) || x.Title.ToLower().Contains(SearchText.ToLower()) || x.Description.ToLower().Contains(SearchText.ToLower())))
                {
                    Listings.Add(item);
                }
            }

            IsBusy = false;
        }
    }
}