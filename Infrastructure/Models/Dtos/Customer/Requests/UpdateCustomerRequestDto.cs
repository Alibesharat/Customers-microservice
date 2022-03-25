using System.Runtime.Serialization;

namespace Models.Dtos
{
    [DataContract]

    public class UpdateCustomerAddressRequestDto
    {
        public UpdateCustomerAddressRequestDto()
        {
            Address = new Address();
        }


        [DataMember(Order = 1)]
        public string Email { get; set; }

        [DataMember(Order = 2)]
        public Address Address { get; set; }
    }
}
