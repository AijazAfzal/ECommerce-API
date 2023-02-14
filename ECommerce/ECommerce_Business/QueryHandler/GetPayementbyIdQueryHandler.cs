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
    public class GetPayementbyIdQueryHandler : IRequestHandler<GetPayementbyIdQuery, Payement>
    {
        readonly IPaymentRepository _paymentRepository;
        public GetPayementbyIdQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;  

        }
        public async Task<Payement> Handle(GetPayementbyIdQuery request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetPayementbyId(request.Payment_Id); 
            
        }
    }
}
