using Xamarin.Essentials;

namespace MoviesMobileApp.Helpers
{
    public class MyPreferences
    {

        private static string _languageInfoKey = "language_info";
        public static string LanguageInfo {
            get =>  Preferences.Get(_languageInfoKey, string.Empty);
            set => Preferences.Set(_languageInfoKey, value);
        }

        private static string _regionInfoKey = "region_info";
        public static string RegionInfo
        {
            get => Preferences.Get(_regionInfoKey, string.Empty);
            set => Preferences.Set(_regionInfoKey, value);
        }

        private static string _imageBaseUrlKey = "image_base_url";
        public static string ImageBaseUrl
        {
            get => Preferences.Get(_imageBaseUrlKey, "http://image.tmdb.org/t/p/");
            set => Preferences.Set(_imageBaseUrlKey, value);
        }

        private static string _posterImageSize = "poster_image_size";
        public static string PosterImageSize
        {
            get => Preferences.Get(_posterImageSize, "w185");
            set => Preferences.Set(_posterImageSize, value);
        }

        private static string _backdropImageSize = "backdrop_image_size";
        public static string BackdropImageSize
        {
            get => Preferences.Get(_backdropImageSize, "w780");
            set => Preferences.Set(_backdropImageSize, value);
        }
    }

}




