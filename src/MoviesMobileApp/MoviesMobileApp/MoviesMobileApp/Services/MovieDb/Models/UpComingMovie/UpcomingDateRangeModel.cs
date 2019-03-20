using Newtonsoft.Json;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class UpcomingMoviesDateRange
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}
