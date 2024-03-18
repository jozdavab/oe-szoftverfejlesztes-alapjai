using GYAK_06_20240318_Teachers.Deliverables;

namespace GYAK_06_20240318_Teachers.Exceptions
{
    // Készítse el az említett kivétel osztályt is.
    public class OverWeightException : Exception
    {
        // (A súly ami a kivételt kiváltotta)
        public double Weight { get; }

        // (A példány amin a kivétel keletkezett)
        public IDeliverable Deliverable { get; }

        public OverWeightException(double weight, IDeliverable deliverable)
        {
            Weight = weight;
            Deliverable = deliverable;
        }
    }
}