namespace HazasFeladatsor
{
    //Projekten jobb klikk -> Set as StartUp Project
    public class Program
    {
        static void Main(string[] args)
        {
            ApartmentHouse apartmentHouse = ApartmentHouse.LoadFromFile("bemenet.txt");

            Console.WriteLine("Összes lakó a társasházban: " + apartmentHouse.InhibitantsCount);
            Console.WriteLine("Társasházi lakások/garázsok kiadása...");

            for (int i = 0; i < apartmentHouse.CurrentFlatCount; i++)
            {
                if (apartmentHouse.Flats[i] is Lodgings)
                {
                    //4 hónapra beköltözik 2 ember minden albérletbe
                    if ((apartmentHouse.Flats[i] as Lodgings).Book(4))
                    {
                        if ((apartmentHouse.Flats[i] as Lodgings).MoveIn(2))
                        {
                            Console.WriteLine("Sikeres beköltözés");
                        }
                        else
                        {
                            Console.WriteLine("Hiba, ennyi ember nem tud beköltözni ebbe az albérletbe.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hiba, az albérlet már ki van adva másnak.");
                    }
                }
                else if (apartmentHouse.Flats[i] is FamilyApartment)
                {
                    //2 hónapra beköltözik 1 ember minden családi házba
                    if ((apartmentHouse.Flats[i] as FamilyApartment).MoveIn(2))
                    {
                        Console.WriteLine("Sikeres beköltözés");
                    }
                    else
                    {
                        Console.WriteLine("Sikertlen beköltözés a családi házba.");
                    }
                }
            }

            for (int i = 0; i < apartmentHouse.CurrentGarageCount; i++)
            {
                //Minden olcsó garázst kiadunk
                if (apartmentHouse.Garages[i].GetCost(1) < 10000000)
                {
                    if (apartmentHouse.Garages[i].Book(1))
                    {
                        apartmentHouse.Garages[i].UpdateOccupied();
                        Console.WriteLine("Sikeres garázsbérlés");
                    }
                    else
                    {
                        Console.WriteLine("A garázs foglalása sikertelen");
                    }
                }
                else
                {
                    Console.WriteLine("Túl drága a garázs, nem veszi meg senki");
                }
            }

            Console.WriteLine("Összes lakó a társasházban: " + apartmentHouse.InhibitantsCount);
            Console.WriteLine("Összérték: " + apartmentHouse.TotalValue());     //OF,UF történhet!
        }
    }
}
