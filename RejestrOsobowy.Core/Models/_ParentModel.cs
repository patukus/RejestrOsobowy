using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RejestrOsobowy.Core.Models
{
    public class _ParentModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
