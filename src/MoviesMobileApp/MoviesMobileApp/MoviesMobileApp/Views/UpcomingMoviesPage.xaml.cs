
using MoviesMobileApp.Views.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesPage : ContentPage, IUpcomingMoviesPage
    {
        public UpcomingMoviesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //avoiding multiple taps where page is rendering
            lstUpcoming.SelectedItem = null;
        }
    }
}