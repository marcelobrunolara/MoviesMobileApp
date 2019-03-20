using ML.Framework.Base.Services.Models;
using MoviesMobileApp.Services.MovieDb.Models;
using MoviesMobileApp.ViewModels.Input;
using System.Collections.Generic;

namespace MoviesMobileApp.Services.MovieDb.Interface
{
    public interface IMovieDbService
    {
        IList<Result<MovieViewModel>> GetUpcomingMovies(int? pageNumber = null);
        IList<Result<MovieViewModel>> SearchSpecific(string movieName, int? pageNumber=null);
        Result<MovieViewModel> GetMovieDetail(int movieId);
        Result<ImagesConfigurationModel> ConfigurationModel();
        Result<ImagesConfigurationModel> GetGenre(int movieId);
    }
}
