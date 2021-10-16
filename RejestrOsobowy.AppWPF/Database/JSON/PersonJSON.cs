using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy.AppWPF.Database.JSON
{
    public class PersonJSON : IPerson
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetSearch(string search)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Person objToInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person objToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
