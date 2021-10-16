using RejestrOsobowy.AppWPF.Binding;
using RejestrOsobowy.AppWPF.Database;
using RejestrOsobowy.AppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy.AppWPF.Interfaces
{
    public interface IMainProgram
    {
        MainWindow _MainWindow { get; set; }
        MyFontSize _MyFontSize { get; set; }
        _ManagementOfDatabase _ManagementOfDatabase { get; set; }

        MainViewModel _MainViewModel { get; set; }
    }
}
