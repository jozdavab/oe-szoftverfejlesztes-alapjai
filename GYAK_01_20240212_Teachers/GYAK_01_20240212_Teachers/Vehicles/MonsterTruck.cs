namespace GYAK_01_20240212_Teachers.Vehicles
{

    //Saját osztály deklarálása.
    public class MonsterTruck : Vehicle // : után ősosztály deklarálható. C# ban maximum 1 őse lehet egy osztálynak!
    {
        public MonsterTruck(int pos, int speed) : base('m', pos, speed) //A base kulcsszóval hivatkozunk az ősosztály konstruktorára.
        {
            //A leszármazott osztály 0 paraméteres konstruktorából meghívtuk az ősosztály 3 paraméteres konstruktorát.
            //Először az ős osztály konstruktora fut le, majd a leszármazotté.
            //Beállítjuk a motor ikonját 'm'-re. A pozíciót és a sebességet a paraméterekből kapjuk.

            Icon = 'M';     //Felülírjuk az ősosztály konstruktora által beállított 'm' ikont.
            //icon = 'M';   //Ezt nem lehet csinálni, mert 'icon' mező privát. Legalább protected kellene legyen.
        }

        //A leszármazott osztály felülírhatja az ősosztály metódusait. override kulcsszóval.
        public override bool CanMoveHere(RoadType roadType)
        {
            //A MonsterTruck földúton is tud közlekedni ezért új logikát írunk a metódusnak.
            return roadType == RoadType.Dirt || roadType == RoadType.Paved;
        }
    }
}