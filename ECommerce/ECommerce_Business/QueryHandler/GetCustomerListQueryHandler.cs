using ECommerce_Business.Query;
using Ecommerce_Domain.Domain;
using Ecommerce_Domain.IRepository;
using Ecommerce_Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.QueryHandler
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery,IList<Customer>>
    {
        readonly ICustomerRepository _customerRepository;
        public GetCustomerListQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IList<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
           
           return await _customerRepository.GetCustomers(); 
           
        }
    }
}
