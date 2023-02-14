using ECommerce_Business.Command;
using ECommerce_Business.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{

    [ApiController]
    [Route("api/Order")] 
    public class OrderController : ControllerBase 
    {
        readonly IMediator _mediator;
        readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]

        public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand addOrderCommand) 
        {
            try
            {
                var order = await _mediator.Send(addOrderCommand); 
                return Ok(order); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(AddOrder));  
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var list = await _mediator.Send(new GetOrderListQuery()); 
                return Ok(list);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetOrders)); 
                throw;
            }

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrderbyId([FromRoute] int Id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderbyIdQuery { Order_Id = Id });
                return Ok(order); 

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetOrderbyId)); 
                throw;
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand updateOrderCommand)
        {
            try
            {
                var order = await _mediator.Send(updateOrderCommand); 
                return Ok(order); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(UpdateOrder));
                throw;
            }


        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int Id)
        {
            try
            {
                var order = await _mediator.Send(new DeleteOrderCommand { Order_Id = Id }); 
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(DeleteOrder));
                throw;
            }

        }
    }
}
