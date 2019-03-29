using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ML.Framework.Base.MVVM.Interface
{
    public interface INavigationProxy
    {
        IReadOnlyList<Page> NavigationStack { get; }
        IReadOnlyList<Page> ModalStack { get; }

        Task PopToRoot();
        Task<Page> PopModal();
        Task<Page> PopNavigation();

        Task PushModal<TPage, TViewModel>(Action<TViewModel> executeOnTViewModel = null) where TPage : class, IPage where TViewModel : class, IViewModel;
        Task PushOnNavigation<TPage, TViewModel>(Action<TViewModel> executeOnTViewModel = null) where TPage : class, IPage where TViewModel : class, IViewModel;
    }
}
