namespace HazasFeladatsor
{
    public abstract class Flat : IRealEstate
    {
        //protected változók, hogy a leszármazottak is hozzáférjenek.
        protected double area;          //A lakás alapterülete.
        protected int roomsCount;       //A szobák száma.
        protected int inhabitantsCount; //A lakók száma.
        protected int unitPrice;        //A lakás négyzetméterenkénti ára.

        public int InhabitantsCount
        {
            get { return inhabitantsCount; }
        }

        protected Flat(double area, int roomsCount, int inhabitantsCount, int unitPrice)
        {
            this.area = area;
            this.roomsCount = roomsCount;
            this.inhabitantsCount = inhabitantsCount;
            this.unitPrice = unitPrice;
        }

        public abstract bool MoveIn(int newInhabitants);

        public int TotalValue()
        {
            // Kasztolás miatt értékvesztés történhet!
            // Túlcsordulás nincs ellenőrizve, mintaadatok esetén hibás eredményt okoz!
            return (int)(area * unitPrice);
        }

        public override string ToString()
        {
            return $"area: {area}, roomsCount: {roomsCount}, inhabitantsCount: {inhabitantsCount}, unitPrice: {unitPrice}";
        }
    }
}