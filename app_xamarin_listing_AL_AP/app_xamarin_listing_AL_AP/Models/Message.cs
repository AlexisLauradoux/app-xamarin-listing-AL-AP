using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace app_xamarin_listing_AL_AP.Models
{
    public partial class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Content { get; set; }

        [JsonProperty("id_annonce")]
        public string IdAnnonce { get; set; }
    }
}