using Newtonsoft.Json;
using RejestrOsobowy.AppWPF.Interfaces;
using RejestrOsobowy.Core.Enums;
using RejestrOsobowy.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RejestrOsobowy.AppWPF.Database.JSON
{
    public class PersonJSON : IPerson
    {
        public string FilePath { get; set; } = "database.json";
        public List<Person> PersonList { get; set; } = new List<Person>();

        public bool Delete(int id)
        {
            if (File.Exists(FilePath))
            {
                ReadDataFromFile();
                var objToDelete = PersonList.FirstOrDefault(c => c.Id == id);
                if (objToDelete is null)
                {
                    return true;
                }
                if (PersonList.Remove(objToDelete))
                {
                    string jsonString = JsonConvert.SerializeObject(PersonList);
                    File.WriteAllText(FilePath, jsonString);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
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
                if (PersonList.Count > 0)
                {
                    objToInsert.Id = PersonList.Max(c => c.Id) + 1;
                }
                else
                {
                    objToInsert.Id = 1;
                }
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
                obj.UserAdress = objToUpdate.UserAdress;
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
            if (PersonList is null)
            {
                PersonList = new List<Person>();
            }
        }

        private void CheckOrCreateFile()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Dispose();
            }
        }

        public bool SeedDatabase()
        {
            try
            {
                Random random = new Random();
                List<string> maleNames = new List<string>() { "Krzysztof", "Dominik", "Łukasz", "Jakub", "Patryk", "Andrzej", "Maciej", "Mateusz", "Szymon", "Bartłomiej", "Hubert", "Ryszard", "Tomasz", "Jacek", "Zygmunt", "Rafał" };
                List<string> maleLastNames = new List<string>() { "Nowak", "Kowalski", "Wiśniewski", "Wójcik", "Kowalczyk", "Kamiński", "Lewandowski", "Zieliński", "Szymański", "Woźniak" };
                List<string> femaleNames = new List<string>() { "Anna", "Joanna", "Zuzanna", "Patrycja", "Anita", "Agnieszka", "Alicja", "Barbara", "Magdalena", "Monika", "Katarzyna", "Oliwia", "Martyna", "Maria", "Julia", "Sandra" };
                List<string> femaleLastNames = new List<string>() { "Nowak", "Kowalska", "Wiśniewska", "Wójcik", "Kowalczyk", "Kamińska", "Lewandowska", "Zielińska", "Szymańska", "Woźniak" };
                List<string> streets = new List<string>() { "Łagodna", "Miła", "Jabłoniowa", "Morelowa", "Wiśniowa", "Kozia", "Masztalarska", "Wysoka", "Długa", "Ogrodowa", "Niebieska", "Mostowa" };
                List<string> cities = new List<string>() { "Poznań", "Luboń", "Komorniki", "Warszawa", "Gdańsk", "Gdynia", "Sopot", "Elbląg", "Sosonowiec", "Kraków", "Łowicz", "Rzeszów" };


                for (int i = 0; i < 25; i++)
                {
                    var genderRandom = random.Next(0, 1000);
                    var flatNumberGen = random.Next(0, 100);
                    var flatNumber = "";
                    var streetNumberGen = random.Next(0, 9999);
                    var streetNumber = "";
                    if (flatNumberGen % 5 != 0 && flatNumberGen % 3 != 0)
                    {
                        flatNumber = $"{flatNumberGen}";
                    }
                    if (streetNumberGen % 7 == 0)
                    {
                        List<string> letters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
                        streetNumber = $"{streetNumberGen}{letters[random.Next(0, letters.Count)]}";
                    }
                    else
                    {
                        streetNumber = $"{streetNumberGen}";
                    }
                    if (genderRandom % 2 == 0)
                    {
                        Insert(new Person(maleNames[random.Next(0, maleNames.Count)], maleLastNames[random.Next(0, maleLastNames.Count)], random.Next(18, 65), Gender.Male, new Adress(streets[random.Next(0, streets.Count)], streetNumber, flatNumber, cities[random.Next(0, cities.Count)], $"{random.Next(10, 99)}-{random.Next(100, 999)}")));
                    }
                    else
                    {
                        Insert(new Person(femaleNames[random.Next(0, femaleNames.Count)], femaleLastNames[random.Next(0, femaleLastNames.Count)], random.Next(18, 65), Gender.Female, new Adress(streets[random.Next(0, streets.Count)], streetNumber, flatNumber, cities[random.Next(0, cities.Count)], $"{random.Next(10, 99)}-{random.Next(100, 999)}")));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
