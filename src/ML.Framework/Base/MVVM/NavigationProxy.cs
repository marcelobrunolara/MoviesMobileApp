using ML.Framework.Base.IoC;
using ML.Framework.Base.MVVM.Interface;
using ML.Framework.Base.MVVM.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ML.Framework.Base.MVVM
{
    public partial class PageProxy : IPageProxy, INavigationProxy
    {

        private INavigation _navigation
        {
            get
            {
                return CurrentPage?.Navigation;
            }
        }

        private IContainer _container
        {
            get
            {
                return IoCHelper.Container;
            }
        }

        public IReadOnlyList<Page> NavigationStack => _navigation.NavigationStack;

        public IReadOnlyList<Page> ModalStack => _navigation.ModalStack;

        public async Task PopToRoot() => await _navigation.PopToRootAsync();

        public async Task<Page> PopModal() => await _navigation.PopModalAsync();

        public async Task<Page> PopNavigation() => await _navigation.PopAsync();


        public async Task PushModal<TPage, TViewModel>(Action<TViewModel> executeOnTViewModel)
            where TPage : class, IPage
            where TViewModel : class, IViewModel
        {
            TPage _page = MakePage<TPage, TViewModel>(executeOnTViewModel);

            await _navigation.PushModalAsync(_page as Page);
        }


        public async Task PushOnNavigation<TPage, TViewModel>(Action<TViewModel> executaNaViewModel)
            where TPage : class, IPage
            where TViewModel : class, IViewModel
        {
            TPage _page = MakePage<TPage, TViewModel>(executaNaViewModel);

            await _navigation.PushAsync(_page as Page);
        }

        private TPage MakePage<TPage, TViewModel>(Action<TViewModel> action = null)
        where TPage : class, IPage
        where TViewModel : class, IViewModel
        {
            try
            {
                var _page = _container.GetInstance<TPage>();
                var _viewModel = _container.GetInstance<TViewModel>();

                action?.Invoke(_viewModel);

                _viewModel.ExecuteBeforeBinding();
                _page.BindingContext = _viewModel;

                return _page;
            }
            catch (Exception e)
            {
                ExecuteOnMainThread(
                    async ()=> await ShowAlert(
                        FrameworkResources.label_ok, 
                        FrameworkResources.msg_page_not_initilized, 
                        FrameworkResources.label_ok)
                    );

                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
