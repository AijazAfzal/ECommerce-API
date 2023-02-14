using ECommerce_Business.Command;
using ECommerce_Business.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
  
    [ApiController]
    [Route("api/payment")]  
    public class PaymentController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<PaymentController> _logger; 
        public PaymentController(IMediator mediator,ILogger<PaymentController> logger)
        {
            _mediator = mediator; 
            _logger= logger; 
        }
        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] AddPayementCommand addPayementCommand) 
            
        {
            try
            {
                var payement = await _mediator.Send(addPayementCommand); 
                return Ok(payement); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(AddPayment));  
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPayments() 
        {
            try
            {
                var list = await _mediator.Send(new GetPayementListQuery()); 
                return Ok(list);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetPayments)); 
                throw;
            }

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPaymentbyId([FromRoute] int Id)
        {
            try
            {
                var order = await _mediator.Send(new GetPayementbyIdQuery { Payment_Id = Id }); 
                return Ok(order);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetPaymentbyId));
                throw;
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment(UpdatePayementCommand updatePayementCommand)
        {
            try
            {
                var order = await _mediator.Send(updatePayementCommand);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(UpdatePayment)); 
                throw;
            }


        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int Id)
        {
            try
            {
                var order = await _mediator.Send(new DeletePayementCommand { Payment_Id = Id });
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(DeletePayment)); 
                throw;
            }

        }
    }
}
