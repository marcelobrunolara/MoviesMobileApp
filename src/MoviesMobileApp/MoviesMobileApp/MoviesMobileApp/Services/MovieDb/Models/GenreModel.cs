using Newtonsoft.Json;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class GenreModel : IDataDictionary
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
