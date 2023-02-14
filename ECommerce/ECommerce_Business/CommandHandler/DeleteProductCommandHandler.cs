using ECommerce_Business.Command;
using Ecommerce_Domain.IRepository;
using Ecommerce_Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.CommandHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseMessage>
    {
        readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository; 

        }
        public async Task<ResponseMessage> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
            await _productRepository.DeleteProduct(request.Prod_Id);
            message.Message = "Product deleted sucessfully"; 
            return message;

        }
    }
}
