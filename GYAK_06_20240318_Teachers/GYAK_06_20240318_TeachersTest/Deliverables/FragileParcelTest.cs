using GYAK_06_20240318_Teachers.Deliverables;
using GYAK_06_20240318_Teachers.Exceptions;
using GYAK_06_20240318_Teachers.Utils;
using NUnit.Framework;

namespace GYAK_06_20240318_TeachersTest.Deliverables
{
    [TestFixture]
    public class FragileParcelTest
    {
        // csomagautomatás díj kalkulációnál előáll a megfelelő kivéltel
        [Test]
        public void CalculationThrowsExceptionWhenParcelSentFromLocker()
        {
            // Given
            FragileParcel fp = new FragileParcel(10, "address", Placement.Horizontal);

            // When && Then
            DeliveryException ex =
                Assert.Throws<DeliveryException>(() => fp.CalculatePrice(true));
            Assert.That(ex.FaultyDeliverable, Is.EqualTo(fp));
        }

        // hibás elhelyezési mód beállításakor előáll a megfelelő kivétel
        [Test]
        public void FragileParcelThrowsExceptionWhenPlacementIsArbitary()
        {
            // Given && When && Then
            Assert.Throws<IncorrectOrientationException>(() => new FragileParcel(0, "address", Placement.Arbitrary));
        }
    }
}