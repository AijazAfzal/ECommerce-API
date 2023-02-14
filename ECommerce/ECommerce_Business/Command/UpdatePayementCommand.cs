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
    public class UpdatePayementCommand : IRequest<ResponseMessage> 
    {
        [Required]
        public int Payment_Id { get;  set; }
        [Required]
        public float Payment_Amount { get;  set; } 
        [Required] 
        public DateTime Payment_Date { get;  set; } 

        
    }
}
