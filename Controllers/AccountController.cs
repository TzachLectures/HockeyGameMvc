using HockeyGameMvc.Models;
using HockeyGameMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HockeyGameMvc.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(model);
                if (result)
                {
                    // Automatically log in the user after a successful registration
                    Console.WriteLine("registration success");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. User may already exist.");
                }
            }
            return View(model);
        }
    }
}
