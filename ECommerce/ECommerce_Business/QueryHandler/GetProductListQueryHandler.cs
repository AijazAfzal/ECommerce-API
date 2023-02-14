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
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IList<Product>>
    {
        readonly IProductRepository _productRepository;
        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        public async Task<IList<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts(); 
        }
    }
}
