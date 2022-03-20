using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly IPaymentData _paymentData;
        private readonly IMapper _mapper;

        public PaymentRepo(IPaymentData paymentData, IMapper mapper)
        {
            _paymentData = paymentData;
            _mapper = mapper;
        }

        public async Task<AddPaymentResponseViewModel> AddPayment(PaymentViewModel entity)
        {
            Payment obj = await _paymentData.AddPayment(_mapper.Map<Payment>(entity));
            return _mapper.Map<AddPaymentResponseViewModel>(obj);
        }

        public async Task<DeletePaymentResponseViewModel> DeletePayment(PaymentViewModel entity)
        {
            Payment obj = await _paymentData.DeletePayment(_mapper.Map<Payment>(entity));
            return _mapper.Map<DeletePaymentResponseViewModel>(obj);
        }
        public async Task<UpdatePaymentResponseViewModel> UpdatePayment(PaymentViewModel entity)
        {
            Payment obj = await _paymentData.UpdatePayment(_mapper.Map<Payment>(entity));
            return _mapper.Map<UpdatePaymentResponseViewModel>(obj);
        }

        public async Task<GetPaymentResponseViewModel> GetPayment(int StoreId)
        {
            Payment obj = await _paymentData.GetPayment(StoreId);
            return _mapper.Map<GetPaymentResponseViewModel>(obj);
        }
        public async Task<List<GetPaymentResponseViewModel>> PaymentList()
        {
            List<Payment> obj = await _paymentData.PaymentList();
            return _mapper.Map<List<GetPaymentResponseViewModel>>(obj);
        }
        public async Task<List<GetPaymentResponseViewModel>> ListPagignationPayment(int pageIndex, int pageSize)
        {
            List<Payment> obj = await _paymentData.ListPagignationPayment(pageIndex, pageSize);
            return (_mapper.Map<List<GetPaymentResponseViewModel>>(obj));
        }
        public async Task<List<GetPaymentResponseViewModel>> ListFilterPaginationPayment(int pageIndex, int pageSize, ListPaymentPaginationViewModel entity)

        {
            List<Payment> obj = await _paymentData.ListFilterPaginationPayment(pageIndex, pageSize, (_mapper.Map<Payment>(entity)));
            return (_mapper.Map<List<GetPaymentResponseViewModel>>(obj));
        }

        public Task<List<GetPaymentResponseViewModel>> ListFilterPaginationPayment(int pageIndex, int pageSize, PaymentViewModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
