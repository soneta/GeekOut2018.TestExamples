using System.Collections.Generic;
using NUnit.Framework;
using Soneta.Business;
using Soneta.Towary;

namespace GeekOut2018.EnovaUnitTestExtension.Tests
{
    public class ZmianaNazwTowarowWorkerTests
    {
        [Test]
        public void ZmianaNazw_AddPostfix_PostfixIsAdded()
        {
            // Arrange
            var bikini = Bikini; 
            var worker = CreateWorker(new [] {bikini}, TypTowaru.Towar, "xxx");

            // Act
            worker.ZmienNazwyTowarow();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damskixxx", bikini.Nazwa);
        }

        [Test]
        public void ZmianaNazw_AddPostfixToSpecifiedTypeOnly_PostfixIsAddedToSpecifiedTypleOnly()
        {
            // Arrange
            var bikini = Bikini;
            var montaz = Montaz;
            var worker = CreateWorker(new[] { bikini, montaz }, TypTowaru.Usługa, "xxx");

            // Act
            worker.ZmienNazwyTowarow();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damski", bikini.Nazwa);
            Assert.AreEqual("Montaż wiązań narciarskichxxx", montaz.Nazwa);
        }

        [Test]
        public void ZmianaNazw_AddPostfixToMultipleArticles_PostfixIsAddedToMultipleArticles()
        {
            // Arrange
            var bikini = Bikini;
            var buty45 = Buty45;
            var worker = CreateWorker(new[] { bikini, buty45 }, TypTowaru.Towar, "xxx");

            // Act
            worker.ZmienNazwyTowarow();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damskixxx", bikini.Nazwa);
            Assert.AreEqual("Buty do nart Extreme 45xxx", buty45.Nazwa);
        }

        [Test]
        public void ZmianaNazw_AddPostfixWhenPostfixAlreadyExists_PostfixShouldNotBeAdded()
        {
            // Arrange
            var bikini = Bikini;
            var worker = CreateWorker(new[] { bikini }, TypTowaru.Towar, "damski");

            // Act
            worker.ZmienNazwyTowarow();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damski", bikini.Nazwa);
        }

        [Test]
        public void ZmianaNazw_RemoveSpecifiedPostfixFromOneArticle_PostfixIsRemoved()
        {
            // Arrange
            var bikini = Bikini;
            var worker = CreateWorker(new[] { bikini }, TypTowaru.Towar, null, " damski");

            // Act
            worker.ZmienNazwyTowarow();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy", bikini.Nazwa);
        }

        [Test]
        public void ZmianaNazw_RemoveSpecifiedPostfixFromMultipleArticles_PostfixIsRemovedFromArticlesThatHaveSpecifiedPostfix()
        {
            // Arrange
            var bikini = Bikini;
            var buty45 = Buty45;
            var worker = CreateWorker(new[] { bikini, buty45 }, TypTowaru.Towar, null, " damski");

            // Act
            worker.ZmienNazwyTowarow();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy", bikini.Nazwa);
            Assert.AreEqual("Buty do nart Extreme 45", buty45.Nazwa);
        }

        private ZmianaNazwTowarowWorker CreateWorker(IEnumerable<TowarProxy> proxies, TypTowaru typTowaru,
            string dodajPostfix, string usunPostfix = null)
        {
            return new ZmianaNazwTowarowWorkerStub(Context.Empty)
            {
                StubProxies = proxies,
                Params = new ZmianaNazwTowarowParams(Context.Empty)
                {
                    DodajPostfiks = dodajPostfix,
                    UsunPostfiks = usunPostfix,
                    TypTowaru = typTowaru
                }
            };
        }

        internal TowarProxy Bikini => new TowarProxy {Nazwa = "Bikini - Strój kąpielowy damski", TypTowaru = TypTowaru.Towar};
        internal TowarProxy Buty45 => new TowarProxy {Nazwa = "Buty do nart Extreme 45", TypTowaru = TypTowaru.Towar};
        internal TowarProxy Montaz => new TowarProxy { Nazwa = "Montaż wiązań narciarskich", TypTowaru = TypTowaru.Usługa };
    }
}
