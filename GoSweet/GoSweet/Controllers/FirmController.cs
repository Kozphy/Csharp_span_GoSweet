using Microsoft.AspNetCore.Mvc;

namespace GoSweet.Controllers
{
    public class FirmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
