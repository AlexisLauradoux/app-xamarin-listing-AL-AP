using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace app_xamarin_listing_AL_AP.Models
{
    public class Response
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}