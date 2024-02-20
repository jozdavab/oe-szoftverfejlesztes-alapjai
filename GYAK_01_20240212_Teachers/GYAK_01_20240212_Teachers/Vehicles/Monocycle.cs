namespace GYAK_01_20240212_Teachers.Vehicles
{
    //Saját osztály deklarálása.
    //Az egykereű osztály sealed, tehát nem lehet belőle leszármaztatni.
    public sealed class Monocycle : Vehicle
    {
        //Mivel a Vehicle osztály rendelkezik 0 paraméteres konstruktorral, nem szükséges explicit meghívni.

        //A leszármazott osztály felülírhatja az ősosztály metódusait. override kulcsszóval.
        public override bool CanMoveHere(RoadType roadType)
        {
            //Mivel az egykerekű ugyanott tud közlekedni ahol a 'jármű' osztály, nem szükséges új logikát írni.
            //base kulcsszóval hivatkozunk az ősosztály metódusára.
            //Mivel mást nem csinálunk ebben a metódusban, ezért igazából ki is törölhetnénk.
            //Ha kitörölnénk a metódust, akkor az ősosztály metódusa futna le.
            return base.CanMoveHere(roadType);
        }

        //Egykerekű speciális metódusa.
        //A 'DoTrick' metódus csak az egykerekűre jellemző.
        //A 'DoTrick' metódus nem szerepel az ősosztályban, tehát nem hívható meg a 'Vehicle' típusú referencián keresztül.
        public void DoTrick()
        {
            Console.WriteLine("Egykerekű trükk!");
        }
    }
}