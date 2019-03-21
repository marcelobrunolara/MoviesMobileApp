using MoviesMobileApp.Helpers;
using MoviesMobileApp.Services.MovieDb.DataDictionary.Helpers;
using MoviesMobileApp.Services.MovieDb.Models;
using MoviesMobileApp.ViewModels.Input;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace MoviesMobileApp.Services.MovieDb.Extensions
{
    public static class MovieDbExtensions
    {
        public static UpcomingMoviesViewModel ToViewModel (this UpcomingMoviesModel model)
        {
            if (model is null)
                return default(UpcomingMoviesViewModel);

            var upcomingMoviesViewModel = new UpcomingMoviesViewModel
            {
                InitialDate = model.Dates.Minimum,
                FinalDate = model.Dates.Maximum,
                Page = model.Page,
                TotalPages = model.Page,
                TotalResults = model.TotalResults
            };

            upcomingMoviesViewModel.MovieViewModelList = new ObservableCollection<MovieViewModel>();

            foreach(var movie in model.Movies)
            {
                var genre = DataDictionaryHelper.Genre.GetSpecificValuesSeparatedByComma(movie.GenreIds);
                var backdropUrl = string.Concat(MyPreferences.ImageBaseUrl, MyPreferences.BackdropImageSize, movie.BackdropPath);
                var posterUrl = string.Concat(MyPreferences.ImageBaseUrl, MyPreferences.PosterImageSize, movie.PosterPath);

                var movieViewModel = new MovieViewModel
                {
                    Name = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    Overview = movie.Overview,
                    Genre = genre,
                    BackdropUrl = backdropUrl,
                    PosterUrl = posterUrl
                };

                upcomingMoviesViewModel.MovieViewModelList.Add(movieViewModel);
            }

            return upcomingMoviesViewModel;

        }
    }
}
