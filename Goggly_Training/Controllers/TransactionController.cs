using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo _transactionRepo;
        public TransactionController(ITransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionViewModel entity)
        {
            AddTransactionResponseViewModel objUser = await _transactionRepo.AddTransaction(entity);
            return Ok(objUser);
        }
        [HttpPut("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionViewModel entity)
        {
            UpdateTransactionResponseViewModel objUser = await _transactionRepo.UpdateTransaction(entity);
            return Ok(objUser);
        }
        [HttpGet("GetTransaction")]
        public async Task<IActionResult> GetTransaction(int TransactionId)
        {
            GetTransactionResponseViewModel objUser = await _transactionRepo.GetTransaction(TransactionId);
            return Ok(objUser);
        }
        [HttpDelete("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransaction([FromBody] TransactionViewModel entity)
        {
            DeleteTransactionResponseViewModel objUser = await _transactionRepo.DeleteTransaction(entity);
            return Ok(objUser);
        }
        [HttpGet("TransactionList")]
        public async Task<IActionResult> TransactionList()
        {
            List<GetTransactionResponseViewModel> objUser = await _transactionRepo.TransactionList();
            return Ok(objUser);
        }
        [HttpGet("ListPaginationTransaction")]
        public async Task<IActionResult> ListPaginationTransaction([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            List<GetTransactionResponseViewModel> objUser = await _transactionRepo.ListPaginationTransaction(pageIndex, pageSize);
            return Ok(objUser);
        }
        [HttpGet("ListFilterPaginationTransaction")]
        public async Task<IActionResult> ListFilterPaginationTransaction([FromQuery] int PageIndex, [FromQuery] int PageSize,[FromQuery] GetRequestViewModel entity)
        {
            List<GetTransactionResponseViewModel> objUser = await _transactionRepo.ListFilterPaginationTransaction(PageIndex, PageSize,entity);
            return Ok(objUser);
        }
    }
}
