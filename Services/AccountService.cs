using HockeyGameMvc.Data;
using HockeyGameMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HockeyGameMvc.Services
{
    public class AccountService:IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(UserModel userModel)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == userModel.Email);

            if (existingUser != null)
            {
                // User already exists
                return false;
            }

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> LoginAsync(LoginModel login)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

            return user;
        }
    }
}
