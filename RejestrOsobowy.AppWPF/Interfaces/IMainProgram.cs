using RejestrOsobowy.AppWPF.Binding;
using RejestrOsobowy.AppWPF.Database;
using RejestrOsobowy.AppWPF.ViewModels;
using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;

namespace RejestrOsobowy.AppWPF.Interfaces
{
    public interface IMainProgram
    {
        MainWindow _MainWindow { get; set; }
        MyFontSize _MyFontSize { get; set; }
        _ManagementOfDatabase _ManagementOfDatabase { get; set; }

        MainViewModel _MainViewModel { get; set; }

        PersonWindowViewModel _PersonWindowViewModel { get; set; }
    }
}
