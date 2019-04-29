using app_xamarin_listing_AL_AP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace app_xamarin_listing_AL_AP.DAL
{
    internal class ListingDataStore : IDataStore<Listing>
    {
        private readonly string ApiUri = @"https://app-ruby-listing-al-ap.herokuapp.com/api/v1/";

        public Task<bool> AddItemAsync(Listing item)
        {
            throw new NotImplementedException();
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
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(ApiUri + "annonces");
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonbrut = await response.Content.ReadAsStringAsync();
                        resultat = JsonConvert.DeserializeObject<List<Listing>>(jsonbrut);
                        return resultat;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public Task<bool> UpdateItemAsync(Listing item)
        {
            throw new NotImplementedException();
        }
    }
}