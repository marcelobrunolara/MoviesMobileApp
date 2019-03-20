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
    }

}




