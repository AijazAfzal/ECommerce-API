using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.Domain
{
    public class Order
    {
        [Key]
        public int Order_Id { get; private set; }

        public DateTime Order_Date { get; private set; }

        public string? Order_Status { get; private set; }

        public int Customer_Id { get; private set; }
        [ForeignKey("Customer_Id")]

        public virtual Customer Customer { get; set; }

        public int Prod_Id { get; set; }
        [ForeignKey("Prod_Id")]

        public virtual Product Product { get; set; }

        public Order SetOrder(DateTime orderdate, string orderstatus, int customerId, int prodId)
        {
            Order_Date = orderdate;
            Order_Status = orderstatus;
            Customer_Id = customerId;
            Prod_Id = prodId;
            return this;

        }

        public Order UpdateOrder(DateTime orderdate, string orderstatus)
        {
            Order_Date = orderdate;
            Order_Status = orderstatus; 
            return this; 
        }



    }
}
