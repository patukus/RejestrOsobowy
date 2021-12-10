using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.WindowViews.PersonWindowViews
{
    /// <summary>
    /// Interaction logic for PersonWindowHeaderView.xaml
    /// </summary>
    public partial class PersonWindowHeaderView : UserControl
    {
        PersonWindowViewModel vm;
        public PersonWindowHeaderView(PersonWindowViewModel vm)
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
