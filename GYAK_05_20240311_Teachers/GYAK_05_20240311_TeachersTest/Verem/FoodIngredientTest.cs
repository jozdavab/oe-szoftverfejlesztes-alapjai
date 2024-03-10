using GYAK_05_20240311_Teachers.Verem;
using NUnit.Framework;

namespace GYAK_05_20240311_TeachersTest.Verem
{
    // 3. Teszt projekten jobb klikk - add reference - GYAK_05_20240311_Teachers
    [TestFixture]
    public class FoodIngredientTest
    {
        [Test]
        public void ToStringContainsInformationRegardingNotEmptyProperties()
        {
            // Given
            FoodIngredient fi = new FoodIngredient();
            fi.Name = "Alma";
            fi.Amount = 2;
            fi.Unit = Unit.darab;

            // When
            string result = fi.ToString();

            // Then
            Assert.That(result, Does.Contain(fi.Name));
            Assert.That(result, Does.Contain(fi.Amount.ToString()));
            Assert.That(result, Does.Contain(fi.Unit.ToString()));
        }

        [Test]
        public void ToStringIsNeverBlankOrEmpty()
        {
            // Given
            FoodIngredient fi = new FoodIngredient();

            // When
            string result = fi.ToString();

            // Then
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Trim(), Is.Not.Empty);
        }

        [Test]
        public void ToStringContainsUnknownIngredientWhenNameIsNull()
        {
            // Given
            FoodIngredient fi = new FoodIngredient();
            fi.Amount = 2;
            fi.Unit = Unit.darab;

            // When
            string result = fi.ToString();

            // Then
            Assert.That(result, Does.Contain("unknown ingredient"));
        }
    }
}