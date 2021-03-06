﻿using Newtonsoft.Json;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class ProductionCountryModel
    {
        [JsonProperty("iso_3166_1")]
        public string ISO3166_1 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
