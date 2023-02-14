using Ecommerce_Domain.Domain;
using Ecommerce_Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Command
{
    public class AddCustomerCommand : IRequest<ResponseMessage>     
    {
        [Required]
        public string? Customer_Name { get; set; }
        [Required]
        public string? Customer_Email { get; set; } 
        [Required]
        public string? Customer_City { get; set; } 
    }
}
