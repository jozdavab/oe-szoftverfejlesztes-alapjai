using GYAK_06_20240318_Teachers.Utils;

namespace GYAK_06_20240318_Teachers.Deliverables
{
    // Készítsen egy NormalParcel nevű osztályt, amely a Parcel osztályból származik. Az osztály egy hagyományos csomagot reprezentál.
    public class NormalParcel : Parcel
    {
        static readonly Random rnd = new Random();

        // A tömeg és a címzett a konstruktor paramétereként adható meg.
        // A csomag elhelyezésének módját példányosításkor véletlenszerűen állítsa be.
        public NormalParcel(int weight, string address) : base(weight, address)
        {
            int enumCount = Enum.GetNames(typeof(Placement)).Length;
            Placement = (Placement)rnd.Next(0, enumCount);
        }

        // A szállítás alapdíja 500 Ft + grammonként 1 Ft.
        // Ha a csomagot automatából adják fel, akkor vonjon le a díjból 250 Ft-ot.
        public override double CalculatePrice(bool fromLocker)
        {
            double price = Weight + 500;
            if (fromLocker) price -= 250;
            return price;
        }
    }
}