using ECommerce_Business.Query;
using Ecommerce_Domain.Domain;
using Ecommerce_Domain.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.QueryHandler
{
    public class GetProductbyIdQueryHandler : IRequestHandler<GetProductbyIdQuery, Product>
    {
        readonly IProductRepository _productRepository;
        public GetProductbyIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductbyId(request.Prod_Id); 
           
        }
    }
}
