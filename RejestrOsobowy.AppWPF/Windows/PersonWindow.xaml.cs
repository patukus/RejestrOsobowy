using MahApps.Metro.Controls;
using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;

namespace RejestrOsobowy.AppWPF.Windows
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : MetroWindow
    {
        PersonWindowViewModel vm;
        public PersonWindow(PersonWindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = new
            {
                vm = this.vm,
            };
        }
    }
}
