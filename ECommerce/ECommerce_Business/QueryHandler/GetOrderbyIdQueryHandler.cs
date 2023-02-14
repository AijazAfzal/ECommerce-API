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
    public class GetOrderbyIdQueryHandler : IRequestHandler<GetOrderbyIdQuery, Order>
    {
        readonly IOrderRepository _orderRepository;
        public GetOrderbyIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository; 
        }
 
        public async Task<Order> Handle(GetOrderbyIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderbyId(request.Order_Id); 
           
        }
    }
}
