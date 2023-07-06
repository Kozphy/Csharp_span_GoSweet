using Microsoft.AspNetCore.Mvc;

namespace BigWork_Test.Controllers {
    public class BuyListController : Controller {

        public IActionResult BuyList() {
            return View();
        }

        public IActionResult BuyListGroup() {
            return View();
        }
    }
}
