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
    public class PayementRepository : IPaymentRepository
    {
        readonly EcommerceDbContext _ecommerceDbContext;
        public PayementRepository(EcommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext= ecommerceDbContext; 

        }
        public async Task<int> AddPayement(Payement payement)
        {
            await _ecommerceDbContext.Payement.AddAsync(payement);
            return await  _ecommerceDbContext.SaveChangesAsync();  
          
        }

        public async Task DeletePayement(int Id)
        {
            var Payementtobedeleted = await _ecommerceDbContext.Payement.Where(x=>x.Payment_Id==Id).FirstOrDefaultAsync();
            _ecommerceDbContext.Payement.Remove(Payementtobedeleted); 
            await _ecommerceDbContext.SaveChangesAsync(); 
            
        }

        public async Task<Payement> GetPayementbyId(int Id)
        {
            return await _ecommerceDbContext.Payement.Where(x => x.Payment_Id == Id).Include(x=>x.Order).FirstOrDefaultAsync();   

        }

        public async Task<IList<Payement>> GetPayements()
        {
            return await _ecommerceDbContext.Payement.Include(x=>x.Order).ToListAsync();  
        }

   

        public async Task<Payement> UpdatePayment(Payement payement)
        {
            _ecommerceDbContext.Payement.Update(payement);
            await _ecommerceDbContext.SaveChangesAsync();  
            return payement; 
           
        }

        
    }
}
