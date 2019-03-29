using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class ConfigurationModel
    {
        [JsonProperty("change_keys")]
        public List<string> ChangeKeys { get; set; }


        [JsonProperty("images")]
        public ImagesConfigurationModel Images { get; set; }
    }
}
