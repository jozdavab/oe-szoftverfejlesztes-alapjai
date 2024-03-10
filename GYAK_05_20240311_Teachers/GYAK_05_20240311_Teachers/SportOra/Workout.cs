using GYAK_05_20240311_Teachers.SportOra.Exceptions;
using System.Text;

namespace GYAK_05_20240311_Teachers.SportOra
{
    public enum WorkoutType
    {
        Cycling,
        Hiking,
        Running,
        Swimming,
    }

    public class Workout
    {
        public WorkoutType Type { get; set; }
        public double Length { get; set; }
        public Time Time { get; set; }
        public int Elevation { get; set; }
        public int HeartRate { get; set; }

        private static string[] Split(string input)
        {
            StringBuilder sb = new StringBuilder();

            // type
            int i = 0;

            while (i < input.Length && input[i] != ',')
            {
                sb.Append(input[i++]);
            }

            string message = $"{input} cannot be parsed as a workout.";
            if (i >= input.Length) throw new WorkoutException(message);

            string[] result = new string[5];
            result[0] = sb.ToString();

            //distance
            for (int j = 0; j < 4; ++j)
            {
                if (input[i] != ',') throw new WorkoutException(message);
                i++;

                if (input[i] != '"') throw new WorkoutException(message);
                i++;

                sb = new StringBuilder();
                while (i < input.Length && input[i] != '"')
                {
                    sb.Append(input[i++]);
                }
                if (i >= input.Length) throw new WorkoutException(message);

                result[j + 1] = sb.ToString();
                i++;
            }

            return result;
        }

        public static Workout Parse(string input)
        {
            string[] items = Split(input);
            Workout result = new Workout();
            string message = $"{input} cannot be parsed as a workout.";

            try
            {
                result.Type = (WorkoutType)Enum.Parse(typeof(WorkoutType), items[0]);
            }
            catch (ArgumentException argumentException)
            {
                throw new WorkoutException(message, argumentException);
            }

            try
            {
                result.Length = double.Parse(items[1]);
                if (result.Length <= 0) throw new WorkoutException(message);
            }
            catch (FormatException formatException)
            {
                throw new FormatException(message, formatException);
            }

            try
            {
                result.Time = Time.Parse(items[2]);
            }
            catch (TimeException timeException)
            {
                throw new WorkoutException(message, timeException);
            }

            try
            {
                result.Elevation = int.Parse(items[3]);
            }
            catch (FormatException formatException)
            {
                throw new WorkoutException(message, formatException);
            }

            try
            {
                result.HeartRate = int.Parse(items[4]);
                if (result.HeartRate <= 0) throw new WorkoutException(message);
            }
            catch (FormatException formatException)
            {
                throw new WorkoutException(message, formatException);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Type}: {Length} km, {Time}, ({Elevation}, {HeartRate})";
        }
    }
}
