using GYAK_06_20240318_Teachers.Deliverables;

namespace GYAK_06_20240318_Teachers.Exceptions
{
    public class DeliveryException : Exception
    {
        public IDeliverable FaultyDeliverable { get; }

        public DeliveryException(IDeliverable deliverable, string reason) : base(reason)
        {
            FaultyDeliverable = deliverable;
        }
    }
}