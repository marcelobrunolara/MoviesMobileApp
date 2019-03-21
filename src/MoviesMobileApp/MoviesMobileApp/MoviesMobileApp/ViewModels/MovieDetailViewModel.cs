using ML.Framework.Base.MVVM;
using MoviesMobileApp.ViewModels.Input;
using MoviesMobileApp.ViewModels.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviesMobileApp.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel<MovieViewModel>, IMovieDetailViewModel
    {
        #region Fields

        private ICommand _closeModalCommand;

        #endregion

        #region Methods

        public void CloseThisModal()
        {
            PageProxy.PopModal();
        }

        #endregion

        #region Commands

        public ICommand CloseModalCommand
        {
            get => _closeModalCommand ?? (_closeModalCommand = new Command(() => CloseThisModal()));

        }

        #endregion
    }
}
