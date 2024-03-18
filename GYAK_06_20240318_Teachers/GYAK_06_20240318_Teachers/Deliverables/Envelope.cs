using GYAK_06_20240318_Teachers.Exceptions;

namespace GYAK_06_20240318_Teachers.Deliverables
{
    // Készítsen egy Envelope nevű osztályt, amely megvalósítja az IDeliverable interfészt.
    // Az osztály egy lapos formátumú küldeményt(pl.borítékot, hanglemezt) reprezentál.
    public class Envelope : IDeliverable
    {
        public int Weight { get; set; }
        public string Address { get; set; }
        // A küldemény leírását tárolja egy karakterlánc típusú mezőben.
        public string Details { get; set; }

        // A tömeg, címzett és a leírás a konstruktor paramétereként adható meg.
        public Envelope(int weight, string address, string details)
        {
            Weight = weight;
            Address = address;
            Details = details;
        }

        // A szállítási díj 50 grammig 200 Ft, 51–500 gramm között 400 Ft, 501–2000 gramm között 1000 Ft,
        // függetlenül attól, hogy automatából történt-e a feladás(fromLocker paraméter).
        // A díjszámítás során dobjon el OverweightException kivételt, ha a küldemény tömege
        // meghaladja a 2000 grammot. Készítse el az említett kivéWtel osztályt is.
        public double CalculatePrice(bool fromLocker)
        {
            if (Weight > 2000)
            {
                // Note: Ezt inkább a konstruktorban kellett volna...
                throw new OverWeightException(Weight, this);
            }
            if (Weight < 50)
            {
                return 200;
            }
            else if (Weight < 500)
            {
                return 400;
            }
            else
            {
                return 2000;
            }
        }

        // A ToString metódus adja vissza a csomag adatait az alábbi formátumnak megfelelően.
        public override string ToString()
        {
            // Címzett: Travis Kelce / Leírás: Taylor Swift hanglemez / Tömeg:750 g
            return $"Címzett:{Address} / Leírás: {Details} / Tömeg:{Weight} g";
        }
    }
}