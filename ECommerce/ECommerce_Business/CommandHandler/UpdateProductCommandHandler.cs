using ECommerce_Business.Command;
using Ecommerce_Domain.IRepository;
using Ecommerce_Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.CommandHandler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResponseMessage>
    {
        readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;  
        }
        public async Task<ResponseMessage> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
            var producttobeupdated = await _productRepository.GetProductbyId(request.Prod_Id);
            if (producttobeupdated != null) 
            {
                producttobeupdated.SetProduct(request.Product_Name,request.Prod_Cost);
                _productRepository.UpdateProduct(producttobeupdated); 
                message.Message = "Product Updated sucessfully"; 
                return message;

            }

            message.Message = "Product Updatation failed"; 
            return message; 
            
        }
    }
}
