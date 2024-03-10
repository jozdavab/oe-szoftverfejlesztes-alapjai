using GYAK_05_20240311_Teachers.Verem;
using Moq;
using NUnit.Framework;

namespace GYAK_05_20240311_TeachersTest.Verem
{
    [TestFixture]
    public class IngredientStackHandlerTest
    {
        Mock<IIngredientStack> mockedStack;

        [SetUp]
        public void Setup()
        {
            mockedStack = new Mock<IIngredientStack>();
        }

        [TestCase(1)]
        [TestCase(10)]
        public void StackHandlerTriesToPushForEachIngredient(int ingredientCount)
        {
            // Given
            FoodIngredient[] ingredients = new FoodIngredient[ingredientCount];
            for (int i = 0; i < ingredientCount; i++)
            {
                ingredients[i] = new FoodIngredient();
            }
            IngredientStackHandler handler = new IngredientStackHandler(mockedStack.Object);

            // When
            FoodIngredient[] remaining = handler.Additems(ingredients);

            // Then
            mockedStack.Verify(s => s.Push(It.IsAny<FoodIngredient>()), Times.Exactly(ingredientCount));
            Assert.That(remaining, Is.Null);
        }

        [Test]
        public void StackHandlerReturnsAllRemainingIngredientsOnEmptyStack()
        {
            // Given
            FoodIngredient[] ingredients = new FoodIngredient[3];
            for (int i = 0; i < 3; i++)
            {
                ingredients[i] = new FoodIngredient();
            }
            mockedStack.Setup(s => s.Push(It.IsAny<FoodIngredient>())).Throws(new StackFullException(null, null));
            IngredientStackHandler handler = new IngredientStackHandler(mockedStack.Object);

            // When
            FoodIngredient[] remaining = handler.Additems(ingredients);

            // Then
            Assert.That(remaining, Is.EqualTo(ingredients));
        }
    }
}