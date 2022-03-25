using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]
    public abstract class BaseResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]

        public string Message { get; set; }
    }
}
