using Microsoft.AspNetCore.Mvc;

namespace BigWork_Test.Controllers {
    public class ProductController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Product() {
            return View();
        }
    }
}
