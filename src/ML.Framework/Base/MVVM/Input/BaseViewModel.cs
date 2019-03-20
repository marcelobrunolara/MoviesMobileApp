using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ML.Framework.Base.MVVM.Input
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedPropertyChanged<T>(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetAndRaisePropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;

                RaisedPropertyChanged<T>(propertyName);
            }
        }
    }
}
