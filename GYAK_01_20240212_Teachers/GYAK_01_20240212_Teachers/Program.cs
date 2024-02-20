using GYAK_01_20240212_Teachers.Vehicles;   //Az import szükséges, mivel más névtérben van a Vehicle osztály. (A mappa miatt.)

namespace GYAK_01_20240212_Teachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Az objektum-orientált paradigma elemei: objektum, osztály, osztályok közötti kapcsolatok.
             */

            //Objektumok
            object ancestor = new object();     //Object ősosztály egy példánya. Az object osztály minden osztály ősosztálya.
            Console.WriteLine(ancestor);        //Az object osztály ToString() metódusa alapértelmezetten a típus nevét adja vissza.
            ancestor = "Hello, World!";         //Az object típusú változóba bármilyen típusú objektumot el lehet helyezni.
            Console.WriteLine(ancestor);        //Az stringek ToString() metódusa alapértelmezetten a változó értékét adja vissza.

            Vehicle vehicle = new Vehicle();    //Vehicle osztály deklarálása és inicializálása.
            vehicle.Icon = 'V';                 //Az ikon értékének beállítása.

            Vehicle[] vehicles = new Vehicle[4];

            vehicles[0] = vehicle;
            vehicles[1] = new MonsterTruck(0, 2);
            vehicles[2] = new Helicopter();
            vehicles[2].Icon = 'H';
            vehicles[3] = new Monocycle();
            vehicles[3].Icon = 'O'; 

            RoadType[] road = new RoadType[10];     //10 elemű RoadType tömb létrehozása
            road[0] = RoadType.Paved;               //Az út első eleme aszfalt.
            Random rnd = new Random();              //Random osztály példányosítása.

            //Az út többi eleme véletlenszerűen aszfalt, föld vagy láva.
            for (int i = 1; i < road.Length; i++)
            {
                int chance = rnd.Next(10);
                if (chance == 0)
                {
                    road[i] = RoadType.Lava;
                }
                else if (chance < 4)
                {
                    road[i] = RoadType.Dirt;
                }
                else
                {
                    road[i] = RoadType.Paved;
                }
            }

            //Verseny.
            int lap = 0;
            do
            {
                //Öszes jármű mozgatása.
                for (int i = 0; i < vehicles.Length; i++)
                {
                    //Minden járművet annyiszor mozgatunk amennyi a sebessége
                    for (int j = 0; j < vehicles[i].Speed; j++)
                    {
                        //Ha a jármű tud mozogni az adott úton, akkor mozgatjuk.
                        //A vehicle leszármazottak saját CanMoveHere() implementációja hívódik meg.
                        if (vehicles[i].Position + 1 < road.Length && vehicles[i].CanMoveHere(road[vehicles[i].Position + 1]))
                        {
                            vehicles[i].Position++;
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine($"{lap}. lap");
                PrintRoad(road);
                PrintVehicles(vehicles);
                Thread.Sleep(1000); //1 másodperc (1000ms) várakozás a következő körig.
            } while (!RaceOver(vehicles, road.Length - 1, lap++));
            //Addig folytatódik a verseny összes köre amíg a RaceOver() metódus nem ad vissza igaz értéket.

            foreach (Vehicle v in vehicles)
            {
                //Az 'is' kulcsszóval ellenőrizhetjük, hogy egy objektum egy adott típusú-e.
                if (v is Monocycle)
                {
                    //Az 'as' kulcsszóval típuskényszerítést hajthatunk végre.
                    (v as Monocycle).DoTrick();
                }
            }

            //SpecialClass sc = new SpecialClass();                 //SpecialClass példányosítása. Nem lehetséges mert az osztály abstract.
            ChildOfSpecialClass csc = new ChildOfSpecialClass();    //SpecialClassból származtatott osztály példányosítása.
        }

        static bool RaceOver(Vehicle[] vehicles, int finPos, int lap)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                //Ha bármelyik jármű a célban van, akkor vége a versenynek.
                if (vehicles[i].Position == finPos)
                {
                    return true;
                }
            }
            //Ha mindenki elakadt, akkor is vége a versenynek.
            return lap > finPos + 1;
        }

        static void PrintRoad(RoadType[] road)
        {
            for (int i = 0; i < road.Length; i++)
            {
                //Az út színének beállítása. A konzor háttérszínét állítjuk.
                switch (road[i])
                {
                    case RoadType.Paved:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        break;
                    case RoadType.Dirt:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case RoadType.Lava:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                }
                Console.Write(' ');
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static void PrintVehicles(Vehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                int top = Console.GetCursorPosition().Top;              // Kurzor pozíciójának lekérése.
                Console.SetCursorPosition(vehicles[i].Position, top);   // Kurzor pozíciójának beállítása az autó pozíciójára.
                Console.WriteLine($"{vehicles[i].Icon}");               // Az autó ikonjának kiírása, majd sortörés.
            }
        }
    }
}