using LLM.Store.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LLM.Store.ApplicationCore.Interfaces.Dal
{
    public interface ITransactionData
    {
        Task<Transaction> AddTransaction(Transaction entity);
        Task<Transaction> UpdateTransaction(Transaction entity);
        Task<Transaction> GetTransaction(int TransactionId);
        Task<Transaction> DeleteTransaction(Transaction entity);
        Task<List<Transaction>> TransactionList();
        Task<List<Transaction>> ListPaginationTransaction(int pageIndex, int pageSize);
        Task<List<Transaction>> ListFilterPaginationTransaction(int pageIndex, int pageSize, Transaction entity);
    }
}
