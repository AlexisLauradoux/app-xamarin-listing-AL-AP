using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace app_xamarin_listing_AL_AP.Models
{
    public class Listing
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("author")]
        public string Auteur { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}