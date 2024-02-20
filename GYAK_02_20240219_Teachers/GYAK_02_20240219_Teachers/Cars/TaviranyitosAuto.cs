namespace GYAK_02_20240219_Teachers.Cars
{
    public enum KommunikacioFajta
    {
        BT, WIFI, RADIO
    }

    public sealed class TaviranyitosAuto : ModellAuto
    {
        private int elemToltottseg;

        public int ElemToltottseg
        {
            get { return elemToltottseg; }
            set
            {
                if (value > -1 && value < 101)
                {
                    elemToltottseg = value;
                }
                else
                {
                    //Kivételeket még nem tanultuk, ezért egyelőre csak konzolra írunk figyelmeztetést
                    Console.WriteLine("Hibás érték!");
                }
            }
        }

        public KommunikacioFajta KommunikacioFajtaja { get; set; }

        public override double Fogyasztas()
        {
            return 0;
        }

        public void ElemCsere()
        {
            if (rnd.Next(0, 100) < 80)
            {
                ElemToltottseg = 100;
            }
        }
    }
}