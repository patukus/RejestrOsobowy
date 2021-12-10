using RejestrOsobowy.AppWPF.ViewModels;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.MainViews
{
    /// <summary>
    /// Interaction logic for MainFooterView.xaml
    /// </summary>
    public partial class MainFooterView : UserControl
    {
        MainViewModel vm;
        public MainFooterView(MainViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = new
            {
                vm = this.vm,
            };
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm._SearchTimer.Stop();
            vm._SearchTimer.Start();
        }
    }
}
