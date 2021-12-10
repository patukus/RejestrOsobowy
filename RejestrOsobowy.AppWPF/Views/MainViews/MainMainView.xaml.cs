using RejestrOsobowy.AppWPF.ViewModels;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.MainViews
{
    /// <summary>
    /// Interaction logic for MainMainView.xaml
    /// </summary>
    public partial class MainMainView : UserControl
    {
        MainViewModel vm;
        public MainMainView(MainViewModel vm)
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
