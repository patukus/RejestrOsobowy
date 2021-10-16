using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RejestrOsobowy.AppWPF.Binding
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
