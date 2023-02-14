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
    public class AddPayementCommandHandler : IRequestHandler<AddPayementCommand, ResponseMessage>
    {
        readonly IPaymentRepository _paymentRepository;
        public AddPayementCommandHandler(IPaymentRepository paymentRepository) 
        {
            _paymentRepository=paymentRepository; 
        }
        public async Task<ResponseMessage> Handle(AddPayementCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message=new ResponseMessage();
            var newpayement = new Payement().SetPayement(request.Payment_Amount,request.Payment_Date,request.Order_Id);
            await _paymentRepository.AddPayement(newpayement);
            message.Message = "Payment Added sucessfully"; 
            return message; 
        }
    }
}
