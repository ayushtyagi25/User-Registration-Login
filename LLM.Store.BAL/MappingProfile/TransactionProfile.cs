using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;


namespace LLM.Store.BAL.MappingProfile
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionViewModel, Transaction>();
            CreateMap<Transaction, TransactionViewModel>();
            CreateMap<Transaction, AddTransactionResponseViewModel>();
            CreateMap<AddTransactionResponseViewModel, Transaction>();
            CreateMap<Transaction, DeleteTransactionResponseViewModel>();
            CreateMap<DeleteTransactionResponseViewModel, Transaction>();
            CreateMap<Transaction, GetTransactionResponseViewModel>();
            CreateMap<GetTransactionResponseViewModel, Transaction>();
            CreateMap<Transaction, UpdateTransactionResponseViewModel>();
            CreateMap<UpdateTransactionResponseViewModel, Transaction>();
            CreateMap<GetRequestViewModel, Transaction>();
            CreateMap<Transaction, GetRequestViewModel>();
        }
            
    }
}
