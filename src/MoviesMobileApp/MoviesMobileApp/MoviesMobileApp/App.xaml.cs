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

            IoCContainer.RegisterDependencies();

            var firstPage = PageHelper.CreateMainPage<IUpcomingMoviesPage, IUpcomingMoviesListViewModel>();
            MainPage = new NavigationPage(firstPage as Page);
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
            MyPreferences.LanguageInfo = System.Globalization.CultureInfo.CurrentCulture.Name;
            MyPreferences.RegionInfo = System.Globalization.RegionInfo.CurrentRegion.TwoLetterISORegionName;
        }

    }
}
