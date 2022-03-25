using System;
using System.Runtime.Serialization;

namespace GrpcModelFirst.Models
{
    [DataContract]
    public class GetCustomerResultDto
    {

        [DataMember(Order = 1)]
        public string Email { get; set; }
        [DataMember(Order = 2)]

        public Address Address { get; set; }

        [DataMember(Order = 3)]
        //TODO :Must be UTC DateTime

        public DateTime CreatedAt { get; set; }

        [DataMember(Order = 4)]

        public bool IsArchived { get; set; }

        //TODO :Must be UTC DateTime
        [DataMember(Order = 5)]

        public DateTime PurchasedAt { get; set; }
    }
}
