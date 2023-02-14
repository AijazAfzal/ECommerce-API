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
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand,ResponseMessage> 
    {
        readonly ICustomerRepository _customerRepository;
        public AddCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public async Task<ResponseMessage> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var message=new ResponseMessage(); 
            var newcustomer = new Customer().SetCustomer(request.Customer_Name,request.Customer_Email,request.Customer_City);  
             var customer=await _customerRepository.AddCustomer(newcustomer);
            if (customer!= null)
            {
                message.Message = "New Customer added sucessfully"; 
                return message;
                
            }
            message.Message = "Failed to add Customer"; 
            return message;  

        }
    }
}
