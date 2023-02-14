using Ecommerce_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.IRepository
{
    public interface ICustomerRepository
    {
        Task<IList<Customer>> GetCustomers(); 

        Task<int> AddCustomer(Customer customer);

        Task<Customer> GetCustomerbyId(int Id);

        Task DeleteCustomer(int Id);   

        Task<Customer> UpdateCustomer(Customer customer); 
    }
}
