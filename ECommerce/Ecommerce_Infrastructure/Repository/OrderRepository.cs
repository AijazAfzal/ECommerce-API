using Ecommerce_Domain.Domain;
using Ecommerce_Domain.IRepository;
using Ecommerce_Infrastructure.ECommerce_DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        readonly EcommerceDbContext _ecommerceDbContext;
        public OrderRepository(EcommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;

        }
        public async Task<int> AddOrder(Order order)
        {
            await _ecommerceDbContext.Order.AddAsync(order); 
            return await _ecommerceDbContext.SaveChangesAsync(); 

            
        }

        public async Task DeleteOrder(int Id)
        {
            var ordertobedeleted =await  _ecommerceDbContext.Order.Where(x => x.Order_Id == Id).FirstOrDefaultAsync();
           _ecommerceDbContext.Order.Remove(ordertobedeleted);
            await _ecommerceDbContext.SaveChangesAsync();  
            
        }

        public async Task<Order> GetOrderbyId(int Id)
        {
           var order= await _ecommerceDbContext.Order.Where(x => x.Order_Id == Id).Include(x=>x.Customer).Include(x=>x.Product).FirstOrDefaultAsync(); 
            return order;
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _ecommerceDbContext.Order.Include(x=>x.Customer).Include(x=>x.Product).ToListAsync();  
            
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _ecommerceDbContext.Order.Update(order);
            await _ecommerceDbContext.SaveChangesAsync();  
            return order;

        }
    }
}
