namespace GYAK_02_20240219_Teachers.Cars
{
    public sealed class Teherauto : Haszongepjarmu
    {
        public int SzallithatoUtasokSzama { get; set; }
        public int Teherbiras { get; set; }
        public bool PonyvazhatoE { get; set; }

        public double Rakodas()
        {
            return (double)Teherbiras / SzallithatoUtasokSzama;
        }

        public override double Fogyasztas()
        {
            if (PonyvazhatoE)
            {
                return Teherbiras * SzallithatoUtasokSzama;
            }
            else
            {
                return Teherbiras * SzallithatoUtasokSzama % 4;
            }
        }
    }
}
