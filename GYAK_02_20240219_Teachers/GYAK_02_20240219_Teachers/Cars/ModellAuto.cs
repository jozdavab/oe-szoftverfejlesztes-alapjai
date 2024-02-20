namespace GYAK_02_20240219_Teachers.Cars
{
    public class ModellAuto : Auto
    {
        private int osszeszerelesNehezsege;

        public int OsszeszerelesNehezsege
        {
            get { return osszeszerelesNehezsege; }
            set
            {
                if (value > 0 && value < 10)
                {
                    osszeszerelesNehezsege = value;
                }
                else
                {
                    //Kivételeket még nem tanultuk, ezért egyelőre csak konzolra írunk figyelmeztetést
                    Console.WriteLine("Hibás érték!");
                }
            }
        }

        public int Suly { get; set; }

        public override double Fogyasztas()
        {
            return (double)LoEro / 100 * Suly * OsszeszerelesNehezsege;
        }
    }
}