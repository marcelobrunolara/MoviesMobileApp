using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviesMobileApp.Services.Models.MovieDb.MovieDetail
{
    public class MovieDetailModel
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("budget")]
        public int Budget { get; set; }

        [JsonProperty("genres")]
        public List<GenreModel> Genres { get; set; }

        [JsonProperty("homepage")]
        public string HomePage { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public object PosterPath { get; set; }

        [JsonProperty("production_companies")]
        public List<ProductionCompanyModel> ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountryModel> ProductionCountries { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("revenue")]
        public int Revenue { get; set; }

        [JsonProperty("runtime")]
        public int runtime { get; set; }

        [JsonProperty("spoken_languages")]
        public List<SpokenLanguageModel> SpokenLanguages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
    }
}
