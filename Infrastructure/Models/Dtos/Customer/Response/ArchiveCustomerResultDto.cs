﻿using System.Runtime.Serialization;

namespace Models.Dtos
{
    [DataContract]
    public class ArchiveCustomerResultDto 
    {
        [DataMember(Order =1)]
        public bool IsSuccess { get; set; }

        [DataMember(Order=2)]

        public string Message { get; set; }
    }
}
