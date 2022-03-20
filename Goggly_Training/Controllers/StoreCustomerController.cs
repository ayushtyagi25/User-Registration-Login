using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreCustomerController : Controller
    {
        private readonly IStoreCustomerRepo _StoreCustomerRepo;
        public StoreCustomerController(IStoreCustomerRepo StoreCustomerRepo)
        {
            _StoreCustomerRepo = StoreCustomerRepo;
        }

        [HttpPost("AddStoreCustomer")]
        public async Task<IActionResult> AddStoreCustomer([FromBody] AddStoreCustomerInputViewModel entity)
        {
            AddStoreCustomerResponseViewModel obj = await _StoreCustomerRepo.AddStoreCustomer(entity);
            return Ok(obj);
        }
        [HttpPut("UpdateStoreCustomer")]
        public async Task<IActionResult> UpdateStoreCustomer(int StoreCustomerId)
        {
            UpdateStoreCustomerResponseViewModel obj = await _StoreCustomerRepo.UpdateStoreCustomer(StoreCustomerId);
            return Ok(obj);
        }
        [HttpGet("GetStoreCustomer")]
        public async Task<IActionResult> GetStoreCustomer(int StoreCustomerId)
        {
            GetStoreCustomerResponseViewModel obj = await _StoreCustomerRepo.GetStoreCustomer(StoreCustomerId);
            return Ok(obj);
        }
        [HttpDelete("DeleteStoreCustomer")]
        public async Task<IActionResult> DeleteStoreCustomer(int StoreCustomerId)
        {
            DeleteStoreCustomerResponseViewModel obj = await _StoreCustomerRepo.DeleteStoreCustomer(StoreCustomerId);
            return Ok(obj);
        }
        [HttpGet("ListStoreCustomer")]
        public async Task<IActionResult> ListStoreCustomer()
        {
            List<StoreCustomer> result = await _StoreCustomerRepo.ListStoreCustomer();
            return Ok(result);
        }
        [HttpGet("ListPaginationStoreCustomer")]
        public async Task<IActionResult> ListPaginationStoreCustomer(int pageIndex, int pageSize)
        {
            List<GetStoreCustomerResponseViewModel> result = await _StoreCustomerRepo.ListPaginationStoreCustomer(pageIndex, pageSize);
            return Ok(result);
        }
        [HttpGet("ListPaginationFilterStoreCustomer")]
        public async Task<IActionResult> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int StoreCustomerId, string Name, string ContactNo, string FlatNo, string Block)
        {
            List<ListPaginationStoreCustomerViewModel> result = await _StoreCustomerRepo.ListPaginationFilterStoreCustomer(pageIndex, pageSize, StoreCustomerId, Name, ContactNo, FlatNo, Block);
            return Ok(result);
        }
    }
}
