using Entites;
using Events;
using GrpcModelFirst;
using GrpcModelFirst.Models;
using MessageBroker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AggregateGateway.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {


        private readonly ILogger<CustomerController> _logger;
        private readonly IMessageSender _sender;
        ICustomerService customerService;

        public CustomerController(ILogger<CustomerController> logger, IMessageSender sender, IGrpcBaseChannel grpcBaseChannel)
        {

            _logger = logger;
            _sender = sender;
            customerService = grpcBaseChannel.GetCustomerService();
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomerRequestDto dto)
        {
            var result = await customerService.GetCustomer(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatCustomerRequestDto customer)
        {
            //await _sender.SendMessageToCustomerTopic(customer.Email, customer);
            //return Ok("Add Sucess");

            var result = await customerService.CreateCustomer(customer);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] UpdateCustomerAddressRequestDto address)
        {
            var result = await customerService.UpdateCustomerAdress(address);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }


        [HttpPut(nameof(OrderCompleted))]
        public async Task<IActionResult> ArchiveCustomer([FromBody] ArchiveCustomerRequestDto dto)
        {
            var result = await customerService.ArchiveCustomer(dto);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }


    }

}

