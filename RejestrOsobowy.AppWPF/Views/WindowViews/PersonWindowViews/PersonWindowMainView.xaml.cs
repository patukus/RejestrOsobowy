using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.WindowViews.PersonWindowViews
{
    /// <summary>
    /// Interaction logic for PersonWindowMainView.xaml
    /// </summary>
    public partial class PersonWindowMainView : UserControl
    {
        PersonWindowViewModel vm;
        public PersonWindowMainView(PersonWindowViewModel vm)
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
