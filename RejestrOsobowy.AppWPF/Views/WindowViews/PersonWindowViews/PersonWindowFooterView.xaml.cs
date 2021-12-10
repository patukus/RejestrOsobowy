using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.WindowViews.PersonWindowViews
{
    /// <summary>
    /// Interaction logic for PersonWindowFooterView.xaml
    /// </summary>
    public partial class PersonWindowFooterView : UserControl
    {
        PersonWindowViewModel vm;
        public PersonWindowFooterView(PersonWindowViewModel vm)
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
