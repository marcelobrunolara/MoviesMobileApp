using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesMobileApp.Services.Models.MovieDb.UpComingMovie
{
    public class UpComingMoviesModel
    {
        [JsonProperty("results")]
        public List<MovieModel> Movies { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("dates")]
        public DateRangeModel Dates { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
