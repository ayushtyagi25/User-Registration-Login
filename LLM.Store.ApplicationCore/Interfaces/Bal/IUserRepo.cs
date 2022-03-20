using LLM.Store.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface IUserRepo
    {
        Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock);
        Task<LoginAuthenticationResponse> LoginUser(LoginAuthenticationRequest entity);
    }
}
