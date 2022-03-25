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
    public class OrderController : ControllerBase
    {


        private readonly ILogger<OrderController> _logger;
        private readonly IMessageSender _sender;
        IOrderService _OrderService;

        public OrderController(ILogger<OrderController> logger, IMessageSender sender, IGrpcBaseChannel grpcBaseChannel)
        {

            _logger = logger;
            _sender = sender;
            _OrderService = grpcBaseChannel.GetOrderService();
        }


       



        [HttpPut]
        public async Task<IActionResult> SetOder([FromBody] OrderCompleteRequestDto dto)
        {
            //await _sender.SendMessageToCustomerTopic(customer.Email, customer);
            //return Ok("Add Sucess");

            var result = await _OrderService.OrderComplete(dto);
            return result.IsSuccess ? Ok() : BadRequest(result.Message);
        }


       

       


    }

}

