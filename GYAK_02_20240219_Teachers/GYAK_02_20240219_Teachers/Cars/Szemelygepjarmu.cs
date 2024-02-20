namespace GYAK_02_20240219_Teachers.Cars
{
    public sealed class Szemelygepjarmu : Auto
    {
        public int AjtokSzama { get; set; }
        public int SzallithatoUtasokSzama { get; set; }

        public override double Fogyasztas()
        {
            return LoEro * AjtokSzama;
        }
    }
}