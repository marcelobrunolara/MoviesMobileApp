using MoviesMobileApp.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviesMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            FirstSetUp();
        }

        private void FirstSetUp()
        {
            GetDeviceLanguageAndRegion();
        }

        private void GetDeviceLanguageAndRegion()
        {
            if (LanguageAndInfoAlreadyDefined())
                return;

            MyPreferences.LanguageInfo = System.Globalization.CultureInfo.CurrentCulture.Name;
            MyPreferences.RegionInfo = System.Globalization.RegionInfo.CurrentRegion.TwoLetterISORegionName;
        }

        private bool LanguageAndInfoAlreadyDefined()
        {
            return !string.IsNullOrEmpty(MyPreferences.LanguageInfo) && !string.IsNullOrEmpty(MyPreferences.RegionInfo);
        }
    }
}
