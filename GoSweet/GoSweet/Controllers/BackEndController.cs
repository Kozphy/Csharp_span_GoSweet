using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class BackEndController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult ItemPage()
        {
            return View();
        }

        public IActionResult Banned()
        {
            return View();
        }

        public IActionResult FirmPage()
        {
            return View();
        }

        public IActionResult CustomPage()
        {
            return View();
        }
    }
}
