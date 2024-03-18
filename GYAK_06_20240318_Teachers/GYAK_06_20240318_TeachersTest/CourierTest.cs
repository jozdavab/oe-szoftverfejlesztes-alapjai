using GYAK_06_20240318_Teachers;
using GYAK_06_20240318_Teachers.Deliverables;
using GYAK_06_20240318_Teachers.Utils;
using NUnit.Framework;

namespace GYAK_06_20240318_TeachersTest
{
    [TestFixture]
    public class CourierTest
    {
        // a PickUpItem meghívásakor az össztömeg helyesen értékre áll be
        [Test]
        public void PickingUpNewItemIncreasesOverallWeight()
        {
            // Given
            Courier c = new Courier(2);
            int weight1 = 100, weight2 = 5;
            IDeliverable item1 = new Envelope(weight1, "address", "details");
            IDeliverable item2 = new Envelope(weight2, "address", "details");

            // When
            c.PickUpItem(item1);
            c.PickUpItem(item2);

            // Then
            Assert.That(c.SumWeight, Is.EqualTo(weight1 + weight2));
        }

        // a FragilesSorted helyesen elvégzi a kiválogatást és a rendezést
        // Note: Ezt érdemes lenne külön teszt esetekre bontani.
        [Test]
        public void FragilesSortedReturnsSortedArrayWithoutSurplusItems()
        {
            // Given
            List<IDeliverable> items = new List<IDeliverable>()
            {
                new FragileParcel(10, "address", Placement.Horizontal),
                new FragileParcel(5, "address", Placement.Horizontal),
                new Envelope(7,"address","details"),
                new FragileParcel(100, "address", Placement.Vertical)
            };
            Courier c = new Courier(items.Count);
            foreach (IDeliverable item in items)
            {
                c.PickUpItem(item);
            }

            // When
            IDeliverable[] sorted = c.FragilesSorted();

            // Then
            Assert.That(sorted.Length, Is.EqualTo(items.Count - 1));
            for (int i = 0; i < sorted.Length - 1; i++)
            {
                Assert.That(sorted[i].Weight <= sorted[i + 1].Weight);
            }
        }
    }
}