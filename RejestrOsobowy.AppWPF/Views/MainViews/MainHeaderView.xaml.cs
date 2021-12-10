using RejestrOsobowy.AppWPF.ViewModels;
using RejestrOsobowy.Core.Enums;
using System.Windows;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.MainViews
{
    /// <summary>
    /// Interaction logic for MainHeaderView.xaml
    /// </summary>
    public partial class MainHeaderView : UserControl
    {
        MainViewModel vm;
        public MainHeaderView(MainViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = new
            {
                vm = this.vm,
            };
        }

        private async void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            await vm.MainProgram._PersonWindowViewModel.OpenPersonWindow(OpenWindow.Add);
        }

        private void SeedDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SeedDatabase();
        }
    }
}
