namespace FizetosFeladatsor
{
    public class LetiltottBankKartya : BankKartya, IElvesztett
    {
        private DateTime eltunesIdeje;

        public DateTime EltunesIdeje
        {
            get
            {
                return eltunesIdeje;
            }
            set
            {
                eltunesIdeje = value;
            }
        }

        public LetiltottBankKartya(string tulajdonos, decimal egyenleg, DateTime eltunesIdeje) : base(tulajdonos, egyenleg)
        {
            EltunesIdeje = eltunesIdeje;
        }

        public bool Fizet(decimal fizetendo)
        {
            Console.WriteLine("Letiltott Bankkártyás fizetési próbálkozás");
            Console.WriteLine("Sikertelen tranzakció");
            return false;
        }
    }
}