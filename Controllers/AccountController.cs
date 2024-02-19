using HockeyGameMvc.Models;
using HockeyGameMvc.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                    return await Login(new LoginModel { Email = model.Email,Password=model.Password });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. User may already exist.");
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl=null)
        {
            if(ModelState.IsValid)
            {
                var user = await _accountService.LoginAsync(model);
                if(user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,user.Email)

                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,"CookieAuthScheme");

                    await HttpContext.SignInAsync("CookieAuthScheme", new ClaimsPrincipal(claimsIdentity));

                    return LocalRedirect(returnUrl ?? "/");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            return View(model);
        }

    }
}
