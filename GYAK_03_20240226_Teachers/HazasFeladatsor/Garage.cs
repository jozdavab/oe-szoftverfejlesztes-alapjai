namespace HazasFeladatsor
{
    public class Garage : IRealEstate, IRent
    {
        private double area;    // A garázs alapterülete.
        private int unitPrice;  // A garázs négyzetméterenkénti ára.
        private bool isHeated;  // Fűtött-e a garázs.
        private int months;     // Hány hónapra van lefoglalva.
        private bool isOccupied;// Áll-e benne autó.

        public bool IsBooked
        {
            get
            {
                return isOccupied || months > 0;
            }
        }

        public Garage(double area, int unitPrice, bool isHeated)
        {
            this.area = area;
            this.unitPrice = unitPrice;
            this.isHeated = isHeated;
            this.months = 0;            // Alapértelmezetten is nulla lenne, elhagyható.
            this.isOccupied = false;    // Alapértelmezetten is nulla lenne, elhagyható.
        }

        public bool Book(int months)
        {
            if (IsBooked)
            {
                return false;
            }
            else
            {
                this.months = months;
                return true;
            }
        }

        public int GetCost(int months)
        {
            if (isHeated)
            {
                // Kasztolás miatt értékvesztés történhet!
                return ((int)(TotalValue() / 120 * 1.5d));
            }
            else
            {
                // Egész számokat osztunk, értékvesztés történhet!
                return TotalValue() / 120;
            }
        }

        public int TotalValue()
        {
            // Kasztolás miatt értékvesztés történhet!
            return (int)(area * unitPrice);
        }

        public void UpdateOccupied()
        {
            this.isOccupied = !this.isOccupied; //Bool billentése.
        }

        public override string ToString()
        {
            return $"Garage: {area} m2, {unitPrice} Ft/m2, {(isHeated ? "heated" : "not heated")}, {(isOccupied ? "occupied" : "not occupied")}, {months} months booked";
        }
    }
}