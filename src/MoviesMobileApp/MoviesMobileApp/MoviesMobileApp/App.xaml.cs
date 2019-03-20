using ML.Framework.Base.MVVM.Helper;
using MoviesMobileApp.Helpers;
using MoviesMobileApp.IoC;
using MoviesMobileApp.ViewModels.Interfaces;
using MoviesMobileApp.Views.Interfaces;
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

            var firstPage = PageHelper.CreateMainPage<IUpcomingMoviesPage, IUpcomingMoviesViewModel>();
            MainPage = new NavigationPage(firstPage as Page);
        }

        protected override void OnStart()
        {
            FirstSetUp();
        }

        private void FirstSetUp()
        {
            IoCContainer.RegisterDependencies();
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
