using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepo _storeRepo;

        public StoreController(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;

        }

        [HttpPost("AddStore")]
        public async Task<IActionResult> AddStore([FromBody] AddRequestViewModel entity)
        {
            AddResponseViewModel result = await _storeRepo.AddStore(entity);
            return Ok(result);
        }

        [HttpPut("UpdateStore")]
        public async Task<IActionResult> UpdateStore([FromQuery] int storeId)
        {
            UpdateResponseViewModel result = await _storeRepo.UpdateStore(storeId);
            return Ok(result);
        }

        [HttpGet("GetStore")]
        public async Task<IActionResult> GetStore([FromQuery] int storeId)
        {
            GetResponseViewModel result = await _storeRepo.GetStore(storeId);
            return Ok(result);
        }

        [HttpGet("StoreList")]
        public async Task<IActionResult> StoreList([FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] StoreListRequestViewModel entity)
        {
            List<GetResponseViewModel> result = await _storeRepo.StoreList(pageIndex,pageSize,entity);
            return Ok(result);
        }

        [HttpDelete("DeleteStore")]
        public async Task<IActionResult> DeleteStore([FromQuery] int storeId)
        {
            ResponseViewModel result=await _storeRepo.DeleteStore(storeId);
            return Ok(result);
        }



    }
}
