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
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseMessage>
    {
        readonly ICustomerRepository _customerRepository; 
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository; 

        }
        public async Task<ResponseMessage> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage();
           await _customerRepository.DeleteCustomer(request.Customer_Id);
           message.Message = "Record deleted sucessfully";  
           return message; 
            
                 

           
        }
    }
}
