using RejestrOsobowy.AppWPF.Binding;
using RejestrOsobowy.AppWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        private Visibility isEdit;
        public Visibility IsEdit
        {
            get
            {
                return isEdit;
            }
            set
            {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                if (value != null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                {
                    isEdit = value;
                    OnPropertyChanged(nameof(IsEdit));
                    OnPropertyChanged(nameof(IsNotEdit));
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }


        private Visibility isNotEdit;
        public Visibility IsNotEdit
        {
            get
            {
                return isNotEdit;
            }
            set
            {
                if (value != null)
                {
                    isNotEdit = value;
                    OnPropertyChanged(nameof(IsNotEdit));
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }


        private Visibility isAdd;
        public Visibility IsAdd
        {
            get
            {
                return isAdd;
            }
            set
            {
                if (value != null)
                {
                    isAdd = value;
                    OnPropertyChanged(nameof(IsAdd));
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public bool IsAddOnly
        {
            get
            {
                if (isAdd == IsLoadingTrue)
                    return true;
                else
                    return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                if (isAdd == IsLoadingTrue || isEdit == IsLoadingTrue)
                    return false;
                else
                    return true;
            }
        }

        public bool IsEnabled
        {
            get
            {
                if (isAdd == IsLoadingTrue || isEdit == IsLoadingTrue)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Ustawienie zmiennej odpowiadającej za bindowanie edytowania na widoczną
        /// </summary>
        public async Task EditOn()
        {
            IsEdit = IsLoadingTrue;
            IsNotEdit = IsLoadingFalse;
        }

        /// <summary>
        /// Ustawienie zmiennej odpowiadającej za bindowanie edytowania na niewidoczną
        /// </summary>
        public async Task EditOff()
        {
            IsEdit = IsLoadingFalse;
            IsNotEdit = IsLoadingTrue;
        }

        /// <summary>
        /// Ustawienie zmiennej odpowiadającej za bindowanie dodawania na widoczną
        /// </summary>
        public async Task AddOn()
        {
            IsAdd = IsLoadingTrue;
            IsEdit = IsLoadingFalse;
            IsNotEdit = IsLoadingFalse;
        }

        /// <summary>
        /// Ustawienie zmiennej odpowiadającej za bindowanie dodawania na niewidoczną
        /// </summary>
        public async Task AddOff()
        {
            IsAdd = IsLoadingFalse;
            EditOn();
        }
    }
}
