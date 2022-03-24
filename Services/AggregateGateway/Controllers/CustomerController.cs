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
            await _sender.SendMessageToCustomerTopic( customer.Email, customer);
            return Ok("Add Sucess");

        }


        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            return Ok("Update Sucess");
        }


    }
}
