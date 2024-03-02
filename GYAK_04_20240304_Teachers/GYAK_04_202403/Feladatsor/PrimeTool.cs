namespace GYAK_04_202403.Feladatsor
{
    public class PrimeTool
    {
        private readonly int number; // Tárolhatnánk uint-ként is, mivel prímszám nem lehet negatív.

        public PrimeTool(int number)
        {
            this.number = number;
        }

        public bool IsPrime()
        {
            if (number < 2) // 0,1 illetve negatív számok nem prímek.
            {
                return false;
            }
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)     // 2-től a négyzetgyökig bejárjuk a számokat.
            {
                if (number % i == 0)            // Ha bármelyik osztó, akkor a szám nem prím.
                {
                    return false;
                }
            }

            return true;
        }
    }
}