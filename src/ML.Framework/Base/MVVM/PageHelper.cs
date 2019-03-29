using ML.Framework.Base.IoC;
using ML.Framework.Base.MVVM.Interface;
using System;

namespace ML.Framework.Base.MVVM.Helper
{
    public class PageHelper
    {
        private static IPageProxy _pageProxy;

        private static IContainer _container
        {
            get
            {
                return IoCHelper.Container;
            }
        }

        /// <summary>
        /// Este método cria a instancia de uma página com uma view model no bindingcontext e deve
        /// ser usado somente para criação de MainPages no Xamarin.
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public static IPage CreateMainPage<TPage, TViewModel> () 
            where TPage : class, IPage
            where TViewModel : class, IViewModel
        {
            TentaInicializarPageProxy();

            var _page = _container.GetInstance<TPage>();
            var _viewModel = _container.GetInstance<TViewModel>();

            _viewModel.ExecuteBeforeBinding();
            _page.BindingContext = _viewModel;

            return _page;
        }

        private static void TentaInicializarPageProxy()
        {
            try
            {
                _container.RegisterASingleton<IPageProxy, PageProxy>();
                _pageProxy = _container.GetInstance<IPageProxy>();
            }
            catch 
            {
                Console.Write("Page proxy already initialized");
            }
        }

    }
}
