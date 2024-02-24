namespace FizetosFeladatsor
{
    public class PlasztikKartya : ITulajdon
    {
        private string tulajdonos;

        public string Tulajdonos
        {
            get
            {
                return tulajdonos;
            }
            set
            {
                tulajdonos = value;
            }
        }

        public PlasztikKartya(string tulajdonos)
        {
            Tulajdonos = tulajdonos;
        }
    }
}