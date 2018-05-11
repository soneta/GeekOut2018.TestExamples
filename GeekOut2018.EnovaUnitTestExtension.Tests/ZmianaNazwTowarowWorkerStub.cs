using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soneta.Business;

namespace GeekOut2018.EnovaUnitTestExtension.Tests
{
    public class ZmianaNazwTowarowWorkerStub : ZmianaNazwTowarowWorker
    {
        public ZmianaNazwTowarowWorkerStub(Context context) : base(context)
        {
        }

        internal IEnumerable<TowarProxy> StubProxies { get; set; }

        public override IEnumerable<TowarProxy> Proxies => StubProxies;
    }
}
