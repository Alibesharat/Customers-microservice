using Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AggregateGateway.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("All Get");
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string Email)
        {
            return Ok($" Get {Email}");
        }


        [HttpPost]
        public IActionResult Add([FromBody] Customer customer)
        {
            return Ok("Add Sucess");
        }


        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            return Ok("Update Sucess");
        }


    }
}
