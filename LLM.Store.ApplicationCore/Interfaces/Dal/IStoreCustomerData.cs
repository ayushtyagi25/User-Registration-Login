using LLM.Store.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Dal
{
    public interface IStoreCustomerData
    {
        Task<StoreCustomer> AddStoreCustomer(StoreCustomer entity);
        Task<StoreCustomer> UpdateStoreCustomer(int StoreCustomerId);
        Task<StoreCustomer> GetStoreCustomer(int StoreCustomerId);
        Task<StoreCustomer> DeleteStoreCustomer(int StoreCustomerId);
        Task<List<StoreCustomer>> ListStoreCustomer();
        Task<List<StoreCustomer>> ListPaginationStoreCustomer(int pageIndex, int pageSize);
        Task<List<StoreCustomer>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int StoreCustomerId, string Name, string ContactNo, string
            FlatNo, string Block);
    }
}
