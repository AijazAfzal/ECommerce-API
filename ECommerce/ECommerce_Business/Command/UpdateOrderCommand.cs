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
    public class UpdateOrderCommand : IRequest<ResponseMessage>
    {
        [Required]
        public int Order_Id { get;  set; }
        [Required]
        public DateTime Order_Date { get;  set; }
        [Required] 
        public string? Order_Status { get;  set; } 
    }
}
