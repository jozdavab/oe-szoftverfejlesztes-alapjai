using GYAK_05_20240311_Teachers.Verem;
using GYAK_05_20240311_Teachers.Verem.Exceptions;
using NUnit.Framework;

namespace GYAK_05_20240311_TeachersTest.Verem
{
    [TestFixture]
    public class IngredientStackTest
    {
        [Test]
        public void StackIsEmptyOnCreation()
        {
            // Given
            IngredientStack stack = new IngredientStack(10);

            // When
            bool actualEmpty = stack.Empty();

            // Then
            Assert.That(actualEmpty, Is.True);
        }

        [Test]
        public void EmptyReturnsFalseWhenStackContainsItems()
        {
            // Given
            IngredientStack stack = new IngredientStack(10);
            stack.Push(new FoodIngredient());

            // When
            bool empty = stack.Empty();

            // Then
            Assert.That(empty, Is.False);
        }

        [Test]
        public void PopOnEmptyStackThrowsException()
        {
            // Given
            IngredientStack stack = new IngredientStack(1);

            // When Then
            Assert.Throws<StackEmptyException>(() => stack.Pop());
            Assert.That(stack.Empty(), Is.True);
        }

        [Test]
        public void PushOnFullStackThrowsException()
        {
            // Given
            IngredientStack stack = new IngredientStack(1);
            stack.Push(new FoodIngredient());

            // When Then
            Assert.Throws<StackFullException>(() => stack.Push(new FoodIngredient()));
        }

        [Test]
        public void PopAfterPushGivesBackOriginalValue()
        {
            // Given
            FoodIngredient originalItem = new FoodIngredient();
            IngredientStack stack = new IngredientStack(1);
            stack.Push(originalItem);

            // When
            FoodIngredient actualItem = stack.Pop();

            // Then
            Assert.That(actualItem, Is.EqualTo(originalItem));
        }

        [Test]
        public void PopAfterPushingMultipleItemsGivesBackLastPushedItem()
        {
            // Given
            FoodIngredient anItem = new FoodIngredient();
            FoodIngredient lastAddedItem = new FoodIngredient();
            IngredientStack stack = new IngredientStack(2);
            stack.Push(anItem);
            stack.Push(lastAddedItem);

            // When
            FoodIngredient actualItem = stack.Pop();

            // Then
            Assert.That(actualItem, Is.EqualTo(lastAddedItem));
        }

        [Test]
        public void TopOnEmptyStackReturnsNull()
        {
            // Given
            IngredientStack stack = new IngredientStack(1);

            // When
            FoodIngredient actualItem = stack.Top();

            // Then
            Assert.That(actualItem, Is.Null);
        }

        [Test]
        public void TopGivesBackItemWithoutDecreasingStackSize()
        {
            // Given
            FoodIngredient originalItem = new FoodIngredient();
            IngredientStack stack = new IngredientStack(1);
            stack.Push(originalItem);

            // When
            FoodIngredient actualItem = stack.Top();

            // Then
            Assert.That(actualItem, Is.EqualTo(originalItem));
            Assert.That(stack.Empty(), Is.False);
        }
    }
}
