using Microsoft.AspNetCore.Mvc;

namespace GoSweet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
