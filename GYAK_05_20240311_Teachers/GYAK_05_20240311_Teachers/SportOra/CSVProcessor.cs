using GYAK_05_20240311_Teachers.SportOra.Exceptions;

namespace GYAK_05_20240311_Teachers.SportOra
{
    internal class CSVProcessor
    {
        string fileName;

        public CSVProcessor(string fileName)
        {
            this.fileName = fileName;
        }

        int CountItems()
        {
            int count = 0;

            using (StreamReader sr = new StreamReader(fileName)) // Using blokk végén az erőforrás felszabadul
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    ++count;
                }
            }

            return count;
        }

        public Workout[] AllItems()
        {
            Workout[] result = new Workout[CountItems()];

            using (StreamReader sr = new StreamReader(fileName))
            {
                sr.ReadLine();

                for (int i = 0; i < result.Length; ++i)
                {
                    try
                    {
                        result[i] = Workout.Parse(sr.ReadLine());
                    }
                    catch (WorkoutException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return result;
        }
    }
}
