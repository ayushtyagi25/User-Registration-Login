using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ICustomerData _customerData;
        private readonly IMapper _mapper;
        public CustomerRepo(ICustomerData customerData, IMapper mapper)
        {
            _customerData = customerData;
            _mapper = mapper;
        }
        public async Task<AddCustomerViewModel> AddCustomer(CustomerViewModel entity)
        {
            Customer obj = await _customerData.AddCustomer(_mapper.Map<Customer>(entity));
            return _mapper.Map<AddCustomerViewModel>(obj);
        }
        public async Task<UpdateCustomerViewModel> UpdateCustomer(UpdateRequestViewModel entity)
        {
            Customer obj1 = await _customerData.UpdateCustomer(_mapper.Map<Customer>(entity));
            return _mapper.Map<UpdateCustomerViewModel>(obj1);
        }
        public async Task<DeleteCustomerViewModel> DeleteCustomer(int CustomerId)
        {
            Customer obj = await _customerData.DeleteCustomer(CustomerId);
            return _mapper.Map<DeleteCustomerViewModel>(obj);
        }
        public async Task<List<Customer>> ListCustomer()
        {
            return await _customerData.ListCustomer();
        }
        public async Task<GetCustomerViewModel> GetCustomer(int CustomerId)
        {
            Customer obj = await _customerData.GetCustomer(CustomerId);
            return _mapper.Map<GetCustomerViewModel>(obj);
        }
       
        public async Task<List<ListCustomerPaginationViewModel>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int CustomerId, int OperatorId, string Name)
        {
            List<Customer> obj = await _customerData.ListPaginationFilterStoreCustomer(pageIndex, pageSize, CustomerId, OperatorId,Name);
            return _mapper.Map<List<ListCustomerPaginationViewModel>>(obj);
            
        }
        //public async Task<CreateResponseViewModel> CreateCustomer(CreateRequestViewModel entity)
        //{
        //    Customer obj = await _customerData.AddCustomer(_mapper.Map<Customer>(entity));
        //    return _mapper.Map<CreateResponseViewModel>(obj);
        //}

        public async Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock)
        {
            return await _customerData.CreateUser(entity,CreatedIP,LoginFailedCount,IsUserBlock);

        }
        public async Task<LoginAuthentication> LoginUser(LoginAuthentication entity)
        {
            return await _customerData.LoginUser(entity);

        }
    }
}
