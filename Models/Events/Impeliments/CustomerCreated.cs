using Entites;

namespace Events
{
    public class CustomerCreated : Event
    {
        public string Email { get; set; }

        public Address Address { get; set; }


    }
}
