using GrpcModelFirst.Models;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GrpcModelFirst
{
    [ServiceContract]

    public interface ICustomerService
    {

        Task<CreateCustomerResultDto> CreateCustomer(CreatCustomerRequestDto dto);

        Task<AchiveCustomerResultDto> ArchiveCustomer(ArchiveCustomerRequestDto dto);

        Task<UpdateCustomerAddressResultDto> UpdateCustomerAdress(UpdateCustomerAddressRequestDto dto);
    }
}
