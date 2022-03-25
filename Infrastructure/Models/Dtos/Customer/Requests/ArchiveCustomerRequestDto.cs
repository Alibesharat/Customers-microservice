using System.Runtime.Serialization;

namespace Models.Dtos
{
    [DataContract]
    public class ArchiveCustomerRequestDto
    {
        [DataMember(Order = 1)]
        public string Email { get; set; }
    }
}
