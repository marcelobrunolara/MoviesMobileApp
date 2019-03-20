using MoviesMobileApp.Views.Interfaces;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieSearchPage : ContentPage, IMovieSearchPage
	{
		public MovieSearchPage ()
		{
			InitializeComponent ();
		}
	}
}