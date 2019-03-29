using ML.Framework.Base.MVVM.Interface;
using ML.Framework.Base.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ML.Framework.Base.MVVM
{
    public partial class PageProxy : IPageProxy
    {
        public Page CurrentPage {
            get
            {
                var page = Application.Current.MainPage;

                if (page is NavigationPage)
                    return ((NavigationPage)page).CurrentPage;

                else return page;      
            }
        }

        public void ExecuteOnMainThread(Action action)
        {
            Device.BeginInvokeOnMainThread(action.Invoke);
        }

    }
}
