using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Response;
using LLM.Store.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserRepo UserRepo, IHttpContextAccessor httpContextAccessor)
        {
            _userRepo = UserRepo;
            _httpContextAccessor = httpContextAccessor;

        }

        //Registration Api
        [HttpPut("UserRegistration")]
        public async Task<IActionResult> CreateUser([FromBody] CreateRequestViewModel entity)
        {
            ISingleModelResponse<CreateResponseViewModel> response = new SingleModelResponse<CreateResponseViewModel>();
            try
            {
                var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

                int LoginFailedCount = 0;
                int IsUserBlock = 0;
            
                CreateResponseViewModel ResponseViewModel = await _userRepo.CreateUser(entity, ip, LoginFailedCount, IsUserBlock);

                if (ResponseViewModel.UserName != null && ResponseViewModel.msg != "User Successfully Updated")
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
        //Login Api
        [HttpPut("UserLogin")]
        public async Task<IActionResult> LoginUser([FromBody] LoginAuthenticationRequest entity)
        {
            ISingleModelResponse<LoginAuthenticationResponse> response = new SingleModelResponse<LoginAuthenticationResponse>();

            try
            {

                LoginAuthenticationResponse Demo = await _userRepo.LoginUser(entity);

                if (Demo.UserName != null && Demo.msg == "Login sucessfully")
                {
                    response.Model = Demo;
                    response.Message = "Succesfull login";
                }
                else if (Demo.UserName == Demo.UserName && Demo.msg != "Login Failed")
                {

                    response.IsError = true;
                    response.Message = " user Blocked for 10 min ";
                }
                else 
                {
                    response.IsError = true;
                    response.Message = " Login Failed ";
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