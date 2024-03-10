using GYAK_05_20240311_Teachers.SportOra;
using GYAK_05_20240311_Teachers.SportOra.Exceptions;
using NUnit.Framework;

namespace GYAK_05_20240311_TeachersTest.SportOra
{
    [TestFixture]
    internal class TimeTest
    {
        [Test]
        public void Parse_Successful()
        {
            // Arrange
            string input = "0:14:47";

            // Act
            Time result = Time.Parse(input);

            // Assert
            Assert.That(result.Hour, Is.EqualTo(0));
            Assert.That(result.Minute, Is.EqualTo(14));
            Assert.That(result.Second, Is.EqualTo(47));
        }

        [Test]
        public void Parse_WrongFormat()
        {
            // Arrange
            string input = "13:47";

            // Act && Assert
            Assert.Throws<TimeException>(() => Time.Parse(input));
        }

        [Test]
        public void Parse_NegativeHourFail()
        {
            // Arrange
            string input = "-42:38:51";

            // Act && Assert
            Assert.Throws<HourException>(() => Time.Parse(input));
        }

        [Test]
        public void Parse_NegativeMinuteFail()
        {
            // Arrange
            string input = "3:-34:06";

            // Act && Assert
            Assert.Throws<MinuteException>(() => Time.Parse(input));
        }

        [Test]
        public void Parse_TooManyMinutesFail()
        {
            // Arrange
            string input = "3:60:06";

            // Act && Assert
            Assert.Throws<MinuteException>(() => Time.Parse(input));
        }

        [Test]
        public void Parse_NegativeSecondFail()
        {
            // Arrange
            string input = "3:34:-6";

            // Act && Assert
            Assert.Throws<SecondException>(() => Time.Parse(input));
        }

        [Test]
        public void Parse_TooManySecondsFail()
        {
            // Arrange
            string input = "3:58:60";

            // Act && Assert
            try
            {
                Time.Parse(input);
                Assert.Fail();
            }
            catch (SecondException secondException)
            {
                Assert.That(secondException.Second, Is.EqualTo(60));
            }
            catch (Exception)
            {
                Assert.Fail(); // Ha nem a megfelelő kivétel keletkezik, törjön el a teszt
            }
        }
    }
}