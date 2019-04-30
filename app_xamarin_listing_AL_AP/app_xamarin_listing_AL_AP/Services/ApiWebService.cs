using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Utilities;
using app_xamarin_listing_AL_AP.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.Services
{
    internal class ApiWebService
    {
        private readonly string ApiUri = @"https://app-ruby-listing-al-ap.herokuapp.com/api/v1/";
        private readonly string ApiUriAuth = @"https://app-ruby-listing-al-ap.herokuapp.com/api/auth";

        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> resultat = new List<Category>();
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(ApiUri + "categories");
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonbrut = await response.Content.ReadAsStringAsync();
                        resultat = JsonConvert.DeserializeObject<List<Category>>(jsonbrut);
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

        public async Task<List<Listing>> GetListingsAsync()
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

        public async Task<bool> CreateListingAsync(Listing listing)
        {
            if (listing == null)
                return false;

            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    HttpClient client = new HttpClient();
                    List<KeyValuePair<string, string>> tuples = new List<KeyValuePair<string, string>>();
                    tuples.Add(new KeyValuePair<string, string>("category_id", listing.Category));
                    tuples.Add(new KeyValuePair<string, string>("content", listing.Description));
                    tuples.Add(new KeyValuePair<string, string>("price", listing.Price.ToString()));
                    tuples.Add(new KeyValuePair<string, string>("user_id", listing.Auteur));
                    tuples.Add(new KeyValuePair<string, string>("title", listing.Title));
                    HttpContent content = new FormUrlEncodedContent(tuples);
                    content.Headers.Add("token", Settings.Token);
                    var response = await client.PostAsync(ApiUri + "create", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        await Authentification();
                        response = await client.PostAsync(ApiUri + "create", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public async Task<string> Authentification()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    HttpClient client = new HttpClient();
                    Dictionary<string, string> keyValues = new Dictionary<string, string>();
                    keyValues.Add("email", Settings.Login);
                    keyValues.Add("password", Settings.Password);
                    HttpContent content = new FormUrlEncodedContent(keyValues);
                    var responseHttp = await client.PostAsync(ApiUriAuth, content);
                    if (responseHttp.IsSuccessStatusCode)
                    {
                        string jsonbrut = await responseHttp.Content.ReadAsStringAsync();
                        Response response = JsonConvert.DeserializeObject<Response>(jsonbrut);
                        Settings.Token = response.Token;
                        Settings.IsConnected = true;
                        MessagingCenter.Send<ApiWebService>(this, "IsConnected");
                        return Settings.Token;
                    }
                    Settings.IsConnected = false;
                    MessagingCenter.Send<ApiWebService>(this, "IsConnected");
                    return "";
                }
                else
                {
                    Settings.IsConnected = false;
                    MessagingCenter.Send<ApiWebService>(this, "IsConnected");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.IsConnected = false;
                MessagingCenter.Send<ApiWebService>(this, "IsConnected");
            }
            return null;
        }
    }
}