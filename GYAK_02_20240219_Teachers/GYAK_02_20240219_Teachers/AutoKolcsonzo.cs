using GYAK_02_20240219_Teachers.Cars;

namespace GYAK_02_20240219_Teachers
{
    public sealed class AutoKolcsonzo
    {
        Auto[] autok; // A félév során tanulni fogunk új adatszerkezeteket, amelyekkel könnyebben lehetne kezelni az autókat.

        public AutoKolcsonzo()
        {
            autok = new Auto[0];
        }

        public void AutoFelvetele(Auto auto)
        {
            Auto[] temp = new Auto[autok.Length + 1];
            for (int i = 0; i < autok.Length; i++)
            {
                temp[i] = autok[i];
            }
            temp[autok.Length] = auto;
            autok = temp;
        }

        public void AutoTorlese(Auto auto)
        {
            Auto[] temp = new Auto[autok.Length - 1];
            int j = 0;
            for (int i = 0; i < autok.Length; i++)
            {
                if (autok[i] != auto)
                {
                    temp[j] = autok[i];
                    j++;
                }
            }
            autok = temp;
        }

        public void AutoLista()
        {
            foreach (Auto auto in autok)
            {
                Console.WriteLine(auto);
                //Az autó osztály ToString metódusát felülírtuk, így formázottan történik a megjelenítés.
            }
            Console.WriteLine();
        }

        public double OsszFogyasztas()
        {
            double osszFogyasztas = 0;
            foreach (Auto auto in autok)
            {
                //A virtuális függvények miatt késői kötés történik, így mindig a megfelelő fogyasztás függvény hívódik meg.
                osszFogyasztas += auto.Fogyasztas();
                Console.WriteLine($"Az aktuális vizsgált auto:{auto}");
                Console.WriteLine($"Az aktuális autó fogyasztása:{auto.Fogyasztas()}");
                Console.WriteLine($"Az eddigi össz fogyasztás: {osszFogyasztas}");
            }
            Console.WriteLine();
            return osszFogyasztas;
        }

        public void Rakodas()
        {
            int counter = 0;
            foreach (Auto auto in autok)
            {
                if (auto is Teherauto)
                {
                    (auto as Teherauto).Rakodas();
                    Console.WriteLine($"Rakdoni kezdtem az {++counter}. teherautót");
                }
            }
            Console.WriteLine();
        }

        public void Feltoltes()
        {
            for (int i = autok.Length / 2; i < autok.Length; i++)
            {
                if (autok[i] is TaviranyitosAuto)
                {
                    (autok[i] as TaviranyitosAuto).ElemCsere();
                    Console.WriteLine($"Elemcsere történt az {i}. autóban");
                }
            }
            Console.WriteLine();
        }
    }
}