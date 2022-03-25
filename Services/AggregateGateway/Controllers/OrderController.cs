using GrpcModelFirst;
using GrpcModelFirst.Models;
using MessageBroker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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




        /// <summary>
        ///  Complete Order
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPut]
        public IActionResult SetOder([FromBody] OrderCompleteRequestDto dto)
        {
            //await _sender.SendMessageToCustomerTopic(customer.Email, customer);
            //return Ok("Add Sucess");

            _OrderService.OrderComplete(dto);
            return Ok("Mesage Will be sending");
        }







    }

}

