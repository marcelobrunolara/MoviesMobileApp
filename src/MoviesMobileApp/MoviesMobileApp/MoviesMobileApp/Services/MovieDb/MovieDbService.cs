using ML.Framework.Base.Services.Connector.Interface;
using ML.Framework.Base.Services.Models;
using MoviesMobileApp.Services.MovieDb.Interface;
using MoviesMobileApp.Services.MovieDb.Models;
using MoviesMobileApp.ViewModels.Input;
using System.Collections.Generic;

namespace MoviesMobileApp.Services.MovieDb
{
    public class MovieDbService : IMovieDbService
    {
        private IRestConnector _connector;

        public MovieDbService(IRestConnector connector)
        {
            _connector = connector;
        }

        public Result<ImagesConfigurationModel> ConfigurationModel()
        {
            throw new System.NotImplementedException();
        }

        public Result<ImagesConfigurationModel> GetGenre(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public Result<MovieViewModel> GetMovieDetail(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public IList<Result<MovieViewModel>> GetUpcomingMovies(int? pageNumber = null)
        {
            throw new System.NotImplementedException();
        }

        public IList<Result<MovieViewModel>> SearchSpecific(string movieName, int? pageNumber = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
