using LLM.Store.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Dal
{
   public interface IPaymentData 
    {
        Task<Payment> AddPayment(Payment entity);
        
        Task<Payment> DeletePayment(Payment entity);
        Task<Payment> UpdatePayment(Payment entity);
        Task<Payment> GetPayment(int storeId);
        Task<List<Payment>> PaymentList();
        Task<List<Payment>> ListPagignationPayment(int pageIndex, int pageSize);
        Task<List<Payment>> ListFilterPaginationPayment(int pageIndex, int pageSize,Payment entity);
    }
}
