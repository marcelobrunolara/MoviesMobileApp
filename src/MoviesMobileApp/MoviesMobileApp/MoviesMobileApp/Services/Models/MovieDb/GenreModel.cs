using MoviesMobileApp.Services.DataDictionary;
using Newtonsoft.Json;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class GenreModel : IDataDictionary
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
