using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]

    public class CreatCustomerRequestDto
    {

        [DataMember(Order = 1)]
        public string Email { get; set; }

        [DataMember(Order = 2)]
        public Address Address { get; set; }
    }

    [DataContract]
    public class Address
    {
        [DataMember(Order = 1)]
        public string Street { get; set; }

        [DataMember(Order = 2)]

        public string City { get; set; }

        [DataMember(Order = 3)]

        public string Country { get; set; }
    }
}
