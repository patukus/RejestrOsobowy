using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.AppWPF.Views.MainViews;
using RejestrOsobowy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace RejestrOsobowy.AppWPF.ViewModels
{
    public class MainViewModel : _ParentViewModel<Person>
    {
        public MainView _View { get; set; }
        public MainHeaderView _HeaderView { get; set; }
        public MainMainView _MainView { get; set; }
        public MainFooterView _FooterView { get; set; }
        public MainListView _ListView { get; set; }

        public DispatcherTimer _SearchTimer;
        public MainViewModel(IMainProgram mainProgram)
        {
            IsLoading = IsLoadingTrue;

            this.MainProgram = mainProgram;
            CreateViews();
            _SearchTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            _SearchTimer.Tick += new EventHandler(OnSearchTimerTick);
            IsLoading = IsLoadingFalse;
        }

        private async void OnSearchTimerTick(object sender, EventArgs e)
        {
            _SearchTimer.Stop();
            await GetList(false, true);
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
                    _View = new MainView(this);
                    _HeaderView = new MainHeaderView(this);
                    _MainView = new MainMainView(this);
                    _FooterView = new MainFooterView(this);
                    _ListView = new MainListView(this);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Pobranie listy osób
        /// </summary>
        /// <param name="first"></param>
        /// <param name="firstSearch"></param>
        /// <returns></returns>
        public async Task GetList(bool first = false, bool firstSearch = false)
        {
            try
            {
                if (first || firstSearch)
                {
                    await Task.Run(async () =>
                    {
                        IsLoading = IsLoadingTrue;

                        await Task.Delay(500);

                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                        {
                            if (first || firstSearch)
                            {
                                if (_ListView.dataGrid.Items != null && _ListView.dataGrid.Items.Count > 0)
                                {
                                    _ListView.dataGrid.ScrollIntoView(_ListView.dataGrid.Items[0]);
                                    _ListView.UpdateLayout();
                                }

                                ListShow.Clear();
                            }
                        })).Wait();

                        List<Person> list = new List<Person>();

                        if (Search.Length > 0)
                        {
                            list = MainProgram._ManagementOfDatabase.IPerson.GetSearch(Search);
                        }
                        else
                        {
                            list = MainProgram._ManagementOfDatabase.IPerson.GetAll();
                        }

                        if (list != null)
                        {
                            foreach (var x in list)
                            {
                                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                                {
                                    ListShow.Add(x);
                                })).Wait();
                            }


                        }
                        IsLoading = IsLoadingFalse;
                    });
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
