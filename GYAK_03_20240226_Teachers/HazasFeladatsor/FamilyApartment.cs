namespace HazasFeladatsor
{
    public class FamilyApartment : Flat
    {
        private int childrenCount;

        public FamilyApartment(double area, int roomsCount, int unitPrice) : base(area, roomsCount, 0, unitPrice)
        {
            this.childrenCount = 0; // Alapértelmezetten is nulla lenne, elhagyható.
        }

        public bool ChildIsBorn()
        {
            if (InhabitantsCount - childrenCount > 1)
            {
                inhabitantsCount++;
                childrenCount++;
                return true;
            }
            return false;
        }

        public override bool MoveIn(int newInhabitants)
        {
            if (newInhabitants + InhabitantsCount > roomsCount * 2)
            {
                // Az apartman egy szobájában maximum 2 fő lakhat.
                return false;
            }
            else if (area / (newInhabitants + InhabitantsCount - (childrenCount / 2)) < 10)
            {
                // Egy főre minimum 10m^2 területnek kell jutnia.
                // A gyerekek csak fél főnek számítanak.
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
            return base.ToString() + $", childrenCount: {childrenCount}";
        }
    }
}