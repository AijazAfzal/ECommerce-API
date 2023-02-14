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
    public class CustomerRepository : ICustomerRepository
    {
        readonly EcommerceDbContext _ecommerceDbContext;
        public CustomerRepository(EcommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext; 

        }

        public async Task<int> AddCustomer(Customer customer) 
        {
           await _ecommerceDbContext.Customer.AddAsync(customer);  
           return await  _ecommerceDbContext.SaveChangesAsync(); 
            

            
        }

        public async Task DeleteCustomer(int Id)
        {
            var customer = await _ecommerceDbContext.Customer.Where(x => x.Customer_Id == Id).FirstOrDefaultAsync();
           _ecommerceDbContext.Customer.Remove(customer);    
            await _ecommerceDbContext.SaveChangesAsync(); 
           
            
           
            
        }

        public async Task<Customer> GetCustomerbyId(int Id)
        {
           var customer= await _ecommerceDbContext.Customer.Where(x => x.Customer_Id == Id).FirstOrDefaultAsync();
            return customer; 
            
        }

         public async Task<IList<Customer>> GetCustomers()
         {
            return await  _ecommerceDbContext.Customer.ToListAsync();  
            
         }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
           _ecommerceDbContext.Customer.Update(customer);
             await _ecommerceDbContext.SaveChangesAsync(); 
            return customer; 
        }
    }
}
