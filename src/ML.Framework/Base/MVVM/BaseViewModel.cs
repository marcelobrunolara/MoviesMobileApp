﻿using ML.Framework.Base.IoC;
using ML.Framework.Base.MVVM.Input;
using ML.Framework.Base.MVVM.Interface;
using ML.Framework.Base.Services.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ML.Framework.Base.MVVM
{
    public abstract class BaseViewModel<TViewModel> : BaseViewModel, IViewModel
    where TViewModel : class, new()
    {

        #region Fields

        private bool _isBusy;
        private TViewModel _currentItem = new TViewModel();


        #endregion

        #region Properties

        public IPageProxy PageProxy { get
            {
                return IoCHelper.Container.GetInstance<IPageProxy>();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetAndRaisePropertyChanged(ref _isBusy, value); }
        }

        public virtual TViewModel CurrentItem
        {
            get { return _currentItem; }
            set { SetAndRaisePropertyChanged(ref _currentItem, value); }
        }

        public void ExecuteOnMainThread(Action action)
        {
            Device.BeginInvokeOnMainThread(action.Invoke);
        }

        #endregion

        #region Methods

        public virtual void ExecuteBeforeBinding()
        {

        }

        #endregion
    }

}
