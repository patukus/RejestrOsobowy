using RejestrOsobowy.AppWPF.ViewModels;
using RejestrOsobowy.Core.Enums;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrOsobowy.AppWPF.Views.MainViews
{
    /// <summary>
    /// Interaction logic for MainListView.xaml
    /// </summary>
    public partial class MainListView : UserControl
    {
        MainViewModel vm;
        public MainListView(MainViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = new
            {
                vm = this.vm,
            };
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.MainProgram._PersonWindowViewModel.OpenPersonWindow(OpenWindow.Info);
        }
    }
}
