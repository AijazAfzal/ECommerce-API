using Ecommerce_Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Infrastructure.ECommerce_DbContext
{
    public class EcommerceDbContext : DbContext 
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options):base(options)   
        {

        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; } 

        public DbSet<Payement> Payement { get; set; } 

        public DbSet<Product> Product { get; set; } 

    }
}
