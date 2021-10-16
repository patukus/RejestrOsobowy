using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.AppWPF.Views.MainViews;
using RejestrOsobowy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace RejestrOsobowy.AppWPF.ViewModels
{
    public class MainViewModel : _ParentViewModel<Person>
    {
        public MainView _MainView { get; set; }
        public MainHeaderView _HeaderView { get; set; }
        public MainMainView _MainMainView { get; set; }
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

        private void OnSearchTimerTick(object sender, EventArgs e)
        {


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
                    _MainView = new MainView(this);
                    _HeaderView = new MainHeaderView(this);
                    _MainMainView = new MainMainView(this);
                    _FooterView = new MainFooterView(this);
                    _ListView = new MainListView(this);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
