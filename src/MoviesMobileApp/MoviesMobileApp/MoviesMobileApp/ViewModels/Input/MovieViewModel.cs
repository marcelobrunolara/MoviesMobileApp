using ML.Framework.Base.MVVM.Input;
using System;
using Xamarin.Forms;

namespace MoviesMobileApp.ViewModels.Input
{
    public class MovieViewModel : BaseViewModel
    {
        private string _genre;

        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string ProductionCompany { get; set; }
        public string Overview {get;set;}
        public DateTime ReleaseDate { get; set; }
        public string Genre { get => _genre; set => SetAndRaisePropertyChanged(ref _genre, value); }
        public UriImageSource BackdropImageSource
        {
            get => new UriImageSource
            {
                Uri = new Uri(BackdropUrl),
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromDays(1)
            };
        }
        public UriImageSource PosterImageSource
        {
            get => new UriImageSource
            {
                Uri = new Uri(PosterUrl),
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromDays(1)
            };
        }
    }
}
