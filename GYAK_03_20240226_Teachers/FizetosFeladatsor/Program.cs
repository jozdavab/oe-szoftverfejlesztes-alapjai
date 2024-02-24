namespace FizetosFeladatsor
{
    //Projekten jobb klikk -> Set as StartUp Project
    public class Program
    {
        static void Main(string[] args)
        {
            //Interfészeket megvalósító osztályok tárolása
            //BankKartya és Hitel osztályok között nincs közvetlen kapcsolat, mégis egy gyűjteményben tárolhatók.
            IFizetoEszkoz[] eszkozok = new IFizetoEszkoz[3];
            eszkozok[0] = new BankKartya("Jozsa David", 90);
            eszkozok[2] = new LetiltottBankKartya("Jozsa David", 100, DateTime.Now);
            eszkozok[1] = new Hitel();

            bool outcome = Fizetes(eszkozok);
            if (outcome)
            {
                Console.WriteLine("Sikeres fizetés");
            }
            else
            {
                Console.WriteLine("Sikertelen fizetés");
            }

            outcome = EllenorzottFizetes(eszkozok, "Jozsa David");
            if (outcome)
            {
                Console.WriteLine("Sikeres ellenőrzött fizetés");
            }
            else
            {
                Console.WriteLine("Sikertelen ellenőrzött fizetés");
            }
        }

        public static bool Fizetes(IFizetoEszkoz[] fizetoEszkozok)
        {
            foreach (IFizetoEszkoz eszkoz in fizetoEszkozok)
            {
                if (eszkoz.Fizet(100))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EllenorzottFizetes(IFizetoEszkoz[] fizetoEszkozok, string tulajdonos)
        {
            foreach (IFizetoEszkoz eszkoz in fizetoEszkozok)
            {
                //Hitel osztály nem fog megfelelni ennek a kritériumnak.
                if (eszkoz is ITulajdon)
                {
                    //Rövidzár kiértékelés, sorrend fontos!
                    if ((eszkoz as ITulajdon).Tulajdonos == tulajdonos && eszkoz.Fizet(10))
                    {
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Tulajdonos nem ellenőrizhető az eszközön");
                }
            }
            return false;
        }
    }
}
