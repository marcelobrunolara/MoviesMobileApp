using ML.Framework.Base.MVVM;
using MoviesMobileApp.ViewModels.Input;
using MoviesMobileApp.ViewModels.Interfaces;

namespace MoviesMobileApp.ViewModels
{
    public class UpcomingMoviesViewModel : BaseViewModelList<MovieViewModel>, IUpcomingMoviesViewModel
    {
        #region Methods

        public override void ExecuteBeforeBinding()
        {
            PageProxy.
            base.ExecuteBeforeBinding();
        }

        #endregion
    }
}
