using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Response;
using LLM.Store.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerController(ICustomerRepo customerRepo, IHttpContextAccessor httpContextAccessor)
        {
            _customerRepo = customerRepo;
            _httpContextAccessor = httpContextAccessor;

        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerViewModel entity)
        {
            AddCustomerViewModel result = await _customerRepo.AddCustomer(entity);
            return Ok(result);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateRequestViewModel entity)
        {
            UpdateCustomerViewModel result = await _customerRepo.UpdateCustomer(entity);
            return Ok(result);
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int CustomerId)
        {
            DeleteCustomerViewModel result = await _customerRepo.DeleteCustomer(CustomerId);
            return Ok(result);
        }
        [HttpGet("ListCustomer")]
        public async Task<IActionResult> ListCustomer()
        {
            List<Customer> result = await _customerRepo.ListCustomer();
            return Ok(result);
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(int CustomerId)
        {
            GetCustomerViewModel obj = await _customerRepo.GetCustomer(CustomerId);
            return Ok(obj);
        }
        [HttpGet("ListPaginationCustomer")]
        public async Task<IActionResult> ListPaginationCustomer(int pageIndex, int pageSize, int CustomerId, int OperatorId, string Name)
        {
            List<ListCustomerPaginationViewModel> result = await _customerRepo.ListPaginationFilterStoreCustomer(pageIndex, pageSize, CustomerId, OperatorId, Name);
            return Ok(result);
        }
        //[HttpPost("CreateCustomer")]
        //public async Task<IActionResult> CreateCustomer([FromBody] CreateRequestViewModel entity)
        //{
        //    CreateResponseViewModel result = await _customerRepo.CreateCustomer(entity);
        //    return Ok(result);
        //}


        //Create User Api
        [HttpPut("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateRequestViewModel entity)
        {
            ISingleModelResponse<CreateResponseViewModel> response = new SingleModelResponse<CreateResponseViewModel>();
            try
            {
                var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

                int LoginFailedCount = 0;
                int IsUserBlock = 0;
              //string IP = "192.168.2.2";
                CreateResponseViewModel ResponseViewModel = await _customerRepo.CreateUser(entity, ip, LoginFailedCount, IsUserBlock);

                if (ResponseViewModel.UserId != 0)
                {
                    response.Model = ResponseViewModel;
                    response.Message = "SuccesfullyCreated";

                }
                else
                {
                    response.IsError = true;
                    response.Model = ResponseViewModel;
                    response.Message = "succesfullyUpdated.";
                }

                return Ok(response);


            }

            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }

        }
        [HttpPut("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginAuthentication entity)
        {
            ISingleModelResponse<LoginAuthentication> response = new SingleModelResponse<LoginAuthentication>();

            try
            {
                // int LoginFailedCount = 0;
                // int IsUserBlock = 0;

                LoginAuthentication Demo = await _customerRepo.LoginUser(entity);

                if (Demo.UserName != "User Not found")
                {
                    response.Model = Demo;
                    response.Message = "Succesfull login";
                }
                else if (Demo.UserName == "User Blocked ")
                {

                    response.IsError = true;
                    response.Message = " User Blocked ";
                }
                else
                {
                    response.IsError = true;
                    response.Message = " User Not Found ";
                }

                return Ok(response);

            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
