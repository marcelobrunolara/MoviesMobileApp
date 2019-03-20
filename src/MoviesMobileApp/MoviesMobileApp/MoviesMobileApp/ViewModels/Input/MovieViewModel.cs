using ML.Framework.Base.MVVM.Input;
using System;

namespace MoviesMobileApp.ViewModels.Input
{
    public class MovieViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string Genre { get; set; }
        public string ProductionCompany { get; set; }
        public string Overview {get;set;}
        public DateTime ReleaseDate { get; set; }
    }
}
