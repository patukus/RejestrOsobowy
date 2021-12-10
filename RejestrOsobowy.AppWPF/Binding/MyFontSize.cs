namespace RejestrOsobowy.AppWPF.Binding
{
    public class MyFontSize : NotifyPropertyChanged
    {
        private int xs;
        public int XS
        {
            get
            {
                return xs;
            }
            set
            {
                if (value != null)
                {
                    xs = value;
                    OnPropertyChanged(nameof(XS));
                }
            }
        }

        private int s;
        public int S
        {
            get
            {
                return s;
            }
            set
            {
                if (value != null)
                {
                    s = value;
                    OnPropertyChanged(nameof(S));
                }
            }
        }

        private int m;
        public int M
        {
            get
            {
                return m;
            }
            set
            {
                if (value != null)
                {
                    m = value;
                    OnPropertyChanged(nameof(M));
                }
            }
        }

        private int l;
        public int L
        {
            get
            {
                return l;
            }
            set
            {
                if (value != null)
                {
                    l = value;
                    OnPropertyChanged(nameof(L));
                }
            }
        }

        private int xl;
        public int XL
        {
            get
            {
                return xl;
            }
            set
            {
                if (value != null)
                {
                    xl = value;
                    OnPropertyChanged(nameof(XL));
                }
            }
        }

        private int xxl;
        public int XXL
        {
            get
            {
                return xxl;
            }
            set
            {
                if (value != null)
                {
                    xxl = value;
                    OnPropertyChanged(nameof(XXL));
                }
            }
        }

        private int xxxl;
        public int XXXL
        {
            get
            {
                return xxxl;
            }
            set
            {
                if (value != null)
                {
                    xxxl = value;
                    OnPropertyChanged(nameof(XXXL));
                }
            }
        }

        private int xxxxl;
        public int XXXXL
        {
            get
            {
                return xxxxl;
            }
            set
            {
                if (value != null)
                {
                    xxxxl = value;
                    OnPropertyChanged(nameof(XXXXL));
                }
            }
        }

        private int xxxxxl;
        public int XXXXXL
        {
            get
            {
                return xxxxxl;
            }
            set
            {
                if (value != null)
                {
                    xxxxxl = value;
                    OnPropertyChanged(nameof(XXXXXL));
                }
            }
        }

        /// <summary>
        /// Ustawia rozmiar czcionek w programie
        /// </summary>
        public void SetMyFontSize()
        {
            XS = 8;
            S = 10;
            M = 12;
            L = 14;
            XL = 16;
            XXL = 20;
            XXXL = 24;
            XXXXL = 36;
            XXXXXL = 42;
        }
    }
}
