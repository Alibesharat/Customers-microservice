using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]
    public class CreateCustomerResultDto
    {
        [DataMember(Order = 1)]
        public BaseResult BaseResult { get; set; }
    }
}
