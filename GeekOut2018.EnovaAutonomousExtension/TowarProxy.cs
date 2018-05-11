using Soneta.Towary;

namespace GeekOut2018.EnovaUnitTestExtension
{
    public class TowarProxy
    {
        internal Towar Towar;

        internal string NazwaProxy;
        internal TypTowaru TypProxy;

        public string Nazwa
        {
            get => Towar != null ? Towar.Nazwa : NazwaProxy;
            set
            {
                if (Towar != null)
                {
                    Towar.Nazwa = value;
                }
                else
                {
                    NazwaProxy = value;
                }
            }
        }

        public TypTowaru TypTowaru
        {
            get => Towar?.Typ ?? TypProxy;
            set
            {
                if (Towar != null)
                {
                    Towar.Typ = value;
                }
                else
                {
                    TypProxy = value;
                }
            }
        }
    }
}