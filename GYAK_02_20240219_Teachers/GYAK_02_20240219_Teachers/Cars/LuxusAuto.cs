namespace GYAK_02_20240219_Teachers.Cars
{
    public sealed class LuxusAuto : Auto
    {
        public int Ar { get; set; }
        public bool ElektromosE { get; set; }

        public override double Fogyasztas()
        {
            if (ElektromosE)
            {
                return 0;
            }
            else return LoEro * 2;
        }

        public bool MegengedhetemEMagamnak(string foglalkozasom)
        {
            return foglalkozasom.ToLower().Trim() == "mérnökinformatikus";
        }
    }
}