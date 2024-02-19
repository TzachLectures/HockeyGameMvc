using Microsoft.AspNetCore.Mvc;

namespace HockeyGameMvc.Controllers
{
    public class TennisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
