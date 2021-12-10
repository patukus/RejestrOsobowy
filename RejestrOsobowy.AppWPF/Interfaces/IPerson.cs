using RejestrOsobowy.Core.Models;

namespace RejestrOsobowy.AppWPF.Interfaces
{
    public interface IPerson : _ParentInterface<Person>
    {
        bool SeedDatabase();
    }
}
