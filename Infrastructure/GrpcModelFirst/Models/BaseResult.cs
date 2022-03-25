using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]
    public class BaseResult
    {
        [DataMember(Order = 1)]
        public bool IsSuccess { get; set; }

        [DataMember(Order = 2)]

        public string Message { get; set; }
    }
}
