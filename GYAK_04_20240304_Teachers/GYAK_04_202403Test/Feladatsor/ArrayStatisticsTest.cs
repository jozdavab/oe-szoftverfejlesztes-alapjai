using GYAK_04_202403.Feladatsor;
using NUnit.Framework;

namespace GYAK_04_202403Test.Feladatsor
{
    [TestFixture] // Attrubútum, jelzi, hogy ez egy teszt osztály. NUnit.Framework névtérből!
    public class ArrayStatisticsTest
    {
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 6)]
        [TestCase(new int[] { -4, -3 }, -7)]
        [TestCase(new int[] { -3, 0, 2 }, -1)]
        public void TotalTest(int[] array, int expectedSum)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array); // Másik névtérben vagyunk, ezért kell a using GYAK_04_202403 a fájl elejére! 

            // Act
            int actualSum = arrayStatistics.Total();

            // Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        [TestCase(null, 0, false)]
        [TestCase(new int[] { }, 0, false)]
        [TestCase(new int[] { 1 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3, 3, 4 }, 4, true)]
        [TestCase(new int[] { -2, -1 }, 1, false)]
        [TestCase(new int[] { -3, 0, 2 }, -3, true)]
        public void ContainsTest(int[] array, int number, bool expected)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array);

            // Act
            bool actualContains = arrayStatistics.Contains(number);

            // Assert
            Assert.That(actualContains, Is.EqualTo(expected));
        }

        [TestCase(null, false)]
        [TestCase(new int[] { }, false)]
        [TestCase(new int[] { 1 }, true)]
        [TestCase(new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 3, 2, 1 }, false)]
        [TestCase(new int[] { 1, 1, 1 }, true)]
        [TestCase(new int[] { 1, 2, 1 }, false)]
        [TestCase(new int[] { 1, 1, 2 }, true)]
        [TestCase(new int[] { -1, 0, 1 }, true)]
        public void SortedTest(int[] array, bool expected)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array);

            // Act
            bool actualSorted = arrayStatistics.Sorted();

            // Assert
            Assert.That(actualSorted, Is.EqualTo(expected));
        }

        [TestCase(null, 0, -1)]
        [TestCase(new int[] { }, 0, -1)]
        [TestCase(new int[] { 1 }, 1, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3 }, 3, -1)]
        [TestCase(new int[] { -2, -1, 0 }, -2, -1)]
        public void GreaterTest(int[] array, int number, int expectedResult)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array);

            // Act
            int actualResult = arrayStatistics.FirstGreater(number);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3, -4 }, 2)]
        [TestCase(new int[] { 0, 0 }, 2)]
        public void CountEvensTest(int[] array, int expectedCount)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array);

            // Act
            int actualCount = arrayStatistics.CountEvens();

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }


        [TestCase(null, -1)]
        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { 1, 2, 3, -4 }, 2)]
        [TestCase(new int[] { 100, 100 }, 0)]
        public void MaxindexTest(int[] array, int expectedMaxIndex)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array);

            // Act
            int actualMaxIndex = arrayStatistics.MaxIndex();

            // Assert
            Assert.That(actualMaxIndex, Is.EqualTo(expectedMaxIndex));
        }

        [TestCase(null, null)]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { -1, 1, 0, -1 }, new int[] { -1, -1, 0, 1 })]
        public void SortTest(int[] array, int[] expectedArray)
        {
            // Arrange
            ArrayStatistics arrayStatistics = new ArrayStatistics(array);

            // Act
            arrayStatistics.Sort();

            // Assert
            Assert.That(arrayStatistics.Array, Is.EqualTo(expectedArray));
        }
    }
}