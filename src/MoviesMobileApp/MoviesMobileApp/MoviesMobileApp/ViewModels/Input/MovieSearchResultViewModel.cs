using ML.Framework.Base.MVVM.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoviesMobileApp.ViewModels.Input
{
    public class MovieSearchResultViewModel : BaseViewModel
    {
        public ObservableCollection<MovieViewModel> Movies { get; set; }
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public DateTime UpcomingInitialDate { get; set; }
        public DateTime UpcomingFinalDate { get; set; }
        public int TotalPages { get; set; }
    }
}
