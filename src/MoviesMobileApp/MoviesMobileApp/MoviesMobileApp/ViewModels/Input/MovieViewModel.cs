using ML.Framework.Base.MVVM.Input;
using System;
using Xamarin.Forms;

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

        public UriImageSource PosterImage
        {
            get => new UriImageSource
            {
                Uri = new Uri(PosterUrl),
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromDays(5)
            };
       }
    }
}
