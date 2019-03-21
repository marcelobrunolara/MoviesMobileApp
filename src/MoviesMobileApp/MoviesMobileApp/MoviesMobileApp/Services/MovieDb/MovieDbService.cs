using ML.Framework.Base.Services.Connector;
using ML.Framework.Base.Services.Connector.Interface;
using ML.Framework.Base.Services.Models;
using MoviesMobileApp.Helpers;
using MoviesMobileApp.Services.MovieDb.DataDictionary.Helpers;
using MoviesMobileApp.Services.MovieDb.Interface;
using MoviesMobileApp.Services.MovieDb.Models;
using MoviesMobileApp.ViewModels.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesMobileApp.Services.MovieDb
{
    public class MovieDbService : IMovieDbService
    {
        private IRestConnector _connector;

        public MovieDbService(IRestConnector connector)
        {
            _connector = connector;
        }

        public async Task<Result<bool>> GetAndSetConfigurationOnPreferences()
        {
            var url = URLHelper.MakeURL(ServicesResource.BaseURL, ServicesResource.Configurations, ServicesResource.API_KEY);

            var result = await _connector.GetJson(url);

            if (!result.IsValid)
                return ResultHelper.MakeErrorMessage(result.HttpStatusCode, result.Message, false);
                
            var configurations = JsonConvert.DeserializeObject<ConfigurationModel>(result.Content);

            MyPreferences.ImageBaseUrl = configurations.Images.BaseUrl;
            MyPreferences.PosterImageSize = configurations.Images.PosterSizes?[0];
            MyPreferences.BackdropImageSize = configurations.Images.BackdropSizes?[0];

            return ResultHelper.MakeResponseContentMessage(true);
        }

        public async Task<Result<bool>> GetAndStoreGenres()
        {
            var url = URLHelper.MakeURL(ServicesResource.BaseURL, ServicesResource.Genre, ServicesResource.API_KEY, MyPreferences.LanguageInfo);

            var result = await _connector.GetJson(url);

            if (!result.IsValid)
                return ResultHelper.MakeErrorMessage(result.HttpStatusCode, result.Message, false);

            var genreList = JsonConvert.DeserializeObject<IList<GenreModel>>(result.Content);
            var dataDictionaryList = genreList.ToList<IDataDictionary>();

            DataDictionaryHelper.Genre.Save(dataDictionaryList);

            return ResultHelper.MakeResponseContentMessage(true);
        }

        public Task<Result<MovieViewModel>> GetMovieDetail(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Result<MovieViewModel>>> GetUpcomingMovies(int? pageNumber = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Result<MovieViewModel>>> SearchSpecific(string movieName, int? pageNumber = null)
        {
            throw new NotImplementedException();
        }
    }
}
