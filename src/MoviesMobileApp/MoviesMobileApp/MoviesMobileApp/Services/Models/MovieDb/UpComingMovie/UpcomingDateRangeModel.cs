using Newtonsoft.Json;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class UpcomingMoviesDateRange
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}
