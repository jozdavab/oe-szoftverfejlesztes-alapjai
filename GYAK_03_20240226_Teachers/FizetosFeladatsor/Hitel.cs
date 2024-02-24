namespace FizetosFeladatsor
{
    public class Hitel : IFizetoEszkoz
    {
        private decimal hitelosszeg;

        public Hitel()
        {
            //Alapértelmezett hitelösszeg.
            hitelosszeg = 1000;
        }

        public bool Fizet(decimal fizetendo)
        {
            Console.WriteLine("Hitel fizetési próbálkozás");
            if (fizetendo > hitelosszeg)
            {
                Console.WriteLine("Sikertelen tranzakció");
                return false;
            }
            else
            {
                hitelosszeg -= fizetendo;
                Console.WriteLine("Sikeres tranzakció");
                return true;
            }
        }
    }
}