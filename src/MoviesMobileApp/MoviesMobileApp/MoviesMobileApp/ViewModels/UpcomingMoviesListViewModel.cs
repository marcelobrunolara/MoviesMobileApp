using System;
using System.Threading.Tasks;
using ML.Framework.Base.MVVM;
using MoviesMobileApp.Services.MovieDb.Interface;
using MoviesMobileApp.ViewModels.Input;
using MoviesMobileApp.ViewModels.Interfaces;
using Xamarin.Essentials;

namespace MoviesMobileApp.ViewModels
{
    public class UpcomingMoviesListViewModel : BaseViewModelList<MovieViewModel>, IUpcomingMoviesListViewModel
    {

        #region Fields

        IMovieDbService _movieDbService;

        #endregion

        #region Constructor

        public UpcomingMoviesListViewModel(IMovieDbService movieDbService)
        {
            _movieDbService = movieDbService;
        } 

        #endregion

        #region Methods

        public override void ExecuteBeforeBinding()
        {
            LoadConfigurationAndGenreList();
        }

        private void LoadConfigurationAndGenreList()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            UpcomingMoviesViewModel viewModel = default(UpcomingMoviesViewModel);

            IsBusy = true;

            Task.Run(async () =>
            {
                await _movieDbService.GetAndSetConfigurationOnPreferences();
                await _movieDbService.GetAndStoreGenres();

                var response = await _movieDbService.GetUpcomingMovies();

                if (response.IsValid)
                    viewModel = response.Content;

            });
        }

        #endregion
    }
}
