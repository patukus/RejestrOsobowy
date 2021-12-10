namespace RejestrOsobowy.Core.Models
{
    public class Adress : _ParentModel
    {
        public Adress()
        {

        }

        public Adress(string street, string streetNumber, string flatNumber, string city, string postCode)
        {
            Street = street;
            StreetNumber = streetNumber;
            FlatNumber = flatNumber;
            City = city;
            PostCode = postCode;
        }

        private string postCode;
        public string PostCode
        {
            get
            {
                return postCode;
            }
            set
            {
                if (value != null)
                {
                    postCode = value;
                    OnPropertyChanged(nameof(PostCode));
                }
            }
        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value != null)
                {
                    city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string street;
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (value != null)
                {
                    street = value;
                    OnPropertyChanged(nameof(Street));
                }
            }
        }

        private string streetNumber;
        public string StreetNumber
        {
            get
            {
                return streetNumber;
            }
            set
            {
                if (value != null)
                {
                    streetNumber = value;
                    OnPropertyChanged(nameof(StreetNumber));
                }
            }
        }

        private string flatNumber;
        public string FlatNumber
        {
            get
            {
                return flatNumber;
            }
            set
            {
                if (value != null)
                {
                    flatNumber = value;
                    OnPropertyChanged(nameof(FlatNumber));
                }
            }
        }
    }
}
