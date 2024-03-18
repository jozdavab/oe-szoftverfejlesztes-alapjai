using GYAK_06_20240318_Teachers.Deliverables;

namespace GYAK_06_20240318_Teachers.Exceptions
{
    public class IncorrectOrientationException : DeliveryException
    {
        public IncorrectOrientationException(IDeliverable deliverable, string reason) : base(deliverable, reason)
        {
        }
    }
}