using GYAK_06_20240318_Teachers.Deliverables;
using GYAK_06_20240318_Teachers.Exceptions;
using NUnit.Framework;

namespace GYAK_06_20240318_TeachersTest.Deliverables
{
    [TestFixture]
    public class EnvelopeTest
    {
        // helyesen kalkulált csomagszállítási díj automatából és nem automatából feladva
        [TestCase(1, false, 200)]
        [TestCase(50, false, 400)]
        [TestCase(500, false, 2000)]
        [TestCase(1, true, 200)]
        [TestCase(50, true, 400)]
        [TestCase(500, true, 2000)]
        public void PriceCalculationTest(int weight, bool fromLocker, double expectedPrice)
        {
            // Given
            Envelope e = new Envelope(weight, "address", "details");

            // When
            double actualPrice = e.CalculatePrice(fromLocker);

            // Then
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
        }

        // 2000 g-nál nehezebb küldemény esetén előáll a megfelelő kivéltel
        [Test]
        public void EnvelopeOver2000gThrowsException()
        {
            // Given
            int weight = 2001;
            Envelope e = new Envelope(weight, "address", "details");

            // When && then
            OverWeightException ex = Assert.Throws<OverWeightException>(() => e.CalculatePrice(true));
            Assert.That(ex.Weight, Is.EqualTo(weight));
            Assert.That(ex.Deliverable, Is.EqualTo(e));
        }
    }
}