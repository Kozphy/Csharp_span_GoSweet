using Microsoft.AspNetCore.Mvc;

namespace Lab_0704_Firm.Controllers {
    public class FirmPageController : Controller {
        public IActionResult ProductSale()
        {
            return View();
        }

        public IActionResult FirmData()
        {
            return View();
        }

        public IActionResult ProductSearch()
        {
            return View();
        }
    }
}
