using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{
    public class StoreCustomerRepo : IStoreCustomerRepo
    {
        private readonly IStoreCustomerData _StoreCustomerData;
        private readonly IMapper _mapper;
        public StoreCustomerRepo(IStoreCustomerData StoreCustomerData, IMapper mapper)
        {
            _StoreCustomerData = StoreCustomerData;
            _mapper = mapper;
        }
        public async Task<AddStoreCustomerResponseViewModel> AddStoreCustomer(AddStoreCustomerInputViewModel entity)
        {
            StoreCustomer obj = await _StoreCustomerData.AddStoreCustomer(_mapper.Map<StoreCustomer>(entity));
            return _mapper.Map<AddStoreCustomerResponseViewModel>(obj);

        }
        public async Task<UpdateStoreCustomerResponseViewModel> UpdateStoreCustomer(int StoreCustomerId)
        {
            StoreCustomer obj = await _StoreCustomerData.UpdateStoreCustomer(StoreCustomerId);
            return _mapper.Map<UpdateStoreCustomerResponseViewModel>(obj);

        }
        public async Task<GetStoreCustomerResponseViewModel> GetStoreCustomer(int StoreCustomerId)
        {
            StoreCustomer obj = await _StoreCustomerData.GetStoreCustomer(StoreCustomerId);
            return _mapper.Map<GetStoreCustomerResponseViewModel>(obj);

        }
        public async Task<DeleteStoreCustomerResponseViewModel> DeleteStoreCustomer(int StoreCustomerId)
        {
            StoreCustomer obj = await _StoreCustomerData.DeleteStoreCustomer(StoreCustomerId);
            return _mapper.Map<DeleteStoreCustomerResponseViewModel>(obj);

        }
        public async Task<List<StoreCustomer>> ListStoreCustomer()
        {

            return await _StoreCustomerData.ListStoreCustomer();


        }
        public async Task<List<GetStoreCustomerResponseViewModel>> ListPaginationStoreCustomer(int pageIndex, int pageSize)
        {

            List<StoreCustomer> obj = await _StoreCustomerData.ListPaginationStoreCustomer(pageIndex, pageSize);
            return _mapper.Map<List<GetStoreCustomerResponseViewModel>>(obj);
        }
        public async Task<List<ListPaginationStoreCustomerViewModel>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int StoreCustomerId, string Name, string ContactNo, string FlatNo, string Block)
        {
            List<StoreCustomer> obj = await _StoreCustomerData.ListPaginationFilterStoreCustomer(pageIndex, pageSize, StoreCustomerId, Name, ContactNo, FlatNo, Block);
            return _mapper.Map<List<ListPaginationStoreCustomerViewModel>>(obj);

        }
    }
}

