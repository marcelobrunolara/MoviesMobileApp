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

        public const int MILLISECONDS_WAITING_TASK = 250;

        private string _warningMessage;
        private int _currentPage = 1;
        private bool _seeMoreButtonVisibility = false;
        private bool _isDeviceOffline;
        private bool _anErrorOcurred;
        private Result<bool> _cachedInformationIsOk;

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

        public bool IsDeviceOffline
        {
            get => _isDeviceOffline;
            set => SetAndRaisePropertyChanged(ref _isDeviceOffline, value);
        }

        public bool AnErrorOcurred
        {
            get => _anErrorOcurred;
            set => SetAndRaisePropertyChanged(ref _anErrorOcurred, value);
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
            LoadAplicationData();
        }

        private void LoadAplicationData()
        {
            if (CheckAndSetIfItsNotConnected())
                return;

            if(BasicDataNotDownloaded())
                LoadConfigurationAndGenreList();

            LoadUpcomingMovies();
        }

        private bool CheckAndSetIfItsNotConnected()
        {
            return IsDeviceOffline = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        private bool BasicDataNotDownloaded()
        {
            if (_cachedInformationIsOk is null)
                return true;

            return !_cachedInformationIsOk.IsValid;
        }

        private void LoadConfigurationAndGenreList()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (CheckAndSetIfItsNotConnected())
            {
                IsBusy = false;
                return;
            }
            Task.Run(async () =>
            {
                await _movieDbService.GetAndSetConfigurationOnPreferences();
                _cachedInformationIsOk = await _movieDbService.GetAndStoreGenres();

            }).ContinueWith(c =>
            {
                if (c.IsCompleted)
                    IsBusy = false;
            });
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
                while (_cachedInformationIsOk is null)
                    await Task.Delay(MILLISECONDS_WAITING_TASK);

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
            WarningMessage = response.Message;
            AnErrorOcurred = !response.IsValid;
        }
        
        private void RefreshPageProperties()
        {
            WarningMessage = string.Empty;
            AnErrorOcurred = false;
            CurrentPage = 1;
            Items = new ObservableCollection<MovieViewModel>();
            IsPullToRefreshBusy = false;
            SeeMoreButtonVisibility = false;
        }

        #endregion

        #region Commands

        public ICommand UpcomingMoviesNextPageCommand
        {
            get => _upcomingMoviesNextPage ?? (_upcomingMoviesNextPage = new Command(() => LoadUpcomingMovies()));

        }

        public ICommand RefreshUpcomingMoviesListCommand
        {
            get => _refreshUpcomingMoviesListCommand ?? (_refreshUpcomingMoviesListCommand = new Command(() =>
            {
                RefreshPageProperties();
                LoadAplicationData();
            }));
        }

        #endregion
    }
}
