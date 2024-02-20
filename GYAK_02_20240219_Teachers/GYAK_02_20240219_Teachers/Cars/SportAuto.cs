namespace GYAK_02_20240219_Teachers.Cars
{
    public sealed class SportAuto : Auto
    {
        public double rajsagiRata;
        public int Nyomatek { get; set; }
        public int SzallithatoUtasokSzama { get; set; }

        public double RajsagiRata
        {
            get
            {
                return rajsagiRata;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    rajsagiRata = value;
                }
                else
                {
                    //Kivételeket még nem tanultuk, ezért egyelőre csak konzolra írunk figyelmeztetést
                    Console.WriteLine("Hibás érték!");
                }
            }
        }
        public bool PotkerekVanE { get; set; }
        public bool VontathatoE { get; set; }
        public bool UltetveVanE { get; set; }

        public override double Fogyasztas()
        {
            return RajsagiRata * 999 * Nyomatek;
        }

        public bool MegengedhetemEMagamnak()
        {
            return rnd.Next(0, 100) > 94; //Tudjuk használni az ős random generátorát is.
        }
    }
}