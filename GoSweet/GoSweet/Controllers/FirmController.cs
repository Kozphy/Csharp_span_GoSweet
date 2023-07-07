using Microsoft.AspNetCore.Mvc;

namespace Datafor0704.Controllers
{
    public class FirmpageController : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Revenue()
        {
            return View();
        }
    }
}
