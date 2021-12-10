using System.Collections.Generic;

namespace RejestrOsobowy.AppWPF.Interfaces
{
    public interface _ParentInterface<T>
    {
        List<T> GetAll();
        List<T> GetSearch(string search);
        T GetById(int id);
        bool Insert(T objToInsert);
        bool Update(T objToUpdate);
        bool Delete(int id);
    }
}
