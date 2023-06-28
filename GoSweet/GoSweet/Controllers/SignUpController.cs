using Microsoft.AspNetCore.Mvc;

namespace GoSweet.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
