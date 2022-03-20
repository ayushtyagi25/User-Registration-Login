using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentController(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentViewModel entity)
        {
            AddPaymentResponseViewModel objStore = await _paymentRepo.AddPayment(entity);
            return Ok(objStore);
        }
        [HttpGet("GetPayment")]
        public async Task<IActionResult> GetPayment(int StoreId)
        {
            GetPaymentResponseViewModel objStore = await _paymentRepo.GetPayment(StoreId);
            return Ok(objStore);
        }
        [HttpDelete("DeletePayment")]
        public async Task<IActionResult> DeletePayment([FromBody] PaymentViewModel entity)
        {
            DeletePaymentResponseViewModel objStore = await _paymentRepo.DeletePayment(entity);
            return Ok(objStore);
        }
        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentViewModel entity)
        {
            UpdatePaymentResponseViewModel objStore = await _paymentRepo.UpdatePayment(entity);
            return Ok(objStore);
        }
        [HttpGet("PaymentList")]
        public async Task<IActionResult> PaymentList()
        {
            List<GetPaymentResponseViewModel> objStore = await _paymentRepo.PaymentList();
            return Ok(objStore);
        }
        [HttpGet("ListPagignationPayment")]
        public async Task<IActionResult> ListPagignationPayment(int PageIndex, int PageSize)
        {
            List<GetPaymentResponseViewModel> objStore = await _paymentRepo.ListPagignationPayment(PageIndex, PageSize);
            return Ok(objStore);
        }
        [HttpGet("ListFilterPaginationPayment")]
        public async Task<IActionResult> ListFilterPaginationPayment([FromQuery]int PageIndex,[FromQuery] int PageSize,[FromQuery] ListPaymentPaginationViewModel entity)
        {
            List<GetPaymentResponseViewModel> objStore = await _paymentRepo.ListFilterPaginationPayment(PageIndex, PageSize,(entity));
            return Ok(objStore);
        }
    }
}