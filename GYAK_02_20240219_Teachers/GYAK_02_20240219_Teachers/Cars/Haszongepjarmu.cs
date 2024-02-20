namespace GYAK_02_20240219_Teachers.Cars
{
    public abstract class Haszongepjarmu : Auto
    {
        private double hasznossagiHanyados;

        double HasznossagiHanyados
        {
            get { return hasznossagiHanyados; }
            set
            {
                if (value > 0 && value < 2)
                {
                    hasznossagiHanyados = value;
                }
                else
                {
                    //Kivételeket még nem tanultuk, ezért egyelőre csak konzolra írunk figyelmeztetést
                    Console.WriteLine("Hibás érték!");
                }
            }
        }
        string FelhasznalasiTerulet { get; set; }

        //Vegyük észre, hogy bár az Auto osztály rendelkezik egy abstract medótussal, a Haszongepjarmu osztályban nem kell implementálni azt.
        //Az abstract metódusokat csak azokban az osztályokban kell implementálni, amelyek nem abstract osztályok.
    }
}
