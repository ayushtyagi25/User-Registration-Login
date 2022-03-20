using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;

namespace LLM.Store.BAL.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerViewModel , Customer>();
            CreateMap<Customer, AddCustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<UpdateCustomerViewModel, Customer>();
            CreateMap<Customer, UpdateCustomerViewModel>();
            CreateMap<DeleteCustomerViewModel, Customer>();
            CreateMap<Customer, DeleteCustomerViewModel>();
            CreateMap<GetCustomerViewModel, Customer>();
            CreateMap<Customer, GetCustomerViewModel>();
            CreateMap<ListCustomerPaginationViewModel, Customer>();
            CreateMap<Customer, ListCustomerPaginationViewModel>();
            CreateMap<UpdateRequestViewModel, Customer>();
            CreateMap<MailRequest, MailSettings>();
            CreateMap<MailSettings, MailRequest>();
            CreateMap<WelcomeRequest, MailSettings>();
            CreateMap<MailSettings, WelcomeRequest>();

        }
    }
}
