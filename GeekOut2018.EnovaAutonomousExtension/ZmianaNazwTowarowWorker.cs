using System.Collections.Generic;
using System.Linq;
using GeekOut2018.EnovaUnitTestExtension;
using Soneta.Business;
using Soneta.Towary;

[assembly: Worker(typeof(ZmianaNazwTowarowWorker), typeof(Towary))]

namespace GeekOut2018.EnovaUnitTestExtension
{
    /// <summary>
    /// This worker is based on Example 5 from soneta.Examples - https://github.com/soneta/Examples
    /// </summary>
    public class ZmianaNazwTowarowWorker : ContextBase
    {
        public ZmianaNazwTowarowWorker(Context context) : base(context)
        {
        }

        // Potrzebne dla akcji parametry
        [Context]
        public ZmianaNazwTowarowParams Params
        {
            get;
            set;
        }

        // Potrzebne dane na których zostanie wykonana akcja
        [Context]
        public Towar[] Towary
        {
            get; set;
        }

        // Akcja jaka zostanie wykonana na danych w oparciu o ustawione parametry
        [Action("Soneta Examples/Zmiana postfiksu", Mode = ActionMode.SingleSession | ActionMode.ConfirmSave, Target = ActionTarget.ToolbarWithText)]
        public void ZmianaNazw()
        {
            using (var t = Params.Session.Logout(true))
            {
                ZmienNazwyTowarow();
                t.Commit();
            }
        }

        public void ZmienNazwyTowarow()
        {
            foreach (var towar in FilteredProxies)
            {
                if (towar.Nazwa.MoznaDodacPostfiks(Params.DodajPostfiks))
                {
                    towar.Nazwa = towar.Nazwa.DodajPostfiks(Params.DodajPostfiks);
                }

                if (towar.Nazwa.MoznaUsunacPostfiks(Params.UsunPostfiks))
                {
                    towar.Nazwa = towar.Nazwa.UsunPostfiks(Params.UsunPostfiks);
                }
            }
        }

        // SEAM - wirtualizacja tej metody pozwala na podmianę kolekcji dla testów
        public virtual IEnumerable<TowarProxy> Proxies => from towar in Towary select new TowarProxy {Towar = towar};

        private IEnumerable<TowarProxy> FilteredProxies
        {
            get { return Proxies.Where(towar => Params.TypTowaru == towar.TypTowaru); }
        }
    }
}
