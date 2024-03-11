using GYAK_05_20240311_Teachers.SportOra;

namespace GYAK_05_20240311_Teachers
{
    public class Program
    {
        static void Main(string[] args)
        {
            CSVProcessor csv = new CSVProcessor("workouts.csv");
            try
            {
                foreach (Workout item in csv.AllItems())
                {
                    Console.WriteLine(item);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Invalid file!");
            }
        }
    }
}