using AutoMapper;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModels;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{

    public class UserRepo : IUserRepo
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;
        public UserRepo(IUserData UserData, IMapper mapper)
        {
            _userData = UserData;
            _mapper = mapper;
        }
        public async Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock)
        {
            return await _userData.CreateUser(entity, CreatedIP, LoginFailedCount, IsUserBlock);

        }
        public async Task<LoginAuthenticationResponse> LoginUser(LoginAuthenticationRequest entity)
        {
            return await _userData.LoginUser(entity);

        }
    }
}
  
