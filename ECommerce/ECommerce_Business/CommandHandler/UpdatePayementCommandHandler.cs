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
    public class UpdatePayementCommandHandler : IRequestHandler<UpdatePayementCommand, ResponseMessage>
    {
        readonly IPaymentRepository _paymentRepository;
        public UpdatePayementCommandHandler(IPaymentRepository paymentRepository)
        {
             _paymentRepository = paymentRepository;
        }

        public async Task<ResponseMessage> Handle(UpdatePayementCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
            var payementtobeupdated = await _paymentRepository.GetPayementbyId(request.Payment_Id);
            if (payementtobeupdated != null)
            {
                payementtobeupdated.UpdatePayment(request.Payment_Amount, request.Payment_Date);
                _paymentRepository.UpdatePayment(payementtobeupdated);
                message.Message = "Payment updated sucessfully";
                return message; 
            }

            message.Message = "Payment updation failed";
            return message; 

           
        }
    }
}
