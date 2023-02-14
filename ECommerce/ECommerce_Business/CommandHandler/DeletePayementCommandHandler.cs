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
    public class DeletePayementCommandHandler : IRequestHandler<DeleteOrderCommand, ResponseMessage>
    {
        readonly IPaymentRepository _paymentRepository;
        public DeletePayementCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<ResponseMessage> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var message=new ResponseMessage();
            await _paymentRepository.DeletePayement(request.Order_Id);
            message.Message = "Payement deleted sucessfully";
            return message; 

            
            

        }
    }
}
