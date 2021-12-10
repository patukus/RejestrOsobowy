using MahApps.Metro.Controls;

namespace RejestrOsobowy.AppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MainProgram MainProgram { get; set; }

        public MainWindow()
        {
            MainProgram = new MainProgram(this);

            this.DataContext = new
            {
                MainProgram = this.MainProgram
            };
            InitializeComponent();
        }
    }
}
