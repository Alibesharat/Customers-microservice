using Entites;

namespace Events
{
    public class AddressUpdated : IEvent
    {
        public Customer Customer { get; set; }
    }
}
