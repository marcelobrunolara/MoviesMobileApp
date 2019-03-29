using MoviesMobileApp.Helpers;
using MoviesMobileApp.Services.MovieDb.DataDictionary.Helpers;
using MoviesMobileApp.Services.MovieDb.Models;
using MoviesMobileApp.ViewModels.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMobileApp.Services.MovieDb.Extensions
{
    public static class MovieDbModelExtensions
    {
        public static MovieSearchResultViewModel ToViewModel (this MovieSearchResultModel model)
        {
            if (model is null)
                return default(MovieSearchResultViewModel);

            var viewModel = new MovieSearchResultViewModel
            {
                Page = model.Page,
                TotalPages = model.TotalPages,
                TotalResults = model.TotalResults,
                UpcomingInitialDate = model.Dates.Minimum,
                UpcomingFinalDate = model.Dates.Maximum,
            };

            viewModel.Movies = new ObservableCollection<MovieViewModel>();

            foreach(var movie in model.Movies)
            {
                var backdropUrl = string.IsNullOrEmpty(movie.BackdropPath) ? ServicesResource.BackdropNotFoundURL :
                    string.Concat(MyPreferences.ImageBaseUrl, MyPreferences.BackdropImageSize, movie.BackdropPath);

                string posterUrl = string.IsNullOrEmpty(movie.PosterPath) ? ServicesResource.PosterNotFoundURL :
                    string.Concat(MyPreferences.ImageBaseUrl, MyPreferences.PosterImageSize, movie.PosterPath);

                var genres = DataDictionaryHelper.Genre.GetSpecificValuesSeparatedByComma(movie.GenreIds);

                var movieViewModel = new MovieViewModel()
                {
                    Genre = genres,
                    Name = movie.Title,
                    Overview = movie.Overview,
                    ReleaseDate = movie.ReleaseDate,
                    BackdropUrl = backdropUrl,
                    PosterUrl = posterUrl,
                };

                viewModel.Movies.Add(movieViewModel);
            }

            return viewModel;
        }
    }
}
