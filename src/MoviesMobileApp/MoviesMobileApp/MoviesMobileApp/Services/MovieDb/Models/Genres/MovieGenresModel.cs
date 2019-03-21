using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class MovieGenresModel
    {
        [JsonProperty("genres")]
        public List<GenreModel> Genre { get; set; }
    }
}
