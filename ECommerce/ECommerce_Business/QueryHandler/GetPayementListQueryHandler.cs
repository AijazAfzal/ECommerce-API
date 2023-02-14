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
    public class GetPayementListQueryHandler : IRequestHandler<GetPayementListQuery, IList<Payement>>
    {
        readonly IPaymentRepository _paymentRepository;
        public GetPayementListQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository; 

        }
        public async Task<IList<Payement>> Handle(GetPayementListQuery request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetPayements();
           
        }
    }
}
