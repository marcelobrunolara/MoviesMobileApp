using ML.Framework.Base.IoC;
using ML.Framework.Base.Services.Connector;
using ML.Framework.Base.Services.Connector.Interface;
using MoviesMobileApp.ViewModels;
using MoviesMobileApp.ViewModels.Interfaces;

namespace MoviesMobileApp.IoC
{
    public class IoCContainer
    {
        public static void RegisterDependencies()
        {
            //Pages


            //ViewModels
            IoCHelper.Container.Register<IMovieDetailViewModel, MovieDetailViewModel>();
            IoCHelper.Container.Register<IMovieSearchViewModel, MovieSearchViewModel>();
            IoCHelper.Container.Register<IUpcomingMoviesViewModel, UpcomingMoviesViewModel>();

            //Services


            //Others
            IoCHelper.Container.Register<IRestConnector, RestConnector>();
        }
    }
}
