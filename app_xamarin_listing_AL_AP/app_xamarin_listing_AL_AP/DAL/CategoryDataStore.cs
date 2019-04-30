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
    internal class CategoryDataStore : IDataStore<Category>
    {
        private ApiWebService apiWebService => DependencyService.Get<ApiWebService>() ?? new ApiWebService();

        public Task<bool> AddItemAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            List<Category> resultat = new List<Category>();
            resultat = await apiWebService.GetCategoriesAsync();
            return resultat;
        }

        public Task<bool> UpdateItemAsync(Category item)
        {
            throw new NotImplementedException();
        }
    }
}