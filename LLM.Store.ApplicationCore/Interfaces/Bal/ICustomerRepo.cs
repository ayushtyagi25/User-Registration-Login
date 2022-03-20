using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface ICustomerRepo
    {
        Task<AddCustomerViewModel> AddCustomer(CustomerViewModel entity);
        Task<UpdateCustomerViewModel> UpdateCustomer(UpdateRequestViewModel entity);
        Task<List<Customer>> ListCustomer();
        Task<GetCustomerViewModel> GetCustomer(int customerId);
        Task<DeleteCustomerViewModel> DeleteCustomer(int CustomerId);

        Task<List<ListCustomerPaginationViewModel>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int CustomerId, int OperatorId, string Name);
        // Task<CreateResponseViewModel> CreateCustomer(CreateRequestViewModel entity);
        Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock);
        Task<LoginAuthentication> LoginUser(LoginAuthentication entity );
    }
}
