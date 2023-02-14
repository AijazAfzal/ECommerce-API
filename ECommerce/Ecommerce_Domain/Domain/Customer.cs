using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.Domain
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; private set; }

        public string? Customer_Name { get;private set; } 

        public string? Customer_Email { get; private set; }

        public string? Customer_City { get; private set; } 

      

        public Customer SetCustomer(string Customername,string customeremail,string customercity)
        {
            Customer_Name= Customername;
            Customer_Email = customeremail; 
            Customer_City = customercity;  
            return this;
            
        }

        


    }
}
