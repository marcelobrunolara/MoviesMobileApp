using System.Threading.Tasks;
using Xamarin.Forms;

namespace ML.Framework.Base.MVVM.Interface
{
    public interface IPage
    {
        object BindingContext { get; set; }
        INavigation Navigation { get; }

        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

    }
}
