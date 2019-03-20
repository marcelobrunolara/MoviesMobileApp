using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class MovieSearchList
    {
        [JsonProperty("results")]
        public List<MovieModel> Movies { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("dates")]
        public UpcomingMoviesDateRange Dates { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
