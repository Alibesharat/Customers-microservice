using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]
    public class OrderCompleteRequestDto
    {
        [DataMember(Order = 1)]
        public string Email { get; set; }
    }
}
