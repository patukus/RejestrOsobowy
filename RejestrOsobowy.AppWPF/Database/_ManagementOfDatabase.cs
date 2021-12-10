using RejestrOsobowy.AppWPF.Database.JSON;
using RejestrOsobowy.AppWPF.Interfaces;

namespace RejestrOsobowy.AppWPF.Database
{
    public class _ManagementOfDatabase
    {
        public IMainProgram MainProgram { get; set; }
        public IPerson IPerson { get; set; }

        public _ManagementOfDatabase(IMainProgram mainProgram)
        {
            MainProgram = mainProgram;

            IPerson = new PersonJSON();
        }
    }
}
