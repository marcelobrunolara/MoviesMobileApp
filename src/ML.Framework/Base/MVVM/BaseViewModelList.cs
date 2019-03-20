using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ML.Framework.Base.MVVM
{
    public abstract class BaseViewModelList<TViewModel> : BaseViewModel<TViewModel>
            where TViewModel : class, new()
    {
        #region Fields

        private bool _isPullToRefreshBusy;

        private ObservableCollection<TViewModel> _items;

        #endregion

        #region Methods

        public virtual ObservableCollection<TViewModel> Items
        {
            get { return _items; }
            set { SetAndRaisePropertyChanged(ref _items, value); }
        }

        public bool IsPullToRefreshBusy
        {
            get { return _isPullToRefreshBusy; }
            set { SetAndRaisePropertyChanged(ref _isPullToRefreshBusy, value); }
        }


        #endregion
    }
}
