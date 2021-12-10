using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;
using System.Windows.Controls;

namespace RejestrOsobowy.AppWPF.Views.WindowViews.PersonWindowViews
{
    /// <summary>
    /// Interaction logic for PersonWindowView.xaml
    /// </summary>
    public partial class PersonWindowView : UserControl
    {
        PersonWindowViewModel vm;
        public PersonWindowView(PersonWindowViewModel vm)
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
