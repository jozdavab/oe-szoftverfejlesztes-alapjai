namespace GYAK_01_20240212_Teachers.Vehicles
{
    //Saját osztály deklarálása.
    public class Helicopter : Vehicle
    {
        //Mivel a Vehicle osztály rendelkezik 0 paraméteres konstruktorral, nem szükséges explicit meghívni.

        //A leszármazott osztály felülírhatja az ősosztály metódusait. override kulcsszóval.
        public override bool CanMoveHere(RoadType roadType)
        {
            return true;    //A helikopter bármilyen úton felett közlekedni.
        }
    }
}