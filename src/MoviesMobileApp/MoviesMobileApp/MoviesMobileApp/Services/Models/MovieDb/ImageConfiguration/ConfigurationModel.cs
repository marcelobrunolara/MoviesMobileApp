using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class ConfigurationModel
    {
        [JsonProperty("change_keys")]
        public List<string> ChangeKeys { get; set; }


        [JsonProperty("images")]
        public ImagesConfigurationModel Images { get; set; }
    }
}
