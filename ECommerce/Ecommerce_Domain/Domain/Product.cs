using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.Domain
{
    public class Product
    {
        [Key]
        public int Prod_Id { get; private set; }

        public string? Product_Name { get; private set; }   

        public double Prod_Cost { get; private set; } 

        public Product SetProduct(string ProductName,double prodcost)
        {
            Product_Name= ProductName; 
            Prod_Cost= prodcost; 
            return this; 

            
        }
    }
}
