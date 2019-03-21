using ML.Framework.Base.Services.Connector;
using ML.Framework.Base.Services.Connector.Interface;
using ML.Framework.Base.Services.Models;
using MoviesMobileApp.Helpers;
using MoviesMobileApp.Services.MovieDb.DataDictionary.Helpers;
using MoviesMobileApp.Services.MovieDb.Extensions;
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
            try
            {
                var url = URLHelper.MakeURL(ServicesResource.BaseURL, ServicesResource.Configurations, ServicesResource.API_KEY);

                var result = await _connector.GetJson(url);

                if (!result.IsValid)
                    return ResultHelper.MakeErrorMessage(result.HttpStatusCode, result.Message, false);

                var configurations = JsonConvert.DeserializeObject<ConfigurationModel>(result.Content);

                MyPreferences.ImageBaseUrl = configurations.Images.SecureBaseUrl;
                MyPreferences.PosterImageSize = configurations.Images.PosterSizes?[2];
                MyPreferences.BackdropImageSize = configurations.Images.BackdropSizes?[1];

                return ResultHelper.MakeResponseContentMessage(true);
            }
            catch (Exception e)
            {
                return ResultHelper.MakeExceptionMessage<bool>(e);
            }
        }

        public async Task<Result<bool>> GetAndStoreGenres()
        {
            try
            {
                var url = URLHelper.MakeURL(ServicesResource.BaseURL, ServicesResource.Genre, ServicesResource.API_KEY, MyPreferences.LanguageInfo);

                var result = await _connector.GetJson(url);

                if (!result.IsValid)
                    return ResultHelper.MakeErrorMessage(result.HttpStatusCode, result.Message, false);

                var movieGenres = JsonConvert.DeserializeObject<MovieGenresModel>(result.Content);
                var dataDictionaryList = movieGenres.Genre.ToList<IDataDictionary>();

                DataDictionaryHelper.Genre.Save(dataDictionaryList);

                return ResultHelper.MakeResponseContentMessage(true);
            }
            catch (Exception e)
            {
                return ResultHelper.MakeExceptionMessage<bool>(e);
            }
        }

        public async Task<Result<MovieSearchResultViewModel>> GetUpcomingMovies(int? pageNumber = null)
        {
            var _pageNumber = pageNumber ?? 1;

                        try
            {
                var url = URLHelper.MakeURL(ServicesResource.BaseURL, 
                                            ServicesResource.Upcoming, ServicesResource.API_KEY, 
                                            _pageNumber, MyPreferences.LanguageInfo, 
                                            MyPreferences.RegionInfo);

                var result = await _connector.GetJson(url);

                if (!result.IsValid)
                    return ResultHelper.MakeErrorMessage(result.HttpStatusCode, result.Message, default(MovieSearchResultViewModel));

                var movieSearchResultModel = JsonConvert.DeserializeObject<MovieSearchResultModel>(result.Content);
                var movieSearchResultViewModel = movieSearchResultModel.ToViewModel();

                return ResultHelper.MakeResponseContentMessage(movieSearchResultViewModel);
            }
            catch (Exception e)
            {
                return ResultHelper.MakeExceptionMessage<MovieSearchResultViewModel>(e);
            }
        }

        public Task<Result<MovieViewModel>> GetMovieDetail(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Result<MovieViewModel>>> SearchSpecific(string movieName, int? pageNumber = null)
        {
            throw new NotImplementedException();
        }
    }
}
