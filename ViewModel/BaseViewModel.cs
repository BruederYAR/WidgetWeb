using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WidgetWeb.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged //Базовый клас для viewmodels. NotifyPropertyChanged для обновления view
    {
        protected bool CanStandartCommandExecute(object p) => true;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
