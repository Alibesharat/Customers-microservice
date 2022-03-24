using Entites;

namespace Events
{
    public class AddressUpdated : Event
    {
        public Customer Customer { get; set; }
    }
}
