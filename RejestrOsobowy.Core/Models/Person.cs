using RejestrOsobowy.Core.Enums;

namespace RejestrOsobowy.Core.Models
{
    public class Person : _ParentModel
    {
        public Person()
        {

        }

        public Person(string firstName, string lastName, int age, Gender gender, Adress adress)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            UserAdress = adress;
        }

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

        private Adress userAdress = new Adress();
        public Adress UserAdress
        {
            get
            {
                return userAdress;
            }
            set
            {
                if (value != null)
                {
                    userAdress = value;
                    OnPropertyChanged(nameof(UserAdress));
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

    public class GenderClass : _ParentModel
    {
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

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
    }
}
