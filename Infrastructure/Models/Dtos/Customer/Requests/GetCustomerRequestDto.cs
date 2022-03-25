using System.Runtime.Serialization;

namespace Models.Dtos
{
    [DataContract]
    public class GetCustomerRequestDto
    {
        [DataMember(Order = 1)]
        public string Email { get; set; }
    }
}
