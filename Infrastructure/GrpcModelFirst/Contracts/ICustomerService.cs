using GrpcModelFirst.Models;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GrpcModelFirst
{
    [ServiceContract]

    public interface ICustomerService
    {
        [OperationContract]
        Task<GetCustomerResultDto> GetCustomer(GetCustomerRequestDto dto);


        [OperationContract]

        Task<CreateCustomerResultDto> CreateCustomer(CreatCustomerRequestDto dto);

        [OperationContract]

        Task<AchiveCustomerResultDto> ArchiveCustomer(ArchiveCustomerRequestDto dto);

        [OperationContract]

        Task<UpdateCustomerAddressResultDto> UpdateCustomerAdress(UpdateCustomerAddressRequestDto dto);
    
    
    
    
    }
}
