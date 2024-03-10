namespace GYAK_05_20240311_Teachers.SportOra.Exceptions
{
    public class TimeException : Exception
    {
        public TimeException(string message = "", Exception innerException = null)
            : base(message, innerException)
        {
        }
    }

    public class HourException : TimeException
    {
        public int Hour { get; private set; }

        public HourException(int hour, string message = "", Exception innerException = null)
            : base(message, innerException)
        {
            Hour = hour;
        }
    }

    public class MinuteException : TimeException
    {
        public int Minute { get; private set; }

        public MinuteException(int minute, string message = "", Exception innerException = null)
            : base(message, innerException)
        {
            Minute = minute;
        }
    }

    public class SecondException : TimeException
    {
        public int Second { get; private set; }

        public SecondException(int second, string message = "", Exception innerException = null)
            : base(message, innerException)
        {
            Second = second;
        }
    }
}