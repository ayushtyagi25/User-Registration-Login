using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Dal
{
    public interface ICustomerData
    {
        Task<Customer> AddCustomer(Customer entity);
        Task<Customer> UpdateCustomer(Customer tblcustomer);
        Task<Customer> DeleteCustomer(int CustomerId);
        Task<List<Customer>> ListCustomer();
        Task<Customer> GetCustomer(int customerId);
        Task<List<Customer>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int CustomerId, int OperatorId, string Name);
        //  Task<CreateResponseViewModel> CreateCustomer(CreateRequestViewModel entity);
        Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock);
        Task<LoginAuthentication> LoginUser(LoginAuthentication entity);
        }
}
