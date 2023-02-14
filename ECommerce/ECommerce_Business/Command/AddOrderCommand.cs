using Ecommerce_Domain.Domain;
using Ecommerce_Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Command
{
    public class AddOrderCommand : IRequest<ResponseMessage>
    {
        [Required]
        public DateTime Order_Date { get;  set; }
        [Required]
        public string? Order_Status { get;  set; }
        [Required]
        public int Customer_Id { get;  set; }
        [Required] 
        public int Prod_Id { get; set; } 






    }
}
