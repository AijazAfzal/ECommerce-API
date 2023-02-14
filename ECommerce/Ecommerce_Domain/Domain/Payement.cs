using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.Domain
{
    public class Payement
    {
        [Key]
        public int Payment_Id { get;private set; } 

        public float Payment_Amount { get; private set; }

        public DateTime Payment_Date { get; private set; } 

        public int Order_Id { get; private set; } 
        [ForeignKey("Order_Id")] 

        public virtual Order Order { get; set; } 

        public Payement SetPayement(float paymentamt,DateTime Paymentdate,int orderId)
        {
            Payment_Amount= paymentamt;
            Payment_Date = Paymentdate;  
            Order_Id= orderId;
            return this; 
            
        }

        public Payement UpdatePayment(float paymentamt, DateTime Paymentdate)
        {
            Payment_Amount = paymentamt;
            Payment_Date = Paymentdate;  
            return this; 
        }
    }
}
