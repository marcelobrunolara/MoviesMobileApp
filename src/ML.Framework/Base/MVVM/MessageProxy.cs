using ML.Framework.Base.MVVM.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ML.Framework.Base.MVVM
{
    public partial class PageProxy : IPageProxy, IMessageProxy
    {
        public async Task ShowAlert(string title, string message, string cancel) => await CurrentPage.DisplayAlert(title, message, cancel);

        public async Task<bool> ShowAlert(string title, string message, string acept, string cancel) => await CurrentPage.DisplayAlert(title, message, acept, cancel);

        public async Task<string> ShowActionSheet(string title, string cancel, params string[] options) => await CurrentPage.DisplayActionSheet(title, cancel, null, options);


    }
}
