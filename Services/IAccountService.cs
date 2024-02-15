using HockeyGameMvc.Models;

namespace HockeyGameMvc.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(UserModel userModel);
        Task <UserModel> LoginAsync (LoginModel loginModel);
    }
}
