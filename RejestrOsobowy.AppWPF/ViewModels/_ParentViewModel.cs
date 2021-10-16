using RejestrOsobowy.AppWPF.Binding;
using RejestrOsobowy.AppWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace RejestrOsobowy.AppWPF.ViewModels
{
    public class _ParentViewModel<T> : NotifyPropertyChanged
    {
        public IMainProgram MainProgram { get; set; }

        public Visibility IsLoadingTrue = Visibility.Visible;
        public Visibility IsLoadingFalse = Visibility.Collapsed;
        public Visibility IsLoadingFalseHidden = Visibility.Hidden;

        private Visibility isLoading;
        public Visibility IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                if (value != null)
                {
                    isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        protected ObservableCollection<T> listShow = new ObservableCollection<T>();
        public ObservableCollection<T> ListShow
        {
            get
            {
                return listShow;
            }
            set
            {
                if (value != null)
                {
                    listShow = value;
                    OnPropertyChanged(nameof(ListShow));
                }
            }
        }

        protected T selected;
        public T Selected
        {
            get
            {
                return selected;
            }
            set
            {
                try
                {
                    selected = value;
                    OnPropertyChanged(nameof(Selected));
                }
                catch { }
            }
        }

        private string search = "";
        public string Search
        {
            get
            {
                return search;
            }
            set
            {
                if (value != null)
                {
                    search = value;
                    OnPropertyChanged(nameof(Search));
                }
            }
        }

        /// <summary>
        /// Zmiana listy na ObservableCollection
        /// </summary>
        public ObservableCollection<T> ConvertListToObservableCollection(List<T> list)
        {
            try
            {
                ObservableCollection<T> result = new ObservableCollection<T>();
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        result.Add(item);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
