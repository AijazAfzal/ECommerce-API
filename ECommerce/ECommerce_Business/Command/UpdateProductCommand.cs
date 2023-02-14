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
    public class UpdateProductCommand : IRequest<ResponseMessage>
    {
        [Required] 
        public int Prod_Id { get;  set; }
        [Required]
        public string? Product_Name { get; set; }
        [Required] 
        public double Prod_Cost { get;  set; }   

    }
}
