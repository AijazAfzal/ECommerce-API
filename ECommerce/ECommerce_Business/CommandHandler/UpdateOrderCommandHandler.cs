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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ResponseMessage>
    {
        readonly IOrderRepository _orderRepository;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseMessage> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage(); 
            var ordertobeupdated = await _orderRepository.GetOrderbyId(request.Order_Id);
            if (ordertobeupdated != null)
            {
              ordertobeupdated.UpdateOrder(request.Order_Date,request.Order_Status); 
                _orderRepository.UpdateOrder(ordertobeupdated); 
                message.Message = "Order updated sucessfully"; 
                return message;  
                     

            }
            message.Message = "Order updation failed";
            return message; 
        }
    }
}
