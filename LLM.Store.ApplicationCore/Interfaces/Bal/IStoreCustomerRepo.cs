using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface IStoreCustomerRepo
    {
        Task<AddStoreCustomerResponseViewModel> AddStoreCustomer(AddStoreCustomerInputViewModel entity);
        Task<UpdateStoreCustomerResponseViewModel> UpdateStoreCustomer(int StoreCustomerId);
        Task<List<StoreCustomer>> ListStoreCustomer();
        Task<GetStoreCustomerResponseViewModel> GetStoreCustomer(int StoreCustomerId);
        Task<DeleteStoreCustomerResponseViewModel> DeleteStoreCustomer(int StoreCustomerId);
        Task<List<GetStoreCustomerResponseViewModel>> ListPaginationStoreCustomer(int pageIndex, int pageSize);
        Task<List<ListPaginationStoreCustomerViewModel>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int StoreCustomerId, string Name, string ContactNo, string FlatNo, string Block);

    }
}
