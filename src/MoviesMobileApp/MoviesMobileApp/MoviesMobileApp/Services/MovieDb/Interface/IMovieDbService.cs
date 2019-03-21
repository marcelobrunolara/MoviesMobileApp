using ML.Framework.Base.Services.Models;
using MoviesMobileApp.Services.MovieDb.Models;
using MoviesMobileApp.ViewModels.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesMobileApp.Services.MovieDb.Interface
{
    public interface IMovieDbService
    {
        Task<Result<MovieSearchResultViewModel>> GetUpcomingMovies(int? pageNumber = null);
        Task<IList<Result<MovieViewModel>>> SearchSpecific(string movieName, int? pageNumber=null);
        Task<Result<MovieViewModel>> GetMovieDetail(int movieId);
        Task<Result<bool>> GetAndSetConfigurationOnPreferences();
        Task<Result<bool>> GetAndStoreGenres();
    }
}
