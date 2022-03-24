using Entites;
using Events;
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

        public CustomerController(ILogger<CustomerController> logger, IMessageSender sender)
        {

            _logger = logger;
            _sender = sender;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("All Get");
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerCreated customer)
        {
            await _sender.SendMessageToCustomerTopic(customer.Email, customer);
            return Ok("Add Sucess");

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] AddressUpdated address)
        {
            await _sender.SendMessageToCustomerTopic(address.Customer.Email, address);
            return Ok("Update Sucess");
        }


        [HttpPut(nameof(OrderCompleted))]
        public async Task<IActionResult> OrderCompleted([FromBody] OrderCompleted order)
        {
            await _sender.SendMessageToCustomerTopic(order.Email, order);
            return Ok("Update Sucess");
        }


    }

}

