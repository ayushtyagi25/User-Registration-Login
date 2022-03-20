using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;

namespace LLM.Store.BAL.MappingProfile
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentViewModel, Payment>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<AddPaymentResponseViewModel, Payment>();
            CreateMap<Payment, AddPaymentResponseViewModel>();
            CreateMap<GetPaymentResponseViewModel, Payment>();
            CreateMap<Payment, GetPaymentResponseViewModel>();
            CreateMap<DeletePaymentResponseViewModel, Payment>();
            CreateMap<Payment, DeletePaymentResponseViewModel>();
            CreateMap<UpdatePaymentResponseViewModel, Payment>();
            CreateMap<Payment, UpdatePaymentResponseViewModel>();
            CreateMap<Payment, ListPaymentPaginationViewModel>();
            CreateMap<ListPaymentPaginationViewModel, Payment>();
        }

    }
}
