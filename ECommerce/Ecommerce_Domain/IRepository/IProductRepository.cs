using Ecommerce_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.IRepository
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProducts();

        Task<int> AddProduct(Product product);

        Task<Product> GetProductbyId(int Id);

        Task DeleteProduct(int Id);

        Task<Product> UpdateProduct(Product product);  
    }
}
