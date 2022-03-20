using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModel;

namespace LLM.Store.BAL.MappingProfile
{
    public class StoreCustomerMappingProfile : Profile
    {
        public StoreCustomerMappingProfile()
        {
            CreateMap<AddStoreCustomerInputViewModel, StoreCustomer>();
            CreateMap<StoreCustomer, AddStoreCustomerInputViewModel>();
            CreateMap<AddStoreCustomerResponseViewModel, StoreCustomer>();
            CreateMap<StoreCustomer, AddStoreCustomerResponseViewModel>();
            CreateMap<UpdateStoreCustomerResponseViewModel, StoreCustomer>();
            CreateMap<StoreCustomer, UpdateStoreCustomerResponseViewModel>();
            CreateMap<GetStoreCustomerResponseViewModel, StoreCustomer>();
            CreateMap<StoreCustomer, GetStoreCustomerResponseViewModel>();
            CreateMap<DeleteStoreCustomerResponseViewModel, StoreCustomer>();
            CreateMap<StoreCustomer, DeleteStoreCustomerResponseViewModel>();
            CreateMap<ListPaginationStoreCustomerViewModel, StoreCustomer>();
            CreateMap<StoreCustomer, ListPaginationStoreCustomerViewModel>();


        }
    }
}
