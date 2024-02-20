namespace GYAK_01_20240212_Teachers.Vehicles
{
    //Saját osztály deklarálása.
    public class Vehicle
    {
        //--------------------------------------------------------------------------------------MEZŐK || FIELDS
        //Az osztály adattagjai (mezői). Alapértelmezett láthatósági mód: privát.
        //Privát adattagok csak az adott osztályon belül érhetőek el.
        //Publikus adattagok az osztályon kívülről is elérhetőek.
        //Protected adattagok az adott osztályon belül valamint a leszármazott osztályokból is elérhetőek!

        char icon;     //A jármű ikonja.
        int position;    //A jármű helyzete 1 dimenziós térben.

        //--------------------------------------------------------------------------------------TULAJDONSÁGOK || PROPERTIES
        //Az adattagok elérését szolgáló tulajdonságok (properties).

        public char Icon
        {
            //Ha valamelyik ág 'hiányzik', akkor az adattag csak olvasható vagy csak írható lesz.
            get
            {
                //A GET ág a 'Icon' tulajdonság olvasásakor fut le. Visszaadjuk 'icon' mező értékét.
                return icon;
            }
            set
            {
                //A SET ág a 'Icon' tulajdonság írásakor fut le. Beállítjuk 'icon' mező értékét a 'value' paraméter értékére.
                //Value paraméter: Az érték, amit a tulajdonság értékének beállításakor használunk.
                //Pl.: vehicleInstance.Icon = 'V'; esetén 'V' érték lesz a value.
                icon = value;
            }
        }

        //Rövidített, lambdás tulajdonság deklaráció. Az előzővel ekvivalens.
        public int Position
        {
            get => position;            //'Position' tulajdonság olvasásakor visszaadja 'position' mező értékét.
            set => position = value;    //'Position' tulajdonság írásakor beállítja 'position' mező értékét a 'value' értékére.
        }

        public int Speed { get; private set; }  //A jármű sebessége. Autoproperty. A set ág privát, így csak az osztályon belül módosítható.


        //Nulla paraméteres konstruktor. Ha üres, a mezőket alapértelmezett értékekkel inicializálja.
        //Amennyiben nincs deklarálva konstruktor, akkor a fordító létrehoz egy alapértelmezett nulla paraméteres konstruktort.
        public Vehicle()
        {
            Speed = 1;
        }

        //Három paraméteres konstruktor amely beállítja az adattagok kezdeti értékét példányosításkor.
        //Mivel deklaráltunk konstruktort, a fordító nem hoz létre alapértelmezett nulla paraméteres konstruktort.
        public Vehicle(char icon, int pos, int speed)
        {
            //This kulcsszó: Az osztály adattagjaira hivatkozik.
            //Mivel a bejövő paraméter neve megegyezik az adattag nevével, a this kulcsszóval kell hivatkoznunk az adattagra.
            //this kulcsszó nélkül a fordító a bejövő paramétert tenné egyenlővé önmagával.
            this.icon = icon;

            //Nem szükséges a this kulcsszó, mivel az adattag neve (position) eltér a paraméter nevétől (pos).
            position = pos;

            //Nem szükséges a this kulcsszó, mivel a Property neve (Speed) eltér a paraméter nevétől (speed).
            Speed = speed;
        }


        //--------------------------------------------------------------------------------------METÓDUSOK || METHODS

        //Az osztály metódusai. Az osztályon belül deklarált függvények.

        //Virtuális metódus. A leszármazott osztályok felülírhatják.
        //Megmondja hogy a jármű közlekedhet-e egy adott úttípuson.
        public virtual bool CanMoveHere(RoadType roadType)
        {
            return roadType == RoadType.Paved;  //A járművek csak aszfalton tudnak közlekedni.
        }
    }
}