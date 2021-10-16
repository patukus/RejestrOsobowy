using RejestrOsobowy.AppWPF.Database.JSON;
using RejestrOsobowy.AppWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
