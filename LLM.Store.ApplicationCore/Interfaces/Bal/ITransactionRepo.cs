using LLM.Store.ApplicationCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface ITransactionRepo
    {
        Task<AddTransactionResponseViewModel> AddTransaction(TransactionViewModel entity);
        Task<UpdateTransactionResponseViewModel> UpdateTransaction(TransactionViewModel entity);
        Task<GetTransactionResponseViewModel> GetTransaction(int TransactionId);
        Task<DeleteTransactionResponseViewModel> DeleteTransaction(TransactionViewModel entity);
        Task<List<GetTransactionResponseViewModel>> TransactionList();
        Task<List<GetTransactionResponseViewModel>> ListPaginationTransaction(int pageIndex, int pageSize);
        Task<List<GetTransactionResponseViewModel>> ListFilterPaginationTransaction(int pageIndex, int pageSize, GetRequestViewModel entity);
    }
}
