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
    public class GetOrderbyIdQuery : IRequest<Order>
    {
        [Required]
        public int Order_Id { get;  set; }  
    }
}
