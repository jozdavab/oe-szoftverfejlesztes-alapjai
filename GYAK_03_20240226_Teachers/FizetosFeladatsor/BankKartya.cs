namespace FizetosFeladatsor
{
    public class BankKartya : PlasztikKartya, IFizetoEszkoz
    {
        private decimal egyenleg;

        public BankKartya(string tulajdonos, decimal egyenleg) : base(tulajdonos)
        {
            this.egyenleg = egyenleg;
        }

        public bool Fizet(decimal fizetendo)
        {
            Console.WriteLine("Bankkártyás fizetési próbálkozás");
            if (fizetendo > egyenleg)
            {
                Console.WriteLine("Sikertelen tranzakció");
                return false;
            }
            else
            {
                egyenleg -= fizetendo;
                Console.WriteLine("Sikeres tranzakció");
                return true;
            }
        }
    }
}