using System;
using System.Collections.Generic;
using System.Text;

namespace TMDb.Test
{
    public class Constants
    {
        public const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";

        public const string ApiBaseURL = "https://api.themoviedb.org/3/";
        public const string ImageBaseURL = "https://image.tmdb.org/t/p/{0}/{1}";

        public const string ImageConfigurationsResource = "configuration?api_key={0}";
        public const string MoviesGenreResource = "genre/movie/list?api_key={0}&language={1}";
        public const string UpComingMoviesResource = "movie/upcoming?api_key={0}&language={1}&page={2}&region={3}";
        public const string MovieDetailResource = "/movie/{movie_id}";

    }
}
