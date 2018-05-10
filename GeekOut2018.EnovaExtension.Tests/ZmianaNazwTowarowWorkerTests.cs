using System;
using NUnit.Framework;
using Soneta.Test.Poligon;
using Soneta.Towary;

namespace GeekOut2018.EnovaExtension.Tests
{
    [TestFixture]
    public class ZmianaNazwTowarowWorkerTests : DbTransactionTestBase
    {
        [Test]
        public void ZmianaNazwTowarowWorker_AddSuffix_SuffixIsAdded()
        {
            // Arrange
            var worker = CreateWorker(new[] { Bikini }, TypTowaru.Towar, "xxx");

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damskixxx", Bikini.Nazwa);
        }

        [Test]
        public void ZmianaNazwTowarowWorker_AddSuffixToSpecifiedTypeOnly_SuffixIsAddedToSpecifiedTypleOnly()
        {
            // Arrange
            var worker = CreateWorker(new[] { Bikini, Montaz }, TypTowaru.Usługa, "xxx");

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
            var worker = CreateWorker(new[] { Bikini, Buty45 }, TypTowaru.Towar, "xxx");

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy damskixxx", Bikini.Nazwa);
            Assert.AreEqual("Buty do nart Extreme 45xxx", Buty45.Nazwa);
        }

        [Test]
        public void ZmianaNazwTowarowWorker_RemoveSpecifiedSuffixFromOneArticle_SuffixIsRemoved()
        {
            // Arrange
            var worker = CreateWorker(new[] { Bikini }, TypTowaru.Towar, null, " damski");

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy", Bikini.Nazwa);
        }

        [Test]
        public void ZmianaNazwTowarowWorker_RemoveSpecifiedSuffixFromMultipleArticles_SuffixIsRemovedFromArticlesThatHaveSpecifiedSufix()
        {
            // Arrange
            var worker = CreateWorker(new[] { Bikini, Buty45 }, TypTowaru.Towar, null, " damski");

            // Act
            worker.ZmianaNazw();

            // Assert
            Assert.AreEqual("Bikini - Strój kąpielowy", Bikini.Nazwa);
            Assert.AreEqual("Buty do nart Extreme 45", Buty45.Nazwa);
        }

        private ZmianaNazwTowarowWorker CreateWorker(Towar[] towary, TypTowaru typTowaru,
            string dodajPostfix, string usunPostfix = null)
        {
            return new ZmianaNazwTowarowWorker(Context)
            {
                Towary = towary,
                Params = new ZmianaNazwTowarowParams(Context)
                {
                    DodajPostfiks = dodajPostfix,
                    UsunPostfiks = usunPostfix,
                    TypTowaru = typTowaru
                }
            };
        }

        private Towar Bikini => Get<Towar>(new Guid("65336878-70cf-4e64-bd72-b742cd26a657"));
        private Towar Buty45 => Get<Towar>(new Guid("61e50151-9f26-4de3-85dc-5d0983f56956"));
        private Towar Montaz => Get<Towar>(new Guid("0f8a8597-e2d1-40a6-a8e5-cc1045228660"));
    }
}
