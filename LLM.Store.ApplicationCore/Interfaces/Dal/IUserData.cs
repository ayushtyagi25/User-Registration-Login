using LLM.Store.ApplicationCore.ViewModels;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Dal
{
    public interface IUserData
    {
        Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock);
        Task<LoginAuthenticationResponse> LoginUser(LoginAuthenticationRequest entity);
    }
}
