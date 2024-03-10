using GYAK_05_20240311_Teachers.SportOra;
using NUnit.Framework;

namespace GYAK_05_20240311_TeachersTest.SportOra
{
    [TestFixture]
    internal class WorkoutTest
    {
        [Test]
        public void Parse_Successful()
        {
            // Arrange
            string input = @"Cycling,""35,8"",""1:28:03"",""314"",""142""";

            // Act
            Workout result = Workout.Parse(input);

            // Assert
            Assert.That(result.Type, Is.EqualTo(WorkoutType.Cycling));
            Assert.That(result.Length, Is.EqualTo(35.8));
            Assert.That(result.Time, Is.EqualTo(new Time(1, 28, 3)));
            Assert.That(result.Elevation, Is.EqualTo(314));
            Assert.That(result.HeartRate, Is.EqualTo(142));
        }
    }
}