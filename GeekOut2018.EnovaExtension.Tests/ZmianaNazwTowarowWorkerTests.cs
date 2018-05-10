using System;
using NUnit.Framework;
using Soneta.Test.Poligon;
using Soneta.Towary;

namespace GeekOut2018.EnovaExtension.Tests
{
    [TestFixture]
    public class ZmianaNazwTowarowWorkerTests : DbTransactionTestBase
    {
        private Towar Bikini => Get<Towar>(new Guid("65336878-70cf-4e64-bd72-b742cd26a657"));
        private Towar Buty45 => Get<Towar>(new Guid("61e50151-9f26-4de3-85dc-5d0983f56956"));
        private Towar Montaz => Get<Towar>(new Guid("0f8a8597-e2d1-40a6-a8e5-cc1045228660"));

        [Test]
        public void ZmianaNazwTowarowWorker_CanAddSuffix_SuffixIsAdded()
        {
            // Arrange
            var worker = new ZmianaNazwTowarowWorker(Context)
            {
                Towary = new[] {Bikini},
                Params = new ZmianaNazwTowarowParams(Context)
                {
                    DodajPostfiks = "xxx",
                    TypTowaru = TypTowaru.Towar
                }
            };

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damskixxx", Bikini.Nazwa);
        }

        [Test]
        public void ZmianaNazwTowarowWorker_AddSuffixToSpecifiedTypeOnly_SuffixIsAddedToSpecifiedTypleOnly()
        {
            // Arrange
            var worker = new ZmianaNazwTowarowWorker(Context)
            {
                Towary = new[] {Bikini, Montaz},
                Params = new ZmianaNazwTowarowParams(Context)
                {
                    DodajPostfiks = "xxx",
                    TypTowaru = TypTowaru.Usługa
                }
            };

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damski", Bikini.Nazwa);
            Assert.AreEqual("Montaż wiązań narciarskichxxx", Montaz.Nazwa);
        }

        [Test]
        public void ZmianaNazwTowarowWorker_AddSuffixToMultipleArticles_SuffixIsAddedToMultipleArticles()
        {
            // Arrange
            var worker = new ZmianaNazwTowarowWorker(Context)
            {
                Towary = new[] { Bikini, Buty45 },
                Params = new ZmianaNazwTowarowParams(Context)
                {
                    DodajPostfiks = "xxx",
                    TypTowaru = TypTowaru.Towar
                }
            };

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damskixxx", Bikini.Nazwa);
            Assert.AreEqual("Buty do nart Extreme 45xxx", Buty45.Nazwa);
        }
    }
}
