using System;
using System.Threading.Tasks;
using ML.Framework.Base.MVVM;
using MoviesMobileApp.Services.MovieDb.Interface;
using MoviesMobileApp.ViewModels.Input;
using MoviesMobileApp.ViewModels.Interfaces;

namespace MoviesMobileApp.ViewModels
{
    public class UpcomingMoviesViewModel : BaseViewModelList<MovieViewModel>, IUpcomingMoviesViewModel
    {

        IMovieDbService _movieDbService;

        public UpcomingMoviesViewModel(IMovieDbService movieDbService)
        {
            _movieDbService = movieDbService;
        }

        #region Methods

        public override void ExecuteBeforeBinding()
        {
            LoadConfigurationAndGenreList();
        }

        private void LoadConfigurationAndGenreList()
        {
            Task.Run(async () =>
            {
                await _movieDbService.GetAndSetConfigurationOnPreferences();
                await _movieDbService.GetAndStoreGenres();
            });
        }

        #endregion
    }
}
