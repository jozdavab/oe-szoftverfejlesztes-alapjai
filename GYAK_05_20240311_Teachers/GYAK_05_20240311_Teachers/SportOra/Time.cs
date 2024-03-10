using GYAK_05_20240311_Teachers.SportOra.Exceptions;

namespace GYAK_05_20240311_Teachers.SportOra
{
    public class Time
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }

        public Time(int hour = 0, int minute = 0, int second = 0)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public override bool Equals(object? obj)
        {
            return obj is Time other && Hour == other.Hour && Minute == other.Minute && Second == other.Second;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hour, Minute, Second);
        }

        public static Time Parse(string input)
        {
            string[] items = input.Split(':');
            if (items.Length != 3) throw new TimeException();
            Time result = new Time();
            string message = $"{input} cannot be parsed as a time.";

            try
            {
                int h = int.Parse(items[0]);
                if (h < 0) throw new HourException(h, message);
                result.Hour = h;
            }
            catch (FormatException formatException) // int.Parse() dobhat FormatException-t
            {
                throw new TimeException(message, formatException); // Kivételek egymásba ágyazhatók
            }

            try
            {
                int m = int.Parse(items[1]);
                if (m < 0 || m > 59) throw new MinuteException(m, message);
                result.Minute = m;
            }
            catch (FormatException formatException)// int.Parse() dobhat FormatException-t
            {
                throw new TimeException(message, formatException); // Kivételek egymásba ágyazhatók
            }

            try
            {
                int s = int.Parse(items[2]);
                if (s < 0 || s > 59) throw new SecondException(s, message);
                result.Second = s;
            }
            catch (FormatException formatException)// int.Parse() dobhat FormatException-t
            {
                throw new TimeException(message, formatException); // Kivételek egymásba ágyazhatók
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Hour}:{Minute}:{Second}";
        }
    }
}