﻿using GrpcModelFirst.Contracts;
using GrpcModelFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerServiceApp.Impelimentions
{
    public class CustomerService : ICustomerService
    {
        public Task<AchiveCustomerResultDto> ArchiveCustomer(ArchiveCustomerRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CreateCustomerResultDto> CreateCustomer(CreatCustomerRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateCustomerAddressResultDto> UpdateCustomerAdress(UpdateCustomerAddressRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}