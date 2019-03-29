using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class ImagesConfigurationModel
    {
        [JsonProperty("base_url")]
        public string BaseUrl { get; set; }

        [JsonProperty("secure_base_url")]
        public string SecureBaseUrl { get; set; }

        [JsonProperty("backdrop_sizes")]
        public List<string> BackdropSizes { get; set; }


        [JsonProperty("poster_sizes")]
        public List<string> PosterSizes { get; set; }

    }
}
