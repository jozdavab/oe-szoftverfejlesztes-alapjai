namespace GYAK_03_20240226_Teachers
{
    public class User : IComparable //Az IComparable objektumok összehasonlíthatóak.
    {
        //A usernek neve és jegye van.
        public string Name { get; set; }
        public double Grade { get; set; }

        public int CompareTo(object other)
        {
            // Azonos osztályzat esetén név szerint rendezünk.
            if (Grade == ((User)other).Grade)
            {
                // Stringekre nem szükséges külön logikát írni,
                // mert a string osztály már tartalmaz CompareTo megvalósítást.
                return Name.CompareTo(((User)other).Name);
            }
            else if (Grade > ((User)other).Grade)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //Szép kiírás miatt felüldefiniáljuk a ToString metódust.
        public override string ToString()
        {
            return $"{Name} - {Grade}";
        }
    }
}