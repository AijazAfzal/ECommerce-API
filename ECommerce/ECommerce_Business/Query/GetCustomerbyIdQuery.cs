using Ecommerce_Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Query
{
    public class GetCustomerbyIdQuery : IRequest<Customer>
    {
        [Required]
        public int Customer_Id { get; set; }   
    }
}
