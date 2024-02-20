namespace GYAK_02_20240219_Teachers.Cars
{
    public abstract class Auto
    {
        protected static readonly Random rnd = new Random();   //Statikus! Ne hozzunk létre minden példányhoz új generátort!
        private static int autoCounter = 0;
        public string Rendszam { get; set; }
        public int TengelyTav { get; set; }
        public DateTime GyartasiIdo { get; set; }
        public int LoEro { get; set; }

        //Tesztelést megegyszerűsítendő konstruktor
        public Auto()
        {
            Rendszam = "AAA-" + autoCounter++.ToString("D3"); // Formázás. https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings?redirectedfrom=MSDN 
            TengelyTav = rnd.Next(1, 10);
            GyartasiIdo = DateTime.Now;
            LoEro = rnd.Next(50, 100);
        }

        public override string ToString()
        {
            return $"{GetType().Name} Rendszam:{Rendszam}\tTengelytav:{TengelyTav}\tGyartva:{GyartasiIdo}\tLoero:{LoEro}";
        }

        public abstract double Fogyasztas();
    }
}