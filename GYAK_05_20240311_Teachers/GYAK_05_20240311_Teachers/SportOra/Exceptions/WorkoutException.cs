namespace GYAK_05_20240311_Teachers.SportOra.Exceptions
{
    public class WorkoutException : Exception
    {
        public WorkoutException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
