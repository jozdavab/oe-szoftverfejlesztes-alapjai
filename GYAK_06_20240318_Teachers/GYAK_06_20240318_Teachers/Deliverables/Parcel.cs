using GYAK_06_20240318_Teachers.Utils;

namespace GYAK_06_20240318_Teachers.Deliverables
{
    // Készítsen egy Parcel nevű absztrakt osztályt, amely megvalósítja az IDeliverable és az IComparable interfészeket.
    // Az osztály egy csomagot reprezentál. Az összehasonlítás történjen a küldemény tömege alapján.
    public abstract class Parcel : IDeliverable, IComparable
    {
        public int Weight { get; set; }
        public string Address { get; set; }

        // Tárolja a csomag elhelyezésének módját, amely legyen lekérdezhető egy publikus tulajdonságon keresztül.
        // Az elhelyezési mód(tetszőleges, állítva, fektetve) az alábbiak egyike lehet:
        // Arbitrary, Horizontal, Vertical. (Ehhez készítse el a megfelelő enumot is.)
        public Placement Placement { get; set; }

        // A tömeg, címzett és az elhelyezési mód a konstruktor paramétereként adható meg. 
        protected Parcel(int weight, string address, Placement placement) : this(weight, address)
        {
            Placement = placement;
        }

        // Készítsen egy olyan konstruktort is, amely csak a tömeget és a címzettet fogadja.
        protected Parcel(int weight, string address)
        {
            Weight = weight;
            Address = address;
        }

        // A CalculatePrice metódus legyen absztrakt.
        public abstract double CalculatePrice(bool fromLocker);

        // Az összehasonlítás történjen a küldemény tömege alapján.
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            return Weight.CompareTo((obj as Parcel).Weight);
        }

        // A ToString metódus adja vissza a csomag adatait az Envelope-nál megadott formátumhoz hasonlóan.
        public override string ToString()
        {
            return $"Címzett:{Address} / Elhelyezés: {Placement} / Tömeg:{Weight} g";
        }
    }
}