namespace GYAK_03_20240226_Teachers
{
    public class Program
    {
        //Projekten jobb klikk -> Set as StartUp Project
        static void Main(string[] args)
        {
            // IComparable gyakorlás

            //Teszt tömb
            User[] users = new User[]
            {
                new User { Name = "Kiss József", Grade = 4.5 },
                new User { Name = "Nagy Béla", Grade = 3.5 },
                new User { Name = "Kovács László", Grade = 4.5 },
                new User { Name = "Tóth Péter", Grade = 3.5 },
                new User { Name = "Szabó Gábor", Grade = 5.0 }
            };

            Console.WriteLine("\nRendezetlen tömb\n");
            DisplayArrayItems(users);

            Array.Sort(users); // Beépített rendezési algoritmus, Comparable elemekhez.

            Console.WriteLine("\nRendezett tömb\n");
            DisplayArrayItems(users);

        }

        //Mivel object tömböt kap a metódus, ezért bármilyen típusú tömböt meg tud jeleníteni.
        static void DisplayArrayItems(object[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item); // ToString() hívódik meg. Ha felüldefiniáltuk, szép lesz a kiírás.
            }
        }
    }
}