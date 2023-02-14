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
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ResponseMessage>
    {
        readonly IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseMessage> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
             await _orderRepository.DeleteOrder(request.Order_Id);
            message.Message = "Order deleted sucessfully"; 
            return message; 
        }
    }
}
