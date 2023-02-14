using Ecommerce_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Domain.IRepository
{
    public interface IPaymentRepository
    {
        Task<IList<Payement>> GetPayements();

        Task<int> AddPayement(Payement payement);

        Task<Payement> GetPayementbyId(int Id); 

        Task DeletePayement(int Id);

        Task<Payement> UpdatePayment(Payement payement);  
    }
}
