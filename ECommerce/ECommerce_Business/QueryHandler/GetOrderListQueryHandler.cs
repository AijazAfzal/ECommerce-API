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
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IList<Order>>
    {
        readonly IOrderRepository _orderRepository;
        public GetOrderListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository= orderRepository; 

        }
        public async Task<IList<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
           return await  _orderRepository.GetOrders(); 
        }
    }
}
