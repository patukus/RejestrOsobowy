using RejestrOsobowy.AppWPF.Binding;
using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.AppWPF.Views.WindowViews.PersonWindowViews;
using RejestrOsobowy.AppWPF.Windows;
using RejestrOsobowy.Core.Enums;
using RejestrOsobowy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RejestrOsobowy.AppWPF.ViewModels.WindowViewModels
{
    public class PersonWindowViewModel : _ParentViewModel<Person>
    {
        public PersonWindow _PersonWindow { get; set; }

        public PersonWindowView _View { get; set; }
        public PersonWindowHeaderView _HeaderView { get; set; }
        public PersonWindowMainView _MainView { get; set; }
        public PersonWindowFooterView _FooterView { get; set; }

        public PersonWindowViewModel(IMainProgram mainProgram)
        {
            IsLoading = IsLoadingTrue;

            this.MainProgram = mainProgram;
            CreateViews();
            CreateGenderList();

            IsLoading = IsLoadingFalse;
        }

        private List<GenderClass> genderList = new List<GenderClass>();
        public List<GenderClass> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                if (value != null)
                {
                    genderList = value;
                    OnPropertyChanged(nameof(GenderList));
                }
            }
        }

        private GenderClass selectedGender;
        public GenderClass SelectedGender
        {
            get
            {
                return selectedGender;
            }
            set
            {
                if (value != null)
                {
                    selectedGender = value;
                    OnPropertyChanged(nameof(SelectedGender));
                }
            }
        }

        /// <summary>
        /// Utworzenie widoków
        /// </summary>
        public void CreateViews()
        {
            try
            {
                if (MainProgram is MainProgram)
                {
                    _View = new PersonWindowView(this);
                    _HeaderView = new PersonWindowHeaderView(this);
                    _MainView = new PersonWindowMainView(this);
                    _FooterView = new PersonWindowFooterView(this);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CreateGenderList()
        {
            if (GenderList.Count == 0)
            {
                GenderList.Add(new GenderClass() { Gender = Gender.Male, Name = "Mężczyzna" });
                GenderList.Add(new GenderClass() { Gender = Gender.Female, Name = "Kobieta" });
            }
        }

        /// <summary>
        /// Otworzenie okna
        /// </summary>
        /// <returns></returns>
        public async Task OpenPersonWindow(OpenWindow openWindow)
        {
            try
            {
                CreateViews();

                switch (openWindow)
                {
                    case OpenWindow.Add:
                        Selected = new Person();
                        CreateViews();
                        await AddOn();
                        break;
                    case OpenWindow.Info:
                        Selected = MainProgram._MainViewModel.Selected;
                        SelectedGender = GenderList.FirstOrDefault(c => c.Gender == Selected.Gender);
                        await AddOff();
                        await EditOff();
                        break;
                    case OpenWindow.Edit:
                        Selected = MainProgram._MainViewModel.Selected;
                        SelectedGender = GenderList.FirstOrDefault(c => c.Gender == Selected.Gender);
                        await AddOff();
                        await EditOn();
                        break;
                }

                _PersonWindow = new PersonWindow(this)
                {
                    Width = 600,
                    Height = 500,
                    Title = "Rejestr Osobowy"
                };

                _PersonWindow.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Edycja osoby
        /// </summary>
        private readonly bool __setButtonEditSaveCommandCanExecute = true;
        private ICommand _setButtonEditSaveCommand;
        public ICommand SetButtonEditSaveCommand
        {
            get
            {
                return _setButtonEditSaveCommand ?? (_setButtonEditSaveCommand = new CommandHandler(() => EditPerson(), __setButtonEditSaveCommandCanExecute));
            }
        }

        /// <summary>
        /// Usunięcie osoby
        /// </summary>
        private readonly bool __setButtonEditRemoveCommandCanExecute = true;
        private ICommand _setButtonEditRemoveCommand;
        public ICommand SetButtonEditRemoveCommand
        {
            get
            {
                return _setButtonEditRemoveCommand ?? (_setButtonEditRemoveCommand = new CommandHandler(() => RemovePerson(Selected), __setButtonEditRemoveCommandCanExecute));
            }
        }


        /// <summary>
        /// Przerwanie edycji
        /// </summary>
        private readonly bool __setButtonEditOffCommandCanExecute = true;
        private ICommand _setButtonEditOffCommand;
        public ICommand SetButtonEditOffCommand
        {
            get
            {
                return _setButtonEditOffCommand ?? (_setButtonEditOffCommand = new CommandHandler(() => _PersonWindow.Close(), __setButtonEditOffCommandCanExecute));
            }
        }

        /// <summary>
        /// Otwarcie edycji
        /// </summary>
        private readonly bool __setButtonEditOnCommandCanExecute = true;
        private ICommand _setButtonEditOnCommand;
        public ICommand SetButtonEditOnCommand
        {
            get
            {
                return _setButtonEditOnCommand ?? (_setButtonEditOnCommand = new CommandHandler(() => EditOn(), __setButtonEditOnCommandCanExecute));
            }
        }

        /// <summary>
        /// Dodanie osoby
        /// </summary>
        private readonly bool __setButtonAddCommandCanExecute = true;
        private ICommand _setButtonAddCommand;
        public ICommand SetButtonAddCommand
        {
            get
            {
                return _setButtonAddCommand ?? (_setButtonAddCommand = new CommandHandler(() => AddPerson(), __setButtonAddCommandCanExecute));
            }
        }

        /// <summary>
        /// Anulowanie dodania
        /// </summary>
        private readonly bool __setButtonCancelAddCommandCanExecute = true;
        private ICommand _setButtonCancelAddCommand;
        public ICommand SetButtonCancelAddCommand
        {
            get
            {
                return _setButtonCancelAddCommand ?? (_setButtonCancelAddCommand = new CommandHandler(() => _PersonWindow.Close(), __setButtonCancelAddCommandCanExecute));
            }
        }

        /// <summary>
        /// Dodawanie osoby
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddPerson()
        {
            try
            {
                IsLoading = IsLoadingTrue;

                await Task.Delay(500);
                if (SelectedGender != null)
                {
                    Selected.Gender = SelectedGender.Gender;
                }
                if (MainProgram._ManagementOfDatabase.IPerson.Insert(Selected))
                {
                    await MainProgram._MainViewModel.GetList(true);
                    _PersonWindow.Close();

                    IsLoading = IsLoadingFalse;
                    return true;
                }
                else
                {
                    IsLoading = IsLoadingFalse;
                    return false;
                }
            }
            catch (Exception ex)
            {
                IsLoading = IsLoadingFalse;
                return false;
            }
        }

        /// <summary>
        /// Edycja osoby
        /// </summary>
        /// <returns></returns>
        public async Task EditPerson()
        {
            try
            {
                IsLoading = IsLoadingTrue;

                if (MainProgram._ManagementOfDatabase.IPerson.Update(Selected))
                {
                    await MainProgram._MainViewModel.GetList(true);
                    EditOff();
                }

                IsLoading = IsLoadingFalse;
            }
            catch (Exception ex)
            {
                IsLoading = IsLoadingFalse;
            }
        }

        /// <summary>
        /// Usunięcie osoby
        /// </summary>
        /// <returns></returns>
        public async Task RemovePerson(Person person)
        {
            try
            {
                IsLoading = IsLoadingTrue;
                MainProgram._MainViewModel.IsLoading = IsLoadingTrue;

                await Task.Delay(500);

                if (MessageBox.Show($"Czy napewno chcesz usunąć tą osobę z rejestru?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (MainProgram._ManagementOfDatabase.IPerson.Delete(person.Id))
                    {
                        await MainProgram._MainViewModel.GetList(true);
                        Selected = null;
                        _PersonWindow.Close();
                    }
                }

                MainProgram._MainViewModel.IsLoading = IsLoadingFalse;
                IsLoading = IsLoadingFalse;
            }
            catch (Exception ex)
            {
                IsLoading = IsLoadingFalse;
                MainProgram._MainViewModel.IsLoading = IsLoadingFalse;
            }
        }
    }
}
