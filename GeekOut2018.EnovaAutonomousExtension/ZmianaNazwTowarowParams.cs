using Soneta.Business;
using Soneta.Towary;
using Soneta.Types;

namespace GeekOut2018.EnovaUnitTestExtension
{
    public class ZmianaNazwTowarowParams : ContextBase
    {
        public ZmianaNazwTowarowParams(Context context) : base(context)
        {
            TypTowaru = TypTowaru.Towar;
        }

        public TypTowaru TypTowaru { get; set; }

        public string DodajPostfiks { get; set; }

        [Caption("Usuń postfiks")]
        public string UsunPostfiks { get; set; }
    }
}