using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrpcModelFirst.Models
{
    [DataContract]
    public class AchiveCustomerResultDto 
    {
        [DataMember(Order =1)]
        public bool IsSuccess { get; set; }

        [DataMember(Order=2)]

        public string Message { get; set; }
    }
}
