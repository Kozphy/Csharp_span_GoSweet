using Microsoft.AspNetCore.Mvc;

namespace BigWork_Test.Controllers {
    public class SearchController : Controller {

        public IActionResult searchResult() { 
            return View(); 
        }

        public IActionResult searchResultGroup() {
            return View();
        }
    }
}
