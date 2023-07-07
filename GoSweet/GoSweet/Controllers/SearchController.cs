using Microsoft.AspNetCore.Mvc;

namespace BigWork_Test.Controllers {
    public class SearchController : Controller {

        public IActionResult SearchResult() { 
            return View(); 
        }

        public IActionResult SearchResultGroup() {
            return View();
        }

        public IActionResult Product() {
            return View();
        }
    }
}
