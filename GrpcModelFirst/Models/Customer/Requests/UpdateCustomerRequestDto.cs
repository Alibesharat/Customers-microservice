using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]

    public class UpdateCustomerAddressRequestDto
    {
        [DataMember(Order = 1)]
        public string Email { get; set; }

        [DataMember(Order = 2)]
        public Address Address { get; set; }
    }
}
