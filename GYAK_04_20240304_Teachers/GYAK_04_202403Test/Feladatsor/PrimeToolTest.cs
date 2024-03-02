using GYAK_04_202403.Feladatsor;
using NUnit.Framework;

namespace GYAK_04_202403Test.Feladatsor
{
    // 1. Solutionon jobb klikk - add new Project - Class Library (.NET Core)
    // 2. Teszt projekten jobb klikk - manage NuGet packages - Browse :
    //    NUnit - Install, NUnit3TestAdapter - Install, Microsoft.NET.Test.Sdk - Install
    // 3. Teszt projekten jobb klikk - add reference - GYAK_04_202403
    // 4. Tesztelendő osztályok és metódusok legyenek publikusak! 

    [TestFixture]  // Attrubútum, jelzi, hogy ez egy teszt osztály. NUnit.Framework névtérből!
    public class PrimeToolTest
    {
        [Test]  // Attrubútum, jelzi, hogy ez egy teszt metódus. NUnit.Framework névtérből!
        public void ZeroIsNotAPrime()
        {
            // Arrange -> Teszteléshez szükséges előfeltételek megteremtése.
            var primeTool = new PrimeTool(0);  // Másik névtérben vagyunk, ezért kell a using GYAK_04_202403 a fájl elejére! 

            // Act -> Tesztelendő kód meghívása.
            bool result = primeTool.IsPrime();

            // Assert -> Elvárásokat ellenőrző kód.
            Assert.That(result, Is.False);
        }

        [Test]
        public void OneIsNotAPrime()
        {
            // Arrange
            var primeTool = new PrimeTool(1);

            // Act
            bool result = primeTool.IsPrime();

            // Assert
            Assert.That(result, Is.False);
        }

        // TestCase attrubútummal több tesztesetet is megadhatunk egy metódusnak.
        // Fontos, hogy próbáljunk különböző eseteket lefedni!
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(-3, false)]
        [TestCase(int.MaxValue, true)]
        [TestCase(int.MinValue, false)]
        public void PrimeToolDetectsPrimeNumbers(int number, bool expected)
        {
            // Arrange
            var primeTool = new PrimeTool(number);

            // Act
            bool result = primeTool.IsPrime();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}