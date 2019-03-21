using Newtonsoft.Json;
using System;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class UpcomingMoviesDateRange
    {
        [JsonProperty("maximum")]
        public DateTime Maximum { get; set; }

        [JsonProperty("minimum")]
        public DateTime Minimum { get; set; }
    }
}
