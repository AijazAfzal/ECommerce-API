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
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResponseMessage>
    {
        readonly ICustomerRepository _customerRepository;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ResponseMessage> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            ResponseMessage message = new ResponseMessage(); 
          var customertobeupdated= await  _customerRepository.GetCustomerbyId(request.Customer_Id);
         var value= customertobeupdated.SetCustomer(request.Customer_Name,request.Customer_Email,request.Customer_City);
          var updatedvalue=_customerRepository.UpdateCustomer(value);
            if (updatedvalue != null)
            {
                message.Message = "Record updated sucessfully";
                return message; 
            }
            return default; 
          



        }
    }
}
