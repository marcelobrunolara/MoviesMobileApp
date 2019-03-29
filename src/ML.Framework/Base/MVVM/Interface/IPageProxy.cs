using Xamarin.Forms;

namespace ML.Framework.Base.MVVM.Interface
{
    public interface IPageProxy: IMessageProxy, INavigationProxy
    {
        Page CurrentPage { get; }
    }
}
