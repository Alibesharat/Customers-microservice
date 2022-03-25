using GrpcModelFirst;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using System.Threading.Tasks;
using Validators;

namespace AggregateGateway.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {


        ICustomerService customerService;
        ICustomeValidator _Validator;

        public CustomerController(IGrpcBaseChannel grpcBaseChannel, ICustomeValidator validator)
        {

            customerService = grpcBaseChannel.GetCustomerService();
            _Validator = validator;
        }

        /// <summary>
        /// Get the Customer By Email
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomerRequestDto dto)
        {
            var validate = _Validator.ValidateGetCustomer(dto);
            if (validate.IsValid)
            {
                var result = await customerService.GetCustomer(dto);
                return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
            }
            return BadRequest(validate.Errors);

        }


        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerRequestDto dto)
        {
            var validate = _Validator.ValidateCreateCustomer(dto);
            if (validate.IsValid)
            {
                var result = await customerService.CreateCustomer(dto);
                return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
            }
            return BadRequest(validate.Errors);

        }


        /// <summary>
        /// Update Address of Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateCustomerAddressRequestDto dto)
        {
            var validate = _Validator.ValidateUpdateCustomer(dto);
            if (validate.IsValid)
            {
                var result = await customerService.UpdateCustomerAdress(dto);
                return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
            }
            return BadRequest(validate.Errors);


        }


        /// <summary>
        /// Archive Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut(nameof(ArchiveCustomer))]
        public async Task<IActionResult> ArchiveCustomer([FromBody] ArchiveCustomerRequestDto dto)
        {
            var validate = _Validator.ValidateArchiveCustomer(dto);
            if (validate.IsValid)
            {
                var result = await customerService.ArchiveCustomer(dto);
                return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
            }
            return BadRequest(validate.Errors);


        }


    }

}

