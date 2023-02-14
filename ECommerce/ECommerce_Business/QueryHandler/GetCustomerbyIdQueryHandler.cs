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
    public class GetCustomerbyIdQueryHandler : IRequestHandler<GetCustomerbyIdQuery, Customer> 
    {
        readonly ICustomerRepository _customerRepository;
        public GetCustomerbyIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository=customerRepository;
        }
        public async Task<Customer> Handle(GetCustomerbyIdQuery request, CancellationToken cancellationToken)
        {
           var customer= await _customerRepository.GetCustomerbyId(request.Customer_Id); 
            return customer; 
        }
    }
}
