using GYAK_04_202403.Feladatsor;
using NUnit.Framework;

namespace GYAK_04_202403Test.Feladatsor
{

    [TestFixture]
    public class StackTest
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void StackIsCreatedWithGivenSizeOrAtLeastOne(int givenSize)
        {
            // Arrange
            Stack stack = new Stack(givenSize);

            // Act
            int expectedStackSize = givenSize < 1 ? 1 : givenSize;
            for (int i = 0; i < expectedStackSize; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.That(stack.Count, Is.EqualTo(expectedStackSize));
            Assert.That(stack.Full(), Is.EqualTo(true));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void StackIsEmptyOnCreation(int size)
        {
            // Arrange
            Stack stack = new Stack(size);

            // Act
            bool actualEmpty = stack.Empty();

            // Assert
            Assert.That(actualEmpty, Is.True);
        }

        [Test]
        public void StackIsNotEmptyAfterPush()
        {
            // Arrange
            Stack stack = new Stack(1);
            stack.Push(1);

            // Act
            bool actualEmpty = stack.Empty();

            // Assert
            Assert.That(actualEmpty, Is.False);
        }

        [Test]
        public void EmptyStackCantPop()
        {
            // Arrange
            Stack stack = new Stack(1);

            // Act
            bool actualPop = stack.Pop(out int item);

            // Assert
            Assert.That(actualPop, Is.False);
            Assert.That(item, Is.EqualTo(0));
            Assert.That(stack.Empty(), Is.True);
        }

        [Test]
        public void FullStackCantPush()
        {
            // Arrange
            Stack stack = new Stack(1);
            stack.Push(1);

            // Act
            bool actualPush = stack.Push(2);

            // Assert
            Assert.That(actualPush, Is.False);
            Assert.That(stack.Full(), Is.True);
        }

        [Test]
        public void PopAfterPushGivesBackOriginalValue()
        {
            // Arrange
            int originalItem = 1;
            Stack stack = new Stack(originalItem);
            stack.Push(1);

            // Act
            bool actualPop = stack.Pop(out int actualItem);

            // Assert
            Assert.That(actualPop, Is.True);
            Assert.That(actualItem, Is.EqualTo(originalItem));
        }

        [Test]
        public void SucessfulPopDecreasesCountByOne()
        {
            // Arrange
            Stack stack = new Stack(2);
            stack.Push(1);
            stack.Push(2);
            int originalCount = stack.Count;

            // Act
            stack.Pop(out int item);

            // Assert
            Assert.That(stack.Count, Is.EqualTo(originalCount - 1));
        }

        [Test]
        public void PopAfterPushingMultipleItemsGivesBackLastPushedItem()
        {
            // Arrange
            int originalItem = 2;
            Stack stack = new Stack(3);
            stack.Push(1);
            stack.Push(originalItem);

            // Act
            stack.Pop(out int actualItem);

            // Assert
            Assert.That(actualItem, Is.EqualTo(originalItem));
        }

        [Test]
        public void SuccesfulPushIncreasesCountByOne()
        {
            // Arrange
            Stack stack = new Stack(2);
            int originalCount = stack.Count;

            // Act
            stack.Push(1);

            // Assert
            Assert.That(stack.Count, Is.EqualTo(originalCount + 1));
        }
    }
}