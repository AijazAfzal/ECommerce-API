using Ecommerce_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.IRepository
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetOrders();

        Task<int> AddOrder(Order order);

        Task<Order> GetOrderbyId(int Id);  

        Task DeleteOrder(int Id);

        Task<Order> UpdateOrder(Order order); 
    }
}
