using Newtonsoft.Json;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class ProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string ISO3166_1 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
