﻿using RejestrOsobowy.AppWPF.Binding;
using RejestrOsobowy.AppWPF.Database;
using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.AppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy.AppWPF
{
    public class MainProgram : IMainProgram
    {
        public MainWindow _MainWindow { get; set; }
        public _ManagementOfDatabase _ManagementOfDatabase { get; set; }
        public MyFontSize _MyFontSize { get; set; } = new MyFontSize();

        public MainViewModel _MainViewModel { get; set; }

        public MainProgram(MainWindow mainWindow)
        {
            _MainWindow = mainWindow;
            _MyFontSize.SetMyFontSize();

            //Ustawianie bazy danych
            _ManagementOfDatabase = new _ManagementOfDatabase(this);

            _MainViewModel = new MainViewModel(this);
        }
    }
}
