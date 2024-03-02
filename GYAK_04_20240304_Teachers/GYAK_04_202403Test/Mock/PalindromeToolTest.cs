using GYAK_04_202403.Mock;
using Moq;
using NUnit.Framework;

namespace GYAK_04_202403Test.Mock
{
    // 2. Teszt projekten jobb klikk - manage NuGet packages - Browse : Moq - Install
    [TestFixture]
    public class PalindromeToolTest
    {
        Mock<IIOHelper> ioHelperMock;

        [SetUp]
        public void Setup()
        {
            // A setup metódus minden teszt előtt lefut!
            ioHelperMock = new Mock<IIOHelper>(); // Mock a DI hez. Moq névtérből!
        }

        /*
            PalindromeTool teszteléséhez példányosítanunk kellett egy IOHelperImpl objektumot.
            IOHelperImpl működése befolyásolja a tesztelés eredményét. Ez elkerülendő.
            További probléma, hogy IOHelperImpl() a konzolról várna inputot, amivel mi nem akarunk foglalkozni.
         */
        //[Test]
        //public void IsPalindromeTestWrong()
        //{
        //    // Arrange
        //    IIOHelper ioHelper = new IOHelperImpl();
        //    PalindromeTool palindromeTool = new PalindromeTool(ioHelper);

        //    // Act
        //    bool result = palindromeTool.IsPalindrome();

        //    // Assert
        //    Assert.That(result, Is.False);
        //}

        /*
            Mockolhatjuk PalindromeTool függőségét IIOHelper interfészre.        
        */
        [Test]
        public void IsPalindromeDetectsPalindromes()
        {
            // Arrange
            // Lambda kifejezések később lesznek részletesen bevezetve. ( x => x.GetUserInput() )
            ioHelperMock.SetupSequence(x => x.GetUserInput()).Returns("radar"); // A GetUserInput() metódus hívása esetén visszaadja a "radar" stringet.
            PalindromeTool palindromeTool = new PalindromeTool(ioHelperMock.Object); // Mock objektumot adjuk át a PalindromeTool konstruktorának.

            // Act
            bool result = palindromeTool.IsPalindrome();

            // Assert
            Assert.That(result, Is.True);
            ioHelperMock.Verify(x => x.GetUserInput(), Times.Once); // Meghívódott-e egyszer a GetUserInput()?
        }

        [Test]
        public void IsPalindromeIgnoresSpacesAndCapitals()
        {
            // Arrange
            ioHelperMock.SetupSequence(x => x.GetUserInput()).Returns("Latin ital");
            PalindromeTool palindromeTool = new PalindromeTool(ioHelperMock.Object);

            // Act
            bool result = palindromeTool.IsPalindrome();

            // Assert
            Assert.That(result, Is.True);
            ioHelperMock.Verify(x => x.GetUserInput(), Times.Once);
        }
    }
}