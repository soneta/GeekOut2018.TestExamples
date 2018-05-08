using NUnit.Framework;

namespace GeekOut2018.TestExamples.Tests
{
    [TestFixture]
    public class PeselValidatorTests
    {
        [Test]
        public void Validate_PeselTooShort_ReturnsFasle()
        {
            //Arrange
            var validator = new PeselValidator();

            //Act
            var result = validator.Validate("111");

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_PeselTooLong_ReturnsFasle()
        {
            //Arrange
            var validator = new PeselValidator();

            //Act
            var result = validator.Validate("11111111111111");

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_MaleValidPesel_ReturnsTrue()
        {
            //Arrange
            var validator = new PeselValidator();

            //Act
            var result = validator.Validate("22011970815");

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_FemaleValidPesel_ReturnsTrue()
        {
            //Arrange
            var validator = new PeselValidator();

            //Act
            var result = validator.Validate("68011951207");

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_PeselWithWrongSum_ReturnsFalse()
        {
            //Arrange
            var validator = new PeselValidator();

            //Act
            var result = validator.Validate("68011951208");

            //Assert
            Assert.IsFalse(result);
        }
    }
}
