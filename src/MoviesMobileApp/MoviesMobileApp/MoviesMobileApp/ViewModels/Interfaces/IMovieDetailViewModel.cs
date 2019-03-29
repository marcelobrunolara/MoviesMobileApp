using ML.Framework.Base.MVVM.Interface;
using MoviesMobileApp.ViewModels.Input;

namespace MoviesMobileApp.ViewModels.Interfaces
{
    public interface IMovieDetailViewModel : IViewModel
    {
        MovieViewModel CurrentItem { get; set; }
    }
}
