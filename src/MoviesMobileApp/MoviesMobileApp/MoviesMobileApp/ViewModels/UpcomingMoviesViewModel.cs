using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ML.Framework.Base.MVVM;
using ML.Framework.Base.Services.Models;
using MoviesMobileApp.Services.MovieDb.Interface;
using MoviesMobileApp.ViewModels.Input;
using MoviesMobileApp.ViewModels.Interfaces;
using MoviesMobileApp.Views.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MoviesMobileApp.ViewModels
{
    public class UpcomingMoviesViewModel : BaseViewModelList<MovieViewModel>, IUpcomingMoviesViewModel
    {

        #region Fields

        private string _warningMessage;
        private int _currentPage = 1;
        private bool _seeMoreButtonVisibility = false;

        private IMovieDbService _movieDbService;
        private MovieViewModel _currentItem;
        private ICommand _upcomingMoviesNextPage;
        private ICommand _refreshUpcomingMoviesListCommand;

        #endregion

        #region Properties

        public string WarningMessage
        {
            get => _warningMessage;
            set => SetAndRaisePropertyChanged(ref _warningMessage, value);
        }

        public int CurrentPage
        {
            get => _currentPage;
            set => SetAndRaisePropertyChanged(ref _currentPage, value);
        }

        public bool SeeMoreButtonVisibility
        {
            get => _seeMoreButtonVisibility;
            set => SetAndRaisePropertyChanged(ref _seeMoreButtonVisibility, value);
        }

        public override MovieViewModel CurrentItem
        {
            get => _currentItem;
            set => DefineAndNavigateToMovieDetail(value);
        }

        public MovieSearchResultViewModel SearchResultViewModel
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public UpcomingMoviesViewModel(IMovieDbService movieDbService)
        {
            _movieDbService = movieDbService;
        }

        #endregion


        #region Methods
        private void DefineAndNavigateToMovieDetail(MovieViewModel value)
        {
            if (value is null)
                return;

            SetAndRaisePropertyChanged(ref _currentItem, value);
            PageProxy.PushModal<IMovieDetailPage, IMovieDetailViewModel>(c => { c.CurrentItem = _currentItem;});
        }

        public override void ExecuteBeforeBinding()
        {
            LoadConfigurationAndGenreList();
            LoadUpcomingMovies();
        }

        private void LoadConfigurationAndGenreList()
        {
            IsBusy = true;

            if (CheckAndSetIfItsNotConnected())
            {
                IsBusy = false;
                return;
            }

            Task.Run(async () =>
            {
                await _movieDbService.GetAndSetConfigurationOnPreferences();
                await _movieDbService.GetAndStoreGenres();

            }).ContinueWith(c =>
            {
                if (c.IsCompleted)
                    IsBusy = false;
            });
        }

        private bool CheckAndSetIfItsNotConnected()
        {
            return IsDeviceOffline = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        private void LoadUpcomingMovies()
        {
            IsBusy = true;

            if (CheckAndSetIfItsNotConnected())
            {
                IsBusy = false;
                return;
            }

            Task.Run(async () =>
            {
                var response = await _movieDbService.GetUpcomingMovies(_currentPage);

                if (response.IsValid)
                    SetViewModelToShowInformation(response.Content);
                else
                    ShowInvalidResponseMessage(response);

            }).ContinueWith(c =>
            {
                if (c.IsCompleted)
                    IsBusy = false;
            });
        }

        private void SetViewModelToShowInformation(MovieSearchResultViewModel content)
        {
            SearchResultViewModel = content;
            SetListViewItems(content.Movies);
            TryToIncrementCurrentPage();
            CheckSeeMoreButtonVisibility();
        }

        private void SetListViewItems(ObservableCollection<MovieViewModel> movies)
        {
            if (Items is null)
                Items = new ObservableCollection<MovieViewModel>();

            foreach (var movie in movies)
                Items.Add(movie);
        }

        private void TryToIncrementCurrentPage()
        {
            if (CurrentPage <= SearchResultViewModel.TotalPages)
                ++CurrentPage;
        }

        private void CheckSeeMoreButtonVisibility()
        {
            SeeMoreButtonVisibility = _currentPage <= SearchResultViewModel.TotalPages;
        }

        private void ShowInvalidResponseMessage(Result<MovieSearchResultViewModel> response)
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region Commands

        public ICommand UpcomingMoviesNextPageCommand
        {
            get => _upcomingMoviesNextPage ?? (_upcomingMoviesNextPage = new Command(() => LoadUpcomingMovies()));

        }

        private void RefreshParameters()
        {
            CurrentPage = 1;
            Items = new ObservableCollection<MovieViewModel>();
            IsPullToRefreshBusy = false;
            SeeMoreButtonVisibility = false;
        }

        public ICommand RefreshUpcomingMoviesListCommand
        {
            get => _refreshUpcomingMoviesListCommand ?? (_refreshUpcomingMoviesListCommand = new Command(() =>
            {
                RefreshParameters();
                LoadUpcomingMovies();
            }));
        }

        #endregion
    }
}
