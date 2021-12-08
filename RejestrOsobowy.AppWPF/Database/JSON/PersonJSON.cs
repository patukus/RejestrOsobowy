using Newtonsoft.Json;
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
        public string FilePath { get; set; } = "database.json";
        public List<Person> PersonList { get; set; } = new List<Person>();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            if (File.Exists(FilePath))
            {
                ReadDataFromFile();
                var list = PersonList;
                return list;
            }
            else
            {
                return null;
            }
        }

        public Person GetById(int id)
        {
            if (File.Exists(FilePath))
            {
                ReadDataFromFile();
                var person = PersonList.FirstOrDefault(c => c.Id == id);
                return person;
            }
            else
            {
                return null;
            }
        }

        public List<Person> GetSearch(string search)
        {
            if (File.Exists(FilePath))
            {
                var ss = search.ToLower().Trim();
                ReadDataFromFile();
                var list = PersonList.Where(c => c.FirstName.ToLower().Contains(search) || c.LastName.ToLower().Contains(search)).ToList();               
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
                CheckOrCreateFile();
                ReadDataFromFile();
                PersonList.Add(objToInsert);
                string jsonString = JsonConvert.SerializeObject(PersonList);
                File.WriteAllText(FilePath, jsonString);
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
                ReadDataFromFile();
                var obj = PersonList.FirstOrDefault(x => x.Id == objToUpdate.Id);
                obj.FirstName = objToUpdate.FirstName;
                obj.LastName = obj.LastName;
                obj.Gender = objToUpdate.Gender;
                obj.Age = objToUpdate.Age;
                string jsonString = JsonConvert.SerializeObject(PersonList);
                File.WriteAllText(FilePath, jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ReadDataFromFile()
        {
            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();
                PersonList = JsonConvert.DeserializeObject<List<Person>>(json);
            }
        }

        private void CheckOrCreateFile()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Dispose();
            }
        }
    }
}
