using LLM.Store.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
   public interface IPaymentRepo
    {
        Task<AddPaymentResponseViewModel> AddPayment(PaymentViewModel entity);
        Task<DeletePaymentResponseViewModel> DeletePayment(PaymentViewModel entity);
        Task<UpdatePaymentResponseViewModel> UpdatePayment(PaymentViewModel entity);
        Task<GetPaymentResponseViewModel> GetPayment(int storeId);
        Task<List<GetPaymentResponseViewModel>> PaymentList();
        Task<List<GetPaymentResponseViewModel>> ListPagignationPayment(int pageIndex, int pageSize);
        Task<List<GetPaymentResponseViewModel>> ListFilterPaginationPayment(int pageIndex, int pageSize, ListPaymentPaginationViewModel entity);
    }
}
