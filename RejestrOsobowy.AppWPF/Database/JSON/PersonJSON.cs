using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RejestrOsobowy.AppWPF.Database.JSON
{
    public class PersonJSON : IPerson
    {
        public string filePath = "database.json";
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
            if (File.Exists(filePath))
            {

                List<Person> list = new List<Person>();
                
                //list = list.Where(p => p.FirstName.Contains())
                return list;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(Person objToInsert)
        {
            try
            {
                if(File.Exists(filePath))
                {

                }
                else
                {
                    //var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                    //File.WriteAllText(filePath, json);
                    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Person objToUpdate)
        {
            try
            {
                if (File.Exists(filePath))
                {

                }
                else
                {

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
