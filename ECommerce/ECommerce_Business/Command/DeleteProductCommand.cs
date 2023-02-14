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
    public class DeleteProductCommand : IRequest<ResponseMessage>
    {
        [Required]
        public int Prod_Id { get;  set; } 
    }
}
