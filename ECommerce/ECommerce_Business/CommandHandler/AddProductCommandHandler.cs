using ECommerce_Business.Command;
using Ecommerce_Domain.Domain;
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
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ResponseMessage>
    {
        readonly IProductRepository _productRepository; 
        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository= productRepository; 

        }
        public async Task<ResponseMessage> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
            var newproduct = new Product().SetProduct(request.Product_Name,request.Prod_Cost);
            await _productRepository.AddProduct(newproduct);
            message.Message = "Product added sucessfully";
            return message; 
        }
    }
}
