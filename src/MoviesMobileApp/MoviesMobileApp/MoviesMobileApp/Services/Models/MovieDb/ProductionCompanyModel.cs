using MoviesMobileApp.Services.DataDictionary;
using Newtonsoft.Json;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class ProductionCompanyModel : IDataDictionary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }
    }
}
