using ECommerce_Business.Command;
using ECommerce_Business.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
 
    [ApiController]
    [Route("api/product")] 
    public class ProductController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<ProductController> _logger;
        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger; 

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand  addProductCommand)
        {
            try
            {
                var product = await _mediator.Send(addProductCommand); 
                return Ok(product); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(AddProduct)); 
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var list = await _mediator.Send(new GetProductListQuery());  
                return Ok(list);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetProducts)); 
                throw;
            }

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductbyId([FromRoute] int Id) 
        {
            try
            {
                var product = await _mediator.Send(new GetProductbyIdQuery { Prod_Id = Id }); 
                return Ok(product); 

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(GetProductbyId));
                throw;
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            try
            {
                var product = await _mediator.Send(updateProductCommand);  
                return Ok(product); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(UpdateProduct)); 
                throw;
            }


        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int Id)
        {
            try
            {
                var product = await _mediator.Send(new DeleteProductCommand { Prod_Id = Id }); 
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {{0}}", nameof(DeleteProduct)); 
                throw;
            }

        }

    }
}
