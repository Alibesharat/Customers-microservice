using Entites;

namespace Events
{
    public class CustomerCreated : IEvent
    {
        public string Email { get; set; }

        public Address Address { get; set; }


    }
}
