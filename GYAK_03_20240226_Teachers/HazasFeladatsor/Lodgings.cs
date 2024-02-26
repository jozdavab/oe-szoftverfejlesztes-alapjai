namespace HazasFeladatsor
{
    public class Lodgings : Flat, IRent
    {
        private int bookedMonths;

        public Lodgings(double area, int roomsCount, int unitPrice) : base(area, roomsCount, 0, unitPrice)
        {
            this.bookedMonths = 0; // Alapértelmezetten is nulla lenne, elhagyható.
        }

        public bool IsBooked
        {
            get { return bookedMonths > 0; }
        }

        public bool Book(int months)
        {
            if (bookedMonths > 0)
            {
                // A lakás már ki van adva.
                return false;
            }
            bookedMonths = months;
            return true;
        }

        public int GetCost(int months)
        {
            if (inhabitantsCount == 0)
            {
                // Zéróosztó hiba elkerülése. Később tanulnuk kivételkezelést / más megoldást.
                return -1;
            }
            // Egész számokat osztunk, értékvesztés történhet!
            return months * TotalValue() / 240 / InhabitantsCount;
        }

        public override bool MoveIn(int newInhabitants)
        {
            if (IsBooked!)
            {
                // Még nem lett kibérelve, ezért nem költözhető.
                return false;
            }
            else if (newInhabitants + InhabitantsCount > roomsCount * 8)
            {
                // Az albérletben egy szobában maximum 8 fő lakhat.
                return false;
            }
            else if (area / (newInhabitants + InhabitantsCount) < 2)
            {
                // Egy főre minimum 2m^2 területnek kell jutnia.
                return false;
            }
            else
            {
                inhabitantsCount += newInhabitants;
                return true;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", bookedMonths: {bookedMonths}";
        }
    }
}