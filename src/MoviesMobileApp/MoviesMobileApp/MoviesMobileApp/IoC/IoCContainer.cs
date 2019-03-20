using ML.Framework.Base.IoC;
using ML.Framework.Base.Services.Connector;
using ML.Framework.Base.Services.Connector.Interface;
using MoviesMobileApp.Services.MovieDb;
using MoviesMobileApp.Services.MovieDb.Interface;
using MoviesMobileApp.ViewModels;
using MoviesMobileApp.ViewModels.Interfaces;
using MoviesMobileApp.Views;
using MoviesMobileApp.Views.Interfaces;

namespace MoviesMobileApp.IoC
{
    public class IoCContainer
    {
        public static void RegisterDependencies()
        {
            //Pages
            IoCHelper.Container.Register<IMovieDetailPage, MovieDetailPage>();
            IoCHelper.Container.Register<IMovieSearchPage, MovieSearchPage>();
            IoCHelper.Container.Register<IUpcomingMoviesPage, UpcomingMoviesPage>();

            //ViewModels
            IoCHelper.Container.Register<IMovieDetailViewModel, MovieDetailViewModel>();
            IoCHelper.Container.Register<IMovieSearchViewModel, MovieSearchViewModel>();
            IoCHelper.Container.Register<IUpcomingMoviesViewModel, UpcomingMoviesViewModel>();

            //Services
            IoCHelper.Container.Register<IMovieDbService, MovieDbService>();

            //Others
            IoCHelper.Container.Register<IRestConnector, RestConnector>();
        }
    }
}
