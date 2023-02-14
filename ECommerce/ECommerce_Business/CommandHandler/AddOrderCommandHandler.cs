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
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, ResponseMessage>
    {
        readonly IOrderRepository _orderRepository;
        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseMessage> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
            var neworder = new Order().SetOrder(request.Order_Date,request.Order_Status,request.Customer_Id,request.Prod_Id); 
            await _orderRepository.AddOrder(neworder);
            message.Message = "Order added sucessfully"; 
            return message; 
            
        }
    }
}
