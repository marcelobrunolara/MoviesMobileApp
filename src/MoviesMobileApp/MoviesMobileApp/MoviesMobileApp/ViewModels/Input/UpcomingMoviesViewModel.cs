using ML.Framework.Base.MVVM.Input;
using System;
using System.Collections.ObjectModel;

namespace MoviesMobileApp.ViewModels.Input
{
    public class UpcomingMoviesViewModel : BaseViewModel
    {
        public ObservableCollection<MovieViewModel> MovieViewModelList { get; set; }

        public int Page { get; set; }

        public int TotalResults { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public int TotalPages { get; set; }
    }
}
