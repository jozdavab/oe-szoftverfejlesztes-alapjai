using GYAK_06_20240318_Teachers.Exceptions;
using GYAK_06_20240318_Teachers.Utils;

namespace GYAK_06_20240318_Teachers.Deliverables
{
    // Készítsen egy FragileParcel nevű osztályt, amely a Parcel osztályból származik.
    // Az osztály egy törékeny csomagot reprezentál.
    public class FragileParcel : Parcel
    {
        // A tömeg, a címzett és az elhelyezési mód a konstruktor paramétereként adható meg.
        // Dobjon IncorrectOrientationException-t, ha a csomag elhelyezési módja Arbitrary volna.
        // Hozza létre ezt a kivételosztályt a DeliveryException leszármazottjaként.
        // Az eldobott kivétel objektum tartalmazzon referenciát az éritett csomagra.
        public FragileParcel(int weight, string address, Placement placement) : base(weight, address, placement)
        {
            if (placement == Placement.Arbitrary)
            {
                throw new IncorrectOrientationException(this, $"Fragile parcels must have fixed orientation.");
            }
        }

        // A szállítás alapdíja 1000 Ft + grammonként 2 Ft.
        // A csomag nem adható fel automatából, ha mégis ez történne, dobjon DeliveryException-t,
        // amelynek hibaüzenetében legyen tájékoztató üzenet a hiba okáról.
        public override double CalculatePrice(bool fromLocker)
        {
            if (fromLocker) throw new DeliveryException(this, $"Fragile parcels cannot be delivered from lockers.");
            return Weight * 2 + 1000;
        }
    }
}