using ECommerce_Business.Command;
using ECommerce_Business.Query;
using Ecommerce_Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
  
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<CustomerController> _logger;
        public CustomerController(IMediator mediator,ILogger<CustomerController>logger)
        {
            _mediator = mediator;   
            _logger=logger; 

        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]AddCustomerCommand addCustomerCommand)
        {
            try { 
                  var customer= await _mediator.Send(addCustomerCommand); 
                   return Ok(customer);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(AddCustomer));  
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try 
            {
                var list = await _mediator.Send(new GetCustomerListQuery()); 
                return Ok(list); 
                
            }

            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetCustomers));  
                throw;
            }
            
        }
        [HttpGet("{Id}")] 
        public async Task<IActionResult> GetCustomerbyId([FromRoute]int Id) 
        {
            try
            {
                var customer = await _mediator.Send(new GetCustomerbyIdQuery { Customer_Id = Id}); 
                return Ok(customer);  

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetCustomerbyId));  
                throw; 
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand updateCustomerCommand) 
        {
            try 
            {
                var customer = await _mediator.Send(updateCustomerCommand); 
                return Ok(customer); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(UpdateCustomer)); 
                throw;
            }


        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int Id)
        {
            try 
            {
                var customer = await _mediator.Send(new  DeleteCustomerCommand {Customer_Id = Id });  
                return Ok(customer); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(DeleteCustomer)); 
                throw;
            }

        }

    }


}
