using GrpcModelFirst;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Validators;

namespace AggregateGateway.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {


        IOrderService _OrderService;
        ICustomeValidator _Validator;

        public OrderController( IGrpcBaseChannel grpcBaseChannel, ICustomeValidator validator)
        {
            _OrderService = grpcBaseChannel.GetOrderService();
            _Validator = validator;
        }




        /// <summary>
        ///  Complete Order
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPut]
        public IActionResult SetOder([FromBody] OrderCompleteRequestDto dto)
        {
            var validate = _Validator.ValidateOrderCompleted(dto);
            if (validate.IsValid)
            {
                _OrderService.OrderComplete(dto);
                return Ok("Mesage Will be sending");
            }
         
            return BadRequest(validate.Errors);

        }







    }

}

