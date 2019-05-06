using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.DAL
{
    internal class ListingDataStore : IDataStore<Listing>
    {
        private ApiWebService apiWebService => DependencyService.Get<ApiWebService>() ?? new ApiWebService();

        public async Task<bool> AddItemAsync(Listing item)
        {
            return await apiWebService.CreateListingAsync(item);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Listing> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Listing>> GetItemsAsync(bool forceRefresh = false)
        {
            List<Listing> resultat = new List<Listing>();
            resultat = await apiWebService.GetListingsAsync();
            return resultat;
        }

        public Task<bool> UpdateItemAsync(Listing item)
        {
            throw new NotImplementedException();
        }
    }
}