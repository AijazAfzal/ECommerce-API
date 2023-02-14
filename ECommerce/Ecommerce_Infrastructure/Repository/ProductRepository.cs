using Ecommerce_Domain.Domain;
using Ecommerce_Domain.IRepository;
using Ecommerce_Infrastructure.ECommerce_DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly EcommerceDbContext _ecommerceDbContext;
        public ProductRepository(EcommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;
        }

        public async Task<int> AddProduct(Product product)
        {
            await _ecommerceDbContext.Product.AddAsync(product);
            return await _ecommerceDbContext.SaveChangesAsync(); 

        }

        public async Task DeleteProduct(int Id)
        {
            var Producttobedeleted = await _ecommerceDbContext.Product.Where(x => x.Prod_Id == Id).FirstOrDefaultAsync(); ;
            _ecommerceDbContext.Product.Remove(Producttobedeleted);
            await _ecommerceDbContext.SaveChangesAsync(); 
        }

        public async Task<Product> GetProductbyId(int Id)
        {
            return await _ecommerceDbContext.Product.Where(x => x.Prod_Id == Id).FirstOrDefaultAsync(); 
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _ecommerceDbContext.Product.ToListAsync(); 
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _ecommerceDbContext.Product.Update(product);
            await _ecommerceDbContext.SaveChangesAsync();
            return product;  
        }
    }
}