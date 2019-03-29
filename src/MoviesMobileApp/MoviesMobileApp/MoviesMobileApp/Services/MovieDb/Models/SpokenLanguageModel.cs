using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class SpokenLanguageModel
    {
        [JsonProperty("iso_639_1")]
        public string ISO639_1 { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
