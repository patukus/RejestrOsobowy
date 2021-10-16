using RejestrOsobowy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy.Core.Models
{
    public class Person : _ParentModel
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != null)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value != null)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value != null)
                {
                    age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        private Gender gender;
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != null)
                {
                    gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }
    }
}
