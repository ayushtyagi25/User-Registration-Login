using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LLM.Store.BAL
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ITransactionData _transactionData;
        private readonly IMapper _mapper;
        public TransactionRepo(ITransactionData transactionData, IMapper mapper)
        {
            _transactionData = transactionData;
            _mapper = mapper;
        }
        public async Task<AddTransactionResponseViewModel> AddTransaction(TransactionViewModel entity)
        {
            Transaction obj = await _transactionData.AddTransaction(_mapper.Map<Transaction>(entity));
            return (_mapper.Map<AddTransactionResponseViewModel>(obj));
        }

        public async Task<DeleteTransactionResponseViewModel> DeleteTransaction(TransactionViewModel entity)
        {
            Transaction obj = await _transactionData.DeleteTransaction(_mapper.Map<Transaction>(entity));
            return (_mapper.Map<DeleteTransactionResponseViewModel>(obj));
        }

        public async Task<GetTransactionResponseViewModel> GetTransaction(int TransactionId)
        {
            Transaction obj = await _transactionData.GetTransaction(TransactionId);
            return (_mapper.Map<GetTransactionResponseViewModel>(obj));
        }

        public async Task<List<GetTransactionResponseViewModel>> TransactionList()
        {
            List<Transaction> obj = await _transactionData.TransactionList();
            return (_mapper.Map<List<GetTransactionResponseViewModel>>(obj));
        }

        public async Task<UpdateTransactionResponseViewModel> UpdateTransaction(TransactionViewModel entity)
        {
            Transaction obj = await _transactionData.UpdateTransaction(_mapper.Map<Transaction>(entity));
            return (_mapper.Map<UpdateTransactionResponseViewModel>(obj));
        }

        public async Task<List<GetTransactionResponseViewModel>> ListPaginationTransaction(int pageIndex, int pageSize)
        {
            List<Transaction> obj = await _transactionData.ListPaginationTransaction(pageIndex, pageSize);
            return (_mapper.Map<List<GetTransactionResponseViewModel>>(obj));
        }

        public async Task<List<GetTransactionResponseViewModel>> ListFilterPaginationTransaction(int pageIndex, int pageSize, GetRequestViewModel entity)
        {
            List<Transaction> obj = await _transactionData.ListFilterPaginationTransaction(pageIndex, pageSize,(_mapper.Map<Transaction>(entity)));
            return (_mapper.Map<List<GetTransactionResponseViewModel>>(obj));
        }
    }
}
